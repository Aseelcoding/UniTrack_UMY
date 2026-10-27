using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    internal class AssignmentStatusChecker
    {
        public TaskItem.TaskStatus? CheckStatus(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return null;

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var submissionTable =
                doc.DocumentNode.SelectSingleNode(
                    "//div[contains(@class, 'submissionstatustable')]");

            if (submissionTable == null)
                return null;

            var statusCell = submissionTable.SelectSingleNode(
                ".//tr[th[contains(normalize-space(.), " +
                "'Submission status')]]/td");

            if (statusCell == null)
                return null;

            string statusText = CleanText(statusCell.InnerText);

            var lateCell = submissionTable.SelectSingleNode(
                ".//td[contains(concat(' ', normalize-space(@class), ' '), " +
                "' latesubmission ')]");

            if (statusText.IndexOf(
                "Submitted for grading",
                StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return lateCell != null
                    ? TaskItem.TaskStatus.SubmittedLate
                    : TaskItem.TaskStatus.Completed;
            }

            if (statusText.IndexOf(
                "No attempt",
                StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return TaskItem.TaskStatus.Overdue;
            }

            return null;
        }

        private string CleanText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return Regex.Replace(text, @"\s+", " ").Trim();
        }
    }
}
