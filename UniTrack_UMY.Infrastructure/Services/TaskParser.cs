using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using UniTrack_UMY.Core.Models;
using System.Linq;
using static UniTrack_UMY.Core.Models.TaskItem;

namespace UniTrack_UMY.Infrastructure.Services
{
    public class TaskParser
    {
        public List<TaskItem> ParseTasks(
            string html,
            string courseId)
        {
            var tasks = new List<TaskItem>();

            if (string.IsNullOrWhiteSpace(html))
                return tasks;

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var activityNodes = doc.DocumentNode.SelectNodes(
                "//li[contains(@class, 'activity-wrapper')]");

            if (activityNodes == null)
                return tasks;

            foreach (var node in activityNodes)
            {
                try
                {
                    string classAttribute =
                        node.GetAttributeValue("class", "");

                    if (classAttribute.Contains("modtype_attendance") ||
                        classAttribute.Contains("modtype_resource"))
                    {
                        continue;
                    }

                    var titleNode = node.SelectSingleNode(
                        ".//span[contains(@class, 'instancename')]");

                    if (titleNode == null)
                        continue;

                    string title = CleanText(titleNode.InnerText);

                    TaskType type;

                    if (classAttribute.Contains("modtype_quiz") ||
                        title.IndexOf("UCP",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        title.IndexOf("Exam",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        title.IndexOf("Ujian",
                            StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        type = TaskType.Quiz;
                    }
                    else if (classAttribute.Contains("modtype_assign"))
                    {
                        type = TaskType.Assignment;
                    }
                    else
                    {
                        continue;
                    }

                    var task = new TaskItem
                    {
                        CourseId = courseId,
                        Title = title,
                        Type = type,
                        Url = string.Empty,
                        DueDateText = "No due date",
                        DueDate = null,
                        Status = UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Pending
                    };

                    var linkNode = node.SelectSingleNode(
                        ".//a[contains(@class, 'aalink')]");

                    if (linkNode != null)
                    {
                        task.Url = linkNode.GetAttributeValue("href", "");
                    }

                    var datesNode = node.SelectSingleNode(
                        ".//div[@data-region='activity-dates']");

                    if (datesNode != null)
                    {
                        string datesText = CleanText(datesNode.InnerText);

                        var match = Regex.Match(
                            datesText,
                            @"Due:\s*([^|]+)",
                            RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            task.DueDateText =
                                match.Groups[1].Value.Trim();

                            if (DateTime.TryParse(
                                task.DueDateText,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime parsedDate))
                            {
                                task.DueDate = parsedDate;
                            }
                        }
                    }

                    bool isCompleted =
                        node.InnerHtml.IndexOf(
                            "fa-check",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        node.InnerHtml.IndexOf(
                            "Completed",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        node.InnerHtml.IndexOf(
                            "Submitted",
                            StringComparison.OrdinalIgnoreCase) >= 0;

                    if (type == TaskType.Quiz)
                    {
                        task.Status =
                            task.DueDate.HasValue &&
                            task.DueDate.Value < DateTime.Now
                                ? UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Overdue
                                : UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Pending;
                    }
                    else if (isCompleted)
                    {
                        task.Status = UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Completed;
                    }
                    else if (task.DueDate.HasValue &&
                             task.DueDate.Value < DateTime.Now)
                    {
                        task.Status = UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Overdue;
                    }

                    tasks.Add(task);
                }
                catch
                {
                    // Skip activities that cannot be parsed.
                    continue;
                }
            }

            return tasks
                .OrderByDescending(t =>
                    t.Type == TaskType.Assignment &&
                    t.Status == UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Overdue)
                .ThenBy(t => t.DueDate ?? DateTime.MaxValue)
                .ToList();
        }
        private string CleanText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return Regex.Replace(text, @"\s+", " ").Trim();
        }
    }
}
