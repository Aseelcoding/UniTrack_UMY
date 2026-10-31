using System.Reflection.PortableExecutable;

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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTasksTitle = new Label();
            lblTasksDescription = new Label();
            pnlToolbar = new Panel();
            cmbCourseFilter = new ComboBox();
            pnlListCard = new Panel();
            lvTasks = new ListView();
            colTask = new ColumnHeader();
            colCourse = new ColumnHeader();
            colDueDate = new ColumnHeader();
            colStatus = new ColumnHeader();
            imgRowHeight = new ImageList(components);
            pnlFooter = new Panel();
            btnAddTask = new Button();
            btnDeleteTask = new Button();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlListCard.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTasksTitle);
            pnlHeader.Controls.Add(lblTasksDescription);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 0, 0, 14);
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.Dock = DockStyle.Fill;
            lblTasksTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.TabIndex = 0;
            lblTasksTitle.Text = "My Tasks";
            lblTasksTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblTasksDescription
            // 
            lblTasksDescription.AutoSize = false;
            lblTasksDescription.Dock = DockStyle.Bottom;
            lblTasksDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblTasksDescription.Name = "lblTasksDescription";
            lblTasksDescription.Size = new Size(1100, 28);
            lblTasksDescription.TabIndex = 1;
            lblTasksDescription.Tag = "muted";
            lblTasksDescription.Text = "Manage assignments and track deadlines";
            lblTasksDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(cmbCourseFilter);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1100, 56);
            pnlToolbar.TabIndex = 1;
            // 
            // cmbCourseFilter
            // 
            cmbCourseFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourseFilter.Font = new Font("Segoe UI", 10.5F);
            cmbCourseFilter.FormattingEnabled = true;
            cmbCourseFilter.Location = new Point(0, 4);
            cmbCourseFilter.Name = "cmbCourseFilter";
            cmbCourseFilter.Size = new Size(360, 31);
            cmbCourseFilter.TabIndex = 0;
            cmbCourseFilter.SelectedIndexChanged += cmbCourseFilter_SelectedIndexChanged;
            // 
            // pnlListCard
            // 
            pnlListCard.BackColor = Color.White;
            pnlListCard.Controls.Add(lvTasks);
            pnlListCard.Controls.Add(pnlFooter);
            pnlListCard.Dock = DockStyle.Fill;
            pnlListCard.Name = "pnlListCard";
            pnlListCard.Padding = new Padding(12);
            pnlListCard.TabIndex = 2;
            // 
            // lvTasks
            // 
            lvTasks.BackColor = Color.White;
            lvTasks.BorderStyle = BorderStyle.None;
            lvTasks.Columns.AddRange(new ColumnHeader[] { colTask, colCourse, colDueDate, colStatus });
            lvTasks.Dock = DockStyle.Fill;
            lvTasks.Font = new Font("Segoe UI", 10.5F);
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = false;
            lvTasks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvTasks.MultiSelect = false;
            lvTasks.Name = "lvTasks";
            lvTasks.SmallImageList = imgRowHeight;
            lvTasks.TabIndex = 0;
            lvTasks.UseCompatibleStateImageBehavior = false;
            lvTasks.View = View.Details;
            lvTasks.DoubleClick += lvTasks_DoubleClick;
            lvTasks.SizeChanged += lvTasks_SizeChanged;
            // 
            // colTask
            // 
            colTask.Text = "Task";
            colTask.Width = 380;
            // 
            // colCourse
            // 
            colCourse.Text = "Course";
            colCourse.Width = 280;
            // 
            // colDueDate
            // 
            colDueDate.Text = "Due Date";
            colDueDate.Width = 160;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            colStatus.Width = 150;
            // 
            // imgRowHeight
            // 
            imgRowHeight.ImageSize = new Size(1, 36);
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnAddTask);
            pnlFooter.Controls.Add(btnDeleteTask);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1000, 62);
            pnlFooter.TabIndex = 1;
            pnlFooter.Tag = "card";
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.FromArgb(55, 110, 190);
            btnAddTask.Cursor = Cursors.Hand;
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI Semibold", 10.5F);
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(0, 14);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(150, 44);
            btnAddTask.TabIndex = 0;
            btnAddTask.Tag = "primary";
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteTask.Cursor = Cursors.Hand;
            btnDeleteTask.FlatAppearance.BorderSize = 0;
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.Font = new Font("Segoe UI Semibold", 10.5F);
            btnDeleteTask.ForeColor = Color.White;
            btnDeleteTask.Location = new Point(162, 14);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(150, 44);
            btnDeleteTask.TabIndex = 1;
            btnDeleteTask.Tag = "danger";
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = false;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // ucTasks
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlListCard);   
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);     
            Font = new Font("Segoe UI", 10F);
            Name = "ucTasks";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            pnlToolbar.ResumeLayout(false);
            pnlListCard.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlToolbar;
        private Panel pnlListCard;
        private Panel pnlFooter;
        private ImageList imgRowHeight;
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
