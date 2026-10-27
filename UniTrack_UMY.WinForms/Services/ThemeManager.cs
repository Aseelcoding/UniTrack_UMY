
using System.Drawing;
using System.Windows.Forms;

namespace UniTrack_UMY.WinForms.Services
{
    public class ThemeManager
    {
        private readonly ThemeColors _colors;

        public ThemeManager(ThemeColors colors)
        {
            _colors = colors;
        }

        public void ApplyTheme(Control control)
        {
            if (control is Form || control is UserControl)
            {
                control.BackColor = _colors.Background;
                control.ForeColor = _colors.Text;
            }
            else if (control is Panel panel)
            {
                panel.BackColor = _colors.Surface;
                panel.ForeColor = _colors.Text;
            }
            else if (control is Label label)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = _colors.Text;
            }
            else if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = _colors.Surface;
                button.ForeColor = _colors.Text;
                button.UseVisualStyleBackColor = false;
            }
            else if (control is ListBox listBox)
            {
                listBox.BackColor = _colors.Surface;
                listBox.ForeColor = _colors.Text;
            }
            else
            {
                control.BackColor = _colors.Background;
                control.ForeColor = _colors.Text;
            }

            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }
        }
    }
}
