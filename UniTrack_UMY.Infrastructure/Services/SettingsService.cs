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
            : this(Path.Combine(
                FileStore.AppDataDirectory,
                "settings.json"))
        {
        }

        public SettingsService(string settingsPath)
        {
            if (string.IsNullOrWhiteSpace(settingsPath))
                throw new ArgumentException(
                    "Settings path cannot be empty.",
                    nameof(settingsPath));

            _settingsPath = settingsPath;
            FileStore.EnsureDirectory(_settingsPath);
        }

        public AppSettings Load()
        {
            return FileStore.Read<AppSettings>(_settingsPath)
                ?? new AppSettings();
        }

        public void Save(AppSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            string json = JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            FileStore.WriteAtomic(_settingsPath, json);
        }
    }
}
