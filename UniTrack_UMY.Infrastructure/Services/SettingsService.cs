
using System;
using System.IO;
using System.Text.Json;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    public class SettingsService
    {
        private readonly string _settingsPath;

        public SettingsService()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack");

            Directory.CreateDirectory(appDataPath);

            _settingsPath = Path.Combine(
                appDataPath, "settings.json");
        }

        public AppSettings Load()
        {
            if (!File.Exists(_settingsPath))
                return new AppSettings();

            string json = File.ReadAllText(_settingsPath);

            return JsonSerializer.Deserialize<AppSettings>(json)
                   ?? new AppSettings();
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
