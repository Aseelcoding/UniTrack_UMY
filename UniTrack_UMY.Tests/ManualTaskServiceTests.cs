using System;
using System.IO;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;
using static UniTrack_UMY.Core.Models.TaskItem;

namespace UniTrack_UMY.Tests
{
    public class ManualTaskServiceTests
    {
        private static string CreateTempDirectory()
        {
            string path = Path.Combine(
                Path.GetTempPath(),
                "UniTrackTests",
                Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(path);
            return path;
        }

        private static void DeleteTempDirectory(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        [Fact]
        public void Load_WhenFileDoesNotExist_ReturnsEmptyList()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ManualTaskService(
                    Path.Combine(dir, "manualtasks.json"));

                Assert.Empty(service.Load());
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Add_GeneratesIdAndSetsManualSource()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ManualTaskService(
                    Path.Combine(dir, "manualtasks.json"));

                TaskItem task = service.Add(new TaskItem
                {
                    Title = "Read chapter 3",
                    CourseId = "C1",
                    Type = TaskType.Task
                });

                Assert.False(string.IsNullOrWhiteSpace(task.Id));
                Assert.Equal(TaskSource.Manual, task.Source);

                Assert.Single(service.Load());
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Update_WhenTaskExists_ReplacesIt()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ManualTaskService(
                    Path.Combine(dir, "manualtasks.json"));

                TaskItem task = service.Add(new TaskItem
                {
                    Title = "Original",
                    CourseId = "C1",
                    Type = TaskType.Task
                });

                task.Title = "Updated";
                bool updated = service.Update(task);

                Assert.True(updated);
                Assert.Equal("Updated", service.Load()[0].Title);
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Delete_WhenTaskExists_RemovesIt()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ManualTaskService(
                    Path.Combine(dir, "manualtasks.json"));

                TaskItem task = service.Add(new TaskItem
                {
                    Title = "To delete",
                    CourseId = "C1",
                    Type = TaskType.Task
                });

                Assert.True(service.Delete(task.Id));
                Assert.Empty(service.Load());
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void SetCompleted_TogglesStatus()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ManualTaskService(
                    Path.Combine(dir, "manualtasks.json"));

                TaskItem task = service.Add(new TaskItem
                {
                    Title = "Toggle",
                    CourseId = "C1",
                    Type = TaskType.Task
                });

                Assert.True(service.SetCompleted(task.Id, true));
                Assert.Equal(
                    TaskItem.TaskStatus.Completed,
                    service.Load()[0].Status);

                Assert.True(service.SetCompleted(task.Id, false));
                Assert.Equal(
                    TaskItem.TaskStatus.Pending,
                    service.Load()[0].Status);
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }
    }
}
