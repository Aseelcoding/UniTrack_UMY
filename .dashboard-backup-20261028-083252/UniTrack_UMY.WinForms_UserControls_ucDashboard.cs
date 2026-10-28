
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucDashboard : UserControl
    {
        private readonly SettingsService _settingsService;

        public ucDashboard()
        {
            InitializeComponent();

            _settingsService = new SettingsService();
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            AppSettings settings = _settingsService.Load();
            bool isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            lblDashboardTitle.Text = isIndonesian
                ? "Dasbor"
                : "Dashboard";

            lblWelcome.Text = isIndonesian
                ? "Selamat datang di UniTrack"
                : "Welcome to UniTrack";

            lblCoursesTitle.Text = isIndonesian
                ? "Mata Kuliah Saya"
                : "My Courses";

            lblTasksTitle.Text = isIndonesian
                ? "Tugas"
                : "Tasks";

            lblUpcomingTitle.Text = isIndonesian
                ? "Mendatang"
                : "Upcoming";

            lblProgressTitle.Text = isIndonesian
                ? "Progres Belajar"
                : "Study Progress";

            lblUpcomingTasks.Text = isIndonesian
                ? "Tugas Mendatang"
                : "Upcoming Tasks";
        }
    }
}
