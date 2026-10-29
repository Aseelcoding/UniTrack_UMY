
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    public class NotesService
    {
        private readonly string _filePath;

        public NotesService()
            : this(Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack",
                "notes.json"))
        {
        }

        public NotesService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "File path cannot be empty.", nameof(filePath));

            _filePath = filePath;

            string? directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }

        public List<StudyNote> LoadNotes()
        {
            if (!File.Exists(_filePath))
                return new List<StudyNote>();

            try
            {
                string json = File.ReadAllText(_filePath);

                return JsonSerializer.Deserialize<List<StudyNote>>(json)
                    ?? new List<StudyNote>();
            }
            catch (JsonException)
            {
                BackupCorruptedFile();
                return new List<StudyNote>();
            }
            catch (IOException)
            {
                return new List<StudyNote>();
            }
        }

        private void BackupCorruptedFile()
        {
            if (!File.Exists(_filePath))
                return;

            string backupPath = _filePath + ".bad-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                if (File.Exists(backupPath))
                {
                    backupPath = _filePath + ".bad-" +
                        DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }

                File.Move(_filePath, backupPath);
            }
            catch (IOException)
            {
                // Preserve the application's ability to continue.
            }
            catch (UnauthorizedAccessException)
            {
                // Preserve the application's ability to continue.
            }
        }

        public void SaveNotes(List<StudyNote> notes)
        {
            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            string json = JsonSerializer.Serialize(
                notes,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            string? directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            string tempPath = _filePath + "." +
                Guid.NewGuid().ToString("N") + ".tmp";

            try
            {
                File.WriteAllText(tempPath, json);

                if (File.Exists(_filePath))
                    File.Replace(tempPath, _filePath, null);
                else
                    File.Move(tempPath, _filePath);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }
    }
}
