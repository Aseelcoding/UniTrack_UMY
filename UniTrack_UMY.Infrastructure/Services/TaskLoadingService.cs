using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using UniTrack_UMY.Core.Interfaces;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    public sealed class TaskLoadingService
    {
        private static readonly Uri MyKlassBaseUri =
            new Uri("https://myklass-eng.umy.ac.id/");

        private readonly IHtmlFetcher _htmlFetcher;
        private readonly TaskParser _taskParser;

        public TaskLoadingService(IHtmlFetcher htmlFetcher)
        {
            _htmlFetcher = htmlFetcher
                ?? throw new ArgumentNullException(nameof(htmlFetcher));

            _taskParser = new TaskParser();
        }

        public async Task<(List<TaskItem> Tasks, List<string> Errors)>
            LoadTasksAsync(IEnumerable<Course> courses)
        {
            if (courses == null)
                throw new ArgumentNullException(nameof(courses));

            var tasks = new List<TaskItem>();
            var errors = new List<string>();

            foreach (Course course in courses)
            {
                try
                {
                    Uri courseUri = ResolveMyKlassUrl(course.Url);

                    string html = await _htmlFetcher.GetHtmlAsync(
                        courseUri.AbsoluteUri);

                    if (string.IsNullOrWhiteSpace(html))
                    {
                        errors.Add(
                            $"{course.Name}: MyKlass returned an empty page.");

                        continue;
                    }

                    if (IsLoginPage(html))
                    {
                        errors.Add(
                            $"{course.Name}: MyKlass session may have expired.");

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
                    errors.Add($"{course.Name}: {ex.Message}");
                }
            }

            return (tasks, errors);
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