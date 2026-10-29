using System;

namespace UniTrack_UMY.Core.Models
{
    public class ErrorLogEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string ErrorType { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
