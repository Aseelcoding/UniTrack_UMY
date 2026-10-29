namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucDashboard
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
            pnlUpcomingTasks = new Panel();
            lstUpcomingTasks = new ListBox();
            lblUpcomingTasks = new Label();
            pnlProgressCard = new Panel();
            lblStudyProgress = new Label();
            lblProgressTitle = new Label();
            pnlUpcomingCard = new Panel();
            lblUpcomingCount = new Label();
            lblUpcomingTitle = new Label();
            pnlTasksCard = new Panel();
            lblTasksCount = new Label();
            lblTasksTitle = new Label();
            pnlCoursesCard = new Panel();
            lblCoursesCount = new Label();
            lblCoursesTitle = new Label();
            lblDashboardTitle = new Label();
            lblWelcome = new Label();
            pnlUpcomingTasks.SuspendLayout();
            pnlProgressCard.SuspendLayout();
            pnlUpcomingCard.SuspendLayout();
            pnlTasksCard.SuspendLayout();
            pnlCoursesCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUpcomingTasks
            // 
            pnlUpcomingTasks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlUpcomingTasks.BackColor = Color.White;
            pnlUpcomingTasks.BorderStyle = BorderStyle.FixedSingle;
            pnlUpcomingTasks.Controls.Add(lstUpcomingTasks);
            pnlUpcomingTasks.Controls.Add(lblUpcomingTasks);
            pnlUpcomingTasks.Location = new Point(13, 316);
            pnlUpcomingTasks.Name = "pnlUpcomingTasks";
            pnlUpcomingTasks.Size = new Size(1084, 431);
            pnlUpcomingTasks.TabIndex = 11;
            // 
            // lstUpcomingTasks
            // 
            lstUpcomingTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstUpcomingTasks.BorderStyle = BorderStyle.None;
            lstUpcomingTasks.ForeColor = Color.FromArgb(60, 70, 85);
            lstUpcomingTasks.FormattingEnabled = true;
            lstUpcomingTasks.IntegralHeight = false;
            lstUpcomingTasks.Location = new Point(-1, 52);
            lstUpcomingTasks.Name = "lstUpcomingTasks";
            lstUpcomingTasks.Size = new Size(1081, 378);
            lstUpcomingTasks.TabIndex = 9;
            // 
            // lblUpcomingTasks
            // 
            lblUpcomingTasks.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUpcomingTasks.ForeColor = Color.FromArgb(32, 43, 60);
            lblUpcomingTasks.Location = new Point(3, 14);
            lblUpcomingTasks.Name = "lblUpcomingTasks";
            lblUpcomingTasks.Size = new Size(400, 35);
            lblUpcomingTasks.TabIndex = 8;
            lblUpcomingTasks.Text = "Upcoming Tasks";
            lblUpcomingTasks.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlProgressCard
            // 
            pnlProgressCard.BackColor = Color.White;
            pnlProgressCard.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressCard.Controls.Add(lblStudyProgress);
            pnlProgressCard.Controls.Add(lblProgressTitle);
            pnlProgressCard.Location = new Point(832, 115);
            pnlProgressCard.Name = "pnlProgressCard";
            pnlProgressCard.Size = new Size(200, 120);
            pnlProgressCard.TabIndex = 10;
            // 
            // lblStudyProgress
            // 
            lblStudyProgress.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudyProgress.ForeColor = Color.FromArgb(32, 43, 60);
            lblStudyProgress.Location = new Point(3, 40);
            lblStudyProgress.Name = "lblStudyProgress";
            lblStudyProgress.Size = new Size(170, 40);
            lblStudyProgress.TabIndex = 10;
            lblStudyProgress.Text = "0";
            lblStudyProgress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProgressTitle
            // 
            lblProgressTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblProgressTitle.Location = new Point(3, 10);
            lblProgressTitle.Name = "lblProgressTitle";
            lblProgressTitle.Size = new Size(170, 25);
            lblProgressTitle.TabIndex = 9;
            lblProgressTitle.Text = "\tStudy Progress";
            // 
            // pnlUpcomingCard
            // 
            pnlUpcomingCard.BackColor = Color.White;
            pnlUpcomingCard.BorderStyle = BorderStyle.FixedSingle;
            pnlUpcomingCard.Controls.Add(lblUpcomingCount);
            pnlUpcomingCard.Controls.Add(lblUpcomingTitle);
            pnlUpcomingCard.Location = new Point(571, 115);
            pnlUpcomingCard.Name = "pnlUpcomingCard";
            pnlUpcomingCard.Size = new Size(200, 120);
            pnlUpcomingCard.TabIndex = 9;
            // 
            // lblUpcomingCount
            // 
            lblUpcomingCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUpcomingCount.ForeColor = Color.FromArgb(32, 43, 60);
            lblUpcomingCount.Location = new Point(3, 40);
            lblUpcomingCount.Name = "lblUpcomingCount";
            lblUpcomingCount.Size = new Size(170, 40);
            lblUpcomingCount.TabIndex = 9;
            lblUpcomingCount.Text = "0";
            lblUpcomingCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUpcomingTitle
            // 
            lblUpcomingTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblUpcomingTitle.Location = new Point(3, 10);
            lblUpcomingTitle.Name = "lblUpcomingTitle";
            lblUpcomingTitle.Size = new Size(170, 25);
            lblUpcomingTitle.TabIndex = 8;
            lblUpcomingTitle.Text = "Upcoming";
            // 
            // pnlTasksCard
            // 
            pnlTasksCard.BackColor = Color.White;
            pnlTasksCard.BorderStyle = BorderStyle.FixedSingle;
            pnlTasksCard.Controls.Add(lblTasksCount);
            pnlTasksCard.Controls.Add(lblTasksTitle);
            pnlTasksCard.Location = new Point(286, 115);
            pnlTasksCard.Name = "pnlTasksCard";
            pnlTasksCard.Size = new Size(200, 120);
            pnlTasksCard.TabIndex = 8;
            // 
            // lblTasksCount
            // 
            lblTasksCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTasksCount.ForeColor = Color.FromArgb(32, 43, 60);
            lblTasksCount.Location = new Point(3, 40);
            lblTasksCount.Name = "lblTasksCount";
            lblTasksCount.Size = new Size(170, 40);
            lblTasksCount.TabIndex = 8;
            lblTasksCount.Text = "0";
            lblTasksCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblTasksTitle.Location = new Point(3, 10);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Size = new Size(170, 25);
            lblTasksTitle.TabIndex = 7;
            lblTasksTitle.Text = "Tasks";
            // 
            // pnlCoursesCard
            // 
            pnlCoursesCard.BackColor = Color.White;
            pnlCoursesCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCoursesCard.Controls.Add(lblCoursesCount);
            pnlCoursesCard.Controls.Add(lblCoursesTitle);
            pnlCoursesCard.Location = new Point(13, 115);
            pnlCoursesCard.Name = "pnlCoursesCard";
            pnlCoursesCard.Size = new Size(200, 120);
            pnlCoursesCard.TabIndex = 7;
            // 
            // lblCoursesCount
            // 
            lblCoursesCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoursesCount.ForeColor = Color.FromArgb(32, 43, 60);
            lblCoursesCount.Location = new Point(3, 40);
            lblCoursesCount.Name = "lblCoursesCount";
            lblCoursesCount.Size = new Size(170, 40);
            lblCoursesCount.TabIndex = 6;
            lblCoursesCount.Text = "0";
            lblCoursesCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCoursesTitle
            // 
            lblCoursesTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblCoursesTitle.Location = new Point(3, 10);
            lblCoursesTitle.Name = "lblCoursesTitle";
            lblCoursesTitle.Size = new Size(170, 25);
            lblCoursesTitle.TabIndex = 6;
            lblCoursesTitle.Text = "My Courses";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.Location = new Point(20, 20);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(400, 50);
            lblDashboardTitle.TabIndex = 12;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.FromArgb(110, 120, 135);
            lblWelcome.Location = new Point(33, 70);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(232, 29);
            lblWelcome.TabIndex = 13;
            lblWelcome.Text = "Welcome to UniTrack_UMY";
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlUpcomingCard);
            Controls.Add(pnlTasksCard);
            Controls.Add(pnlCoursesCard);
            Controls.Add(lblWelcome);
            Controls.Add(lblDashboardTitle);
            Controls.Add(pnlUpcomingTasks);
            Controls.Add(pnlProgressCard);
            Font = new Font("Segoe UI", 10F);
            Name = "ucDashboard";
            Size = new Size(1100, 750);
            pnlUpcomingTasks.ResumeLayout(false);
            pnlProgressCard.ResumeLayout(false);
            pnlUpcomingCard.ResumeLayout(false);
            pnlTasksCard.ResumeLayout(false);
            pnlCoursesCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlUpcomingTasks;
        private ListBox lstUpcomingTasks;
        private Label lblUpcomingTasks;
        private Panel pnlProgressCard;
        private Label lblStudyProgress;
        private Label lblProgressTitle;
        private Panel pnlUpcomingCard;
        private Label lblUpcomingCount;
        private Label lblUpcomingTitle;
        private Panel pnlTasksCard;
        private Label lblTasksCount;
        private Label lblTasksTitle;
        private Panel pnlCoursesCard;
        private Label lblCoursesCount;
        private Label lblCoursesTitle;
        private Label lblDashboardTitle;
        private Label lblWelcome;
    }
}
