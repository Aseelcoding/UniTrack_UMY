using System;
using System.ComponentModel;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using System.Collections.Generic;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucScheduleDay : UserControl
    {
        public event Action<ucScheduleClass> ClassSelected;

        public ucScheduleDay()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DayName
        {
            get => lblDayName.Text;
            set => lblDayName.Text = value;
        }

        public void AddClass(ScheduleItem item)
        {
            ucScheduleClass classCard = new ucScheduleClass();

            classCard.SetClassInfo(item);
            classCard.Selected += card => ClassSelected?.Invoke(card);

            flpClasses.Controls.Add(classCard);
        }

        public void ClearClasses()
        {
            flpClasses.Controls.Clear();
        }

        public void LoadClasses(List<ScheduleItem> schedule)
        {
            ClearClasses();

            foreach (ScheduleItem item in schedule)
            {
                if (item.Day != DayName)
                    continue;

                AddClass(item);
            }
        }
    }
}