
using UniTrack_UMY.Core.Models;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class TaskItemTests
    {
        [Fact]
        public void NewTask_HasExpectedDefaultValues()
        {
            var task = new TaskItem();

            Assert.Equal(string.Empty, task.Id);
            Assert.Equal(string.Empty, task.CourseId);
            Assert.Equal(string.Empty, task.Title);
            Assert.Equal("No due date", task.DueDateText);
            Assert.Null(task.DueDate);
        }

        [Fact]
        public void Task_StatusCanBeChanged()
        {
            var task = new TaskItem
            {
                Status = TaskItem.TaskStatus.Completed
            };

            Assert.Equal(
                TaskItem.TaskStatus.Completed,
                task.Status);
        }

        [Fact]
        public void Task_TypeCanBeChanged()
        {
            var task = new TaskItem
            {
                Type = TaskItem.TaskType.Quiz
            };

            Assert.Equal(TaskItem.TaskType.Quiz, task.Type);
        }

        [Fact]
        public void Task_DueDateCanBeSetAndCleared()
        {
            var task = new TaskItem
            {
                DueDate = new System.DateTime(2099, 12, 31)
            };

            Assert.True(task.DueDate.HasValue);
            Assert.Equal(2099, task.DueDate.Value.Year);

            task.DueDate = null;

            Assert.Null(task.DueDate);
        }

        [Theory]
        [InlineData(TaskItem.TaskType.Assignment)]
        [InlineData(TaskItem.TaskType.Quiz)]
        public void Task_SupportsExpectedTypes(TaskItem.TaskType type)
        {
            var task = new TaskItem
            {
                Type = type
            };

            Assert.Equal(type, task.Type);
        }

    }
}
