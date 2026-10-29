
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
        public void Load_WhenFileIsEmpty_ReturnsDefaultSettingsAndCreatesBackup()
        {
            string directory = Path.Combine(
                Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(directory);
            string settingsPath = Path.Combine(directory, "settings.json");

            try
            {
                File.WriteAllText(settingsPath, string.Empty);

                var service = new SettingsService(settingsPath);
                var settings = service.Load();

                Assert.NotNull(settings);
                Assert.False(File.Exists(settingsPath));

                string[] backups = Directory.GetFiles(
                    directory, "settings.json.bad-*");

                Assert.Single(backups);
                Assert.Equal(string.Empty, File.ReadAllText(backups[0]));
            }
            finally
            {
                Directory.Delete(directory, true);
            }
        }


        [Fact]
        public void Load_WhenJsonIsInvalid_ReturnsDefaultSettingsAndCreatesBackup()
        {
            string directory = Path.Combine(
                Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(directory);
            string settingsPath = Path.Combine(directory, "settings.json");

            try
            {
                File.WriteAllText(settingsPath, "{ invalid json");

                var service = new SettingsService(settingsPath);
                var settings = service.Load();

                Assert.NotNull(settings);
                Assert.False(File.Exists(settingsPath));

                string[] backups = Directory.GetFiles(
                    directory, "settings.json.bad-*");

                Assert.Single(backups);
                Assert.Equal("{ invalid json", File.ReadAllText(backups[0]));
            }
            finally
            {
                Directory.Delete(directory, true);
            }
        }

        [Fact]
        public void Load_WhenFileDoesNotExist_ReturnsDefaultSettings()
        {
            string directory = Path.Combine(
                Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(directory);

            try
            {
                string settingsPath = Path.Combine(directory, "settings.json");
                var service = new SettingsService(settingsPath);

                var settings = service.Load();

                Assert.NotNull(settings);
                Assert.False(File.Exists(settingsPath));
            }
            finally
            {
                Directory.Delete(directory, true);
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
