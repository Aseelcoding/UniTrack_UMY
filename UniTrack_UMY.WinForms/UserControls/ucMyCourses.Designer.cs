using System.Reflection.PortableExecutable;

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
            pnlHeader = new Panel();
            lblCoursesTitle = new Label();
            lblCoursesDescription = new Label();
            pnlFooter = new Panel();
            btnOpenCourse = new Button();
            pnlListCard = new Panel();
            lvCourses = new ListView();
            colCourseName = new ColumnHeader();
            colProgress = new ColumnHeader();
            colStatus = new ColumnHeader();
            colAction = new ColumnHeader();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlListCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblCoursesTitle);
            pnlHeader.Controls.Add(lblCoursesDescription);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 0, 0, 14);
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblCoursesTitle
            // 
            lblCoursesTitle.Dock = DockStyle.Fill;
            lblCoursesTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblCoursesTitle.Location = new Point(0, 0);
            lblCoursesTitle.Name = "lblCoursesTitle";
            lblCoursesTitle.Size = new Size(1100, 58);
            lblCoursesTitle.TabIndex = 0;
            lblCoursesTitle.Text = "My Courses";
            lblCoursesTitle.TextAlign = ContentAlignment.BottomLeft;
            lblCoursesTitle.SizeChanged += lblCoursesTitle_SizeChanged;
            // 
            // lblCoursesDescription
            // 
            lblCoursesDescription.Dock = DockStyle.Bottom;
            lblCoursesDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblCoursesDescription.Location = new Point(0, 58);
            lblCoursesDescription.Name = "lblCoursesDescription";
            lblCoursesDescription.Size = new Size(1100, 28);
            lblCoursesDescription.TabIndex = 1;
            lblCoursesDescription.Tag = "muted";
            lblCoursesDescription.Text = "View your courses from MyKlass";
            lblCoursesDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnOpenCourse);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 686);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(0, 16, 0, 0);
            pnlFooter.Size = new Size(1100, 64);
            pnlFooter.TabIndex = 2;
            // 
            // btnOpenCourse
            // 
            btnOpenCourse.BackColor = Color.FromArgb(55, 110, 190);
            btnOpenCourse.Cursor = Cursors.Hand;
            btnOpenCourse.Dock = DockStyle.Left;
            btnOpenCourse.FlatAppearance.BorderSize = 0;
            btnOpenCourse.FlatStyle = FlatStyle.Flat;
            btnOpenCourse.Font = new Font("Segoe UI Semibold", 10.5F);
            btnOpenCourse.ForeColor = Color.White;
            btnOpenCourse.Location = new Point(0, 16);
            btnOpenCourse.Name = "btnOpenCourse";
            btnOpenCourse.Size = new Size(170, 48);
            btnOpenCourse.TabIndex = 0;
            btnOpenCourse.Tag = "primary";
            btnOpenCourse.Text = "Open Course";
            btnOpenCourse.UseVisualStyleBackColor = false;
            btnOpenCourse.Click += btnOpenCourse_Click;
            // 
            // pnlListCard
            // 
            pnlListCard.BackColor = Color.White;
            pnlListCard.Controls.Add(lvCourses);
            pnlListCard.Dock = DockStyle.Fill;
            pnlListCard.Location = new Point(0, 100);
            pnlListCard.Name = "pnlListCard";
            pnlListCard.Padding = new Padding(12);
            pnlListCard.Size = new Size(1100, 586);
            pnlListCard.TabIndex = 1;
            // 
            // lvCourses
            // 
            lvCourses.BackColor = Color.White;
            lvCourses.BorderStyle = BorderStyle.None;
            lvCourses.Columns.AddRange(new ColumnHeader[] { colCourseName, colProgress, colStatus, colAction });
            lvCourses.Dock = DockStyle.Fill;
            lvCourses.Font = new Font("Segoe UI", 10.5F);
            lvCourses.FullRowSelect = true;
            lvCourses.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvCourses.Location = new Point(12, 12);
            lvCourses.MultiSelect = false;
            lvCourses.Name = "lvCourses";
            lvCourses.Size = new Size(1076, 562);
            lvCourses.TabIndex = 0;
            lvCourses.UseCompatibleStateImageBehavior = false;
            lvCourses.View = View.Details;
            lvCourses.SelectedIndexChanged += lvCourses_SelectedIndexChanged;
           
            // 
            // colCourseName
            // 
            colCourseName.Text = "Course Name";
            colCourseName.Width = 430;
            // 
            // colProgress
            // 
            colProgress.Text = "Progress";
            colProgress.Width = 160;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            colStatus.Width = 140;
            // 
            // colAction
            // 
            colAction.Text = "Action";
            colAction.Width = 180;
            // 
            // ucMyCourses
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlListCard);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            Name = "ucMyCourses";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlListCard.ResumeLayout(false);
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
        private Label lblCoursesDescription;

        private Panel pnlHeader;
        private Panel pnlFooter;
        private Panel pnlListCard;
        
    }
}
