
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

        [Fact]
        public void LoadNotes_WhenFileDoesNotExist_ReturnsEmptyList()
        {
            var service = new NotesService();

            var notes = service.LoadNotes();

            Assert.NotNull(notes);
        }

        [Fact]
        public void SaveNotes_WritesNotesToJsonFile()
        {
            var service = new NotesService();

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

        [Fact]
        public void LoadNotes_WhenJsonIsInvalid_ReturnsEmptyList()
        {
            string appFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack");

            string filePath = Path.Combine(
                appFolder,
                "notes.json");

            string? originalContent = null;
            bool fileExisted = File.Exists(filePath);

            if (fileExisted)
                originalContent = File.ReadAllText(filePath);

            try
            {
                Directory.CreateDirectory(appFolder);
                File.WriteAllText(filePath, "{ invalid json");

                var service = new NotesService();

                var notes = service.LoadNotes();

                Assert.NotNull(notes);
                Assert.Empty(notes);
            }
            finally
            {
                if (fileExisted)
                    File.WriteAllText(filePath, originalContent!);
                else if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }

        [Fact]
        public void SaveNotes_WhenListIsEmpty_SavesEmptyList()
        {
            var service = new NotesService();

            service.SaveNotes(new List<StudyNote>());

            var notes = service.LoadNotes();

            Assert.NotNull(notes);
            Assert.Empty(notes);
        }

        [Fact]
        public void SaveNotes_PreservesMultipleNotes()
        {
            var service = new NotesService();

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

    }
}
