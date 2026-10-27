
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucTasks : UserControl
    {
        private readonly SettingsService _settingsService;

        public ucTasks()
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

            lblTasksTitle.Text = isIndonesian
                ? "Tugas Saya"
                : "My Tasks";
            lblTasksDescription.Text = isIndonesian
    ? "Lihat tugas Anda dari MyKlass"
    : "View your tasks from MyKlass";
            colTask.Text = isIndonesian
                ? "Tugas"
                : "Task";

            colCourse.Text = isIndonesian
                ? "Mata Kuliah"
                : "Course";

            colDueDate.Text = isIndonesian
                ? "Tenggat Waktu"
                : "Due Date";

            colStatus.Text = isIndonesian
                ? "Status"
                : "Status";

            btnAddTask.Text = isIndonesian
                ? "Tambah Tugas"
                : "Add Task";

            btnDeleteTask.Text = isIndonesian
                ? "Hapus Tugas"
                : "Delete Task";
        }
    }
}
