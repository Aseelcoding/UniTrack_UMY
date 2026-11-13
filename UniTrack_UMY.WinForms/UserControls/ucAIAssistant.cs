using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniTrack_UMY.Core.AcademicContext;
using UniTrack_UMY.Core.AI;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.AcademicContext;
using UniTrack_UMY.Infrastructure.AI;

namespace UniTrack_UMY.WinForms.UserControls
{
    public partial class ucAIAssistant : UserControl
    {
        private readonly IAIService _aiService;
        private readonly AISettingsService _settingsService;
        private readonly List<AIChatMessage> _conversation = new();
        private CancellationTokenSource? _streamCts;
        private AISettings _settings = new();
        private bool _busy;

    
        private readonly List<TaskItem> _tasks;
        private readonly List<Course> _courses;
        private readonly List<ScheduleItem> _schedule;

        // Required by the WinForms Designer.
        public ucAIAssistant()
        {
            InitializeComponent();
            InitializeContextCheckBox();
        }

        public ucAIAssistant(
            IAIService aiService,
            AISettingsService settingsService,
            List<TaskItem> tasks = null,
            List<Course> courses = null,
            List<ScheduleItem> schedule = null)
            : this()
        {
            _aiService = aiService ?? throw new ArgumentNullException(nameof(aiService));
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));

            _tasks = tasks ?? new List<TaskItem>();
            _courses = courses ?? new List<Course>();
            _schedule = schedule ?? new List<ScheduleItem>();

