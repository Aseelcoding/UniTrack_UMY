
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
        {
            string appFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack");

            Directory.CreateDirectory(appFolder);

            _filePath = Path.Combine(appFolder, "notes.json");
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
                return new List<StudyNote>();
            }
        }

        public void SaveNotes(List<StudyNote> notes)
        {
            string json = JsonSerializer.Serialize(
                notes,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(_filePath, json);
        }
    }
}
