
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucNotesPlanner : UserControl
    {
        private readonly SettingsService _settingsService;

        public ucNotesPlanner()
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

            lblNotesPlannerTitle.Text = isIndonesian
                ? "Catatan dan Perencana"
                : "Notes and Planner";
            lblNotesPlannerDescription.Text = isIndonesian
    ? "Kelola catatan dan rencana belajar Anda"
    : "Manage your notes and study plans";
            colTitle.Text = isIndonesian
                ? "Judul"
                : "Title";

            columnHeader2.Text = isIndonesian
                ? "Mata Kuliah"
                : "Course";

            txtNoteTitle.PlaceholderText = isIndonesian
                ? "Masukkan judul catatan"
                : "Enter note title";

            txtNoteContent.PlaceholderText = isIndonesian
                ? "Tulis catatan Anda di sini..."
                : "Write your note here...";

            btnAddNote.Text = isIndonesian
                ? "Tambah Catatan"
                : "Add Note";

            btnDeleteNote.Text = isIndonesian
                ? "Hapus Catatan"
                : "Delete Note";

            btnSaveNote.Text = isIndonesian
                ? "Simpan Catatan"
                : "Save Note";
        }
    }
}
