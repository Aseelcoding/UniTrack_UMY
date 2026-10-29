using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucTasks : UserControl
    {
        private readonly SettingsService _settingsService;
        private bool _isIndonesian;

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
            List<Course> courseList = courses.ToList();
            List<TaskItem> taskList = tasks.ToList();
            List<string> errors = loadErrors.ToList();

            var courseNames = courseList
                .Where(c => !string.IsNullOrWhiteSpace(c.Id))
                .GroupBy(c => c.Id)
                .ToDictionary(g => g.Key, g => g.First().Name);

            lvTasks.BeginUpdate();

            try
            {
                lvTasks.Items.Clear();

                if (isLoading)
                {
                    AddMessageRow(
                        _isIndonesian
                            ? "Memuat tugas dari MyKlass..."
                            : "Loading tasks from MyKlass...");

                    return;
                }

                if (!hasLoaded)
                {
                    AddMessageRow(
                        _isIndonesian
                            ? "Data tugas belum dimuat."
                            : "Task data has not been loaded yet.");

                    return;
                }

                foreach (TaskItem task in taskList
                    .OrderBy(t => t.DueDate ?? DateTime.MaxValue))
                {
                    string courseName =
                        courseNames.TryGetValue(
                            task.CourseId,
                            out string? name)
                            ? name
                            : string.Empty;

                    string dueDate;

                    if (task.DueDate.HasValue)
                    {
                        dueDate = task.DueDate.Value.ToString(
                            "dd MMM yyyy",
                            CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        dueDate = _isIndonesian
                            ? "Tanpa tenggat"
                            : "No due date";
                    }

                    var row = new ListViewItem(task.Title);

                    row.SubItems.Add(courseName);
                    row.SubItems.Add(dueDate);
                    row.SubItems.Add(GetStatusText(task.Status));

                    lvTasks.Items.Add(row);
                }
                if (taskList.Count == 0)
                {
                    AddMessageRow(
                        errors.Count > 0
                            ? (_isIndonesian
                                ? "Gagal memuat sebagian data tugas. Periksa pesan peringatan."
                                : "Some task data could not be loaded. Check the warning.")
                            : (_isIndonesian
                                ? "Tidak ada tugas yang ditemukan."
                                : "No tasks were found."));
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
            finally
            {
                lvTasks.EndUpdate();
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
    }
}