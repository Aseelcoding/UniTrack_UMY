using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Services;
namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmMain : Form
    {
        private readonly SettingsService _settingsService;
        private AppSettings _settings;
        private ThemeColors _themeColors;
        private ThemeManager _themeManager;
        public frmMain()
        {
            InitializeComponent();
            _settingsService = new SettingsService();
            _settings = _settingsService.Load();

            _themeColors = new ThemeColors(_settings.Theme);
            _themeManager = new ThemeManager(_themeColors);

            _themeManager.ApplyTheme(this);
        }

        //this function will change the theme 
        private void ChangeTheme(AppTheme theme)
        {
            _settings.Theme = theme;
            _settingsService.Save(_settings);

            _themeColors = new ThemeColors(theme);
            _themeManager = new ThemeManager(_themeColors);

            _themeManager.ApplyTheme(this);
        }

    }
}
