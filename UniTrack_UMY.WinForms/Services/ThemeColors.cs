
using System.Drawing;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.WinForms.Services
{
    public class ThemeColors
    {
        public Color Background { get; private set; }
        public Color Surface { get; private set; }
        public Color Text { get; private set; }
        public Color SecondaryText { get; private set; }
        public Color Sidebar { get; private set; }
        public Color Primary { get; private set; }
        public Color Border { get; private set; }

        public ThemeColors(AppTheme theme)
        {
            if (theme == AppTheme.Dark)
            {
                Background = Color.FromArgb(24, 30, 40);
                Surface = Color.FromArgb(35, 43, 56);
                Text = Color.FromArgb(235, 239, 245);
                SecondaryText = Color.FromArgb(165, 175, 190);
                Sidebar = Color.FromArgb(20, 26, 36);
                Primary = Color.FromArgb(90, 145, 220);
                Border = Color.FromArgb(55, 65, 80);
            }
            else
            {
                Background = Color.FromArgb(245, 247, 250);
                Surface = Color.White;
                Text = Color.FromArgb(32, 43, 60);
                SecondaryText = Color.FromArgb(110, 120, 135);
                Sidebar = Color.FromArgb(32, 43, 60);
                Primary = Color.FromArgb(55, 110, 190);
                Border = Color.FromArgb(220, 225, 233);
            }
        }
    }
}
