using System;

namespace UniTrack_UMY.Core
{
    public static class RemainingTime
    {
        /// <summary>
        /// Returns a human-readable relative time such as "Due in 2 days"
        /// or "Overdue by 1 day". Returns an empty string when no due date
        /// is available so the caller can localize or hide the value.
        /// </summary>
        public static string Describe(DateTime? dueDate, DateTime? now = null)
        {
            if (!dueDate.HasValue)
                return string.Empty;

            DateTime reference = now ?? DateTime.Now;
            TimeSpan diff = dueDate.Value - reference;

            if (diff >= TimeSpan.Zero)
            {
                if (diff.TotalDays >= 1)
                    return $"Due in {Plural((int)Math.Floor(diff.TotalDays), "day")}";
                if (diff.TotalHours >= 1)
                    return $"Due in {Plural((int)Math.Floor(diff.TotalHours), "hour")}";
                if (diff.TotalMinutes >= 1)
                    return $"Due in {Plural((int)Math.Floor(diff.TotalMinutes), "minute")}";
                return "Due now";
            }

            TimeSpan overdue = -diff;
            if (overdue.TotalDays >= 1)
                return $"Overdue by {Plural((int)Math.Floor(overdue.TotalDays), "day")}";
            if (overdue.TotalHours >= 1)
                return $"Overdue by {Plural((int)Math.Floor(overdue.TotalHours), "hour")}";
            return "Overdue by 1 minute";
        }

        private static string Plural(int count, string unit)
        {
            return count == 1
                ? $"1 {unit}"
                : $"{count} {unit}s";
        }
    }
}
