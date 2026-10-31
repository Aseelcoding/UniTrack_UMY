namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucTasks
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
            lblTasksTitle = new Label();
            lvTasks = new ListView();
            colTask = new ColumnHeader();
            colCourse = new ColumnHeader();
            colDueDate = new ColumnHeader();
            colStatus = new ColumnHeader();
            btnAddTask = new Button();
            btnDeleteTask = new Button();
            lblTasksDescription = new Label();
            cmbCourseFilter = new ComboBox();
            SuspendLayout();
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTasksTitle.Location = new Point(20, 20);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Size = new Size(400, 54);
            lblTasksTitle.TabIndex = 0;
            lblTasksTitle.Text = "My Tasks";
            // 
            // lvTasks
            // 
            lvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvTasks.Columns.AddRange(new ColumnHeader[] { colTask, colCourse, colDueDate, colStatus });
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = true;
            lvTasks.Location = new Point(17, 183);
            lvTasks.MultiSelect = false;
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(1038, 502);
            lvTasks.TabIndex = 1;
            lvTasks.UseCompatibleStateImageBehavior = false;
            lvTasks.View = View.Details;
            lvTasks.DoubleClick += lvTasks_DoubleClick;
            // 
            // colTask
            // 
            colTask.Text = "Task";
            colTask.Width = 400;
            // 
            // colCourse
            // 
            colCourse.Text = "Course";
            colCourse.Width = 350;
            // 
            // colDueDate
            // 
            colDueDate.Text = "Due Date";
            colDueDate.Width = 150;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            colStatus.Width = 100;
            // 
            // btnAddTask
            // 
            btnAddTask.Cursor = Cursors.Hand;
            btnAddTask.Location = new Point(17, 691);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(140, 42);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Cursor = Cursors.Hand;
            btnDeleteTask.Location = new Point(172, 691);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(140, 42);
            btnDeleteTask.TabIndex = 3;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // lblTasksDescription
            // 
            lblTasksDescription.AutoSize = true;
            lblTasksDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblTasksDescription.Location = new Point(44, 74);
            lblTasksDescription.Name = "lblTasksDescription";
            lblTasksDescription.Size = new Size(281, 20);
            lblTasksDescription.TabIndex = 4;
            lblTasksDescription.Text = "Manage assignments and track deadlines";
            lblTasksDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbCourseFilter
            // 
            cmbCourseFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourseFilter.FormattingEnabled = true;
            cmbCourseFilter.Location = new Point(419, 149);
            cmbCourseFilter.Name = "cmbCourseFilter";
            cmbCourseFilter.Size = new Size(351, 28);
            cmbCourseFilter.TabIndex = 5;
            cmbCourseFilter.SelectedIndexChanged += cmbCourseFilter_SelectedIndexChanged;
            // 
            // ucTasks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(cmbCourseFilter);
            Controls.Add(lblTasksDescription);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnAddTask);
            Controls.Add(lvTasks);
            Controls.Add(lblTasksTitle);
            Name = "ucTasks";
            Size = new Size(1100, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTasksTitle;
        private ListView lvTasks;
        private ColumnHeader colTask;
        private ColumnHeader colCourse;
        private ColumnHeader colDueDate;
        private ColumnHeader colStatus;
        private Button btnAddTask;
        private Button btnDeleteTask;
        private Label lblTasksDescription;
        private ComboBox cmbCourseFilter;
    }
}
