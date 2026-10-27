
using System;
using System.Windows.Forms;
using UniTrack_UMY.WinForms.Forms;

namespace UniTrack_UMY.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}
