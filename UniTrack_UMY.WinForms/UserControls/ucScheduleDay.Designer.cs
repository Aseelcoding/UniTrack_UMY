
namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucScheduleDay
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
            pnlDay = new Panel();
            lblDayName = new Label();
            flpClasses = new FlowLayoutPanel();

            pnlDay.SuspendLayout();
            SuspendLayout();

            // pnlDay
            pnlDay.BackColor = Color.White;
            pnlDay.BorderStyle = BorderStyle.None;
            pnlDay.Controls.Add(flpClasses);
            pnlDay.Controls.Add(lblDayName);
            pnlDay.Dock = DockStyle.Fill;
            pnlDay.Name = "pnlDay";
            pnlDay.Padding = new Padding(5);
            pnlDay.TabIndex = 0;

            // lblDayName
            lblDayName.Dock = DockStyle.Top;
            lblDayName.Font = new Font(
                "Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDayName.ForeColor =
                Color.FromArgb(45, 55, 70);
            lblDayName.Height = 42;
            lblDayName.Name = "lblDayName";
            lblDayName.TabIndex = 0;
            lblDayName.Text = "Sunday";
            lblDayName.TextAlign =
                ContentAlignment.MiddleCenter;

            // flpClasses
            flpClasses.AutoScroll = true;
            flpClasses.BackColor = Color.White;
            flpClasses.Dock = DockStyle.Fill;
            flpClasses.FlowDirection = FlowDirection.TopDown;
            flpClasses.Margin = new Padding(0);
            flpClasses.Name = "flpClasses";
            flpClasses.Padding = new Padding(2);
            flpClasses.TabIndex = 1;
            flpClasses.WrapContents = false;

            // ucScheduleDay
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDay);
            Name = "ucScheduleDay";
            Size = new Size(145, 500);

            pnlDay.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDay;
        private Label lblDayName;
        private FlowLayoutPanel flpClasses;
    }
}
