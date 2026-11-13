using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UniTrack_UMY.Core.AcademicContext;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.AcademicContext
{
    public class AcademicContextBuilder : IAcademicContextBuilder
    {
        private readonly List<TaskItem> _tasks;
        private readonly List<Course> _courses;
        private readonly List<ScheduleItem> _schedule;
        private readonly ITaskPriorityCalculator _priorityCalculator;

        public AcademicContextBuilder(
            List<TaskItem> tasks,
            List<Course> courses,
            List<ScheduleItem> schedule)
        {
            _tasks = tasks ?? new List<TaskItem>();
            _courses = courses ?? new List<Course>();
            _schedule = schedule ?? new List<ScheduleItem>();
            _priorityCalculator = new TaskPriorityCalculator();
        }

        public Task<AcademicContextData> BuildAsync(
            string userQuestion,
            AcademicContextOptions options,
            CancellationToken cancellationToken = default)
        {
            var contextData = new Dictionary<string, object>();
            // استخدام الاسم الجديد هنا
            var result = new AcademicContextData { GeneratedAt = DateTime.Now };

            if (options.IncludeTasks && _tasks.Count > 0)
            {
                var now = DateTime.Now;
                var relevantTasks = _tasks
                    .Where(t => t.Status != TaskItem.TaskStatus.Completed && t.Status != TaskItem.TaskStatus.SubmittedLate)
                    .Select(t => {
                        var p = _priorityCalculator.Calculate(t, now);
                        return new { Task = t, Priority = p };
                    })
                    .OrderByDescending(x => x.Priority.Score)
                    .Take(options.MaxTasks)
                    .Select(x => new
                    {
                        x.Task.Title,
                        x.Task.CourseName,
                        Type = x.Task.Type.ToString(),
                        Status = x.Task.Status.ToString(),
                        DueDate = x.Task.DueDate?.ToString("yyyy-MM-dd HH:mm"),
                        DaysUntilDue = x.Priority.DaysUntilDue,
                        PriorityScore = x.Priority.Score,
                        PriorityLevel = x.Priority.Level
                    }).ToList();

                if (relevantTasks.Any())
                {
                    contextData["tasks"] = relevantTasks;
                    result.TaskCount = relevantTasks.Count;
                }
            }

            if (options.IncludeCourses && _courses.Count > 0)
            {
                var relevantCourses = _courses
                    .Take(options.MaxCourses)
                    .Select(c => new { c.Name, c.ProgressPercent })
                    .ToList();

                contextData["courses"] = relevantCourses;
                result.CourseCount = relevantCourses.Count;
            }

            if (options.IncludeSchedule && _schedule.Count > 0)
            {
                var relevantSchedule = _schedule
                    .Take(options.MaxScheduleItems)
                    .Select(s => new { s.Day, s.CourseName, s.StartTime, s.EndTime, s.Location })
                    .ToList();

                contextData["schedule"] = relevantSchedule;
                result.ScheduleItemCount = relevantSchedule.Count;
            }

            if (contextData.Count > 0)
            {
                string json = JsonSerializer.Serialize(contextData, new JsonSerializerOptions
                {
                    WriteIndented = false
                });

                result.SerializedData = $"<untrusted_data>\n{json}\n</untrusted_data>";
            }

            return Task.FromResult(result);
        }
    }
}