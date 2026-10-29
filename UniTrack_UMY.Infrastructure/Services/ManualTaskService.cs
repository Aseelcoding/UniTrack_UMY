using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    /// <summary>
    /// Persists manual tasks (tasks the student adds inside an existing MyKlass
    /// course) to a local JSON file with atomic writes and backup/restore.
    /// </summary>
    public class ManualTaskService
    {
        private readonly string _filePath;

        public ManualTaskService()
            : this(Path.Combine(
                FileStore.AppDataDirectory,
                "manualtasks.json"))
        {
        }

        public ManualTaskService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "File path cannot be empty.",
                    nameof(filePath));

            _filePath = filePath;
            FileStore.EnsureDirectory(_filePath);
        }

        public List<TaskItem> Load()
        {
            List<TaskItem> tasks =
                FileStore.Read<List<TaskItem>>(_filePath)
                ?? new List<TaskItem>();

            return tasks
                .Where(t => t != null)
                .ToList();
        }

        public void Save(IEnumerable<TaskItem> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));

            List<TaskItem> list = tasks
                .Where(t => t != null)
                .ToList();

            string json = JsonSerializer.Serialize(
                list,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            FileStore.WriteAtomic(_filePath, json);
        }

        public TaskItem Add(TaskItem task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (string.IsNullOrWhiteSpace(task.Id))
                task.Id = Guid.NewGuid().ToString();

            task.Source = TaskItem.TaskSource.Manual;

            if (task.Status == TaskItem.TaskStatus.Unknown)
                task.Status = TaskItem.TaskStatus.Pending;

            List<TaskItem> tasks = Load();
            tasks.Add(task);
            Save(tasks);

            return task;
        }

        public bool Update(TaskItem task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            List<TaskItem> tasks = Load();

            int index = tasks.FindIndex(t => t.Id == task.Id);
            if (index < 0)
                return false;

            task.Source = TaskItem.TaskSource.Manual;
            tasks[index] = task;
            Save(tasks);

            return true;
        }

        public bool Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            List<TaskItem> tasks = Load();

            int removed = tasks.RemoveAll(t => t.Id == id);
            if (removed == 0)
                return false;

            Save(tasks);
            return true;
        }

        public bool SetStatus(string id, TaskItem.TaskStatus status)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            List<TaskItem> tasks = Load();

            TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;

            task.Status = status;
            Save(tasks);

            return true;
        }

        public bool SetCompleted(string id, bool completed)
        {
            return SetStatus(
                id,
                completed
                    ? TaskItem.TaskStatus.Completed
                    : TaskItem.TaskStatus.Pending);
        }
    }
}
