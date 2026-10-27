using System;
using System.Collections.Generic;
using System.Text;

namespace UniTrack_UMY.Core.Models
{
    public class TaskItem
    {
        public enum TaskType
        {
            Assignment,
            Quiz,
            Other
        }

        public enum TaskStatus
        {
            Pending,       // Not submitted yet
            Completed,     // Submitted on time
            SubmittedLate, // <--- NEW: Submitted but past the deadline
            Overdue,       // Not submitted and deadline passed
            NoDueDate,      // No deadline 
            Unknown
        }

        public string Id { get; set; } = string.Empty;
        public string CourseId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public TaskType Type { get; set; }
        public string Url { get; set; } = string.Empty;

        public string DueDateText { get; set; } = "No due date";
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }
    }
}
