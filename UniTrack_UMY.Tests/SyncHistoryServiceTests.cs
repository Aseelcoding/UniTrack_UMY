using System;
using System.IO;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class SyncHistoryServiceTests
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
                var service = new SyncHistoryService(
                    Path.Combine(dir, "sync.json"));

                Assert.Empty(service.Load());
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Add_ThenLoad_ReturnsNewestFirst()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new SyncHistoryService(
                    Path.Combine(dir, "sync.json"));

                service.Add(new SyncHistoryEntry
                {
                    Timestamp = DateTime.Now.AddMinutes(-10),
                    Success = false,
                    TotalCourses = 10
                });

                service.Add(new SyncHistoryEntry
                {
                    Timestamp = DateTime.Now,
                    Success = true,
                    TotalCourses = 20
                });

                var entries = service.Load();

                Assert.Equal(2, entries.Count);
                Assert.True(entries[0].Success);
                Assert.False(entries[1].Success);
            }
            finally
            {
                DeleteTempDirectory(dir);
            }
        }

        [Fact]
        public void Load_PrunesEntriesOlderThan30Days()
        {
            string dir = CreateTempDirectory();

            try
            {
                var service = new SyncHistoryService(
                    Path.Combine(dir, "sync.json"));

                service.Add(new SyncHistoryEntry
                {
                    Timestamp = DateTime.Now.AddDays(-40),
                    Success = false
                });

                service.Add(new SyncHistoryEntry
                {
                    Timestamp = DateTime.Now,
                    Success = true
                });

                var entries = service.Load();

                Assert.Single(entries);
                Assert.True(entries[0].Success);
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
                var service = new SyncHistoryService(
                    Path.Combine(dir, "sync.json"));

                service.Add(new SyncHistoryEntry
                {
                    Timestamp = DateTime.Now,
                    Success = true
                });

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
