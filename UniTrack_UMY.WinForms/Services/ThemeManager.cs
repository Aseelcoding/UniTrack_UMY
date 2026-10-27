
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
                if (panel.Name == "pnlSidebar")
                    panel.BackColor = _colors.Sidebar;
                else
                    panel.BackColor = _colors.Background;

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
            else if (control is ListView listView)
            {
                listView.BackColor = _colors.Surface;
                listView.ForeColor = _colors.Text;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = _colors.Surface;
                textBox.ForeColor = _colors.Text;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = _colors.Surface;
                comboBox.ForeColor = _colors.Text;
            }

            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }
        }
    }
}
