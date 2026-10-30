
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Services;

namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmAddTask : Form
    {
        private readonly List<Course> _courses;
        private readonly SettingsService _settingsService;
        private bool _isIndonesian;

        public TaskItem CreatedTask { get; private set; }

        public frmAddTask(IEnumerable<Course> courses)
        {
            InitializeComponent();

            _courses = courses.ToList();
            _settingsService = new SettingsService();

            ApplySettings();
            LoadCourses();
            LoadTaskTypes();


            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void ApplySettings()
        {
            AppSettings settings = _settingsService.Load();

            _isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            Text = _isIndonesian
                ? "Tambah Tugas Baru"
                : "Add New Task";

            lblTitle.Text = _isIndonesian
                ? "Nama Tugas"
                : "Task Title";

            lblCourse.Text = _isIndonesian
                ? "Mata Kuliah"
                : "Course";

            lblType.Text = _isIndonesian
                ? "Jenis Tugas"
                : "Task Type";

            lblDueDate.Text = _isIndonesian
                ? "Tenggat Waktu"
                : "Due Date";

            btnSave.Text = _isIndonesian
                ? "Simpan"
                : "Save Task";

            btnCancel.Text = _isIndonesian
                ? "Batal"
                : "Cancel";

            ThemeColors colors = new ThemeColors(settings.Theme);

            ThemeManager themeManager =
                new ThemeManager(colors);

            themeManager.ApplyTheme(this);
        }

        private void LoadCourses()
        {
            cmbCourse.DataSource = _courses;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";
        }

        private void LoadTaskTypes()
        {
            cmbType.DataSource =
                Enum.GetValues(typeof(TaskItem.TaskType));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    _isIndonesian
                        ? "Nama tugas harus diisi."
                        : "Task title is required.",
                    "UniTrack",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return;
            }

            Course selectedCourse =
                cmbCourse.SelectedItem as Course;

            if (selectedCourse == null)
                return;

            TaskItem.TaskType selectedType =
                (TaskItem.TaskType)cmbType.SelectedItem;

            CreatedTask = new TaskItem
            {
                CourseId = selectedCourse.Id,
                CourseName = selectedCourse.Name,
                Title = txtTitle.Text.Trim(),
                Type = selectedType,
                Source = TaskItem.TaskSource.Manual,

                DueDate = dtpDueDate.Checked
                    ? dtpDueDate.Value.Date
                    : (DateTime?)null,

                DueDateText = dtpDueDate.Checked
                    ? dtpDueDate.Value.ToString("dd MMM yyyy")
                    : "No due date",

                Status = dtpDueDate.Checked
                    ? TaskItem.TaskStatus.Pending
                    : TaskItem.TaskStatus.NoDueDate
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
