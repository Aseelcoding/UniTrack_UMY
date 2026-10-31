using System.Reflection.PortableExecutable;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSettingsTitle = new Label();
            lblSettingsDescription = new Label();
            pnlBody = new Panel();
            pnlSettingsCard = new Panel();
            tlpSettings = new TableLayoutPanel();
            lblTheme = new Label();
            cmbTheme = new ComboBox();
            lblLanguage = new Label();
            cmbLanguage = new ComboBox();
            btnSaveSettings = new Button();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlSettingsCard.SuspendLayout();
            tlpSettings.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblSettingsTitle);
            pnlHeader.Controls.Add(lblSettingsDescription);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 0, 0, 14);
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.Dock = DockStyle.Fill;
            lblSettingsTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "Settings";
            lblSettingsTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblSettingsDescription
            // 
            lblSettingsDescription.AutoSize = false;
            lblSettingsDescription.Dock = DockStyle.Bottom;
            lblSettingsDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblSettingsDescription.Name = "lblSettingsDescription";
            lblSettingsDescription.Size = new Size(1100, 28);
            lblSettingsDescription.TabIndex = 1;
            lblSettingsDescription.Tag = "muted";
            lblSettingsDescription.Text = "Customize your app preferences";
            lblSettingsDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlSettingsCard);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Name = "pnlBody";
            pnlBody.TabIndex = 1;
            // 
            // pnlSettingsCard
            // 
            pnlSettingsCard.BackColor = Color.White;
            pnlSettingsCard.Controls.Add(tlpSettings);
            pnlSettingsCard.Location = new Point(0, 0);
            pnlSettingsCard.Name = "pnlSettingsCard";
            pnlSettingsCard.Padding = new Padding(28, 24, 28, 24);
            pnlSettingsCard.Size = new Size(640, 270);
            pnlSettingsCard.TabIndex = 0;
            // 
            //
            // 
            tlpSettings.ColumnCount = 2;
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSettings.Controls.Add(lblTheme, 0, 0);
            tlpSettings.Controls.Add(cmbTheme, 1, 0);
            tlpSettings.Controls.Add(lblLanguage, 0, 1);
            tlpSettings.Controls.Add(cmbLanguage, 1, 1);
            tlpSettings.Controls.Add(btnSaveSettings, 0, 2);
            tlpSettings.Dock = DockStyle.Fill;
            tlpSettings.Name = "tlpSettings";
            tlpSettings.RowCount = 4;
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSettings.SetColumnSpan(btnSaveSettings, 2);
            tlpSettings.TabIndex = 0;
            // 
            // lblTheme
            // 
            lblTheme.Dock = DockStyle.Fill;
            lblTheme.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblTheme.Margin = new Padding(0);
            lblTheme.Name = "lblTheme";
            lblTheme.TabIndex = 0;
            lblTheme.Text = "Appearance";
            lblTheme.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTheme
            // 
            cmbTheme.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTheme.Font = new Font("Segoe UI", 10.5F);
            cmbTheme.FormattingEnabled = true;
            cmbTheme.Margin = new Padding(0);
            cmbTheme.Name = "cmbTheme";
            cmbTheme.TabIndex = 1;
            // 
            // lblLanguage
            // 
            lblLanguage.Dock = DockStyle.Fill;
            lblLanguage.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblLanguage.Margin = new Padding(0);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.TabIndex = 2;
            lblLanguage.Text = "Language";
            lblLanguage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbLanguage
            // 
            cmbLanguage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.Font = new Font("Segoe UI", 10.5F);
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Margin = new Padding(0);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.TabIndex = 3;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Anchor = AnchorStyles.Left;
            btnSaveSettings.BackColor = Color.FromArgb(55, 110, 190);
            btnSaveSettings.Cursor = Cursors.Hand;
            btnSaveSettings.FlatAppearance.BorderSize = 0;
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.Font = new Font("Segoe UI Semibold", 10.5F);
            btnSaveSettings.ForeColor = Color.White;
            btnSaveSettings.Margin = new Padding(0);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(170, 44);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Tag = "primary";
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = false;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // ucSettings
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlBody);     
            Controls.Add(pnlHeader);    
            Font = new Font("Segoe UI", 10F);
            Name = "ucSettings";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlSettingsCard.ResumeLayout(false);
            tlpSettings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlBody;
        private Panel pnlSettingsCard;
        private TableLayoutPanel tlpSettings;
        private Label lblSettingsTitle;
        private Label lblTheme;
        private ComboBox cmbTheme;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
        private Button btnSaveSettings;
        private Label lblSettingsDescription;
    }
}
