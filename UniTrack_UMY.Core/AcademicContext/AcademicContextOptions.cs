namespace UniTrack_UMY.Core.AcademicContext
{
    public class AcademicContextOptions
    {
        public bool IncludeTasks { get; set; } = true;
        public bool IncludeCourses { get; set; } = true;
        public bool IncludeSchedule { get; set; } = true;

        public int MaxTasks { get; set; } = 10;
        public int MaxCourses { get; set; } = 10;
        public int MaxScheduleItems { get; set; } = 14;
    }
}