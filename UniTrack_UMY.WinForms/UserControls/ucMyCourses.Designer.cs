namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucMyCourses
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
            lblCoursesTitle = new Label();
            lvCourses = new ListView();
            colCourseName = new ColumnHeader();
            colProgress = new ColumnHeader();
            colStatus = new ColumnHeader();
            colAction = new ColumnHeader();
            btnOpenCourse = new Button();
            SuspendLayout();
            // 
            // lblCoursesTitle
            // 
            lblCoursesTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoursesTitle.Location = new Point(20, 20);
            lblCoursesTitle.Name = "lblCoursesTitle";
            lblCoursesTitle.Size = new Size(400, 50);
            lblCoursesTitle.TabIndex = 0;
            lblCoursesTitle.Text = "My Courses";
            // 
            // lvCourses
            // 
            lvCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvCourses.Columns.AddRange(new ColumnHeader[] { colCourseName, colProgress, colStatus, colAction });
            lvCourses.FullRowSelect = true;
            lvCourses.GridLines = true;
            lvCourses.Location = new Point(20, 90);
            lvCourses.MultiSelect = false;
            lvCourses.Name = "lvCourses";
            lvCourses.Size = new Size(700, 370);
            lvCourses.TabIndex = 1;
            lvCourses.UseCompatibleStateImageBehavior = false;
            lvCourses.View = View.Details;
            // 
            // colCourseName
            // 
            colCourseName.Text = "Course Name";
            colCourseName.Width = 250;
            // 
            // colProgress
            // 
            colProgress.Text = "Progress";
            colProgress.Width = 100;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            colStatus.Width = 100;
            // 
            // colAction
            // 
            colAction.Text = "Action";
            colAction.Width = 200;
            // 
            // btnOpenCourse
            // 
            btnOpenCourse.Cursor = Cursors.Hand;
            btnOpenCourse.Location = new Point(20, 490);
            btnOpenCourse.Name = "btnOpenCourse";
            btnOpenCourse.Size = new Size(150, 42);
            btnOpenCourse.TabIndex = 2;
            btnOpenCourse.Text = "Open Course";
            btnOpenCourse.UseVisualStyleBackColor = true;
            // 
            // ucMyCourses
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(btnOpenCourse);
            Controls.Add(lvCourses);
            Controls.Add(lblCoursesTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "ucMyCourses";
            Size = new Size(742, 598);
            ResumeLayout(false);
        }

        #endregion

        private Label lblCoursesTitle;
        private ListView lvCourses;
        private ColumnHeader colCourseName;
        private ColumnHeader colProgress;
        private ColumnHeader colStatus;
        private ColumnHeader colAction;
        private Button btnOpenCourse;
    }
}
