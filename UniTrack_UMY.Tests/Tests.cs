
using UniTrack_UMY.Core.Models;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class AppSettingsTests
    {
        [Fact]
        public void NewSettings_DefaultLanguageIsEnglish()
        {
            var settings = new AppSettings();

            Assert.Equal(AppLanguage.English, settings.Language);
        }

        [Fact]
        public void NewSettings_DefaultThemeIsLight()
        {
            var settings = new AppSettings();

            Assert.Equal(AppTheme.Light, settings.Theme);
        }

        [Fact]
        public void Settings_CanChangeLanguageAndTheme()
        {
            var settings = new AppSettings
            {
                Language = AppLanguage.Indonesian,
                Theme = AppTheme.Dark
            };

            Assert.Equal(AppLanguage.Indonesian, settings.Language);
            Assert.Equal(AppTheme.Dark, settings.Theme);
        }
    }
}
