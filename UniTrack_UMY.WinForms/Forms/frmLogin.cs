
using System;
using System.Windows.Forms;

namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            Load += frmLogin_Load;
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                await webViewLogin.EnsureCoreWebView2Async();

                webViewLogin.CoreWebView2.Navigate(
                    "https://myklass-eng.umy.ac.id/login/index.php"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to open MyKlass:\n{ex.Message}",
                    "UniTrack",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
