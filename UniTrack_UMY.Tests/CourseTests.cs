
using UniTrack_UMY.Core.Models;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class CourseTests
    {
        [Fact]
        public void NewCourse_DefaultStringsAreEmpty()
        {
            var course = new Course();

            Assert.Equal(string.Empty, course.Id);
            Assert.Equal(string.Empty, course.Name);
            Assert.Equal(string.Empty, course.Url);
        }

        [Fact]
        public void NewCourse_HasNoProgressByDefault()
        {
            var course = new Course();

            Assert.False(course.HasProgress);
            Assert.Equal(0, course.ProgressPercent);
        }

        [Fact]
        public void Course_PropertiesCanBeSet()
        {
            var course = new Course
            {
                Id = "CS101",
                Name = "Programming",
                Url = "https://example.com",
                ProgressPercent = 75,
                HasProgress = true
            };

            Assert.Equal("CS101", course.Id);
            Assert.Equal("Programming", course.Name);
            Assert.Equal("https://example.com", course.Url);
            Assert.Equal(75, course.ProgressPercent);
            Assert.True(course.HasProgress);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(50)]
        [InlineData(100)]
        public void Course_StoresProgressPercent(int progress)
        {
            var course = new Course
            {
                ProgressPercent = progress,
                HasProgress = true
            };

            Assert.Equal(progress, course.ProgressPercent);
            Assert.True(course.HasProgress);
        }

        [Fact]
        public void NewCourse_CanRepresentProgressAsUnavailable()
        {
            var course = new Course
            {
                ProgressPercent = 0,
                HasProgress = false
            };

            Assert.Equal(0, course.ProgressPercent);
            Assert.False(course.HasProgress);
        }

    }
}
