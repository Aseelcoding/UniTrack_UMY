namespace UniTrack_UMY.WinForms.Forms
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnSettings = new Button();
            btnNotesPlanner = new Button();
            btnSchedule = new Button();
            btnTasks = new Button();
            btnMyCourses = new Button();
            btnDashboard = new Button();
            lblAppTitle = new Label();
            pnlContent = new Panel();
            pnlPageContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(32, 43, 60);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnNotesPlanner);
            pnlSidebar.Controls.Add(btnSchedule);
            pnlSidebar.Controls.Add(btnTasks);
            pnlSidebar.Controls.Add(btnMyCourses);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 790);
            pnlSidebar.TabIndex = 0;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Padding = new Padding(24, 0, 0, 0);
            lblAppTitle.Size = new Size(230, 90);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "UniTrack_UMY";
            lblAppTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(32, 43, 60);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 68, 94);
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 58, 80);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10.5F);
            btnDashboard.ForeColor = Color.FromArgb(230, 235, 242);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(24, 0, 0, 0);
            btnDashboard.Size = new Size(230, 48);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnMyCourses
            // 
            btnMyCourses.BackColor = Color.FromArgb(32, 43, 60);
            btnMyCourses.Cursor = Cursors.Hand;
            btnMyCourses.Dock = DockStyle.Top;
            btnMyCourses.FlatAppearance.BorderSize = 0;
            btnMyCourses.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 68, 94);
            btnMyCourses.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 58, 80);
            btnMyCourses.FlatStyle = FlatStyle.Flat;
            btnMyCourses.Font = new Font("Segoe UI", 10.5F);
            btnMyCourses.ForeColor = Color.FromArgb(230, 235, 242);
            btnMyCourses.Name = "btnMyCourses";
            btnMyCourses.Padding = new Padding(24, 0, 0, 0);
            btnMyCourses.Size = new Size(230, 48);
            btnMyCourses.TabIndex = 2;
            btnMyCourses.Text = "My Courses";
            btnMyCourses.TextAlign = ContentAlignment.MiddleLeft;
            btnMyCourses.UseVisualStyleBackColor = false;
            btnMyCourses.Click += btnMyCourses_Click;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = Color.FromArgb(32, 43, 60);
            btnTasks.Cursor = Cursors.Hand;
            btnTasks.Dock = DockStyle.Top;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 68, 94);
            btnTasks.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 58, 80);
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 10.5F);
            btnTasks.ForeColor = Color.FromArgb(230, 235, 242);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(24, 0, 0, 0);
            btnTasks.Size = new Size(230, 48);
            btnTasks.TabIndex = 3;
            btnTasks.Text = "Tasks";
            btnTasks.TextAlign = ContentAlignment.MiddleLeft;
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += btnTasks_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = Color.FromArgb(32, 43, 60);
            btnSchedule.Cursor = Cursors.Hand;
            btnSchedule.Dock = DockStyle.Top;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 68, 94);
            btnSchedule.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 58, 80);
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Segoe UI", 10.5F);
            btnSchedule.ForeColor = Color.FromArgb(230, 235, 242);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Padding = new Padding(24, 0, 0, 0);
            btnSchedule.Size = new Size(230, 48);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "Schedule";
            btnSchedule.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedule.UseVisualStyleBackColor = false;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnNotesPlanner
            // 
            btnNotesPlanner.BackColor = Color.FromArgb(32, 43, 60);
            btnNotesPlanner.Cursor = Cursors.Hand;
            btnNotesPlanner.Dock = DockStyle.Top;
            btnNotesPlanner.FlatAppearance.BorderSize = 0;
            btnNotesPlanner.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 68, 94);
            btnNotesPlanner.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 58, 80);
            btnNotesPlanner.FlatStyle = FlatStyle.Flat;
            btnNotesPlanner.Font = new Font("Segoe UI", 10.5F);
            btnNotesPlanner.ForeColor = Color.FromArgb(230, 235, 242);
            btnNotesPlanner.Name = "btnNotesPlanner";
            btnNotesPlanner.Padding = new Padding(24, 0, 0, 0);
            btnNotesPlanner.Size = new Size(230, 48);
            btnNotesPlanner.TabIndex = 5;
            btnNotesPlanner.Text = "Notes And Planner";
            btnNotesPlanner.TextAlign = ContentAlignment.MiddleLeft;
            btnNotesPlanner.UseVisualStyleBackColor = false;
            btnNotesPlanner.Click += btnNotesPlanner_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(32, 43, 60);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Dock = DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 68, 94);
            btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 58, 80);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10.5F);
            btnSettings.ForeColor = Color.FromArgb(230, 235, 242);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(24, 0, 0, 0);
            btnSettings.Size = new Size(230, 48);
            btnSettings.TabIndex = 6;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlPageContent);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(28);
            pnlContent.TabIndex = 1;
            // 
            // pnlPageContent
            // 
            pnlPageContent.Dock = DockStyle.Fill;
            pnlPageContent.Name = "pnlPageContent";
            pnlPageContent.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1360, 790);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(4);
            MinimumSize = new Size(968, 635);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UniTrack - My Courses";
            pnlSidebar.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblAppTitle;
        private Panel pnlContent;
        private Button btnTasks;
        private Button btnMyCourses;
        private Button btnSettings;
        private Button btnNotesPlanner;
        private Button btnSchedule;
        private Button btnDashboard;
        private Panel pnlPageContent;
    }
}