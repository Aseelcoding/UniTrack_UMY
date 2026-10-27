using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Forms;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucSettings : UserControl
    {
        private readonly SettingsService _settingsService;
        private AppSettings _settings;
      

        public ucSettings()
        {
            InitializeComponent();
            _settingsService = new SettingsService();
            _settings = _settingsService.Load();

            cmbTheme.Items.Clear();
            cmbTheme.Items.Add("Light");
            cmbTheme.Items.Add("Dark");

            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add("English");
            cmbLanguage.Items.Add("Bahasa Indonesia");
            cmbTheme.SelectedIndex = (int)_settings.Theme;
            cmbLanguage.SelectedIndex = (int)_settings.Language;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            _settings.Theme = (AppTheme)cmbTheme.SelectedIndex;
            _settings.Language = (AppLanguage)cmbLanguage.SelectedIndex;

            Form mainForm = this.FindForm();

            if (mainForm is frmMain frm)
            {
                frm.ApplySettings(_settings);
            }
            else
            {
                _settingsService.Save(_settings);
            }
        }
    }
}
