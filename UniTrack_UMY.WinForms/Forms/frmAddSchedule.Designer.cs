
namespace UniTrack_UMY.WinForms.Forms
{
    partial class frmAddSchedule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblTitle = new Label();
            lblCourseName = new Label();
            lblDay = new Label();
            cmbDay = new ComboBox();
            lblStartTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpEndTime = new DateTimePicker();
            lblLocation = new Label();
            txtLocation = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            cmbCourseName = new ComboBox();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(cmbCourseName);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(lblCourseName);
            pnlMain.Controls.Add(lblDay);
            pnlMain.Controls.Add(cmbDay);
            pnlMain.Controls.Add(lblStartTime);
            pnlMain.Controls.Add(dtpStartTime);
            pnlMain.Controls.Add(lblEndTime);
            pnlMain.Controls.Add(dtpEndTime);
            pnlMain.Controls.Add(lblLocation);
            pnlMain.Controls.Add(txtLocation);
            pnlMain.Controls.Add(btnSave);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(25);
            pnlMain.Size = new Size(470, 540);
            pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(35, 45, 60);
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Class";
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Location = new Point(28, 85);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(114, 23);
            lblCourseName.TabIndex = 1;
            lblCourseName.Text = "Course Name";
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Location = new Point(28, 155);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(39, 23);
            lblDay.TabIndex = 3;
            lblDay.Text = "Day";
            // 
            // cmbDay
            // 
            cmbDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDay.Font = new Font("Segoe UI", 10F);
            cmbDay.Location = new Point(28, 180);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(390, 31);
            cmbDay.TabIndex = 4;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(28, 225);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(87, 23);
            lblStartTime.TabIndex = 5;
            lblStartTime.Text = "Start Time";
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(28, 250);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(390, 30);
            dtpStartTime.TabIndex = 6;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(28, 295);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(81, 23);
            lblEndTime.TabIndex = 7;
            lblEndTime.Text = "End Time";
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(28, 320);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(390, 30);
            dtpEndTime.TabIndex = 8;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(28, 365);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(75, 23);
            lblLocation.TabIndex = 9;
            lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Segoe UI", 10F);
            txtLocation.Location = new Point(28, 390);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(390, 30);
            txtLocation.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(55, 110, 190);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 10F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(28, 455);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(185, 42);
            btnSave.TabIndex = 11;
            btnSave.Tag = "primary";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(230, 233, 238);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F);
            btnCancel.ForeColor = Color.FromArgb(50, 60, 75);
            btnCancel.Location = new Point(233, 455);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(185, 42);
            btnCancel.TabIndex = 12;
            btnCancel.Tag = "danger";
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbCourseName
            // 
            cmbCourseName.FormattingEnabled = true;
            cmbCourseName.Location = new Point(28, 112);
            cmbCourseName.Name = "cmbCourseName";
            cmbCourseName.Size = new Size(390, 31);
            cmbCourseName.TabIndex = 13;
            // 
            // frmAddSchedule
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(470, 540);
            Controls.Add(pnlMain);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddSchedule";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Class";
            Load += frmAddSchedule_Load;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlMain;
        private Label lblTitle;

        private Label lblCourseName;

        private Label lblDay;
        private ComboBox cmbDay;

        private Label lblStartTime;
        private DateTimePicker dtpStartTime;

        private Label lblEndTime;
        private DateTimePicker dtpEndTime;

        private Label lblLocation;
        private TextBox txtLocation;

        private Button btnSave;
        private Button btnCancel;
        private ComboBox cmbCourseName;
    }
}
