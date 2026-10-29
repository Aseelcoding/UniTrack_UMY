using System;
using System.IO;
using System.Linq;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class ErrorLogServiceTests
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
                var service = new ErrorLogService(
                    Path.Combine(dir, "errorlog.json"));

                Assert.Empty(service.Load());
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Log_SanitizesCredentialsFromMessages()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ErrorLogService(
                    Path.Combine(dir, "errorlog.json"));

                service.Log(
                    "Exception",
                    "TaskLoading",
                    "Course A",
                    "Failed with token=abc123 and ?session=xyz");

                var entry = service.Load().Single();

                Assert.DoesNotContain("abc123", entry.Message);
                Assert.DoesNotContain("session=xyz", entry.Message);
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void FormatForCopy_JoinsEntriesWithDetails()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ErrorLogService(
                    Path.Combine(dir, "errorlog.json"));

                service.Log(
                    "TimeoutException",
                    "TaskLoading",
                    "Course A",
                    "Request timed out.");

                string text = service.FormatForCopy(service.Load());

                Assert.Contains("TimeoutException", text);
                Assert.Contains("Course A", text);
                Assert.Contains("Request timed out.", text);
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Clear_RemovesAllEntries()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new ErrorLogService(
                    Path.Combine(dir, "errorlog.json"));

                service.Log(
                    "Exception",
                    "TaskLoading",
                    "Course A",
                    "Something failed.");

                service.Clear();

                Assert.Empty(service.Load());
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }
    }
}
