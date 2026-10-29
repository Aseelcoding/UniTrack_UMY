
using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    public class SettingsService
    {
        private readonly string _settingsPath;

        public SettingsService()
            : this(Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack",
                "settings.json"))
        {
        }

        public SettingsService(string settingsPath)
        {
            _settingsPath = settingsPath;

            string? directory = Path.GetDirectoryName(_settingsPath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }

        public AppSettings Load()
        {
            if (!File.Exists(_settingsPath))
                return new AppSettings();

            try
            {
                string json = File.ReadAllText(_settingsPath);

                return JsonSerializer.Deserialize<AppSettings>(json)
                       ?? new AppSettings();
            }
            catch (JsonException)
            {
                MoveCorruptFile();
                return new AppSettings();
            }
            catch (IOException)
            {
                MoveCorruptFile();
                return new AppSettings();
            }
        }

        private void MoveCorruptFile()
        {
            if (!File.Exists(_settingsPath))
                return;

            string backupPath = _settingsPath + ".bad-" +
                DateTime.Now.ToString(
                    "yyyyMMddHHmmss",
                    CultureInfo.InvariantCulture);

            try
            {
                File.Move(_settingsPath, backupPath);
            }
            catch (IOException)
            {
                // Keep loading with default settings if the backup fails.
            }
        }

        public void Save(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(_settingsPath, json);
        }
    }
}
