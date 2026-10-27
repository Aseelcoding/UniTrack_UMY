
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucNotesPlanner : UserControl
    {
        private readonly SettingsService _settingsService;
        private readonly NotesService _notesService;
        private List<StudyNote> _notes = new List<StudyNote>();
        private string _selectedNoteId;
        private List<Course> _courses = new List<Course>();
        public ucNotesPlanner(List<Course> courses)
        {
            InitializeComponent();

            _settingsService = new SettingsService();
            _notesService = new NotesService();
            _courses = courses ?? new List<Course>();
            ConfigureListView();
            LoadCourses();
            ApplyLanguage();
            LoadNotes();
            ClearEditor();

            lvNotes.SelectedIndexChanged += lvNotes_SelectedIndexChanged;
            btnAddNote.Click += btnAddNote_Click;
            btnSaveNote.Click += btnSaveNote_Click;
            btnDeleteNote.Click += btnDeleteNote_Click;
         
        }

        private void ConfigureListView()
        {
            lvNotes.View = View.Details;
            lvNotes.FullRowSelect = true;
            lvNotes.MultiSelect = false;
            lvNotes.GridLines = true;
        }

        private void LoadCourses()
        {
            cmbNoteCourse.Items.Clear();
            cmbNoteCourse.Items.Add("General");

            foreach (Course course in _courses)
            {
                if (!string.IsNullOrWhiteSpace(course.Name))
                {
                    cmbNoteCourse.Items.Add(course.Name);
                }
            }

            cmbNoteCourse.SelectedIndex = 0;
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

            colTitle.Text = isIndonesian ? "Judul" : "Title";
            colCourse.Text = isIndonesian ? "Mata Kuliah" : "Course";

            colNoteContent.Text = isIndonesian
                ? "Isi Catatan"
                : "Note Content";

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

        private void LoadNotes()
        {
            _notes = _notesService.LoadNotes();
            RefreshNotesList();
        }

        private void RefreshNotesList()
        {
            lvNotes.BeginUpdate();
            lvNotes.Items.Clear();

            foreach (StudyNote note in _notes)
            {
                ListViewItem item = new ListViewItem(note.Title);
                item.SubItems.Add(note.CourseName);
                item.SubItems.Add(note.Content);
                item.Tag = note.Id;

                lvNotes.Items.Add(item);
            }

            lvNotes.EndUpdate();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoteTitle.Text))
            {
                MessageBox.Show(
                    "Please enter a note title.",
                    "Missing Title",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNoteTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNoteContent.Text))
            {
                MessageBox.Show(
                    "Please enter the note content.",
                    "Missing Content",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNoteContent.Focus();
                return;
            }

            string courseName = cmbNoteCourse.SelectedItem?.ToString()
                ?? "General";

            StudyNote note = new StudyNote
            {
                Id = Guid.NewGuid().ToString(),
                Title = txtNoteTitle.Text.Trim(),
                CourseName = courseName,
                CourseId = string.Empty,
                Content = txtNoteContent.Text.Trim(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _notes.Add(note);
            _notesService.SaveNotes(_notes);

            RefreshNotesList();
            ClearEditor();
        }

        private void lvNotes_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count == 0)
                return;

            string id = lvNotes.SelectedItems[0].Tag?.ToString();

            StudyNote note = _notes.FirstOrDefault(
                n => n.Id == id);

            if (note == null)
                return;

            _selectedNoteId = note.Id;
            txtNoteTitle.Text = note.Title;
            txtNoteContent.Text = note.Content;

            int courseIndex = cmbNoteCourse.Items.IndexOf(
                note.CourseName);

            if (courseIndex >= 0)
                cmbNoteCourse.SelectedIndex = courseIndex;
            else
                cmbNoteCourse.SelectedIndex = 0;
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedNoteId))
            {
                MessageBox.Show(
                    "Select a note from the list first.",
                    "No Note Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtNoteTitle.Text) ||
                string.IsNullOrWhiteSpace(txtNoteContent.Text))
            {
                MessageBox.Show(
                    "Title and note content are required.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            StudyNote note = _notes.FirstOrDefault(
                n => n.Id == _selectedNoteId);

            if (note == null)
                return;

            note.Title = txtNoteTitle.Text.Trim();
            note.Content = txtNoteContent.Text.Trim();
            note.CourseName =
                cmbNoteCourse.SelectedItem?.ToString() ?? "General";
            note.UpdatedAt = DateTime.Now;

            _notesService.SaveNotes(_notes);
            RefreshNotesList();
            ClearEditor();
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedNoteId))
            {
                MessageBox.Show(
                    "Select a note to delete.",
                    "No Note Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this note?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            StudyNote note = _notes.FirstOrDefault(
                n => n.Id == _selectedNoteId);

            if (note == null)
                return;

            _notes.Remove(note);
            _notesService.SaveNotes(_notes);

            RefreshNotesList();
            ClearEditor();
        }

        private void ClearEditor()
        {
            _selectedNoteId = null;

            txtNoteTitle.Clear();
            txtNoteContent.Clear();

            if (cmbNoteCourse.Items.Count > 0)
                cmbNoteCourse.SelectedIndex = 0;

            lvNotes.SelectedItems.Clear();
        }
    }
}
