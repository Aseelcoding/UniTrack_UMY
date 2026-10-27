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
            lblSettingsTitle = new Label();
            lblTheme = new Label();
            cmbTheme = new ComboBox();
            cmbLanguage = new ComboBox();
            lblLanguage = new Label();
            btnSaveSettings = new Button();
            SuspendLayout();
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSettingsTitle.Location = new Point(20, 20);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(400, 53);
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "Settings";
            // 
            // lblTheme
            // 
            lblTheme.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTheme.Location = new Point(20, 90);
            lblTheme.Name = "lblTheme";
            lblTheme.Size = new Size(200, 30);
            lblTheme.TabIndex = 1;
            lblTheme.Text = "Appearance";
            // 
            // cmbTheme
            // 
            cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTheme.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbTheme.FormattingEnabled = true;
            cmbTheme.Location = new Point(239, 90);
            cmbTheme.Name = "cmbTheme";
            cmbTheme.Size = new Size(250, 31);
            cmbTheme.TabIndex = 2;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(239, 156);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(250, 31);
            cmbLanguage.TabIndex = 4;
            // 
            // lblLanguage
            // 
            lblLanguage.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLanguage.Location = new Point(20, 156);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(200, 30);
            lblLanguage.TabIndex = 3;
            lblLanguage.Text = "Language";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Cursor = Cursors.Hand;
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.Location = new Point(20, 238);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(160, 42);
            btnSaveSettings.TabIndex = 5;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // ucSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(btnSaveSettings);
            Controls.Add(cmbLanguage);
            Controls.Add(lblLanguage);
            Controls.Add(cmbTheme);
            Controls.Add(lblTheme);
            Controls.Add(lblSettingsTitle);
            Name = "ucSettings";
            Size = new Size(742, 598);
            ResumeLayout(false);
        }

        #endregion

        private Label lblSettingsTitle;
        private Label lblTheme;
        private ComboBox cmbTheme;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
        private Button btnSaveSettings;
    }
}
