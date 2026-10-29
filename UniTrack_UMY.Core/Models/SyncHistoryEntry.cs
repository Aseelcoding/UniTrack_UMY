using System;
using System.Collections.Generic;

namespace UniTrack_UMY.Core.Models
{
    public class SyncHistoryEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool Success { get; set; }
        public int TotalCourses { get; set; }
        public int SucceededCourses { get; set; }
        public int FailedCourses { get; set; }
        public int Attempts { get; set; }
        public List<string> FailedCourseNames { get; set; } = new List<string>();
        public List<string> FailureReasons { get; set; } = new List<string>();
    }
}
