using System;

namespace UniTrack_UMY.Core.Models
{
    public class TaskItem
    {
        public enum TaskType
        {
            Assignment,
            Quiz,
            Test,
            Task,
            Other
        }

        public enum TaskStatus
        {
            Pending,       // Not submitted yet
            Completed,     // Submitted on time / marked done
            SubmittedLate, // Submitted but past the deadline
            Overdue,       // Not submitted and deadline passed
            NoDueDate,     // No deadline
            Unknown
        }

        public enum TaskSource
        {
            MyKlass,
            Manual
        }

        public string Id { get; set; } = string.Empty;
        public string CourseId { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public TaskType Type { get; set; }
        public TaskSource Source { get; set; } = TaskSource.MyKlass;
        public string Url { get; set; } = string.Empty;
        public string ModuleWeek { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public string DueDateText { get; set; } = "No due date";
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }
    }
}
