using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Services;

namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmAddSchedule : Form
    {
        private readonly SettingsService _settingsService;
        private readonly List<Course> _courses;
        public frmAddSchedule() : this(new List<Course>())
        {
        }

        public frmAddSchedule(List<Course> courses)
        {
            InitializeComponent();

            _courses = courses ?? new List<Course>();

            _settingsService = new SettingsService();
            ApplySettings();

            LoadCourses();
        }
        private void LoadCourses()
        {
            cmbCourseName.DataSource = _courses;
            cmbCourseName.DisplayMember = "Name";
            cmbCourseName.DropDownStyle = ComboBoxStyle.DropDown;
        }
        public ScheduleItem Schedule { get; private set; }
        private void ApplySettings()
        {
            AppSettings settings = _settingsService.Load();

            ThemeColors colors = new ThemeColors(settings.Theme);

            ThemeManager themeManager = new ThemeManager(colors);

            themeManager.ApplyTheme(this);
        }

        private void LoadDays()
        {
            cmbDay.Items.AddRange(new object[]
            {
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday"
            });

            cmbDay.SelectedIndex = 0;
        }

        private void frmAddSchedule_Load(object sender, EventArgs e)
        {
            LoadDays();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCourseName.Text))
            {
                MessageBox.Show("Please enter the course name.");
                cmbCourseName.Focus();
                return;
            }

            if (dtpEndTime.Value.TimeOfDay <=
                dtpStartTime.Value.TimeOfDay)
            {
                MessageBox.Show("End time must be after start time.");
                return;
            }

            Schedule = new ScheduleItem
            {
                Id = Guid.NewGuid().ToString(),
                Day = cmbDay.SelectedItem.ToString(),
                CourseName = cmbCourseName.Text.Trim(),
                StartTime = dtpStartTime.Value.ToString("HH:mm"),
                EndTime = dtpEndTime.Value.ToString("HH:mm"),
                Location = txtLocation.Text.Trim()
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
