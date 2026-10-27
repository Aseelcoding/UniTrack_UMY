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
            lblNotesPlannerTitle = new Label();
            lvNotes = new ListView();
            colTitle = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            txtNoteContent = new TextBox();
            txtNoteTitle = new TextBox();
            btnAddNote = new Button();
            btnDeleteNote = new Button();
            btnSaveNote = new Button();
            lblNotesPlannerDescription = new Label();
            SuspendLayout();
            // 
            // lblNotesPlannerTitle
            // 
            lblNotesPlannerTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotesPlannerTitle.Location = new Point(20, 20);
            lblNotesPlannerTitle.Name = "lblNotesPlannerTitle";
            lblNotesPlannerTitle.Size = new Size(450, 53);
            lblNotesPlannerTitle.TabIndex = 1;
            lblNotesPlannerTitle.Text = "Notes And Planner";
            // 
            // lvNotes
            // 
            lvNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lvNotes.Columns.AddRange(new ColumnHeader[] { colTitle, columnHeader2 });
            lvNotes.FullRowSelect = true;
            lvNotes.GridLines = true;
            lvNotes.Location = new Point(20, 116);
            lvNotes.MultiSelect = false;
            lvNotes.Name = "lvNotes";
            lvNotes.Size = new Size(350, 350);
            lvNotes.TabIndex = 2;
            lvNotes.UseCompatibleStateImageBehavior = false;
            lvNotes.View = View.Details;
            // 
            // colTitle
            // 
            colTitle.Text = "Title";
            colTitle.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Course";
            columnHeader2.Width = 130;
            // 
            // txtNoteContent
            // 
            txtNoteContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNoteContent.Font = new Font("Segoe UI", 10F);
            txtNoteContent.Location = new Point(400, 116);
            txtNoteContent.Multiline = true;
            txtNoteContent.Name = "txtNoteContent";
            txtNoteContent.ScrollBars = ScrollBars.Vertical;
            txtNoteContent.Size = new Size(300, 350);
            txtNoteContent.TabIndex = 3;
            // 
            // txtNoteTitle
            // 
            txtNoteTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtNoteTitle.Location = new Point(400, 481);
            txtNoteTitle.Name = "txtNoteTitle";
            txtNoteTitle.Size = new Size(300, 27);
            txtNoteTitle.TabIndex = 4;
            // 
            // btnAddNote
            // 
            btnAddNote.Cursor = Cursors.Hand;
            btnAddNote.Location = new Point(20, 496);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(150, 42);
            btnAddNote.TabIndex = 5;
            btnAddNote.Text = "Add Note";
            btnAddNote.UseVisualStyleBackColor = true;
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Cursor = Cursors.Hand;
            btnDeleteNote.Location = new Point(185, 496);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(150, 42);
            btnDeleteNote.TabIndex = 6;
            btnDeleteNote.Text = "Delete Note";
            btnDeleteNote.UseVisualStyleBackColor = true;
            // 
            // btnSaveNote
            // 
            btnSaveNote.Cursor = Cursors.Hand;
            btnSaveNote.Location = new Point(820, 455);
            btnSaveNote.Name = "btnSaveNote";
            btnSaveNote.Size = new Size(150, 42);
            btnSaveNote.TabIndex = 7;
            btnSaveNote.Text = "Save Note";
            btnSaveNote.UseVisualStyleBackColor = true;
            // 
            // lblNotesPlannerDescription
            // 
            lblNotesPlannerDescription.AutoSize = true;
            lblNotesPlannerDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblNotesPlannerDescription.Location = new Point(42, 73);
            lblNotesPlannerDescription.Name = "lblNotesPlannerDescription";
            lblNotesPlannerDescription.Size = new Size(249, 20);
            lblNotesPlannerDescription.TabIndex = 8;
            lblNotesPlannerDescription.Text = "Organize your notes and study plans";
            lblNotesPlannerDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucNotesPlanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(lblNotesPlannerDescription);
            Controls.Add(btnSaveNote);
            Controls.Add(btnDeleteNote);
            Controls.Add(btnAddNote);
            Controls.Add(txtNoteTitle);
            Controls.Add(txtNoteContent);
            Controls.Add(lvNotes);
            Controls.Add(lblNotesPlannerTitle);
            Name = "ucNotesPlanner";
            Size = new Size(742, 598);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNotesPlannerTitle;
        private ListView lvNotes;
        private ColumnHeader colTitle;
        private ColumnHeader columnHeader2;
        private TextBox txtNoteContent;
        private TextBox txtNoteTitle;
        private Button btnAddNote;
        private Button btnDeleteNote;
        private Button btnSaveNote;
        private Label lblNotesPlannerDescription;
    }
}
