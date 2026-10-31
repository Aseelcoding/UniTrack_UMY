using System.Reflection.PortableExecutable;

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
            pnlHeader = new Panel();
            lblScheduleTitle = new Label();
            lblScheduleDescription = new Label();
            pnlListCard = new Panel();
            lvSchedule = new ListView();
            colDay = new ColumnHeader();
            colCourse = new ColumnHeader();
            colStartTime = new ColumnHeader();
            colEndTime = new ColumnHeader();
            colLocation = new ColumnHeader();
            pnlFooter = new Panel();
            btnAddSchedule = new Button();
            btnDeleteSchedule = new Button();
            pnlHeader.SuspendLayout();
            pnlListCard.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblScheduleTitle);
            pnlHeader.Controls.Add(lblScheduleDescription);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 0, 0, 14);
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblScheduleTitle
            // 
            lblScheduleTitle.Dock = DockStyle.Fill;
            lblScheduleTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblScheduleTitle.Name = "lblScheduleTitle";
            lblScheduleTitle.TabIndex = 0;
            lblScheduleTitle.Text = "My Schedule";
            lblScheduleTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblScheduleDescription
            // 
            lblScheduleDescription.AutoSize = false;
            lblScheduleDescription.Dock = DockStyle.Bottom;
            lblScheduleDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblScheduleDescription.Name = "lblScheduleDescription";
            lblScheduleDescription.Size = new Size(1100, 28);
            lblScheduleDescription.TabIndex = 1;
            lblScheduleDescription.Tag = "muted";
            lblScheduleDescription.Text = "Keep your class schedule organized";
            lblScheduleDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlListCard
            // 
            pnlListCard.BackColor = Color.White;
            pnlListCard.Controls.Add(lvSchedule);
            pnlListCard.Controls.Add(pnlFooter);
            pnlListCard.Dock = DockStyle.Fill;
            pnlListCard.Name = "pnlListCard";
            pnlListCard.Padding = new Padding(12);
            pnlListCard.TabIndex = 1;
            // 
            // lvSchedule
            // 
            lvSchedule.BackColor = Color.White;
            lvSchedule.BorderStyle = BorderStyle.None;
            lvSchedule.Columns.AddRange(new ColumnHeader[] { colDay, colCourse, colStartTime, colEndTime, colLocation });
            lvSchedule.Dock = DockStyle.Fill;
            lvSchedule.Font = new Font("Segoe UI", 10.5F);
            lvSchedule.FullRowSelect = true;
            lvSchedule.GridLines = false;
            lvSchedule.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSchedule.MultiSelect = false;
            lvSchedule.Name = "lvSchedule";
            lvSchedule.TabIndex = 0;
            lvSchedule.UseCompatibleStateImageBehavior = false;
            lvSchedule.View = View.Details;
            lvSchedule.SizeChanged += lvSchedule_SizeChanged;
            // 
            // colDay
            // 
            colDay.Text = "Day";
            colDay.Width = 150;
            // 
            // colCourse
            // 
            colCourse.Text = "Course";
            colCourse.Width = 320;
            // 
            // colStartTime
            // 
            colStartTime.Text = "Start Time";
            colStartTime.Width = 130;
            // 
            // colEndTime
            // 
            colEndTime.Text = "End Time";
            colEndTime.Width = 130;
            // 
            // colLocation
            // 
            colLocation.Text = "Location";
            colLocation.Width = 200;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnAddSchedule);
            pnlFooter.Controls.Add(btnDeleteSchedule);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1000, 62);
            pnlFooter.TabIndex = 1;
            pnlFooter.Tag = "card";
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.BackColor = Color.FromArgb(55, 110, 190);
            btnAddSchedule.Cursor = Cursors.Hand;
            btnAddSchedule.FlatAppearance.BorderSize = 0;
            btnAddSchedule.FlatStyle = FlatStyle.Flat;
            btnAddSchedule.Font = new Font("Segoe UI Semibold", 10.5F);
            btnAddSchedule.ForeColor = Color.White;
            btnAddSchedule.Location = new Point(0, 14);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(170, 44);
            btnAddSchedule.TabIndex = 0;
            btnAddSchedule.Tag = "primary";
            btnAddSchedule.Text = "Add Schedule";
            btnAddSchedule.UseVisualStyleBackColor = false;
            // 
            // btnDeleteSchedule
            // 
            btnDeleteSchedule.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteSchedule.Cursor = Cursors.Hand;
            btnDeleteSchedule.FlatAppearance.BorderSize = 0;
            btnDeleteSchedule.FlatStyle = FlatStyle.Flat;
            btnDeleteSchedule.Font = new Font("Segoe UI Semibold", 10.5F);
            btnDeleteSchedule.ForeColor = Color.White;
            btnDeleteSchedule.Location = new Point(182, 14);
            btnDeleteSchedule.Name = "btnDeleteSchedule";
            btnDeleteSchedule.Size = new Size(170, 44);
            btnDeleteSchedule.TabIndex = 1;
            btnDeleteSchedule.Tag = "danger";
            btnDeleteSchedule.Text = "Delete Schedule";
            btnDeleteSchedule.UseVisualStyleBackColor = false;
            // 
            // ucSchedule
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlListCard);   
            Controls.Add(pnlHeader); 
            Font = new Font("Segoe UI", 10F);
            Name = "ucSchedule";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            pnlListCard.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlListCard;
        private Panel pnlFooter;
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
