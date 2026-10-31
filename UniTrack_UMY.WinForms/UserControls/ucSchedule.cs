
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucSchedule : UserControl
    {
        private readonly SettingsService _settingsService;

        public ucSchedule()
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

            lblScheduleTitle.Text = isIndonesian
                ? "Jadwal Saya"
                : "My Schedule";
            lblScheduleDescription.Text = isIndonesian
    ? "Lihat jadwal kuliah Anda"
    : "View your class schedule";
            colDay.Text = isIndonesian
                ? "Hari"
                : "Day";

            colCourse.Text = isIndonesian
                ? "Mata Kuliah"
                : "Course";

          

            colStartTime.Text = isIndonesian
                ? "Waktu Mulai"
                : "Start Time";

            colEndTime.Text = isIndonesian
                ? "Waktu Selesai"
                : "End Time";

            colLocation.Text = isIndonesian
                ? "Lokasi"
                : "Location";

            btnAddSchedule.Text = isIndonesian
                ? "Tambah Jadwal"
                : "Add Schedule";

            btnDeleteSchedule.Text = isIndonesian
                ? "Hapus Jadwal"
                : "Delete Schedule";
        }

        private void lvSchedule_SizeChanged(object? sender, EventArgs e)
        {
            int fixedWidth = colDay.Width + colStartTime.Width
                           + colEndTime.Width + colLocation.Width;
            colCourse.Width = Math.Max(200, lvSchedule.ClientSize.Width - fixedWidth);
        }
    }
}
