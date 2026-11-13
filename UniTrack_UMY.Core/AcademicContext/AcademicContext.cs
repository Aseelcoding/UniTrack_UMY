using System;

namespace UniTrack_UMY.Core.AcademicContext
{
    public class AcademicContextData
    {
        public string SerializedData { get; set; } = string.Empty;
        public int TaskCount { get; set; }
        public int CourseCount { get; set; }
        public int ScheduleItemCount { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;

        public bool HasData =>
            TaskCount > 0 || CourseCount > 0 || ScheduleItemCount > 0;
    }
}