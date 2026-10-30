namespace UniTrack_UMY.WinForms.Forms
{
    partial class frmAddTask
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblCourse = new Label();
            cmbCourse = new ComboBox();
            cmbType = new ComboBox();
            lblType = new Label();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(78, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Task Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(30, 60);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(420, 30);
            txtTitle.TabIndex = 1;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(30, 110);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(63, 23);
            lblCourse.TabIndex = 2;
            lblCourse.Text = "Course";
            // 
            // cmbCourse
            // 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(30, 135);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(420, 31);
            cmbCourse.TabIndex = 2;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(30, 210);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(420, 31);
            cmbType.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(30, 185);
            lblType.Name = "lblType";
            lblType.Size = new Size(81, 23);
            lblType.TabIndex = 4;
            lblType.Text = "Task Type";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(30, 260);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(82, 23);
            lblDueDate.TabIndex = 6;
            lblDueDate.Text = "Due Date";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(30, 285);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.ShowCheckBox = true;
            dtpDueDate.Size = new Size(320, 30);
            dtpDueDate.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 125, 90);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(34, 349);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 40);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save Task";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(220, 80, 80);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(169, 349);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddTask
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(542, 429);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpDueDate);
            Controls.Add(lblDueDate);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(cmbCourse);
            Controls.Add(lblCourse);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(560, 476);
            MinimumSize = new Size(560, 476);
            Name = "frmAddTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblCourse;
        private ComboBox cmbCourse;
        private ComboBox cmbType;
        private Label lblType;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnSave;
        private Button btnCancel;
    }
}