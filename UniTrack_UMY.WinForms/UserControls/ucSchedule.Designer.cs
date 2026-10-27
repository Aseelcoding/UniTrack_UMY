namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucSchedule
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
            lblScheduleTitle = new Label();
            lvSchedule = new ListView();
            colDay = new ColumnHeader();
            colCourse = new ColumnHeader();
            colStartTime = new ColumnHeader();
            colEndTime = new ColumnHeader();
            colLocation = new ColumnHeader();
            btnAddSchedule = new Button();
            btnDeleteSchedule = new Button();
            lblScheduleDescription = new Label();
            SuspendLayout();
            // 
            // lblScheduleTitle
            // 
            lblScheduleTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScheduleTitle.Location = new Point(20, 20);
            lblScheduleTitle.Name = "lblScheduleTitle";
            lblScheduleTitle.Size = new Size(400, 52);
            lblScheduleTitle.TabIndex = 0;
            lblScheduleTitle.Text = "My Schedule";
            // 
            // lvSchedule
            // 
            lvSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvSchedule.Columns.AddRange(new ColumnHeader[] { colDay, colCourse, colStartTime, colEndTime, colLocation });
            lvSchedule.FullRowSelect = true;
            lvSchedule.GridLines = true;
            lvSchedule.Location = new Point(20, 103);
            lvSchedule.MultiSelect = false;
            lvSchedule.Name = "lvSchedule";
            lvSchedule.Size = new Size(680, 350);
            lvSchedule.TabIndex = 1;
            lvSchedule.UseCompatibleStateImageBehavior = false;
            lvSchedule.View = View.Details;
            // 
            // colDay
            // 
            colDay.Text = "Day";
            colDay.Width = 120;
            // 
            // colCourse
            // 
            colCourse.Text = "Course";
            colCourse.Width = 250;
            // 
            // colStartTime
            // 
            colStartTime.Text = "Start Time";
            colStartTime.Width = 150;
            // 
            // colEndTime
            // 
            colEndTime.Text = "End Time";
            colEndTime.Width = 150;
            // 
            // colLocation
            // 
            colLocation.Text = "Location";
            colLocation.Width = 200;
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.Cursor = Cursors.Hand;
            btnAddSchedule.Location = new Point(20, 483);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(150, 42);
            btnAddSchedule.TabIndex = 2;
            btnAddSchedule.Text = "Add Schedule";
            btnAddSchedule.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSchedule
            // 
            btnDeleteSchedule.Cursor = Cursors.Hand;
            btnDeleteSchedule.Location = new Point(202, 483);
            btnDeleteSchedule.Name = "btnDeleteSchedule";
            btnDeleteSchedule.Size = new Size(150, 42);
            btnDeleteSchedule.TabIndex = 3;
            btnDeleteSchedule.Text = "Delete Schedule";
            btnDeleteSchedule.UseVisualStyleBackColor = true;
            // 
            // lblScheduleDescription
            // 
            lblScheduleDescription.AutoSize = true;
            lblScheduleDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblScheduleDescription.Location = new Point(38, 72);
            lblScheduleDescription.Name = "lblScheduleDescription";
            lblScheduleDescription.Size = new Size(244, 20);
            lblScheduleDescription.TabIndex = 9;
            lblScheduleDescription.Text = "Keep your class schedule organized";
            lblScheduleDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(lblScheduleDescription);
            Controls.Add(btnDeleteSchedule);
            Controls.Add(btnAddSchedule);
            Controls.Add(lvSchedule);
            Controls.Add(lblScheduleTitle);
            Name = "ucSchedule";
            Size = new Size(742, 598);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblScheduleTitle;
        private ListView lvSchedule;
        private ColumnHeader colDay;
        private ColumnHeader colCourse;
        private ColumnHeader colStartTime;
        private ColumnHeader colEndTime;
        private ColumnHeader colLocation;
        private Button btnAddSchedule;
        private Button btnDeleteSchedule;
        private Label lblScheduleDescription;
    }
}
