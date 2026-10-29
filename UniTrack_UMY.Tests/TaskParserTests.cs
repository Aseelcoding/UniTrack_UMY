
using System;
using System.Linq;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class TaskParserTests
    {
        private readonly TaskParser _parser = new TaskParser();

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("<html><body>No activities</body></html>")]
        public void ParseTasks_WhenNoActivitiesExist_ReturnsEmptyList(
            string html)
        {
            var result = _parser.ParseTasks(html, "123");

            Assert.Empty(result);
        }

        [Fact]
        public void ParseTasks_ExtractsAssignmentInformation()
        {
            string html = @"
                <ul>
                    <li class='activity-wrapper modtype_assign'>
                        <a class='aalink'
                           href='/mod/assign/view.php?id=50'>
                            <span class='instancename'>
                                Programming Assignment
                            </span>
                        </a>
                    </li>
                </ul>";

            var result = _parser.ParseTasks(html, "123");

            var task = Assert.Single(result);

            Assert.Equal("123", task.CourseId);
            Assert.Equal("Programming Assignment", task.Title);
            Assert.Equal(TaskItem.TaskType.Assignment, task.Type);
            Assert.Equal(
                "/mod/assign/view.php?id=50",
                task.Url);
            Assert.Equal("No due date", task.DueDateText);
            Assert.Null(task.DueDate);
            Assert.Equal(TaskItem.TaskStatus.Pending, task.Status);
        }

        [Fact]
        public void ParseTasks_IgnoresResourceAndAttendanceActivities()
        {
            string html = @"
                <ul>
                    <li class='activity-wrapper modtype_resource'>
                        <span class='instancename'>Lecture Notes</span>
                    </li>
                    <li class='activity-wrapper modtype_attendance'>
                        <span class='instancename'>Attendance</span>
                    </li>
                </ul>";

            var result = _parser.ParseTasks(html, "123");

            Assert.Empty(result);
        }

        [Fact]
        public void ParseTasks_ExtractsDueDate()
        {
            string html = @"
                <li class='activity-wrapper modtype_assign'>
                    <a class='aalink' href='/assign/1'>
                        <span class='instancename'>Assignment One</span>
                    </a>
                    <div data-region='activity-dates'>
                        Due: 31 Dec 2099
                    </div>
                </li>";

            var result = _parser.ParseTasks(html, "123");

            var task = Assert.Single(result);

            Assert.Equal("31 Dec 2099", task.DueDateText);
            Assert.True(task.DueDate.HasValue);
            Assert.Equal(2099, task.DueDate.Value.Year);
            Assert.Equal(12, task.DueDate.Value.Month);
            Assert.Equal(31, task.DueDate.Value.Day);
        }

        [Fact]
        public void ParseTasks_ClassifiesQuizCorrectly()
        {
            string html = @"
                <li class='activity-wrapper modtype_quiz'>
                    <a class='aalink' href='/quiz/1'>
                        <span class='instancename'>Weekly Quiz</span>
                    </a>
                </li>";

            var result = _parser.ParseTasks(html, "123");

            var task = Assert.Single(result);

            Assert.Equal(TaskItem.TaskType.Quiz, task.Type);
            Assert.Equal("Weekly Quiz", task.Title);
        }

        [Fact]
        public void ParseTasks_MarksPastAssignmentAsOverdue()
        {
            string html = @"
                <li class='activity-wrapper modtype_assign'>
                    <a class='aalink' href='/assign/2'>
                        <span class='instancename'>Old Assignment</span>
                    </a>
                    <div data-region='activity-dates'>
                        Due: 01 Jan 2000
                    </div>
                </li>";

            var result = _parser.ParseTasks(html, "123");

            var task = Assert.Single(result);

            Assert.Equal(TaskItem.TaskStatus.Overdue, task.Status);
        }

        [Fact]
        public void ParseTasks_PrioritizesOverdueAssignments()
        {
            string html = @"
                <ul>
                    <li class='activity-wrapper modtype_assign'>
                        <a class='aalink' href='/assign/1'>
                            <span class='instancename'>Future Assignment</span>
                        </a>
                        <div data-region='activity-dates'>
                            Due: 31 Dec 2099
                        </div>
                    </li>
                    <li class='activity-wrapper modtype_assign'>
                        <a class='aalink' href='/assign/2'>
                            <span class='instancename'>Past Assignment</span>
                        </a>
                        <div data-region='activity-dates'>
                            Due: 01 Jan 2000
                        </div>
                    </li>
                </ul>";

            var result = _parser.ParseTasks(html, "123");

            Assert.Equal(2, result.Count);
            Assert.Equal("Past Assignment", result.First().Title);
            Assert.Equal("Future Assignment", result.Last().Title);
        }

        [Fact]
        public void ParseTasks_ExtractsModuleWeek()
        {
            string html = @"
                <li class='section main clearfix' id='section-1'>
                    <h3 class='sectionname'><span>Week 1</span></h3>
                    <div class='content'>
                        <ul>
                            <li class='activity-wrapper modtype_assign'>
                                <a class='aalink' href='/assign/1'>
                                    <span class='instancename'>Assignment One</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </li>";

            var result = _parser.ParseTasks(html, "123");

            var task = Assert.Single(result);

            Assert.Equal("Week 1", task.ModuleWeek);
        }

        [Fact]
        public void ParseTasks_CompletedQuizPastDue_IsCompleted()
        {
            string html = @"
                <li class='activity-wrapper modtype_quiz'>
                    <a class='aalink' href='/quiz/1'>
                        <span class='instancename'>Past Quiz</span>
                    </a>
                    <div data-region='activity-dates'>
                        Due: 01 Jan 2000
                    </div>
                    <span>Completed</span>
                </li>";

            var result = _parser.ParseTasks(html, "123");

            var task = Assert.Single(result);

            Assert.Equal(TaskItem.TaskType.Quiz, task.Type);
            Assert.Equal(TaskItem.TaskStatus.Completed, task.Status);
        }
    }
}
