
namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucAIAssistant
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlHeaderInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.RichTextBox rtbTranscript;

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlInputContainer;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            pnlHeaderInfo = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblModel = new Label();
            cmbModel = new ComboBox();
            btnRefresh = new Button();
            lblStatus = new Label();
            rtbTranscript = new RichTextBox();
            pnlBottom = new Panel();
            pnlInputContainer = new Panel();
            txtInput = new TextBox();
            pnlButtons = new Panel();
            btnSend = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            pnlTop.SuspendLayout();
            pnlHeaderInfo.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlInputContainer.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(pnlHeaderInfo);
            pnlTop.Controls.Add(lblModel);
            pnlTop.Controls.Add(cmbModel);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lblStatus);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(18, 10, 18, 10);
            pnlTop.Size = new Size(900, 82);
            pnlTop.TabIndex = 2;
            // 
            // pnlHeaderInfo
            // 
            pnlHeaderInfo.Controls.Add(lblTitle);
            pnlHeaderInfo.Controls.Add(lblSubtitle);
            pnlHeaderInfo.Dock = DockStyle.Left;
            pnlHeaderInfo.Location = new Point(18, 10);
            pnlHeaderInfo.Name = "pnlHeaderInfo";
            pnlHeaderInfo.Size = new Size(190, 62);
            pnlHeaderInfo.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(149, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "AI Assistant";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblSubtitle.ForeColor = SystemColors.GrayText;
            lblSubtitle.Location = new Point(2, 34);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(191, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Tag = "muted";
            lblSubtitle.Text = "Your personal AI workspace";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblModel.Location = new Point(229, 29);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(57, 20);
            lblModel.TabIndex = 1;
            lblModel.Text = "Model:";
            // 
            // cmbModel
            // 
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.Font = new Font("Segoe UI", 9F);
            cmbModel.Location = new Point(292, 25);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(230, 28);
            cmbModel.TabIndex = 2;
            cmbModel.SelectedIndexChanged += cmbModel_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 8.5F);
            btnRefresh.Location = new Point(538, 24);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(85, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Tag = "secondary";
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.Location = new Point(629, 33);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(63, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Tag = "muted";
            lblStatus.Text = "● Ready";
            // 
            // rtbTranscript
            // 
            rtbTranscript.BorderStyle = BorderStyle.None;
            rtbTranscript.Dock = DockStyle.Fill;
            rtbTranscript.Font = new Font("Segoe UI", 10F);
            rtbTranscript.HideSelection = false;
            rtbTranscript.Location = new Point(0, 82);
            rtbTranscript.Margin = new Padding(0);
            rtbTranscript.Name = "rtbTranscript";
            rtbTranscript.ReadOnly = true;
            rtbTranscript.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbTranscript.Size = new Size(900, 373);
            rtbTranscript.TabIndex = 0;
            rtbTranscript.Text = "";
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(pnlInputContainer);
            pnlBottom.Controls.Add(pnlButtons);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 455);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(16, 10, 16, 14);
            pnlBottom.Size = new Size(900, 145);
            pnlBottom.TabIndex = 1;
            // 
            // pnlInputContainer
            // 
            pnlInputContainer.Controls.Add(txtInput);
            pnlInputContainer.Dock = DockStyle.Fill;
            pnlInputContainer.Location = new Point(16, 10);
            pnlInputContainer.Name = "pnlInputContainer";
            pnlInputContainer.Padding = new Padding(10);
            pnlInputContainer.Size = new Size(743, 121);
            pnlInputContainer.TabIndex = 0;
            pnlInputContainer.Tag = "card";
            // 
            // txtInput
            // 
            txtInput.AcceptsReturn = true;
            txtInput.BorderStyle = BorderStyle.None;
            txtInput.Dock = DockStyle.Fill;
            txtInput.Font = new Font("Segoe UI", 10F);
            txtInput.Location = new Point(10, 10);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(723, 101);
            txtInput.TabIndex = 0;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnSend);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Dock = DockStyle.Right;
            pnlButtons.Location = new Point(759, 10);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(10, 0, 0, 0);
            pnlButtons.Size = new Size(125, 121);
            pnlButtons.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Cursor = Cursors.Hand;
            btnSend.Dock = DockStyle.Top;
            btnSend.Enabled = false;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.Location = new Point(10, 68);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(115, 34);
            btnSend.TabIndex = 0;
            btnSend.Tag = "primary";
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Dock = DockStyle.Top;
            btnCancel.Enabled = false;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.Location = new Point(10, 34);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 34);
            btnCancel.TabIndex = 1;
            btnCancel.Tag = "danger";
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Dock = DockStyle.Top;
            btnClear.Font = new Font("Segoe UI", 9F);
            btnClear.Location = new Point(10, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(115, 34);
            btnClear.TabIndex = 2;
            btnClear.Tag = "secondary";
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // ucAIAssistant
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(rtbTranscript);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Name = "ucAIAssistant";
            Size = new Size(900, 600);
            Load += ucAIAssistant_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlHeaderInfo.ResumeLayout(false);
            pnlHeaderInfo.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlInputContainer.ResumeLayout(false);
            pnlInputContainer.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private CheckBox chkIncludeContext;
    }
}
