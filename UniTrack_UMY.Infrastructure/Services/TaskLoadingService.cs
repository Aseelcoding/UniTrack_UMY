using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using UniTrack_UMY.Core.Interfaces;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    public sealed class TaskLoadingService
    {
        public const int MaxAttempts = 2;

        private static readonly Uri MyKlassBaseUri =
            new Uri("https://myklass-eng.umy.ac.id/");

        private readonly IHtmlFetcher _htmlFetcher;
        private readonly TaskParser _taskParser;
        private readonly SyncHistoryService? _syncHistory;
        private readonly ErrorLogService? _errorLog;

        public TaskLoadingService(IHtmlFetcher htmlFetcher)
            : this(htmlFetcher, new TaskParser(), null, null)
        {
        }

        public TaskLoadingService(
            IHtmlFetcher htmlFetcher,
            SyncHistoryService syncHistory,
            ErrorLogService errorLog)
            : this(htmlFetcher, new TaskParser(), syncHistory, errorLog)
        {
        }

        public TaskLoadingService(
            IHtmlFetcher htmlFetcher,
            TaskParser taskParser,
            SyncHistoryService? syncHistory,
            ErrorLogService? errorLog)
        {
            _htmlFetcher = htmlFetcher
                ?? throw new ArgumentNullException(nameof(htmlFetcher));
            _taskParser = taskParser
                ?? throw new ArgumentNullException(nameof(taskParser));
            _syncHistory = syncHistory;
            _errorLog = errorLog;
        }

        /// <summary>
        /// Loads all tasks for the given courses, retrying failed courses once
        /// (two attempts in total) as required by FR-17/FR-18.
        /// </summary>
        public async Task<(List<TaskItem> Tasks, List<string> Errors)>
            LoadTasksAsync(IEnumerable<Course> courses)
        {
            if (courses == null)
                throw new ArgumentNullException(nameof(courses));

            List<Course> courseList = courses
                .Where(c => c != null)
                .ToList();

            var tasks = new List<TaskItem>();
            var errors = new List<string>();
            var failedCourses = new List<Course>();
            var failureReasons = new List<string>();

            List<Course> remaining = courseList;
            int attempts = 0;

            while (remaining.Count > 0 && attempts < MaxAttempts)
            {
                attempts++;

                var attempt =
                    await LoadCoursesOnceAsync(remaining);

                tasks.AddRange(attempt.Tasks);
                errors = attempt.Errors;
                failedCourses = attempt.FailedCourses;
                failureReasons = attempt.FailureReasons;

                remaining = failedCourses;
            }

            RecordSyncHistory(
                courseList.Count,
                failedCourses,
                failureReasons,
                attempts);

            return (tasks, errors);
        }

        /// <summary>
        /// Loads tasks for a single course. Used for per-subject retry
        /// (FR-22..FR-24).
        /// </summary>
        public async Task<(List<TaskItem> Tasks, List<string> Errors)>
            LoadCourseTasksAsync(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            var attempt = await LoadCoursesOnceAsync(new[] { course });

            RecordSyncHistory(
                1,
                attempt.FailedCourses,
                attempt.FailureReasons,
                1);

            return (attempt.Tasks, attempt.Errors);
        }

        private async Task<(
            List<TaskItem> Tasks,
            List<string> Errors,
            List<Course> FailedCourses,
            List<string> FailureReasons)>
            LoadCoursesOnceAsync(IEnumerable<Course> courses)
        {
            var tasks = new List<TaskItem>();
            var errors = new List<string>();
            var failed = new List<Course>();
            var reasons = new List<string>();

            foreach (Course course in courses)
            {
                try
                {
                    Uri courseUri = ResolveMyKlassUrl(course.Url);

                    string html = await _htmlFetcher.GetHtmlAsync(
                        courseUri.AbsoluteUri);

                    if (string.IsNullOrWhiteSpace(html))
                    {
                        string message =
                            $"{course.Name}: MyKlass returned an empty page.";

                        errors.Add(message);
                        failed.Add(course);
                        reasons.Add(message);

                        LogError(
                            "EmptyPage",
                            "TaskLoading",
                            course.Name,
                            "MyKlass returned an empty page.");

                        continue;
                    }

                    if (IsLoginPage(html))
                    {
                        string message =
                            $"{course.Name}: MyKlass session may have expired.";

                        errors.Add(message);
                        failed.Add(course);
                        reasons.Add(message);

                        LogError(
                            "SessionExpired",
                            "TaskLoading",
                            course.Name,
                            "MyKlass session may have expired.");

                        continue;
                    }

                    List<TaskItem> courseTasks =
                        _taskParser.ParseTasks(html, course.Id);

                    foreach (TaskItem task in courseTasks)
                    {
                        if (string.IsNullOrWhiteSpace(task.Url))
                            continue;

                        try
                        {
                            task.Url = ResolveMyKlassUrl(task.Url)
                                .AbsoluteUri;
                        }
                        catch (InvalidOperationException)
                        {
                            task.Url = string.Empty;
                        }
                    }

                    tasks.AddRange(courseTasks);
                }
                catch (Exception ex)
                {
                    string message = $"{course.Name}: {ex.Message}";

                    errors.Add(message);
                    failed.Add(course);
                    reasons.Add(message);

                    LogError(
                        ex.GetType().Name,
                        "TaskLoading",
                        course.Name,
                        ex.Message);
                }
            }

            return (tasks, errors, failed, reasons);
        }

        private void RecordSyncHistory(
            int totalCourses,
            List<Course> failedCourses,
            List<string> failureReasons,
            int attempts)
        {
            if (_syncHistory == null)
                return;

            try
            {
                _syncHistory.Add(new SyncHistoryEntry
                {
                    Timestamp = DateTime.Now,
                    Success = failedCourses.Count == 0,
                    TotalCourses = totalCourses,
                    SucceededCourses = totalCourses - failedCourses.Count,
                    FailedCourses = failedCourses.Count,
                    Attempts = attempts,
                    FailedCourseNames = failedCourses
                        .Select(c => c.Name)
                        .ToList(),
                    FailureReasons = failureReasons
                });
            }
            catch
            {
                // History recording must never break the sync flow.
            }
        }

        private void LogError(
            string errorType,
            string stage,
            string courseName,
            string message)
        {
            if (_errorLog == null)
                return;

            try
            {
                _errorLog.Log(errorType, stage, courseName, message);
            }
            catch
            {
                // Error logging must never break the sync flow.
            }
        }

        private static Uri ResolveMyKlassUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url) ||
                !Uri.TryCreate(
                    MyKlassBaseUri,
                    url,
                    out Uri? uri) ||
                uri.Scheme != Uri.UriSchemeHttps ||
                !string.Equals(
                    uri.Host,
                    MyKlassBaseUri.Host,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "The URL is not a valid MyKlass HTTPS URL.");
            }

            return uri;
        }

        private static bool IsLoginPage(string html)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            return document.DocumentNode.SelectSingleNode(
                "//form[@id='login' or " +
                "contains(concat(' ', normalize-space(@class), ' '), " +
                "' login-form ')]") != null;
        }
    }
}
