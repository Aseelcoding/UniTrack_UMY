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
            pnlHeader = new Panel();
            lblDashboardTitle = new Label();
            lblWelcome = new Label();
            tlpCards = new TableLayoutPanel();
            pnlCoursesCard = new Panel();
            lblCoursesCount = new Label();
            lblCoursesTitle = new Label();
            pnlCoursesAccent = new Panel();
            pnlTasksCard = new Panel();
            lblTasksCount = new Label();
            lblTasksTitle = new Label();
            pnlTasksAccent = new Panel();
            pnlUpcomingCard = new Panel();
            lblUpcomingCount = new Label();
            lblUpcomingTitle = new Label();
            pnlUpcomingAccent = new Panel();
            pnlProgressCard = new Panel();
            lblStudyProgress = new Label();
            lblProgressTitle = new Label();
            pnlProgressAccent = new Panel();
            pnlOverdueCard = new Panel();
            lblOverdueCount = new Label();
            lblOverdueTitle = new Label();
            pnlOverdueAccent = new Panel();
            pnlSpacer = new Panel();
            pnlUpcomingTasks = new Panel();
            lstUpcomingTasks = new ListBox();
            lblUpcomingTasks = new Label();
            pnlHeader.SuspendLayout();
            tlpCards.SuspendLayout();
            pnlCoursesCard.SuspendLayout();
            pnlTasksCard.SuspendLayout();
            pnlUpcomingCard.SuspendLayout();
            pnlProgressCard.SuspendLayout();
            pnlOverdueCard.SuspendLayout();
            pnlUpcomingTasks.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblDashboardTitle);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 90);
            pnlHeader.TabIndex = 3;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.Dock = DockStyle.Fill;
            lblDashboardTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(32, 43, 60);
            lblDashboardTitle.Location = new Point(0, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(1100, 62);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            lblDashboardTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblWelcome
            // 
            lblWelcome.Dock = DockStyle.Bottom;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.FromArgb(110, 120, 135);
            lblWelcome.Location = new Point(0, 62);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1100, 28);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome to UniTrack_UMY";
            lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpCards
            // 
            tlpCards.ColumnCount = 5;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.Controls.Add(pnlCoursesCard, 0, 0);
            tlpCards.Controls.Add(pnlTasksCard, 1, 0);
            tlpCards.Controls.Add(pnlUpcomingCard, 2, 0);
            tlpCards.Controls.Add(pnlProgressCard, 3, 0);
            tlpCards.Controls.Add(pnlOverdueCard, 4, 0);
            tlpCards.Dock = DockStyle.Top;
            tlpCards.Location = new Point(0, 90);
            tlpCards.Name = "tlpCards";
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(1100, 120);
            tlpCards.TabIndex = 2;
            // 
            // pnlCoursesCard
            // 
            pnlCoursesCard.BackColor = Color.White;
            pnlCoursesCard.Controls.Add(lblCoursesCount);
            pnlCoursesCard.Controls.Add(lblCoursesTitle);
            pnlCoursesCard.Controls.Add(pnlCoursesAccent);
            pnlCoursesCard.Dock = DockStyle.Fill;
            pnlCoursesCard.Location = new Point(0, 0);
            pnlCoursesCard.Margin = new Padding(0, 0, 16, 0);
            pnlCoursesCard.Name = "pnlCoursesCard";
            pnlCoursesCard.Size = new Size(204, 120);
            pnlCoursesCard.TabIndex = 0;
            // 
            // lblCoursesCount
            // 
            lblCoursesCount.Dock = DockStyle.Fill;
            lblCoursesCount.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblCoursesCount.ForeColor = Color.FromArgb(32, 43, 60);
            lblCoursesCount.Location = new Point(5, 48);
            lblCoursesCount.Name = "lblCoursesCount";
            lblCoursesCount.Padding = new Padding(20, 0, 0, 0);
            lblCoursesCount.Size = new Size(199, 72);
            lblCoursesCount.TabIndex = 0;
            lblCoursesCount.Text = "0";
            // 
            // lblCoursesTitle
            // 
            lblCoursesTitle.Dock = DockStyle.Top;
            lblCoursesTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblCoursesTitle.Location = new Point(5, 0);
            lblCoursesTitle.Name = "lblCoursesTitle";
            lblCoursesTitle.Padding = new Padding(20, 18, 0, 0);
            lblCoursesTitle.Size = new Size(199, 48);
            lblCoursesTitle.TabIndex = 1;
            lblCoursesTitle.Text = "My Courses";
            // 
            // pnlCoursesAccent
            // 
            pnlCoursesAccent.BackColor = Color.FromArgb(52, 120, 246);
            pnlCoursesAccent.Dock = DockStyle.Left;
            pnlCoursesAccent.Location = new Point(0, 0);
            pnlCoursesAccent.Name = "pnlCoursesAccent";
            pnlCoursesAccent.Size = new Size(5, 120);
            pnlCoursesAccent.TabIndex = 2;
            // 
            // pnlTasksCard
            // 
            pnlTasksCard.BackColor = Color.White;
            pnlTasksCard.Controls.Add(lblTasksCount);
            pnlTasksCard.Controls.Add(lblTasksTitle);
            pnlTasksCard.Controls.Add(pnlTasksAccent);
            pnlTasksCard.Dock = DockStyle.Fill;
            pnlTasksCard.Location = new Point(220, 0);
            pnlTasksCard.Margin = new Padding(0, 0, 16, 0);
            pnlTasksCard.Name = "pnlTasksCard";
            pnlTasksCard.Size = new Size(204, 120);
            pnlTasksCard.TabIndex = 1;
            // 
            // lblTasksCount
            // 
            lblTasksCount.Dock = DockStyle.Fill;
            lblTasksCount.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblTasksCount.ForeColor = Color.FromArgb(32, 43, 60);
            lblTasksCount.Location = new Point(5, 48);
            lblTasksCount.Name = "lblTasksCount";
            lblTasksCount.Padding = new Padding(20, 0, 0, 0);
            lblTasksCount.Size = new Size(199, 72);
            lblTasksCount.TabIndex = 0;
            lblTasksCount.Text = "0";
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.Dock = DockStyle.Top;
            lblTasksTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblTasksTitle.Location = new Point(5, 0);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Padding = new Padding(20, 18, 0, 0);
            lblTasksTitle.Size = new Size(199, 48);
            lblTasksTitle.TabIndex = 1;
            lblTasksTitle.Text = "Tasks";
            // 
            // pnlTasksAccent
            // 
            pnlTasksAccent.BackColor = Color.FromArgb(0, 168, 150);
            pnlTasksAccent.Dock = DockStyle.Left;
            pnlTasksAccent.Location = new Point(0, 0);
            pnlTasksAccent.Name = "pnlTasksAccent";
            pnlTasksAccent.Size = new Size(5, 120);
            pnlTasksAccent.TabIndex = 2;
            // 
            // pnlUpcomingCard
            // 
            pnlUpcomingCard.BackColor = Color.White;
            pnlUpcomingCard.Controls.Add(lblUpcomingCount);
            pnlUpcomingCard.Controls.Add(lblUpcomingTitle);
            pnlUpcomingCard.Controls.Add(pnlUpcomingAccent);
            pnlUpcomingCard.Dock = DockStyle.Fill;
            pnlUpcomingCard.Location = new Point(440, 0);
            pnlUpcomingCard.Margin = new Padding(0, 0, 16, 0);
            pnlUpcomingCard.Name = "pnlUpcomingCard";
            pnlUpcomingCard.Size = new Size(204, 120);
            pnlUpcomingCard.TabIndex = 2;
            // 
            // lblUpcomingCount
            // 
            lblUpcomingCount.Dock = DockStyle.Fill;
            lblUpcomingCount.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblUpcomingCount.ForeColor = Color.FromArgb(32, 43, 60);
            lblUpcomingCount.Location = new Point(5, 48);
            lblUpcomingCount.Name = "lblUpcomingCount";
            lblUpcomingCount.Padding = new Padding(20, 0, 0, 0);
            lblUpcomingCount.Size = new Size(199, 72);
            lblUpcomingCount.TabIndex = 0;
            lblUpcomingCount.Text = "0";
            // 
            // lblUpcomingTitle
            // 
            lblUpcomingTitle.Dock = DockStyle.Top;
            lblUpcomingTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblUpcomingTitle.Location = new Point(5, 0);
            lblUpcomingTitle.Name = "lblUpcomingTitle";
            lblUpcomingTitle.Padding = new Padding(20, 18, 0, 0);
            lblUpcomingTitle.Size = new Size(199, 48);
            lblUpcomingTitle.TabIndex = 1;
            lblUpcomingTitle.Text = "Upcoming";
            // 
            // pnlUpcomingAccent
            // 
            pnlUpcomingAccent.BackColor = Color.FromArgb(245, 166, 35);
            pnlUpcomingAccent.Dock = DockStyle.Left;
            pnlUpcomingAccent.Location = new Point(0, 0);
            pnlUpcomingAccent.Name = "pnlUpcomingAccent";
            pnlUpcomingAccent.Size = new Size(5, 120);
            pnlUpcomingAccent.TabIndex = 2;
            // 
            // pnlProgressCard
            // 
            pnlProgressCard.BackColor = Color.White;
            pnlProgressCard.Controls.Add(lblStudyProgress);
            pnlProgressCard.Controls.Add(lblProgressTitle);
            pnlProgressCard.Controls.Add(pnlProgressAccent);
            pnlProgressCard.Dock = DockStyle.Fill;
            pnlProgressCard.Location = new Point(660, 0);
            pnlProgressCard.Margin = new Padding(0, 0, 16, 0);
            pnlProgressCard.Name = "pnlProgressCard";
            pnlProgressCard.Size = new Size(204, 120);
            pnlProgressCard.TabIndex = 3;
            // 
            // lblStudyProgress
            // 
            lblStudyProgress.Dock = DockStyle.Fill;
            lblStudyProgress.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblStudyProgress.ForeColor = Color.FromArgb(32, 43, 60);
            lblStudyProgress.Location = new Point(5, 48);
            lblStudyProgress.Name = "lblStudyProgress";
            lblStudyProgress.Padding = new Padding(20, 0, 0, 0);
            lblStudyProgress.Size = new Size(199, 72);
            lblStudyProgress.TabIndex = 0;
            lblStudyProgress.Text = "0";
            // 
            // lblProgressTitle
            // 
            lblProgressTitle.Dock = DockStyle.Top;
            lblProgressTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblProgressTitle.Location = new Point(5, 0);
            lblProgressTitle.Name = "lblProgressTitle";
            lblProgressTitle.Padding = new Padding(20, 18, 0, 0);
            lblProgressTitle.Size = new Size(199, 48);
            lblProgressTitle.TabIndex = 1;
            lblProgressTitle.Text = "Study Progress";
            // 
            // pnlProgressAccent
            // 
            pnlProgressAccent.BackColor = Color.FromArgb(124, 92, 230);
            pnlProgressAccent.Dock = DockStyle.Left;
            pnlProgressAccent.Location = new Point(0, 0);
            pnlProgressAccent.Name = "pnlProgressAccent";
            pnlProgressAccent.Size = new Size(5, 120);
            pnlProgressAccent.TabIndex = 2;
            // 
            // pnlOverdueCard
            // 
            pnlOverdueCard.BackColor = Color.White;
            pnlOverdueCard.Controls.Add(lblOverdueCount);
            pnlOverdueCard.Controls.Add(lblOverdueTitle);
            pnlOverdueCard.Controls.Add(pnlOverdueAccent);
            pnlOverdueCard.Dock = DockStyle.Fill;
            pnlOverdueCard.Location = new Point(880, 0);
            pnlOverdueCard.Margin = new Padding(0);
            pnlOverdueCard.Name = "pnlOverdueCard";
            pnlOverdueCard.Size = new Size(220, 120);
            pnlOverdueCard.TabIndex = 4;
            // 
            // lblOverdueCount
            // 
            lblOverdueCount.Dock = DockStyle.Fill;
            lblOverdueCount.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblOverdueCount.ForeColor = Color.FromArgb(220, 53, 69);
            lblOverdueCount.Location = new Point(5, 48);
            lblOverdueCount.Name = "lblOverdueCount";
            lblOverdueCount.Padding = new Padding(20, 0, 0, 0);
            lblOverdueCount.Size = new Size(215, 72);
            lblOverdueCount.TabIndex = 0;
            lblOverdueCount.Text = "0";
            // 
            // lblOverdueTitle
            // 
            lblOverdueTitle.Dock = DockStyle.Top;
            lblOverdueTitle.ForeColor = Color.FromArgb(110, 120, 135);
            lblOverdueTitle.Location = new Point(5, 0);
            lblOverdueTitle.Name = "lblOverdueTitle";
            lblOverdueTitle.Padding = new Padding(20, 18, 0, 0);
            lblOverdueTitle.Size = new Size(215, 48);
            lblOverdueTitle.TabIndex = 1;
            lblOverdueTitle.Text = "Overdue";
            // 
            // pnlOverdueAccent
            // 
            pnlOverdueAccent.BackColor = Color.FromArgb(220, 53, 69);
            pnlOverdueAccent.Dock = DockStyle.Left;
            pnlOverdueAccent.Location = new Point(0, 0);
            pnlOverdueAccent.Name = "pnlOverdueAccent";
            pnlOverdueAccent.Size = new Size(5, 120);
            pnlOverdueAccent.TabIndex = 2;
            // 
            // pnlSpacer
            // 
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.Location = new Point(0, 210);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(1100, 20);
            pnlSpacer.TabIndex = 1;
            // 
            // pnlUpcomingTasks
            // 
            pnlUpcomingTasks.BackColor = Color.White;
            pnlUpcomingTasks.Controls.Add(lstUpcomingTasks);
            pnlUpcomingTasks.Controls.Add(lblUpcomingTasks);
            pnlUpcomingTasks.Dock = DockStyle.Fill;
            pnlUpcomingTasks.Location = new Point(0, 230);
            pnlUpcomingTasks.Name = "pnlUpcomingTasks";
            pnlUpcomingTasks.Padding = new Padding(24, 16, 24, 20);
            pnlUpcomingTasks.Size = new Size(1100, 520);
            pnlUpcomingTasks.TabIndex = 0;
            // 
            // lstUpcomingTasks
            // 
            lstUpcomingTasks.BorderStyle = BorderStyle.None;
            lstUpcomingTasks.Dock = DockStyle.Fill;
            lstUpcomingTasks.Font = new Font("Segoe UI", 11F);
            lstUpcomingTasks.ForeColor = Color.FromArgb(60, 70, 85);
            lstUpcomingTasks.FormattingEnabled = true;
            lstUpcomingTasks.IntegralHeight = false;
            lstUpcomingTasks.Location = new Point(24, 60);
            lstUpcomingTasks.Name = "lstUpcomingTasks";
            lstUpcomingTasks.Size = new Size(1052, 440);
            lstUpcomingTasks.TabIndex = 0;
            lstUpcomingTasks.DoubleClick += lstUpcomingTasks_DoubleClick;
            // 
            // lblUpcomingTasks
            // 
            lblUpcomingTasks.Dock = DockStyle.Top;
            lblUpcomingTasks.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            lblUpcomingTasks.ForeColor = Color.FromArgb(32, 43, 60);
            lblUpcomingTasks.Location = new Point(24, 16);
            lblUpcomingTasks.Name = "lblUpcomingTasks";
            lblUpcomingTasks.Size = new Size(1052, 44);
            lblUpcomingTasks.TabIndex = 1;
            lblUpcomingTasks.Text = "Upcoming Tasks";
            lblUpcomingTasks.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlUpcomingTasks);
            Controls.Add(pnlSpacer);
            Controls.Add(tlpCards);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            Name = "ucDashboard";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            tlpCards.ResumeLayout(false);
            pnlCoursesCard.ResumeLayout(false);
            pnlTasksCard.ResumeLayout(false);
            pnlUpcomingCard.ResumeLayout(false);
            pnlProgressCard.ResumeLayout(false);
            pnlOverdueCard.ResumeLayout(false);
            pnlUpcomingTasks.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private TableLayoutPanel tlpCards;
        private Panel pnlSpacer;
        private Panel pnlCoursesAccent;
        private Panel pnlTasksAccent;
        private Panel pnlUpcomingAccent;
        private Panel pnlProgressAccent;
        private Panel pnlOverdueAccent;

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
        private Panel pnlOverdueCard;
        private Label lblOverdueCount;
        private Label lblOverdueTitle;
    }
}
