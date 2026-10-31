
using System;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Forms;
using UniTrack_UMY.WinForms.Services;
using System.Collections.Generic;
namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucSchedule : UserControl
    {
        private readonly SettingsService _settingsService;
        private readonly ScheduleService _scheduleService;
        private readonly List<Course> _courses;
        private ucScheduleClass _selectedClass;
        public ucSchedule() : this(new List<Course>())
        {
        }

        public ucSchedule(List<Course> courses)
        {
            InitializeComponent();

            _courses = courses ?? new List<Course>();

            _settingsService = new SettingsService();
            _scheduleService = new ScheduleService();

            InitializeDays();
            LoadSchedule();

            ucSunday.ClassSelected += OnClassSelected;
            ucMonday.ClassSelected += OnClassSelected;
            ucTuesday.ClassSelected += OnClassSelected;
            ucWednesday.ClassSelected += OnClassSelected;
            ucThursday.ClassSelected += OnClassSelected;
            ucFriday.ClassSelected += OnClassSelected;
            ucSaturday.ClassSelected += OnClassSelected;
        }
        private void OnClassSelected(ucScheduleClass selected)
        {
            if (_selectedClass != null)
                _selectedClass.SetSelected(false);

            _selectedClass = selected;
            _selectedClass.SetSelected(true);
        }
        private void InitializeDays()
        {
            ucSunday.DayName = "Sunday";
            ucMonday.DayName = "Monday";
            ucTuesday.DayName = "Tuesday";
            ucWednesday.DayName = "Wednesday";
            ucThursday.DayName = "Thursday";
            ucFriday.DayName = "Friday";
            ucSaturday.DayName = "Saturday";
        }
        private void LoadSchedule()
        {
            _selectedClass = null;
            var schedule = _scheduleService.Load();

            ucSunday.LoadClasses(schedule);
            ucMonday.LoadClasses(schedule);
            ucTuesday.LoadClasses(schedule);
            ucWednesday.LoadClasses(schedule);
            ucThursday.LoadClasses(schedule);
            ucFriday.LoadClasses(schedule);
            ucSaturday.LoadClasses(schedule);
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            using (frmAddSchedule form = new frmAddSchedule(_courses))
            {
               
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ScheduleItem newSchedule = form.Schedule;

                    var schedule = _scheduleService.Load();

                    schedule.Add(newSchedule);

                    _scheduleService.Save(schedule);

                    LoadSchedule();
                }
            }

        }
        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (_selectedClass == null)
            {
                MessageBox.Show("Please select a class first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this class?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            var schedule = _scheduleService.Load();

            schedule.RemoveAll(item => item.Id == _selectedClass.Schedule.Id);

            _scheduleService.Save(schedule);

            _selectedClass = null;

            LoadSchedule();
        }
    }
}
