using System.Reflection.PortableExecutable;

namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucNotesPlanner
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblNotesPlannerTitle = new Label();
            lblNotesPlannerDescription = new Label();
            tlpMain = new TableLayoutPanel();
            pnlListCard = new Panel();
            lvNotes = new ListView();
            colTitle = new ColumnHeader();
            colCourse = new ColumnHeader();
            colNoteContent = new ColumnHeader();
            pnlListFooter = new Panel();
            btnAddNote = new Button();
            btnDeleteNote = new Button();
            pnlEditorCard = new Panel();
            tlpEditor = new TableLayoutPanel();
            label1 = new Label();
            cmbNoteCourse = new ComboBox();
            txtNoteTitle = new TextBox();
            txtNoteContent = new TextBox();
            pnlEditorFooter = new Panel();
            btnSaveNote = new Button();
            pnlHeader.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlListCard.SuspendLayout();
            pnlListFooter.SuspendLayout();
            pnlEditorCard.SuspendLayout();
            tlpEditor.SuspendLayout();
            pnlEditorFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblNotesPlannerTitle);
            pnlHeader.Controls.Add(lblNotesPlannerDescription);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 0, 0, 14);
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblNotesPlannerTitle
            // 
            lblNotesPlannerTitle.Dock = DockStyle.Fill;
            lblNotesPlannerTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblNotesPlannerTitle.Location = new Point(0, 0);
            lblNotesPlannerTitle.Name = "lblNotesPlannerTitle";
            lblNotesPlannerTitle.Size = new Size(1100, 58);
            lblNotesPlannerTitle.TabIndex = 0;
            lblNotesPlannerTitle.Text = "Notes And Planner";
            lblNotesPlannerTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblNotesPlannerDescription
            // 
            lblNotesPlannerDescription.Dock = DockStyle.Bottom;
            lblNotesPlannerDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblNotesPlannerDescription.Location = new Point(0, 58);
            lblNotesPlannerDescription.Name = "lblNotesPlannerDescription";
            lblNotesPlannerDescription.Size = new Size(1100, 28);
            lblNotesPlannerDescription.TabIndex = 1;
            lblNotesPlannerDescription.Tag = "muted";
            lblNotesPlannerDescription.Text = "Organize your notes and study plans";
            lblNotesPlannerDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tlpMain.Controls.Add(pnlListCard, 0, 0);
            tlpMain.Controls.Add(pnlEditorCard, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 100);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1100, 650);
            tlpMain.TabIndex = 1;
            // 
            // pnlListCard
            // 
            pnlListCard.BackColor = Color.White;
            pnlListCard.Controls.Add(lvNotes);
            pnlListCard.Controls.Add(pnlListFooter);
            pnlListCard.Dock = DockStyle.Fill;
            pnlListCard.Location = new Point(0, 0);
            pnlListCard.Margin = new Padding(0, 0, 16, 0);
            pnlListCard.Name = "pnlListCard";
            pnlListCard.Padding = new Padding(12);
            pnlListCard.Size = new Size(622, 650);
            pnlListCard.TabIndex = 0;
            // 
            // lvNotes
            // 
            lvNotes.BackColor = Color.White;
            lvNotes.BorderStyle = BorderStyle.None;
            lvNotes.Columns.AddRange(new ColumnHeader[] { colTitle, colCourse, colNoteContent });
            lvNotes.Dock = DockStyle.Fill;
            lvNotes.Font = new Font("Segoe UI", 10.5F);
            lvNotes.FullRowSelect = true;
            lvNotes.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvNotes.Location = new Point(12, 12);
            lvNotes.MultiSelect = false;
            lvNotes.Name = "lvNotes";
            lvNotes.Size = new Size(598, 564);
            lvNotes.TabIndex = 0;
            lvNotes.UseCompatibleStateImageBehavior = false;
            lvNotes.View = View.Details;
            lvNotes.SizeChanged += lvNotes_SizeChanged;
            // 
            // colTitle
            // 
            colTitle.Text = "Title";
            colTitle.Width = 170;
            // 
            // colCourse
            // 
            colCourse.Text = "Course";
            colCourse.Width = 170;
            // 
            // colNoteContent
            // 
            colNoteContent.Text = "Note Content";
            colNoteContent.Width = 300;
            // 
            // pnlListFooter
            // 
            pnlListFooter.Controls.Add(btnAddNote);
            pnlListFooter.Controls.Add(btnDeleteNote);
            pnlListFooter.Dock = DockStyle.Bottom;
            pnlListFooter.Location = new Point(12, 576);
            pnlListFooter.Name = "pnlListFooter";
            pnlListFooter.Size = new Size(598, 62);
            pnlListFooter.TabIndex = 1;
            pnlListFooter.Tag = "card";
            // 
            // btnAddNote
            // 
            btnAddNote.BackColor = Color.FromArgb(55, 110, 190);
            btnAddNote.Cursor = Cursors.Hand;
            btnAddNote.FlatAppearance.BorderSize = 0;
            btnAddNote.FlatStyle = FlatStyle.Flat;
            btnAddNote.Font = new Font("Segoe UI Semibold", 10.5F);
            btnAddNote.ForeColor = Color.White;
            btnAddNote.Location = new Point(0, 14);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(160, 44);
            btnAddNote.TabIndex = 0;
            btnAddNote.Tag = "primary";
            btnAddNote.Text = "Add Note";
            btnAddNote.UseVisualStyleBackColor = false;
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteNote.Cursor = Cursors.Hand;
            btnDeleteNote.FlatAppearance.BorderSize = 0;
            btnDeleteNote.FlatStyle = FlatStyle.Flat;
            btnDeleteNote.Font = new Font("Segoe UI Semibold", 10.5F);
            btnDeleteNote.ForeColor = Color.White;
            btnDeleteNote.Location = new Point(172, 14);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(160, 44);
            btnDeleteNote.TabIndex = 1;
            btnDeleteNote.Tag = "danger";
            btnDeleteNote.Text = "Delete Note";
            btnDeleteNote.UseVisualStyleBackColor = false;
            // 
            // pnlEditorCard
            // 
            pnlEditorCard.BackColor = Color.White;
            pnlEditorCard.Controls.Add(tlpEditor);
            pnlEditorCard.Dock = DockStyle.Fill;
            pnlEditorCard.Location = new Point(638, 0);
            pnlEditorCard.Margin = new Padding(0);
            pnlEditorCard.Name = "pnlEditorCard";
            pnlEditorCard.Padding = new Padding(20);
            pnlEditorCard.Size = new Size(462, 650);
            pnlEditorCard.TabIndex = 1;
            // 
            // tlpEditor
            // 
            tlpEditor.ColumnCount = 1;
            tlpEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpEditor.Controls.Add(label1, 0, 0);
            tlpEditor.Controls.Add(cmbNoteCourse, 0, 1);
            tlpEditor.Controls.Add(txtNoteTitle, 0, 2);
            tlpEditor.Controls.Add(txtNoteContent, 0, 3);
            tlpEditor.Controls.Add(pnlEditorFooter, 0, 4);
            tlpEditor.Dock = DockStyle.Fill;
            tlpEditor.Location = new Point(20, 20);
            tlpEditor.Name = "tlpEditor";
            tlpEditor.RowCount = 5;
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tlpEditor.Size = new Size(422, 610);
            tlpEditor.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.ForeColor = Color.FromArgb(110, 120, 135);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0, 0, 0, 6);
            label1.Name = "label1";
            label1.Size = new Size(422, 23);
            label1.TabIndex = 0;
            label1.Tag = "muted";
            label1.Text = "Choose Course";
            // 
            // cmbNoteCourse
            // 
            cmbNoteCourse.Dock = DockStyle.Fill;
            cmbNoteCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNoteCourse.FormattingEnabled = true;
            cmbNoteCourse.Location = new Point(0, 29);
            cmbNoteCourse.Margin = new Padding(0, 0, 0, 14);
            cmbNoteCourse.Name = "cmbNoteCourse";
            cmbNoteCourse.Size = new Size(422, 31);
            cmbNoteCourse.TabIndex = 1;
            // 
            // txtNoteTitle
            // 
            txtNoteTitle.Dock = DockStyle.Fill;
            txtNoteTitle.Font = new Font("Segoe UI Semibold", 11F);
            txtNoteTitle.Location = new Point(0, 71);
            txtNoteTitle.Margin = new Padding(0, 0, 0, 14);
            txtNoteTitle.Name = "txtNoteTitle";
            txtNoteTitle.Size = new Size(422, 32);
            txtNoteTitle.TabIndex = 2;
            // 
            // txtNoteContent
            // 
            txtNoteContent.Dock = DockStyle.Fill;
            txtNoteContent.Font = new Font("Segoe UI", 10.5F);
            txtNoteContent.Location = new Point(0, 117);
            txtNoteContent.Margin = new Padding(0);
            txtNoteContent.Multiline = true;
            txtNoteContent.Name = "txtNoteContent";
            txtNoteContent.ScrollBars = ScrollBars.Vertical;
            txtNoteContent.Size = new Size(422, 431);
            txtNoteContent.TabIndex = 3;
            // 
            // pnlEditorFooter
            // 
            pnlEditorFooter.Controls.Add(btnSaveNote);
            pnlEditorFooter.Dock = DockStyle.Fill;
            pnlEditorFooter.Location = new Point(0, 548);
            pnlEditorFooter.Margin = new Padding(0);
            pnlEditorFooter.Name = "pnlEditorFooter";
            pnlEditorFooter.Padding = new Padding(0, 14, 0, 0);
            pnlEditorFooter.Size = new Size(422, 62);
            pnlEditorFooter.TabIndex = 4;
            pnlEditorFooter.Tag = "card";
            // 
            // btnSaveNote
            // 
            btnSaveNote.BackColor = Color.FromArgb(55, 110, 190);
            btnSaveNote.Cursor = Cursors.Hand;
            btnSaveNote.Dock = DockStyle.Right;
            btnSaveNote.FlatAppearance.BorderSize = 0;
            btnSaveNote.FlatStyle = FlatStyle.Flat;
            btnSaveNote.Font = new Font("Segoe UI Semibold", 10.5F);
            btnSaveNote.ForeColor = Color.White;
            btnSaveNote.Location = new Point(262, 14);
            btnSaveNote.Name = "btnSaveNote";
            btnSaveNote.Size = new Size(160, 48);
            btnSaveNote.TabIndex = 0;
            btnSaveNote.Tag = "primary";
            btnSaveNote.Text = "Save Note";
            btnSaveNote.UseVisualStyleBackColor = false;
            // 
            // ucNotesPlanner
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(tlpMain);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            Name = "ucNotesPlanner";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            tlpMain.ResumeLayout(false);
            pnlListCard.ResumeLayout(false);
            pnlListFooter.ResumeLayout(false);
            pnlEditorCard.ResumeLayout(false);
            tlpEditor.ResumeLayout(false);
            tlpEditor.PerformLayout();
            pnlEditorFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlHeader;
        private TableLayoutPanel tlpMain;
        private Panel pnlListCard;
        private Panel pnlListFooter;
        private Panel pnlEditorCard;
        private TableLayoutPanel tlpEditor;
        private Panel pnlEditorFooter;

        private Label lblNotesPlannerTitle;
        private ListView lvNotes;
        private ColumnHeader colTitle;
        private ColumnHeader colCourse;
        private TextBox txtNoteContent;
        private TextBox txtNoteTitle;
        private Button btnAddNote;
        private Button btnDeleteNote;
        private Button btnSaveNote;
        private Label lblNotesPlannerDescription;
        private ComboBox cmbNoteCourse;
        private ColumnHeader colNoteContent;
        private Label label1;
    }
}
