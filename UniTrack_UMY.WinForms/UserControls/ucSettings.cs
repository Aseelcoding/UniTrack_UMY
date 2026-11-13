
using System;
using System.Windows.Forms;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using UniTrack_UMY.WinForms.Forms;
using UniTrack_UMY.WinForms.Services;
using UniTrack_UMY.Core.AI;
using UniTrack_UMY.Infrastructure.AI;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucSettings : UserControl
    {
        private readonly SettingsService _settingsService;
        private AppSettings _settings;
        private IAIService? _aiService;
        private AISettingsService? _aiSettings;
        private AISettings _aiState = new();


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

            ApplyLanguage();
        }
        private void cmbAIModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_aiSettings == null) return;
            string text = cmbAIModel.SelectedItem?.ToString() ?? "";
            int i = text.IndexOf("  (", StringComparison.Ordinal);
            string name = i > 0 ? text[..i] : text;
            if (string.IsNullOrWhiteSpace(name)) return;

            _aiState.SelectedModel = name;
            _aiSettings.Save(_aiState);

            bool large = name.Contains("27b", StringComparison.OrdinalIgnoreCase);
            lblAIStatus.Text = large
                ? "⚠ Large model — slow on this CPU-only laptop."
                : "Saved.";
            lblAIStatus.ForeColor = large ? Color.DarkOrange : Color.SeaGreen;
        }

        private async void btnAIRefresh_Click(object sender, EventArgs e) => await RefreshAIModelsAsync();

        private async void btnAITest_ClickAsync(object sender, EventArgs e)
        {
            if (_aiService == null) return;
            AIConnectionState st = await _aiService.GetConnectionStateAsync();
            lblAIStatus.Text = st.Message;
            lblAIStatus.ForeColor = st.IsConnected ? Color.SeaGreen : Color.Firebrick;
        }
        private async Task RefreshAIModelsAsync()
        {
            if (_aiService == null) return;
            IReadOnlyList<AIModelInfo> models = await _aiService.ListModelsAsync();
            cmbAIModel.Items.Clear();
            foreach (var m in models) cmbAIModel.Items.Add($"{m.Name}  ({m.SizeDisplay})");

            string target = !string.IsNullOrWhiteSpace(_aiState.SelectedModel)
                ? _aiState.SelectedModel
                : (_aiSettings?.SuggestDefaultModel(models) ?? string.Empty);

            for (int i = 0; i < models.Count; i++)
                if (string.Equals(models[i].Name, target, StringComparison.OrdinalIgnoreCase))
                { cmbAIModel.SelectedIndex = i; break; }

            if (cmbAIModel.SelectedIndex < 0 && cmbAIModel.Items.Count > 0)
                cmbAIModel.SelectedIndex = 0;

            lblAIStatus.Text = models.Count == 0
                ? "Ollama not running or no models installed."
                : $"{models.Count} model(s) available.";
        }
        public void AttachAI(IAIService aiService, AISettingsService settingsService)
        {
            _aiService = aiService;
            _aiSettings = settingsService;
            _aiState = _aiSettings.Load();
            _ = RefreshAIModelsAsync();
        }
        private void ApplyLanguage()
        {
            bool isIndonesian =
                _settings.Language == AppLanguage.Indonesian;

            lblSettingsTitle.Text = isIndonesian
                ? "Pengaturan"
                : "Settings";
            lblSettingsDescription.Text = isIndonesian
    ? "Sesuaikan preferensi Anda"
    : "Customize your preferences";
            lblTheme.Text = isIndonesian
                ? "Tampilan"
                : "Appearance";

            lblLanguage.Text = isIndonesian
                ? "Bahasa"
                : "Language";

            btnSaveSettings.Text = isIndonesian
                ? "Simpan Pengaturan"
                : "Save Settings";
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            _settings.Theme = (AppTheme)cmbTheme.SelectedIndex;
            _settings.Language = (AppLanguage)cmbLanguage.SelectedIndex;

            Form mainForm = FindForm();

            if (mainForm is frmMain frm)
            {
                frm.ApplySettings(_settings);
            }
            else
            {
                _settingsService.Save(_settings);
            }

            ApplyLanguage();
        }
    }
}
