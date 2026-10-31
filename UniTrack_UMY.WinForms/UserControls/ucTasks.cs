using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Forms;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucTasks : UserControl
    {
        private readonly SettingsService _settingsService;
        private bool _isIndonesian;
        private readonly ManualTaskService _manualTaskService;
        private List<TaskItem> _allTasks = new List<TaskItem>();
        private List<Course> _courses = new List<Course>();
        public ucTasks()
            : this(
                new List<Course>(),
                new List<TaskItem>(),
                new List<string>(),
                false,
                false)
        {
        }

        public ucTasks(
            IEnumerable<Course> courses,
            IEnumerable<TaskItem> tasks,
            IEnumerable<string> loadErrors,
            bool isLoading,
            bool hasLoaded)
        {
            InitializeComponent();

            _settingsService = new SettingsService();
            _manualTaskService = new ManualTaskService();

            ApplyLanguage();

            PopulateTasks(
                courses,
                tasks,
                loadErrors,
                isLoading,
                hasLoaded);
        }

        private void PopulateTasks(
      IEnumerable<Course> courses,
      IEnumerable<TaskItem> tasks,
      IEnumerable<string> loadErrors,
      bool isLoading,
      bool hasLoaded)
        {
            _courses = courses.ToList();

            _allTasks = tasks.ToList();
            _allTasks.AddRange(_manualTaskService.Load());

            List<string> errors = loadErrors.ToList();

            LoadFilters();

            DisplayTasks(ApplyFilters());

            if (isLoading)
            {
                AddMessageRow(
                    _isIndonesian
                        ? "Memuat tugas dari MyKlass..."
                        : "Loading tasks from MyKlass...");
            }
            else if (!hasLoaded)
            {
                AddMessageRow(
                    _isIndonesian
                        ? "Data tugas belum dimuat."
                        : "Task data has not been loaded yet.");
            }

            if (errors.Count > 0)
            {
                string errorDetails = string.Join(
                    Environment.NewLine,
                    errors);

                lblTasksDescription.Text = _isIndonesian
                    ? $"Peringatan: {errors.Count} mata kuliah gagal dimuat."
                    : $"Warning: {errors.Count} course(s) failed to load.";

                lblTasksDescription.Text +=
                    Environment.NewLine + errorDetails;
            }
        }

        private void AddMessageRow(string message)
        {
            var row = new ListViewItem(message);

            row.SubItems.Add(string.Empty);
            row.SubItems.Add(string.Empty);
            row.SubItems.Add(string.Empty);

            lvTasks.Items.Add(row);
        }

        private string GetStatusText(TaskItem.TaskStatus status)
        {
            if (_isIndonesian)
            {
                switch (status)
                {
                    case TaskItem.TaskStatus.Pending:
                        return "Menunggu";

                    case TaskItem.TaskStatus.Completed:
                        return "Selesai";

                    case TaskItem.TaskStatus.SubmittedLate:
                        return "Terlambat dikumpulkan";

                    case TaskItem.TaskStatus.Overdue:
                        return "Terlambat";

                    case TaskItem.TaskStatus.NoDueDate:
                        return "Tanpa tenggat";

                    default:
                        return "Tidak diketahui";
                }
            }

            switch (status)
            {
                case TaskItem.TaskStatus.Pending:
                    return "Pending";

                case TaskItem.TaskStatus.Completed:
                    return "Completed";

                case TaskItem.TaskStatus.SubmittedLate:
                    return "Submitted late";

                case TaskItem.TaskStatus.Overdue:
                    return "Overdue";

                case TaskItem.TaskStatus.NoDueDate:
                    return "No due date";

                default:
                    return "Unknown";
            }
        }

        private void ApplyLanguage()
        {
            AppSettings settings = _settingsService.Load();

            _isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            lblTasksTitle.Text = _isIndonesian
                ? "Tugas Saya"
                : "My Tasks";

            lblTasksDescription.Text = _isIndonesian
                ? "Lihat tugas Anda dari MyKlass"
                : "View your tasks from MyKlass";

            colTask.Text = _isIndonesian
                ? "Tugas"
                : "Task";

            colCourse.Text = _isIndonesian
                ? "Mata Kuliah"
                : "Course";

            colDueDate.Text = _isIndonesian
                ? "Tenggat Waktu"
                : "Due Date";

            colStatus.Text = _isIndonesian
                ? "Status"
                : "Status";

            btnAddTask.Text = _isIndonesian
                ? "Tambah Tugas"
                : "Add Task";

            btnDeleteTask.Text = _isIndonesian
                ? "Hapus Tugas"
                : "Delete Task";
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            frmAddTask frmAdd = new frmAddTask(_courses);

            if (frmAdd.ShowDialog(this) != DialogResult.OK ||
                frmAdd.CreatedTask == null)
                return;

            TaskItem task = _manualTaskService.Add(frmAdd.CreatedTask);

            var row = new ListViewItem(task.Title);
            row.Tag = task;

            row.SubItems.Add(task.CourseName);
            row.SubItems.Add(
                task.DueDate.HasValue
                    ? task.DueDate.Value.ToString("dd MMM yyyy")
                    : (_isIndonesian ? "Tanpa tenggat" : "No due date"));

            row.SubItems.Add(GetStatusText(task.Status));

            lvTasks.Items.Add(row);
        }

        private void lvTasks_DoubleClick(object sender, EventArgs e)
        {

            if (lvTasks.SelectedItems.Count == 0)
                return;

            TaskItem task = lvTasks.SelectedItems[0].Tag as TaskItem;

            if (task == null || task.Source != TaskItem.TaskSource.MyKlass)
                return;

            if (!Uri.TryCreate(task.Url, UriKind.Absolute, out Uri uri))
                return;

            if (uri.Scheme != Uri.UriSchemeHttp &&
                uri.Scheme != Uri.UriSchemeHttps)
                return;

            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo(task.Url)
                {
                    UseShellExecute = true
                });
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count == 0)
                return;

            TaskItem task =
                lvTasks.SelectedItems[0].Tag as TaskItem;

            if (task == null)
                return;

            if (task.Source != TaskItem.TaskSource.Manual)
            {
                MessageBox.Show(
                    _isIndonesian
                        ? "Hanya tugas manual yang dapat dihapus."
                        : "Only manually added tasks can be deleted.",
                    "UniTrack",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show(
                _isIndonesian
                    ? "Apakah Anda yakin ingin menghapus tugas ini?"
                    : "Are you sure you want to delete this task?",
                "UniTrack",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (_manualTaskService.Delete(task.Id))
            {
                lvTasks.Items.Remove(lvTasks.SelectedItems[0]);
            }
        }
        private void LoadFilters()
        {
            var courseOptions = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>(
            "",
            _isIndonesian ? "Semua Mata Kuliah" : "All Courses")
    };

            foreach (Course course in _courses
                .Where(c => !string.IsNullOrWhiteSpace(c.Id))
                .GroupBy(c => c.Id)
                .Select(g => g.First()))
            {
                courseOptions.Add(
                    new KeyValuePair<string, string>(
                        course.Id,
                        course.Name));
            }

            cmbCourseFilter.DisplayMember = "Value";
            cmbCourseFilter.ValueMember = "Key";
            cmbCourseFilter.DataSource = courseOptions;
            cmbCourseFilter.SelectedIndex = 0;
        }
        private List<TaskItem> ApplyFilters()
        {
            IEnumerable<TaskItem> filteredTasks = _allTasks;

            // Course filter
            if (cmbCourseFilter.SelectedValue is string courseId &&
                !string.IsNullOrWhiteSpace(courseId))
            {
                filteredTasks = filteredTasks.Where(
                    task => task.CourseId == courseId);
            }

            return filteredTasks
                .OrderBy(task => task.DueDate ?? DateTime.MaxValue)
                .ToList();
        }
        private void DisplayTasks(List<TaskItem> taskList)
        {
            lvTasks.BeginUpdate();

            try
            {
                lvTasks.Items.Clear();

                foreach (TaskItem task in taskList)
                {
                    string courseName = _courses
                        .FirstOrDefault(c => c.Id == task.CourseId)?.Name
                        ?? task.CourseName;

                    string dueDate = task.DueDate.HasValue
                        ? task.DueDate.Value.ToString(
                            "dd MMM yyyy",
                            CultureInfo.CurrentCulture)
                        : (_isIndonesian ? "Tanpa tenggat" : "No due date");

                    var row = new ListViewItem(task.Title);
                    row.Tag = task;
                    row.SubItems.Add(courseName);
                    row.SubItems.Add(dueDate);
                    row.SubItems.Add(GetStatusText(task.Status));

                    lvTasks.Items.Add(row);
                }

                if (taskList.Count == 0)
                {
                    AddMessageRow(
                        _isIndonesian
                            ? "Tidak ada tugas yang ditemukan."
                            : "No tasks were found.");
                }
            }
            finally
            {
                lvTasks.EndUpdate();
            }
        }

        private void cmbCourseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTasks(ApplyFilters());
        }
    }
}