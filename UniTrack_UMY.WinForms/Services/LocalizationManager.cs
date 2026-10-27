
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
                { "UpcomingTasks", "Upcoming Tasks" }
            };

        private readonly Dictionary<string, string> _indonesian =
            new Dictionary<string, string>
            {
                { "Dashboard", "Dasbor" },
                { "MyCourses", "Kursus saya" },
                { "Tasks", "Tugas" },
                { "Schedule", "Jadwal" },
                { "NotesPlanner", "Catatan & Perencana" },
                { "Settings", "Pengaturan" },
                { "Welcome", "Welcome to UniTrack" },
                { "UpcomingTasks", "Tugas Mendatang" }
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
