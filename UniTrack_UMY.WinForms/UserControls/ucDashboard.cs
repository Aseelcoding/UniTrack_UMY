using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucDashboard : UserControl
    {
        private readonly SettingsService _settingsService;
        private bool _isIndonesian;

        // This card uses the existing empty space in the Dashboard.
        

        public ucDashboard()
            : this(
                new List<Course>(),
                new List<TaskItem>(),
                new List<string>(),
                false,
                false)
        {
        }

        public ucDashboard(
            IEnumerable<Course> courses,
            IEnumerable<TaskItem> tasks,
            IEnumerable<string>? loadErrors,
            bool isLoading,
            bool hasLoaded)
        {
            InitializeComponent();

            _settingsService = new SettingsService();

           
            ApplyLanguage();

            PopulateDashboard(
                courses ?? Enumerable.Empty<Course>(),
                tasks ?? Enumerable.Empty<TaskItem>(),
                loadErrors ?? Enumerable.Empty<string>(),
                isLoading,
                hasLoaded);
        }

        

        private void PopulateDashboard(
            IEnumerable<Course> courses,
            IEnumerable<TaskItem> tasks,
            IEnumerable<string> loadErrors,
            bool isLoading,
            bool hasLoaded)
        {
            List<Course> courseList = courses
                .Where(c => c != null)
                .ToList();

            List<TaskItem> taskList = tasks
                .Where(t => t != null)
                .ToList();

            List<string> errors = loadErrors.ToList();

            lblCoursesCount.Text = courseList.Count.ToString(
                CultureInfo.CurrentCulture);

            // Average only real progress values supplied by MyKlass.
            List<Course> coursesWithProgress = courseList
                .Where(c => c.HasProgress)
                .ToList();

            if (coursesWithProgress.Count > 0)
            {
                double averageProgress = coursesWithProgress
                    .Average(c => c.ProgressPercent);

                lblStudyProgress.Text =
                    averageProgress.ToString(
                        "0.#",
                        CultureInfo.CurrentCulture) + "%";
            }
            else
            {
                lblStudyProgress.Text = "—";
            }

            if (isLoading)
            {
                lblTasksCount.Text = "…";
                lblUpcomingCount.Text = "…";
                lblOverdueCount.Text = "…";

                lstUpcomingTasks.Items.Clear();
                lstUpcomingTasks.Items.Add(
                    _isIndonesian
                        ? "Memuat tugas dari MyKlass..."
                        : "Loading tasks from MyKlass...");

                return;
            }

            if (!hasLoaded)
            {
                // Do not report zero when task loading has not happened.
                lblTasksCount.Text = "—";
                lblUpcomingCount.Text = "—";
                lblOverdueCount.Text = "—";

                lstUpcomingTasks.Items.Clear();
                lstUpcomingTasks.Items.Add(
                    _isIndonesian
                        ? "Data tugas belum dimuat."
                        : "Task data has not been loaded yet.");

                return;
            }

            lblTasksCount.Text = taskList.Count.ToString(
                CultureInfo.CurrentCulture);

            int overdueCount = taskList.Count(
                t => t.Status == TaskItem.TaskStatus.Overdue);

            lblOverdueCount.Text = overdueCount.ToString(
                CultureInfo.CurrentCulture);

            DateTime today = DateTime.Today;
            DateTime lastUpcomingDay = today.AddDays(7);

            List<TaskItem> upcomingTasks = taskList
                .Where(t =>
                    t.DueDate.HasValue &&
                    t.DueDate.Value.Date >= today &&
                    t.DueDate.Value.Date <= lastUpcomingDay &&
                    t.Status != TaskItem.TaskStatus.Completed &&
                    t.Status != TaskItem.TaskStatus.SubmittedLate &&
                    t.Status != TaskItem.TaskStatus.Overdue)
                .OrderBy(t => t.DueDate)
                .ToList();

            lblUpcomingCount.Text = upcomingTasks.Count.ToString(
                CultureInfo.CurrentCulture);

            Dictionary<string, string> courseNames = courseList
                .Where(c => !string.IsNullOrWhiteSpace(c.Id))
                .GroupBy(c => c.Id)
                .ToDictionary(g => g.Key, g => g.First().Name);

            lstUpcomingTasks.BeginUpdate();

            try
            {
                lstUpcomingTasks.Items.Clear();

                foreach (TaskItem task in upcomingTasks)
                {
                    string courseName =
                        courseNames.TryGetValue(
                            task.CourseId,
                            out string? name)
                            ? name
                            : string.Empty;

                    string dueDate = task.DueDate!.Value.ToString(
                        "ddd, dd MMM",
                        CultureInfo.CurrentCulture);

                    string line = string.IsNullOrWhiteSpace(courseName)
                        ? $"{dueDate} | {task.Title}"
                        : $"{dueDate} | {task.Title} — {courseName}";

                    lstUpcomingTasks.Items.Add(line);
                }

                if (upcomingTasks.Count == 0)
                {
                    lstUpcomingTasks.Items.Add(
                        errors.Count > 0
                            ? (_isIndonesian
                                ? "Tidak ada tugas mendatang yang terkonfirmasi; sebagian mata kuliah gagal dimuat."
                                : "No upcoming tasks could be confirmed; some courses failed to load.")
                            : (_isIndonesian
                                ? "Tidak ada tugas dalam 7 hari ke depan."
                                : "No tasks due in the next 7 days."));
                }

                if (errors.Count > 0 && upcomingTasks.Count > 0)
                {
                    lstUpcomingTasks.Items.Add(
                        _isIndonesian
                            ? $"Peringatan: {errors.Count} mata kuliah gagal dimuat."
                            : $"Warning: {errors.Count} course(s) failed to load.");
                }
            }
            finally
            {
                lstUpcomingTasks.EndUpdate();
            }
        }

        private void ApplyLanguage()
        {
            AppSettings settings = _settingsService.Load();
            _isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            lblDashboardTitle.Text = _isIndonesian
                ? "Dasbor"
                : "Dashboard";

            lblWelcome.Text = _isIndonesian
                ? "Selamat datang di UniTrack"
                : "Welcome to UniTrack";

            lblCoursesTitle.Text = _isIndonesian
                ? "Mata Kuliah Saya"
                : "My Courses";

            lblTasksTitle.Text = _isIndonesian
                ? "Tugas"
                : "Tasks";

            lblUpcomingTitle.Text = _isIndonesian
                ? "Mendatang (7 hari)"
                : "Upcoming (7 days)";

            lblProgressTitle.Text = _isIndonesian
                ? "Progres Belajar"
                : "Study Progress";

            lblUpcomingTasks.Text = _isIndonesian
                ? "Tugas Mendatang"
                : "Upcoming Tasks";

            lblOverdueTitle.Text = _isIndonesian
                ? "Terlambat"
                : "Overdue";
        }
    }
}
