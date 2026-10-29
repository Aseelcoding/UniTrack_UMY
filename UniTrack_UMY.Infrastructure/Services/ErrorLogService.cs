using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    /// <summary>
    /// Maintains a local technical error log with a 30-day retention window.
    /// Messages are sanitized so credentials, cookies, and tokens are never
    /// recorded.
    /// </summary>
    public class ErrorLogService
    {
        private static readonly TimeSpan Retention = TimeSpan.FromDays(30);

        private readonly string _filePath;

        public ErrorLogService()
            : this(Path.Combine(
                FileStore.AppDataDirectory,
                "errorlog.json"))
        {
        }

        public ErrorLogService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "File path cannot be empty.",
                    nameof(filePath));

            _filePath = filePath;
            FileStore.EnsureDirectory(_filePath);
        }

        public List<ErrorLogEntry> Load()
        {
            List<ErrorLogEntry> entries =
                FileStore.Read<List<ErrorLogEntry>>(_filePath)
                ?? new List<ErrorLogEntry>();

            List<ErrorLogEntry> pruned = Prune(entries);

            if (pruned.Count != entries.Count)
                Save(pruned);

            return pruned
                .OrderByDescending(e => e.Timestamp)
                .ToList();
        }

        public void Log(
            string errorType,
            string stage,
            string courseName,
            string message)
        {
            var entry = new ErrorLogEntry
            {
                ErrorType = Sanitize(errorType),
                Stage = Sanitize(stage),
                CourseName = Sanitize(courseName),
                Message = Sanitize(message)
            };

            List<ErrorLogEntry> entries = Load();
            entries.Add(entry);
            Save(entries);
        }

        public void Clear()
        {
            Save(new List<ErrorLogEntry>());
        }

        public string FormatForCopy(IEnumerable<ErrorLogEntry>? entries)
        {
            var builder = new StringBuilder();

            foreach (ErrorLogEntry entry in
                entries ?? Enumerable.Empty<ErrorLogEntry>())
            {
                builder.AppendLine(
                    $"{entry.Timestamp:yyyy-MM-dd HH:mm:ss} | " +
                    $"{entry.ErrorType} | {entry.Stage} | " +
                    $"{entry.CourseName} | {entry.Message}");
            }

            return builder.ToString();
        }

        private void Save(List<ErrorLogEntry> entries)
        {
            string json = JsonSerializer.Serialize(
                entries,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            FileStore.WriteAtomic(_filePath, json);
        }

        private static List<ErrorLogEntry> Prune(
            List<ErrorLogEntry> entries)
        {
            DateTime cutoff = DateTime.Now - Retention;

            return entries
                .Where(e => e != null && e.Timestamp >= cutoff)
                .ToList();
        }

        /// <summary>
        /// Best-effort removal of query strings and credential-like values so
        /// passwords, cookies, and tokens are not persisted or copied.
        /// </summary>
        private static string Sanitize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string result = value;

            result = Regex.Replace(
                result,
                @"\?[^\s]+",
                string.Empty);

            result = Regex.Replace(
                result,
                @"(password|passwd|token|session|cookie|authorization)\s*[=:]\s*\S+",
                "$1=[redacted]",
                RegexOptions.IgnoreCase);

            return result.Trim();
        }
    }
}
