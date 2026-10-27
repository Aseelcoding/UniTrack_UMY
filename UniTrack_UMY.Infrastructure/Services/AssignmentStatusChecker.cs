using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UniTrack_UMY.Infrastructure.Services
{
    public class AssignmentStatusChecker
    {
        public UniTrack_UMY.Core.Models.TaskItem.TaskStatus? CheckStatus(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return null;

            var doc = new HtmlDocument();
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
                    ? UniTrack_UMY.Core.Models.TaskItem.TaskStatus.SubmittedLate
                    : UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Completed;
            }

            if (statusText.IndexOf(
                "No attempt",
                StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return UniTrack_UMY.Core.Models.TaskItem.TaskStatus.Overdue;
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
