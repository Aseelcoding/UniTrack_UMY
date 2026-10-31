
namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucScheduleClass
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlClass = new Panel();
            lblLocation = new Label();
            lblTime = new Label();
            lblCourseName = new Label();
            pnlClass.SuspendLayout();
            SuspendLayout();
            // 
            // pnlClass
            // 
            pnlClass.BackColor = Color.FromArgb(240, 245, 252);
            pnlClass.BorderStyle = BorderStyle.FixedSingle;
            pnlClass.Controls.Add(lblLocation);
            pnlClass.Controls.Add(lblTime);
            pnlClass.Controls.Add(lblCourseName);
            pnlClass.Dock = DockStyle.Fill;
            pnlClass.Location = new Point(0, 0);
            pnlClass.Name = "pnlClass";
            pnlClass.Padding = new Padding(6);
            pnlClass.Size = new Size(116, 91);
            pnlClass.TabIndex = 0;
            pnlClass.Tag = "";
            pnlClass.Click += SelectCard;
            // 
            // lblLocation
            // 
            lblLocation.Dock = DockStyle.Top;
            lblLocation.Font = new Font("Segoe UI", 8F);
            lblLocation.ForeColor = Color.FromArgb(110, 120, 135);
            lblLocation.Location = new Point(6, 67);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(102, 22);
            lblLocation.TabIndex = 2;
            lblLocation.Text = "Room: F6.102";
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;
            lblLocation.Click += SelectCard;
            // 
            // lblTime
            // 
            lblTime.Dock = DockStyle.Top;
            lblTime.Font = new Font("Segoe UI", 8.5F);
            lblTime.ForeColor = Color.FromArgb(70, 90, 115);
            lblTime.Location = new Point(6, 43);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(102, 24);
            lblTime.TabIndex = 1;
            lblTime.Text = "08:00 - 10:00";
            lblTime.TextAlign = ContentAlignment.MiddleLeft;
            lblTime.Click += SelectCard;
            // 
            // lblCourseName
            // 
            lblCourseName.Dock = DockStyle.Top;
            lblCourseName.Font = new Font("Segoe UI Semibold", 6F, FontStyle.Bold);
            lblCourseName.ForeColor = Color.FromArgb(40, 55, 75);
            lblCourseName.Location = new Point(6, 6);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(102, 37);
            lblCourseName.TabIndex = 0;
            lblCourseName.Text = "Course Name";
            lblCourseName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucScheduleClass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlClass);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucScheduleClass";
            Size = new Size(116, 91);
            pnlClass.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlClass;
        private Label lblCourseName;
        private Label lblTime;
        private Label lblLocation;
    }
}
