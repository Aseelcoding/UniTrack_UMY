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
            string? tag = control.Tag as string;

           
            if (tag != "keep")
                ApplyToControl(control, tag);

            foreach (Control child in control.Controls)
                ApplyTheme(child);
        }

        private void ApplyToControl(Control control, string? tag)
        {
            bool inSidebar = control.Parent?.Name == "pnlSidebar";

            if (control is Form || control is UserControl)
            {
                control.BackColor = _colors.Background;
                control.ForeColor = _colors.Text;
            }
            else if (control is Panel panel)
            {
                if (panel.Name == "pnlSidebar")
                    panel.BackColor = _colors.Sidebar;
                else if (panel.Name.EndsWith("Accent"))
                    return; 
                else if (tag == "card" || panel.Name.EndsWith("Card"))
                    panel.BackColor = _colors.Surface;
                else
                    panel.BackColor = _colors.Background;

                panel.ForeColor = _colors.Text;
            }
            else if (control is Label label)
            {
                label.BackColor = Color.Transparent;

                if (inSidebar)
                    label.ForeColor = Color.White;
                else if (tag == "muted")
                    label.ForeColor = _colors.SecondaryText;
                else if (tag == "danger")
                    label.ForeColor = _colors.Danger;
                else
                    label.ForeColor = _colors.Text;
            }
            else if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.UseVisualStyleBackColor = false;

                if (inSidebar)
                {
                    button.BackColor = _colors.Sidebar;
                    button.ForeColor = _colors.SidebarText;
                    button.FlatAppearance.MouseOverBackColor = _colors.SidebarHover;
                    button.FlatAppearance.MouseDownBackColor = _colors.SidebarActive;
                }
                else if (tag == "primary")
                {
                    button.BackColor = _colors.Primary;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(_colors.Primary, 0.15f);
                    button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(_colors.Primary, 0.1f);
                }
                else if (tag == "danger")
                {
                    button.BackColor = _colors.Danger;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(_colors.Danger, 0.15f);
                    button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(_colors.Danger, 0.1f);
                }
                else if (tag == "secondary")
                {
                    button.BackColor = _colors.Background;
                    button.ForeColor = _colors.Text;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = _colors.Border;
                }
                else
                {
                    button.BackColor = _colors.Surface;
                    button.ForeColor = _colors.Text;
                }
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

        }
    }
}