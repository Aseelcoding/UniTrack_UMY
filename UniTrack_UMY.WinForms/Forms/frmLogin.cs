
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Services;

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
                    "https://myklass-eng.umy.ac.id/login/index.php");
            }
            catch (Exception ex)
            {
                ShowError("Failed to open MyKlass", ex);
            }
        }

        private async void CoreWebView2_NavigationCompleted(
            object? sender,
            CoreWebView2NavigationCompletedEventArgs e)
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

            await Task.Delay(3000);

            try
            {
                string result =
                    await webViewLogin.CoreWebView2.ExecuteScriptAsync(
                        "document.documentElement.outerHTML");

                string html =
                    JsonSerializer.Deserialize<string>(result) ?? "";

                var parser = new CourseParser();
                List<Course> courses = parser.ParseCourses(html);

                if (courses.Count == 0)
                {
                    _loginDetected = false;

                    MessageBox.Show(
                        "Login detected, but no courses were found on this page.",
                        "UniTrack",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                Hide();

                var htmlFetcher = new WebViewHtmlFetcher(webViewLogin);
                var mainForm = new frmMain(courses, htmlFetcher);

                mainForm.FormClosed += (s, args) =>
                {
                    Close();
                };
                mainForm.BringToFront();
                mainForm.Show();
                
            }
            catch (Exception ex)
            {
                _loginDetected = false;
                ShowError("Failed to extract courses", ex);
            }
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show(
                $"{title}:{Environment.NewLine}{ex.Message}",
                "UniTrack",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
