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
            btnTasks = new Button();
            btnMyCourses = new Button();
            btnSettings = new Button();
            btnNotesPlanner = new Button();
            btnSchedule = new Button();
            btnDashboard = new Button();
            lblAppTitle = new Label();
            pnlContent = new Panel();
            pnlPageContent = new Panel();
            lblPageTitle = new Label();
            lblPageDescription = new Label();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlPageContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(32, 43, 60);
            pnlSidebar.Controls.Add(btnTasks);
            pnlSidebar.Controls.Add(btnMyCourses);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnNotesPlanner);
            pnlSidebar.Controls.Add(btnSchedule);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 601);
            pnlSidebar.TabIndex = 0;
            // 
            // btnTasks
            // 
            btnTasks.Cursor = Cursors.Hand;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.ForeColor = Color.FromArgb(230, 235, 242);
            btnTasks.Location = new Point(0, 200);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(0, 0, 0, 15);
            btnTasks.Size = new Size(200, 45);
            btnTasks.TabIndex = 6;
            btnTasks.Text = "Tasks";
            btnTasks.TextAlign = ContentAlignment.MiddleLeft;
            btnTasks.UseVisualStyleBackColor = false;
            // 
            // btnMyCourses
            // 
            btnMyCourses.Cursor = Cursors.Hand;
            btnMyCourses.FlatAppearance.BorderSize = 0;
            btnMyCourses.FlatStyle = FlatStyle.Flat;
            btnMyCourses.ForeColor = Color.FromArgb(230, 235, 242);
            btnMyCourses.Location = new Point(0, 150);
            btnMyCourses.Name = "btnMyCourses";
            btnMyCourses.Padding = new Padding(0, 0, 0, 15);
            btnMyCourses.Size = new Size(200, 45);
            btnMyCourses.TabIndex = 5;
            btnMyCourses.Text = "My Courses";
            btnMyCourses.TextAlign = ContentAlignment.MiddleLeft;
            btnMyCourses.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.FromArgb(230, 235, 242);
            btnSettings.Location = new Point(0, 350);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(0, 0, 0, 15);
            btnSettings.Size = new Size(200, 45);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnNotesPlanner
            // 
            btnNotesPlanner.Cursor = Cursors.Hand;
            btnNotesPlanner.FlatAppearance.BorderSize = 0;
            btnNotesPlanner.FlatStyle = FlatStyle.Flat;
            btnNotesPlanner.ForeColor = Color.FromArgb(230, 235, 242);
            btnNotesPlanner.Location = new Point(0, 300);
            btnNotesPlanner.Name = "btnNotesPlanner";
            btnNotesPlanner.Padding = new Padding(0, 0, 0, 15);
            btnNotesPlanner.Size = new Size(200, 45);
            btnNotesPlanner.TabIndex = 3;
            btnNotesPlanner.Text = "Notes And Planner";
            btnNotesPlanner.TextAlign = ContentAlignment.MiddleLeft;
            btnNotesPlanner.UseVisualStyleBackColor = false;
            // 
            // btnSchedule
            // 
            btnSchedule.Cursor = Cursors.Hand;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.ForeColor = Color.FromArgb(230, 235, 242);
            btnSchedule.Location = new Point(0, 250);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Padding = new Padding(0, 0, 0, 15);
            btnSchedule.Size = new Size(200, 45);
            btnSchedule.TabIndex = 2;
            btnSchedule.Text = "Schedule";
            btnSchedule.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.FromArgb(230, 235, 242);
            btnDashboard.Location = new Point(0, 100);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(0, 0, 0, 15);
            btnDashboard.Size = new Size(200, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(20, 25);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(180, 40);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "UniTrack_UMY";
            lblAppTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlPageContent);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(742, 601);
            pnlContent.TabIndex = 1;
            // 
            // pnlPageContent
            // 
            pnlPageContent.Controls.Add(lblPageTitle);
            pnlPageContent.Controls.Add(lblPageDescription);
            pnlPageContent.Location = new Point(0, 3);
            pnlPageContent.Name = "pnlPageContent";
            pnlPageContent.Size = new Size(742, 598);
            pnlPageContent.TabIndex = 2;
            // 
            // lblPageTitle
            // 
            lblPageTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.Location = new Point(6, 5);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(742, 40);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Dashboard";
            lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPageDescription
            // 
            lblPageDescription.AutoSize = true;
            lblPageDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblPageDescription.Location = new Point(30, 50);
            lblPageDescription.Name = "lblPageDescription";
            lblPageDescription.Size = new Size(171, 23);
            lblPageDescription.TabIndex = 1;
            lblPageDescription.Text = "\tWelcome to UniTrack";
            lblPageDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(962, 601);
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
            pnlPageContent.ResumeLayout(false);
            pnlPageContent.PerformLayout();
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
        private Label lblPageDescription;
        private Label lblPageTitle;
    }
}