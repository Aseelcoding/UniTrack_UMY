
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Services;
using UniTrack_UMY.WinForms.UserControls;

namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmMain : Form
    {
        private readonly SettingsService _settingsService;
        private AppSettings _settings;
        private ThemeColors _themeColors;
        private ThemeManager _themeManager;
        private LocalizationManager _localizationManager;
        private readonly List<Course> _courses;

        public frmMain() : this(new List<Course>())
        {
        }

        public frmMain(List<Course> courses)
        {
            InitializeComponent();

            _settingsService = new SettingsService();
            _settings = _settingsService.Load();
            _courses = courses ?? new List<Course>();

            _themeColors = new ThemeColors(_settings.Theme);
            _themeManager = new ThemeManager(_themeColors);
            _localizationManager =
                new LocalizationManager(_settings.Language);

            _themeManager.ApplyTheme(this);
            ApplyLanguage();

            ShowPage(new ucDashboard());
        }

        private void ShowPage(UserControl page)
        {
            page.Dock = DockStyle.Fill;

            _themeManager.ApplyTheme(page);

            pnlPageContent.Controls.Clear();
            pnlPageContent.Controls.Add(page);
        }

        private void ApplyLanguage()
        {
            lblAppTitle.Text = "UniTrack_UMY";
            lblAppTitle.ForeColor = System.Drawing.Color.White;

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
        }

        public void ApplySettings(AppSettings settings)
        {
            _settings = settings;
            _settingsService.Save(_settings);

            _themeColors = new ThemeColors(_settings.Theme);
            _themeManager = new ThemeManager(_themeColors);

            _localizationManager =
                new LocalizationManager(_settings.Language);

            _themeManager.ApplyTheme(this);
            ApplyLanguage();

            if (pnlPageContent.Controls.Count == 0)
                return;

            UserControl currentPage =
                pnlPageContent.Controls[0] as UserControl;

            if (currentPage is ucDashboard)
                ShowPage(new ucDashboard());
            else if (currentPage is ucMyCourses)
                ShowPage(new ucMyCourses());
            else if (currentPage is ucTasks)
                ShowPage(new ucTasks());
            else if (currentPage is ucSchedule)
                ShowPage(new ucSchedule());
            else if (currentPage is ucNotesPlanner)
                ShowPage(new ucNotesPlanner(_courses));
            else if (currentPage is ucSettings)
                ShowPage(new ucSettings());
        }

        private void ChangeTheme(AppTheme theme)
        {
            _settings.Theme = theme;
            _settingsService.Save(_settings);

            _themeColors = new ThemeColors(theme);
            _themeManager = new ThemeManager(_themeColors);

            _themeManager.ApplyTheme(this);

            if (pnlPageContent.Controls.Count > 0 &&
                pnlPageContent.Controls[0] is UserControl page)
            {
                _themeManager.ApplyTheme(page);
            }
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
            ShowPage(new ucDashboard());
        }

        private void btnMyCourses_Click(object sender, EventArgs e)
        {
            ShowPage(new ucMyCourses());
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            ShowPage(new ucTasks());
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ShowPage(new ucSchedule());
        }

        private void btnNotesPlanner_Click(object sender, EventArgs e)
        {
            ShowPage(new ucNotesPlanner(_courses));
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowPage(new ucSettings());
        }
    }
}
