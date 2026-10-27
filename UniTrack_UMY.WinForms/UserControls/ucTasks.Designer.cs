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
            lvTasks.Location = new Point(20, 118);
            lvTasks.MultiSelect = false;
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(680, 350);
            lvTasks.TabIndex = 1;
            lvTasks.UseCompatibleStateImageBehavior = false;
            lvTasks.View = View.Details;
            // 
            // colTask
            // 
            colTask.Text = "Task";
            colTask.Width = 300;
            // 
            // colCourse
            // 
            colCourse.Text = "Course";
            colCourse.Width = 220;
            // 
            // colDueDate
            // 
            colDueDate.Text = "Due Date";
            colDueDate.Width = 180;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            colStatus.Width = 150;
            // 
            // btnAddTask
            // 
            btnAddTask.Cursor = Cursors.Hand;
            btnAddTask.Location = new Point(20, 498);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(140, 42);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Cursor = Cursors.Hand;
            btnDeleteTask.Location = new Point(175, 498);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(140, 42);
            btnDeleteTask.TabIndex = 3;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
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
            // ucTasks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(lblTasksDescription);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnAddTask);
            Controls.Add(lvTasks);
            Controls.Add(lblTasksTitle);
            Name = "ucTasks";
            Size = new Size(742, 598);
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
    }
}
