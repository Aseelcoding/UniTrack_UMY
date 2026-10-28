
using System;
using System.IO;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class SettingsServiceTests
    {
        [Fact]
        public void Load_WhenFileDoesNotExist_ReturnsDefaultSettings()
        {
            string settingsPath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack",
                "settings.json");

            string? originalContent = null;
            bool fileExisted = File.Exists(settingsPath);

            if (fileExisted)
                originalContent = File.ReadAllText(settingsPath);

            try
            {
                if (File.Exists(settingsPath))
                    File.Delete(settingsPath);

                var service = new SettingsService();

                var settings = service.Load();

                Assert.NotNull(settings);
            }
            finally
            {
                if (fileExisted)
                    File.WriteAllText(settingsPath, originalContent!);
            }
        }

        [Fact]
        public void Save_ThenLoad_PreservesSettings()
        {
            var service = new SettingsService();
            var original = service.Load();

            try
            {
                var settings = new AppSettings
                {
                    Language = AppLanguage.English,
                    Theme = AppTheme.Dark
                };

                service.Save(settings);

                var loaded = service.Load();

                Assert.Equal(settings.Language, loaded.Language);
                Assert.Equal(settings.Theme, loaded.Theme);
            }
            finally
            {
                service.Save(original);
            }
        }

        [Fact]
        public void Load_WhenFileIsEmpty_ThrowsJsonException()
        {
            string settingsPath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack",
                "settings.json");

            string? originalContent = null;
            bool fileExisted = File.Exists(settingsPath);

            if (fileExisted)
                originalContent = File.ReadAllText(settingsPath);

            try
            {
                Directory.CreateDirectory(
                    Path.GetDirectoryName(settingsPath)!);

                File.WriteAllText(settingsPath, string.Empty);

                var service = new SettingsService();

                Assert.Throws<System.Text.Json.JsonException>(
                    () => service.Load());
            }
            finally
            {
                if (fileExisted)
                    File.WriteAllText(settingsPath, originalContent!);
                else if (File.Exists(settingsPath))
                    File.Delete(settingsPath);
            }
        }

        [Fact]
      public void Save_ThenLoad_PreservesIndonesianAndLightTheme()
        {
            var service = new SettingsService();
            var original = service.Load();

            try
            {
                var settings = new AppSettings
                {
                    Language = AppLanguage.Indonesian,
                    Theme = AppTheme.Light
                };

                service.Save(settings);

                var loaded = service.Load();

                Assert.Equal(AppLanguage.Indonesian, loaded.Language);
                Assert.Equal(AppTheme.Light, loaded.Theme);
            }
            finally
            {
                service.Save(original);
            }
        }

        [Fact]
        public void Save_ThenLoad_PreservesEnglishAndDarkTheme()
        {
            var service = new SettingsService();
            var original = service.Load();

            try
            {
                var settings = new AppSettings
                {
                    Language = AppLanguage.English,
                    Theme = AppTheme.Dark
                };

                service.Save(settings);

                var loaded = service.Load();

                Assert.Equal(AppLanguage.English, loaded.Language);
                Assert.Equal(AppTheme.Dark, loaded.Theme);
            }
            finally
            {
                service.Save(original);
            }
        }

    }
}