            _settings = _settingsService.Load();
        }

        private void InitializeContextCheckBox()
        {
            chkIncludeContext = new CheckBox
            {
                Text = "Include My Tasks & Schedule",
                AutoSize = true,
                Checked = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };

         
            this.pnlBottom.Controls.Add(chkIncludeContext);
      
            chkIncludeContext.Location = new Point(8, pnlBottom.Height - 25);
            chkIncludeContext.BringToFront();
        }

        private async void ucAIAssistant_Load(object sender, EventArgs e)
        {
            if (DesignMode || _aiService == null) return;
            await RefreshModelsAsync().ConfigureAwait(true);
        }

        private async Task RefreshModelsAsync()
        {
            SetStatus("…", Color.Gray);
            IReadOnlyList<AIModelInfo> models = await _aiService
                .ListModelsAsync().ConfigureAwait(true);

            cmbModel.Items.Clear();
            foreach (AIModelInfo m in models)
                cmbModel.Items.Add($"{m.Name}  ({m.SizeDisplay})");

            if (models.Count == 0)
            {
                SetStatus("Ollama not running or no models installed.", Color.Firebrick);
                btnSend.Enabled = false;
                return;
            }

            string? selected = !string.IsNullOrWhiteSpace(_settings.SelectedModel)
                ? _settings.SelectedModel
                : _settingsService.SuggestDefaultModel(models);

            for (int i = 0; i < models.Count; i++)
            {
                if (string.Equals(models[i].Name, selected,
                    StringComparison.OrdinalIgnoreCase))
                {
                    cmbModel.SelectedIndex = i;
                    break;
                }
            }
            if (cmbModel.SelectedIndex < 0 && cmbModel.Items.Count > 0)
                cmbModel.SelectedIndex = 0;

            SetStatus("Connected", Color.SeaGreen);
            btnSend.Enabled = true;
        }

        private string SelectedModelName()
        {
            if (cmbModel.SelectedIndex < 0) return string.Empty;
            string text = cmbModel.SelectedItem?.ToString() ?? string.Empty;
            int spaceIdx = text.IndexOf("  (", StringComparison.Ordinal);
            return spaceIdx > 0 ? text[..spaceIdx] : text;
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_settingsService == null) return;
            string name = SelectedModelName();
            if (string.IsNullOrWhiteSpace(name)) return;
            _settings.SelectedModel = name;
            _settingsService.Save(_settings);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_busy) return;
            await RefreshModelsAsync().ConfigureAwait(true);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (_busy) return;
            string text = txtInput.Text.Trim();
            if (text.Length == 0) return;
            string model = SelectedModelName();
            if (string.IsNullOrWhiteSpace(model))
            {
                AppendSystem("No model selected.");
                return;
            }

            _busy = true;
            btnSend.Enabled = false;
            btnCancel.Enabled = true;
            txtInput.Clear();

            _conversation.Add(AIChatMessage.User(text));
            AppendLine("You", text, Color.SteelBlue);

            var opts = new AIChatOptions
            {
                ModelName = model,
                Temperature = 0.3,
                Timeout = TimeSpan.FromMinutes(5)
            };

            var messagesToSend = new List<AIChatMessage>(_conversation);

            if (chkIncludeContext != null && chkIncludeContext.Checked)
            {
                AppendSystem("[Building academic context...]");
                try
                {
                    var contextBuilder = new AcademicContextBuilder(_tasks, _courses, _schedule);
                    var context = await contextBuilder.BuildAsync(text, new AcademicContextOptions());

                    if (context.HasData)
                    {
                        string promptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AI", "PromptTemplates", "AcademicAssistantSystemPrompt.txt");
                        string systemPrompt = File.Exists(promptPath)
                            ? File.ReadAllText(promptPath)
                            : "You are a helpful academic assistant.";

                        string fullSystemPrompt = systemPrompt + "\n\n" + context.SerializedData;

                        messagesToSend.Insert(0, AIChatMessage.System(fullSystemPrompt));

                        AppendSystem($"[Context injected: {context.TaskCount} tasks, {context.ScheduleItemCount} schedule items]");
                    }
                }
                catch (Exception ex)
                {
                    AppendSystem($"[Warning: Could not build context - {ex.Message}]");
                }
            }

            _streamCts = new CancellationTokenSource();
            var assistant = new System.Text.StringBuilder();
            AppendLine("Assistant", "", Color.SeaGreen);
            try
            {
                await foreach (AIChatChunk chunk in _aiService
                    .StreamChatAsync(messagesToSend, opts, _streamCts.Token)
                    .ConfigureAwait(true))
                {
                    if (!string.IsNullOrEmpty(chunk.Content))
                    {
                        assistant.Append(chunk.Content);
                        AppendInline(chunk.Content);
                    }
                }
                if (assistant.Length > 0)
                {
                    _conversation.Add(AIChatMessage.Assistant(assistant.ToString()));
                }
                AppendInline(Environment.NewLine);
            }
            catch (OperationCanceledException)
            {
                AppendInline(Environment.NewLine);
                AppendSystem("[cancelled]");
            }
            catch (Exception ex)
            {
                AppendInline(Environment.NewLine);
                AppendSystem("Error: " + ex.Message);
            }
            finally
            {
                _streamCts?.Dispose();
                _streamCts = null;
                _busy = false;
                btnSend.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _streamCts?.Cancel();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _conversation.Clear();
            rtbTranscript.Clear();
            AppendSystem("Conversation cleared.");
        }

        private void SetStatus(string text, Color color)
        {
            lblStatus.Text = text;
            lblStatus.ForeColor = color;
        }

        private void AppendLine(string who, string text, Color color)
        {
            rtbTranscript.SelectionStart = rtbTranscript.TextLength;
            rtbTranscript.SelectionColor = color;
            rtbTranscript.SelectionFont = new Font(rtbTranscript.Font, FontStyle.Bold);
            rtbTranscript.AppendText(who + ": ");
            rtbTranscript.SelectionFont = new Font(rtbTranscript.Font, FontStyle.Regular);
            rtbTranscript.SelectionColor = rtbTranscript.ForeColor;
            rtbTranscript.AppendText(text + Environment.NewLine);
            rtbTranscript.SelectionStart = rtbTranscript.TextLength;
            rtbTranscript.ScrollToCaret();
        }

        private void AppendInline(string text)
        {
            rtbTranscript.SelectionStart = rtbTranscript.TextLength;
            rtbTranscript.SelectionColor = rtbTranscript.ForeColor;
            rtbTranscript.AppendText(text);
            rtbTranscript.SelectionStart = rtbTranscript.TextLength;
            rtbTranscript.ScrollToCaret();
        }

        private void AppendSystem(string text)
        {
            rtbTranscript.SelectionStart = rtbTranscript.TextLength;
            rtbTranscript.SelectionColor = Color.DarkOrange;
            rtbTranscript.AppendText(text + Environment.NewLine);
            rtbTranscript.SelectionStart = rtbTranscript.TextLength;
            rtbTranscript.ScrollToCaret();
        }
    }
}