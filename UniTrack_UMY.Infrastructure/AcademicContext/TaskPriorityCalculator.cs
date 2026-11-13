using System;
using UniTrack_UMY.Core.AcademicContext;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.AcademicContext
{
    public class TaskPriorityCalculator : ITaskPriorityCalculator
    {
        public TaskPriorityResult Calculate(TaskItem task, DateTime now)
        {
            var result = new TaskPriorityResult();

            if (task.Status == TaskItem.TaskStatus.Completed || task.Status == TaskItem.TaskStatus.SubmittedLate)
                return result;

            
            if (task.DueDate.HasValue)
            {
                result.DaysUntilDue = (int)(task.DueDate.Value - now).TotalDays;
            }

            int score = 0;

           
            if (task.Status == TaskItem.TaskStatus.Overdue)
            {
                score += 50;
            }
            else if (result.DaysUntilDue.HasValue)
            {
                if (result.DaysUntilDue <= 1) score += 45;
                else if (result.DaysUntilDue <= 3) score += 35;
                else if (result.DaysUntilDue <= 7) score += 20;
                else score += 10;
            }

            if (task.Type == TaskItem.TaskType.Quiz || task.Type == TaskItem.TaskType.Test)
                score += 30;
            else if (task.Type == TaskItem.TaskType.Assignment)
                score += 20;

          
            if (task.Status == TaskItem.TaskStatus.Pending) score += 20;

            result.Score = score;

       
            if (score >= 70) result.Level = "High";
            else if (score >= 40) result.Level = "Medium";
            else if (score > 0) result.Level = "Low";
            else result.Level = "None";

            return result;
        }
    }
}