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
using UniTrack_UMY.WinForms.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmMain : Form
    {
        private readonly SettingsService _settingsService;
        private AppSettings _settings;
        private ThemeColors _themeColors;
        private ThemeManager _themeManager;
        private LocalizationManager _localizationManager;
        public frmMain()
        {
            InitializeComponent();
            _settingsService = new SettingsService();
            _settings = _settingsService.Load();

            _themeColors = new ThemeColors(_settings.Theme);
            _themeManager = new ThemeManager(_themeColors);

            _themeManager.ApplyTheme(this);
            _localizationManager =
    new LocalizationManager(_settings.Language);
            ApplyLanguage();
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

        private void ApplyLanguage()
        {
            lblAppTitle.Text = "UniTrack_UMY";
            lblAppTitle.ForeColor = Color.White;
            btnDashboard.Text =
                _localizationManager.GetText("Dashboard");

            btnMyCourses.Text =
                _localizationManager.GetText("MyCourses");

            btnTasks.Text =
                _localizationManager.GetText("Tasks");

            btnSchedule.Text =
                _localizationManager.GetText("Schedule");

            btnNotesPlanner.Text =
                _localizationManager.GetText("NotesPlanner");

            btnSettings.Text =
                _localizationManager.GetText("Settings");

            lblPageTitle.Text =
                _localizationManager.GetText("Dashboard");

            lblPageDescription.Text =
                _localizationManager.GetText("Welcome");
        }

        public void ApplySettings(AppSettings settings)
        {
            _settings = settings;
            _settingsService.Save(_settings);

            _themeColors = new ThemeColors(_settings.Theme);
            _themeManager = new ThemeManager(_themeColors);
            _themeManager.ApplyTheme(this);

            _localizationManager =
                new LocalizationManager(_settings.Language);

            ApplyLanguage();
        }
        private void ChangeLanguage(AppLanguage language)
        {
            _settings.Language = language;
            _settingsService.Save(_settings);

            _localizationManager =
                new LocalizationManager(language);

            ApplyLanguage();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UserControls.ucDashboard page =
         new UserControls.ucDashboard();

            page.Dock = DockStyle.Fill;
            _themeManager.ApplyTheme(page);

            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);

            lblPageTitle.Text =
                _localizationManager.GetText("Dashboard");

            lblPageDescription.Text =
                _localizationManager.GetText("Welcome");
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            UserControls.ucSettings page = new UserControls.ucSettings();

            page.Dock = DockStyle.Fill;
            _themeManager.ApplyTheme(page);
            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);

            lblPageTitle.Text = "Settings";
            lblPageDescription.Text = "Customize your preferences";
        }
        private void btnMyCourses_Click(object sender, EventArgs e)
        {
            UserControls.ucMyCourses page = new UserControls.ucMyCourses();
            page.Dock = DockStyle.Fill;
            _themeManager.ApplyTheme(page);
            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);

            lblPageTitle.Text = "My Courses";
            lblPageDescription.Text = "View your courses from MyKlass";
        }
        private void btnTasks_Click(object sender, EventArgs e)
        {
            UserControls.ucTasks page = new UserControls.ucTasks();
            page.Dock = DockStyle.Fill;
            _themeManager.ApplyTheme(page);
            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);

            lblPageTitle.Text = "Tasks";
            lblPageDescription.Text = "View your tasks from MyKlass";

        }
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            UserControls.ucSchedule page = new UserControls.ucSchedule();
            page.Dock = DockStyle.Fill;
            _themeManager.ApplyTheme(page);
            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);

            lblPageTitle.Text = "Schedule";
            lblPageDescription.Text = "View your schedule";

        }
        private void btnNotesPlanner_Click(object sender, EventArgs e)
        {
            UserControls.ucNotesPlanner page = new UserControls.ucNotesPlanner();
            page.Dock = DockStyle.Fill;
            _themeManager.ApplyTheme(page);
            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);

            lblPageTitle.Text = "Notes & Planner";
            lblPageDescription.Text = "Manage your notes and study plans";
        }
    }
}
