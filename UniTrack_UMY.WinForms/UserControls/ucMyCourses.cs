
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucMyCourses : UserControl
    {
        private readonly SettingsService _settingsService;

        public ucMyCourses()
        {
            InitializeComponent();

            _settingsService = new SettingsService();
            ApplyLanguage();
        }
        private readonly List<Course> _courses = new List<Course>();

        public ucMyCourses(IEnumerable<Course> courses)
            : this()
        {
            if (courses != null)
            {
                _courses.AddRange(courses);
            }

            PopulateCourses();
            btnOpenCourse.Enabled = lvCourses.SelectedItems.Count > 0;
        }

        private void PopulateCourses()
        {
            AppSettings settings = _settingsService.Load();

            bool isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            string progressAvailable = isIndonesian
                ? "Progres tersedia"
                : "Progress available";

            string enrolled = isIndonesian
                ? "Terdaftar"
                : "Enrolled";

            string myKlass = "MyKlass";

            lvCourses.BeginUpdate();

            try
            {
                lvCourses.Items.Clear();

                foreach (Course course in _courses)
                {
                    string progress = course.HasProgress
                        ? course.ProgressPercent.ToString("0.#") + "%"
                        : "—";

                    string status = course.HasProgress
                        ? progressAvailable
                        : enrolled;

                    var item = new ListViewItem(course.Name);

                    item.SubItems.Add(progress);
                    item.SubItems.Add(status);
                    item.SubItems.Add(myKlass);

                    item.Tag = course;

                    lvCourses.Items.Add(item);
                }
            }
            finally
            {
                lvCourses.EndUpdate();
            }
        }

        private void ApplyLanguage()
        {
            AppSettings settings = _settingsService.Load();
            bool isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            lblCoursesTitle.Text = isIndonesian
                ? "Mata Kuliah Saya"
                : "My Courses";
            lblCoursesDescription.Text = isIndonesian
    ? "Lihat mata kuliah Anda dari MyKlass"
    : "View your courses from MyKlass";
            colCourseName.Text = isIndonesian
                ? "Nama Mata Kuliah"
                : "Course Name";

            colProgress.Text = isIndonesian
                ? "Progres"
                : "Progress";

            colStatus.Text = isIndonesian
                ? "Status"
                : "Status";

            colAction.Text = isIndonesian
                ? "Aksi"
                : "Action";

            btnOpenCourse.Text = isIndonesian
                ? "Buka Mata Kuliah"
                : "Open Course";
        }

        private void btnOpenCourse_Click(object sender, EventArgs e)
        {
            AppSettings settings = _settingsService.Load();
            bool isIndonesian =
                settings.Language == AppLanguage.Indonesian;

            if (lvCourses.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    isIndonesian
                        ? "Silakan pilih mata kuliah terlebih dahulu."
                        : "Please select a course first.",
                    isIndonesian ? "Mata Kuliah Saya" : "My Courses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (!(lvCourses.SelectedItems[0].Tag is Course course))
                return;

            if (!Uri.TryCreate(
                    course.Url,
                    UriKind.Absolute,
                    out Uri uri) ||
                uri.Scheme != Uri.UriSchemeHttps ||
                !string.Equals(
                    uri.Host,
                    "myklass-eng.umy.ac.id",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    isIndonesian
                        ? "URL mata kuliah tidak valid."
                        : "The course URL is invalid.",
                    isIndonesian ? "Mata Kuliah Saya" : "My Courses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = uri.AbsoluteUri,
                        UseShellExecute = true
                    });
            }
            catch (Exception)
            {
                MessageBox.Show(
                    isIndonesian
                        ? "Tidak dapat membuka mata kuliah di browser."
                        : "Could not open the course in your browser.",
                    isIndonesian ? "Mata Kuliah Saya" : "My Courses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpenCourse.Enabled = lvCourses.SelectedItems.Count > 0;
        }
    }
}
