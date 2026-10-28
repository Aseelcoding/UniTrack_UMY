
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class CourseParserTests
    {
        private readonly CourseParser _parser = new CourseParser();

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("<html><body>No courses</body></html>")]
        public void ParseCourses_WhenNoCoursesExist_ReturnsEmptyList(
            string html)
        {
            var result = _parser.ParseCourses(html);

            Assert.Empty(result);
        }

        [Fact]
        public void ParseCourses_ExtractsCourseInformation()
        {
            string html = @"
                <ul>
                    <li class='course-listitem' data-course-id='123'>
                        <a class='coursename' href='/course/view.php?id=123'>
                            Programming
                            <span class='sr-only'>Hidden text</span>
                        </a>
                        <div class='progress-text'>
                            Course progress: 75% complete
                        </div>
                    </li>
                </ul>";

            var result = _parser.ParseCourses(html);

            var course = Assert.Single(result);

            Assert.Equal("123", course.Id);
            Assert.Equal("Programming", course.Name);
            Assert.Equal("/course/view.php?id=123", course.Url);
            Assert.Equal(75, course.ProgressPercent);
            Assert.True(course.HasProgress);
        }

        [Fact]
        public void ParseCourses_SkipsCourseWithoutId()
        {
            string html = @"
                <li class='course-listitem'>
                    <a class='coursename' href='/course/1'>
                        Programming
                    </a>
                </li>";

            var result = _parser.ParseCourses(html);

            Assert.Empty(result);
        }

        [Fact]
        public void ParseCourses_WithoutProgress_KeepsDefaultValues()
        {
            string html = @"
                <li class='course-listitem' data-course-id='456'>
                    <a class='coursename' href='/course/456'>
                        Database
                    </a>
                </li>";

            var result = _parser.ParseCourses(html);

            var course = Assert.Single(result);

            Assert.Equal("Database", course.Name);
            Assert.Equal(0, course.ProgressPercent);
            Assert.False(course.HasProgress);
        }

        [Fact]
        public void ParseCourses_ExtractsMultipleCourses()
        {
            string html = @"
                <ul>
                    <li class='course-listitem' data-course-id='101'>
                        <a class='coursename' href='/course/101'>
                            Programming
                        </a>
                    </li>
                    <li class='course-listitem' data-course-id='102'>
                        <a class='coursename' href='/course/102'>
                            Database
                        </a>
                    </li>
                </ul>";

            var result = _parser.ParseCourses(html);

            Assert.Equal(2, result.Count);
            Assert.Equal("101", result[0].Id);
            Assert.Equal("Programming", result[0].Name);
            Assert.Equal("102", result[1].Id);
            Assert.Equal("Database", result[1].Name);
        }

        [Fact]
        public void ParseCourses_CleansExtraWhitespaceFromCourseName()
        {
            string html = @"
                <li class='course-listitem' data-course-id='103'>
                    <a class='coursename' href='/course/103'>
                        Programming
                        and
                        Database
                    </a>
                </li>";

            var result = _parser.ParseCourses(html);

            var course = Assert.Single(result);

            Assert.Equal("Programming and Database", course.Name);
        }

        [Fact]
        public void ParseCourses_WhenProgressIsInvalid_KeepsDefaultValues()
        {
            string html = @"
                <li class='course-listitem' data-course-id='104'>
                    <a class='coursename' href='/course/104'>
                        Networking
                    </a>
                    <div class='progress-text'>
                        Progress unavailable
                    </div>
                </li>";

            var result = _parser.ParseCourses(html);

            var course = Assert.Single(result);

            Assert.Equal(0, course.ProgressPercent);
            Assert.False(course.HasProgress);
        }

    }

}
