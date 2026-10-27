
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucMyCourses : UserControl
    {
        private readonly SettingsService _settingsService;

        public ucMyCourses()
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

            lblCoursesTitle.Text = isIndonesian
                ? "Mata Kuliah Saya"
                : "My Courses";
            lblCoursesDescription.Text = isIndonesian
    ? "Lihat mata kuliah Anda dari MyKlass"
    : "View your courses from MyKlass";
            colCourseName.Text = isIndonesian
                ? "Nama Mata Kuliah"
                : "Course Name";

            colProgress.Text = isIndonesian
                ? "Progres"
                : "Progress";

            colStatus.Text = isIndonesian
                ? "Status"
                : "Status";

            colAction.Text = isIndonesian
                ? "Aksi"
                : "Action";

            btnOpenCourse.Text = isIndonesian
                ? "Buka Mata Kuliah"
                : "Open Course";
        }
    }
}
