
using System;
using System.Collections.Generic;
using System.IO;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class NotesServiceTests
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
        public void LoadNotes_WhenFileDoesNotExist_ReturnsEmptyList()
        {
            string directory = CreateTempDirectory();

            try
            {
                var service = new NotesService(
                    Path.Combine(directory, "notes.json"));

                Assert.Empty(service.LoadNotes());
            }
            finally
            {
                DeleteTempDirectory(directory);
            }
        }

        [Fact]
        public void SaveNotes_WritesNotesToJsonFile()
        {
            string directory = CreateTempDirectory();

            try
            {
                var service = new NotesService(
                    Path.Combine(directory, "notes.json"));

                var notes = new List<StudyNote>
                {
                    new StudyNote
                    {
                        Id = "1",
                        Title = "Database Notes",
                        CourseId = "123",
                        CourseName = "Database",
                        Content = "Review SQL joins"
                    }
                };

                service.SaveNotes(notes);

                var loadedNotes = service.LoadNotes();

                Assert.Contains(
                    loadedNotes,
                    note => note.Id == "1"
                        && note.Title == "Database Notes"
                        && note.CourseId == "123"
                        && note.CourseName == "Database"
                        && note.Content == "Review SQL joins");
            }
            finally
            {
                DeleteTempDirectory(directory);
            }
        }

        [Theory]
        [InlineData("{ invalid json")]
        [InlineData("")]
        public void LoadNotes_WhenJsonIsCorrupted_BacksUpFileAndReturnsEmptyList(
            string invalidJson)
        {
            string directory = CreateTempDirectory();
            string filePath = Path.Combine(directory, "notes.json");

            try
            {
                File.WriteAllText(filePath, invalidJson);

                var service = new NotesService(filePath);

                var notes = service.LoadNotes();

                Assert.Empty(notes);
                Assert.False(File.Exists(filePath));

                string[] backups = Directory.GetFiles(
                    directory, "notes.json.bad-*");

                Assert.Single(backups);
                Assert.Equal(invalidJson, File.ReadAllText(backups[0]));
            }
            finally
            {
                DeleteTempDirectory(directory);
            }
        }

        [Fact]
        public void SaveNotes_WhenListIsEmpty_SavesEmptyList()
        {
            string directory = CreateTempDirectory();

            try
            {
                var service = new NotesService(
                    Path.Combine(directory, "notes.json"));

                service.SaveNotes(new List<StudyNote>());

                Assert.Empty(service.LoadNotes());
            }
            finally
            {
                DeleteTempDirectory(directory);
            }
        }

        [Fact]
        public void SaveNotes_PreservesMultipleNotes()
        {
            string directory = CreateTempDirectory();

            try
            {
                var service = new NotesService(
                    Path.Combine(directory, "notes.json"));

                var notes = new List<StudyNote>
                {
                    new StudyNote
                    {
                        Id = "note-1",
                        Title = "Database",
                        Content = "SQL joins"
                    },
                    new StudyNote
                    {
                        Id = "note-2",
                        Title = "Networking",
                        Content = "TCP and UDP"
                    }
                };

                service.SaveNotes(notes);

                var loadedNotes = service.LoadNotes();

                Assert.Contains(loadedNotes, note => note.Id == "note-1");
                Assert.Contains(loadedNotes, note => note.Id == "note-2");
                Assert.Equal(2, loadedNotes.Count);
            }
            finally
            {
                DeleteTempDirectory(directory);
            }
        }

        [Fact]
        public void SaveNotes_WhenSuccessful_LeavesNoTemporaryFiles()
        {
            string directory = CreateTempDirectory();

            try
            {
                string filePath = Path.Combine(directory, "notes.json");
                var service = new NotesService(filePath);

                service.SaveNotes(new List<StudyNote>
                {
                    new StudyNote
                    {
                        Id = "1",
                        Title = "Test",
                        Content = "Content"
                    }
                });

                Assert.True(File.Exists(filePath));
                Assert.Empty(Directory.GetFiles(directory, "*.tmp"));
            }
            finally
            {
                DeleteTempDirectory(directory);
            }
        }
    }
}
