
using System.Collections.Generic;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.WinForms.Services
{
    public class LocalizationManager
    {
        private readonly Dictionary<string, string> _english =
            new Dictionary<string, string>
            {
                { "Dashboard", "Dashboard" },
                { "MyCourses", "My Courses" },
                { "Tasks", "Tasks" },
                { "Schedule", "Schedule" },
                { "NotesPlanner", "Notes & Planner" },
                { "Settings", "Settings" },
                { "Welcome", "Welcome to UniTrack" },
                { "UpcomingTasks", "Upcoming Tasks" },

                { "SettingsDescription", "Customize your preferences" },
                { "MyCoursesDescription", "View your courses from MyKlass" },
                { "TasksDescription", "View your tasks from MyKlass" },
                { "ScheduleDescription", "View your schedule" },
                { "NotesPlannerDescription", "Manage your notes and study plans" }
            };

        private readonly Dictionary<string, string> _indonesian =
            new Dictionary<string, string>
            {
                { "Dashboard", "Dasbor" },
                { "MyCourses", "Mata Kuliah Saya" },
                { "Tasks", "Tugas" },
                { "Schedule", "Jadwal" },
                { "NotesPlanner", "Catatan & Perencana" },
                { "Settings", "Pengaturan" },
                { "Welcome", "Selamat datang di UniTrack" },
                { "UpcomingTasks", "Tugas Mendatang" },

                { "SettingsDescription", "Sesuaikan preferensi Anda" },
                { "MyCoursesDescription", "Lihat mata kuliah Anda dari MyKlass" },
                { "TasksDescription", "Lihat tugas Anda dari MyKlass" },
                { "ScheduleDescription", "Lihat jadwal Anda" },
                { "NotesPlannerDescription", "Kelola catatan dan rencana belajar Anda" }
            };

        private readonly AppLanguage _language;

        public LocalizationManager(AppLanguage language)
        {
            _language = language;
        }

        public string GetText(string key)
        {
            Dictionary<string, string> translations =
                _language == AppLanguage.Indonesian
                    ? _indonesian
                    : _english;

            return translations.TryGetValue(key, out string text)
                ? text
                : key;
        }
    }
}
