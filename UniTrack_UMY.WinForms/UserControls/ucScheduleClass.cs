using System;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucScheduleClass : UserControl
    {
        public ScheduleItem Schedule { get; private set; }

        public event Action<ucScheduleClass> Selected;

        public ucScheduleClass()
        {
            InitializeComponent();

           
        }

        private void SelectCard(object sender, EventArgs e)
        {
            Selected?.Invoke(this);
        }

        public void SetClassInfo(ScheduleItem item)
        {
            Schedule = item;

            lblCourseName.Text = item.CourseName;
            lblTime.Text = $"{item.StartTime} - {item.EndTime}";
            lblLocation.Text = string.IsNullOrWhiteSpace(item.Location)
                ? "Location not specified"
                : item.Location;
        }

        public void SetSelected(bool selected)
        {
            pnlClass.BackColor = selected
                ? System.Drawing.Color.FromArgb(190, 215, 245)
                : System.Drawing.Color.FromArgb(240, 245, 252);

            pnlClass.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetAsUpcoming()
        {
            pnlClass.BackColor = System.Drawing.Color.FromArgb(255, 245, 220);
            pnlClass.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetAsNormal()
        {
            pnlClass.BackColor = System.Drawing.Color.FromArgb(240, 245, 252);
            pnlClass.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}