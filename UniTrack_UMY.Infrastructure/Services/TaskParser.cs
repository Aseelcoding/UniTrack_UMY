using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UniTrack_UMY.Core.Models;

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

                    TaskItem.TaskType type;

                    if (classAttribute.Contains("modtype_quiz") ||
                        title.IndexOf("UCP",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        title.IndexOf("Exam",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        title.IndexOf("Ujian",
                            StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        type = TaskItem.TaskType.Quiz;
                    }
                    else if (classAttribute.Contains("modtype_assign"))
                    {
                        type = TaskItem.TaskType.Assignment;
                    }
                    else
                    {
                        // Other MyKlass activity types are not tasks to track.
                        continue;
                    }

                    var task = new TaskItem
                    {
                        CourseId = courseId,
                        Title = title,
                        Type = type,
                        Source = TaskItem.TaskSource.MyKlass,
                        Url = string.Empty,
                        ModuleWeek = GetModuleWeek(node),
                        DueDateText = "No due date",
                        DueDate = null,
                        Status = TaskItem.TaskStatus.Pending
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

                    task.Status = DetermineStatus(node, task);

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
                    t.Type == TaskItem.TaskType.Assignment &&
                    t.Status == TaskItem.TaskStatus.Overdue)
                .ThenBy(t => t.DueDate ?? DateTime.MaxValue)
                .ToList();
        }

        private static TaskItem.TaskStatus DetermineStatus(
            HtmlNode node,
            TaskItem task)
        {
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

            if (isCompleted)
                return TaskItem.TaskStatus.Completed;

            if (task.DueDate.HasValue &&
                task.DueDate.Value < DateTime.Now)
            {
                return TaskItem.TaskStatus.Overdue;
            }

            return TaskItem.TaskStatus.Pending;
        }

        private static string GetModuleWeek(HtmlNode node)
        {
            HtmlNode? section = node.SelectSingleNode(
                "ancestor::li[contains(@class, 'section')]");

            if (section == null)
                return string.Empty;

            HtmlNode? titleNode =
                section.SelectSingleNode(
                    ".//h3[contains(@class, 'sectionname')]") ??
                section.SelectSingleNode(
                    ".//*[contains(@class, 'sectionname')]");

            return titleNode == null
                ? string.Empty
                : CleanText(titleNode.InnerText);
        }

        private static string CleanText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return Regex.Replace(text, @"\s+", " ").Trim();
        }
    }
}
