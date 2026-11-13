
namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucSettings
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.Label lblSettingsDescription;

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlSettingsCard;
        private System.Windows.Forms.TableLayoutPanel tlpSettings;

        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnSaveSettings;

        private System.Windows.Forms.GroupBox grpAI;
        private System.Windows.Forms.Label lblAIModel;
        private System.Windows.Forms.ComboBox cmbAIModel;
        private System.Windows.Forms.Button btnAIRefresh;
        private System.Windows.Forms.Button btnAITest;
        private System.Windows.Forms.Label lblAIStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSettingsTitle = new System.Windows.Forms.Label();
            this.lblSettingsDescription = new System.Windows.Forms.Label();

            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlSettingsCard = new System.Windows.Forms.Panel();
            this.tlpSettings = new System.Windows.Forms.TableLayoutPanel();

            this.lblTheme = new System.Windows.Forms.Label();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();

            this.grpAI = new System.Windows.Forms.GroupBox();
            this.lblAIModel = new System.Windows.Forms.Label();
            this.cmbAIModel = new System.Windows.Forms.ComboBox();
            this.btnAIRefresh = new System.Windows.Forms.Button();
            this.btnAITest = new System.Windows.Forms.Button();
            this.lblAIStatus = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlSettingsCard.SuspendLayout();
            this.tlpSettings.SuspendLayout();
            this.grpAI.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 105;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);

            this.pnlHeader.Controls.Add(this.lblSettingsTitle);
            this.pnlHeader.Controls.Add(this.lblSettingsDescription);

            // 
            // lblSettingsTitle
            // 
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new System.Drawing.Font(
                "Segoe UI", 21F,
                System.Drawing.FontStyle.Bold);

            this.lblSettingsTitle.Location = new System.Drawing.Point(0, 5);
            this.lblSettingsTitle.Text = "Settings";

            // 
            // lblSettingsDescription
            // 
            this.lblSettingsDescription.AutoSize = true;
            this.lblSettingsDescription.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F);

            this.lblSettingsDescription.Location = new System.Drawing.Point(3, 55);
            this.lblSettingsDescription.Text =
                "Manage your application preferences and AI configuration";

            this.lblSettingsDescription.Tag = "muted";

            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(24, 12, 24, 24);

            this.pnlBody.Controls.Add(this.pnlSettingsCard);

            // 
            // pnlSettingsCard
            // 
            this.pnlSettingsCard.Location = new System.Drawing.Point(24, 12);
            this.pnlSettingsCard.Size = new System.Drawing.Size(680, 510);
            this.pnlSettingsCard.Padding = new System.Windows.Forms.Padding(24);
            this.pnlSettingsCard.Tag = "card";

            this.pnlSettingsCard.Controls.Add(this.tlpSettings);

            // 
            // tlpSettings
            // 
            this.tlpSettings.ColumnCount = 2;
            this.tlpSettings.RowCount = 4;
            this.tlpSettings.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tlpSettings.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Absolute, 160F));

            this.tlpSettings.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tlpSettings.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 65F));

            this.tlpSettings.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 65F));

            this.tlpSettings.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 65F));

            this.tlpSettings.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tlpSettings.Controls.Add(this.lblTheme, 0, 0);
            this.tlpSettings.Controls.Add(this.cmbTheme, 1, 0);
            this.tlpSettings.Controls.Add(this.lblLanguage, 0, 1);
            this.tlpSettings.Controls.Add(this.cmbLanguage, 1, 1);
            this.tlpSettings.Controls.Add(this.btnSaveSettings, 1, 2);
            this.tlpSettings.Controls.Add(this.grpAI, 0, 3);

            this.tlpSettings.SetColumnSpan(this.grpAI, 2);

            // 
            // lblTheme
            // 
            this.lblTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTheme.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 10.5F,
                System.Drawing.FontStyle.Bold);

            this.lblTheme.Text = "Appearance";
            this.lblTheme.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // cmbTheme
            // 
            this.cmbTheme.Anchor =
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.cmbTheme.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbTheme.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbTheme.Size = new System.Drawing.Size(400, 30);

            // 
            // lblLanguage
            // 
            this.lblLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLanguage.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 10.5F,
                System.Drawing.FontStyle.Bold);

            this.lblLanguage.Text = "Language";
            this.lblLanguage.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor =
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.cmbLanguage.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbLanguage.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbLanguage.Size = new System.Drawing.Size(400, 30);

            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor =
                System.Windows.Forms.AnchorStyles.Left;

            this.btnSaveSettings.Size = new System.Drawing.Size(165, 40);
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 9.5F,
                System.Drawing.FontStyle.Bold);

            this.btnSaveSettings.Tag = "primary";
            this.btnSaveSettings.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnSaveSettings.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSaveSettings.FlatAppearance.BorderSize = 0;

            this.btnSaveSettings.Click +=
                new System.EventHandler(this.btnSaveSettings_Click);

            // 
            // grpAI
            // 
            this.grpAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAI.Padding = new System.Windows.Forms.Padding(18);
            this.grpAI.Text = "AI Configuration  |  Ollama";

            this.grpAI.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 10F,
                System.Drawing.FontStyle.Bold);

            this.grpAI.Controls.Add(this.lblAIModel);
            this.grpAI.Controls.Add(this.cmbAIModel);
            this.grpAI.Controls.Add(this.btnAIRefresh);
            this.grpAI.Controls.Add(this.btnAITest);
            this.grpAI.Controls.Add(this.lblAIStatus);

            // 
            // lblAIModel
            // 
            this.lblAIModel.AutoSize = true;
            this.lblAIModel.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F);

            this.lblAIModel.Location = new System.Drawing.Point(20, 42);
            this.lblAIModel.Text = "Selected Model";

            // 
            // cmbAIModel
            // 
            this.cmbAIModel.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbAIModel.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbAIModel.Location = new System.Drawing.Point(20, 70);
            this.cmbAIModel.Size = new System.Drawing.Size(390, 30);

            this.cmbAIModel.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.cmbAIModel.SelectedIndexChanged +=
                new System.EventHandler(this.cmbAIModel_SelectedIndexChanged);

            // 
            // btnAIRefresh
            // 
            this.btnAIRefresh.Location = new System.Drawing.Point(20, 120);
            this.btnAIRefresh.Size = new System.Drawing.Size(105, 36);
            this.btnAIRefresh.Text = "Refresh";
            this.btnAIRefresh.Tag = "secondary";
            this.btnAIRefresh.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnAIRefresh.Click +=
                new System.EventHandler(this.btnAIRefresh_Click);

            // 
            // btnAITest
            // 
            this.btnAITest.Location = new System.Drawing.Point(135, 120);
            this.btnAITest.Size = new System.Drawing.Size(155, 36);
            this.btnAITest.Text = "Test Connection";
            this.btnAITest.Tag = "primary";
            this.btnAITest.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnAITest.Click +=
                new System.EventHandler(this.btnAITest_ClickAsync);

            // 
            // lblAIStatus
            // 
            this.lblAIStatus.AutoSize = true;
            this.lblAIStatus.Font = new System.Drawing.Font(
                "Segoe UI", 9F);

            this.lblAIStatus.Location = new System.Drawing.Point(20, 170);
            this.lblAIStatus.Text = "Connection status: Not tested";
            this.lblAIStatus.Tag = "muted";

            // 
            // ucSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucSettings";
            this.Size = new System.Drawing.Size(1100, 750);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.pnlBody.ResumeLayout(false);
            this.pnlSettingsCard.ResumeLayout(false);
            this.tlpSettings.ResumeLayout(false);

            this.grpAI.ResumeLayout(false);
            this.grpAI.PerformLayout();

            this.ResumeLayout(false);
        }
    }
}
