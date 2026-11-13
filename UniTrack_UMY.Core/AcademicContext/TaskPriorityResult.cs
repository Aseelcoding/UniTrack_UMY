using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Core.AcademicContext
{
    public class TaskPriorityResult
    {
        public int Score { get; set; }
        public string Level { get; set; } = string.Empty;
        public int? DaysUntilDue { get; set; }
    }

    public interface ITaskPriorityCalculator
    {
        TaskPriorityResult Calculate(TaskItem task, System.DateTime now);
    }
}