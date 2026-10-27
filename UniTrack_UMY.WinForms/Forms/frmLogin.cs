
using System;
using System.Windows.Forms;

namespace UniTrack_UMY.WinForms.Forms
{
    public partial class frmLogin : Form
    {
        private bool _loginDetected;

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

                webViewLogin.CoreWebView2.NavigationCompleted +=
                    CoreWebView2_NavigationCompleted;

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

        private void CoreWebView2_NavigationCompleted(
            object? sender,
            Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess || _loginDetected)
                return;

            string url = webViewLogin.Source?.AbsoluteUri ?? "";

            bool isLoggedIn =
                url.Contains("/my/") ||
                url.Contains("/course/") ||
                url.Contains("courses.php");

            if (!isLoggedIn)
                return;

            _loginDetected = true;

            MessageBox.Show(
                "Login detected successfully.",
                "UniTrack",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
