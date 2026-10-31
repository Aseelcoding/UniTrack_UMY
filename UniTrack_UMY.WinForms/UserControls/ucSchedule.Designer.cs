
namespace UniTrack_UMY.WinForms.UserControls
{
    partial class ucSchedule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblScheduleTitle = new Label();
            lblScheduleDescription = new Label();
            pnlListCard = new Panel();
            tlpSchedule = new TableLayoutPanel();
            ucSunday = new ucScheduleDay();
            ucMonday = new ucScheduleDay();
            ucTuesday = new ucScheduleDay();
            ucWednesday = new ucScheduleDay();
            ucThursday = new ucScheduleDay();
            ucFriday = new ucScheduleDay();
            ucSaturday = new ucScheduleDay();
            pnlFooter = new Panel();
            btnAddSchedule = new Button();
            btnDeleteSchedule = new Button();
            pnlHeader.SuspendLayout();
            pnlListCard.SuspendLayout();
            tlpSchedule.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblScheduleTitle);
            pnlHeader.Controls.Add(lblScheduleDescription);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 14);
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblScheduleTitle
            // 
            lblScheduleTitle.Dock = DockStyle.Fill;
            lblScheduleTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblScheduleTitle.ForeColor = Color.FromArgb(35, 45, 60);
            lblScheduleTitle.Location = new Point(20, 0);
            lblScheduleTitle.Name = "lblScheduleTitle";
            lblScheduleTitle.Size = new Size(1060, 58);
            lblScheduleTitle.TabIndex = 0;
            lblScheduleTitle.Text = "My Schedule";
            lblScheduleTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblScheduleDescription
            // 
            lblScheduleDescription.Dock = DockStyle.Bottom;
            lblScheduleDescription.ForeColor = Color.FromArgb(110, 120, 135);
            lblScheduleDescription.Location = new Point(20, 58);
            lblScheduleDescription.Name = "lblScheduleDescription";
            lblScheduleDescription.Size = new Size(1060, 28);
            lblScheduleDescription.TabIndex = 1;
            lblScheduleDescription.Text = "Keep your class schedule organized";
            lblScheduleDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlListCard
            // 
            pnlListCard.BackColor = Color.White;
            pnlListCard.Controls.Add(tlpSchedule);
            pnlListCard.Controls.Add(pnlFooter);
            pnlListCard.Dock = DockStyle.Fill;
            pnlListCard.Location = new Point(0, 100);
            pnlListCard.Name = "pnlListCard";
            pnlListCard.Padding = new Padding(16);
            pnlListCard.Size = new Size(1100, 650);
            pnlListCard.TabIndex = 1;
            // 
            // tlpSchedule
            // 
            tlpSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpSchedule.BackColor = Color.FromArgb(245, 247, 250);
            tlpSchedule.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpSchedule.ColumnCount = 7;
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tlpSchedule.Controls.Add(ucSunday, 0, 0);
            tlpSchedule.Controls.Add(ucMonday, 1, 0);
            tlpSchedule.Controls.Add(ucTuesday, 2, 0);
            tlpSchedule.Controls.Add(ucWednesday, 3, 0);
            tlpSchedule.Controls.Add(ucThursday, 4, 0);
            tlpSchedule.Controls.Add(ucFriday, 5, 0);
            tlpSchedule.Controls.Add(ucSaturday, 6, 0);
            tlpSchedule.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpSchedule.Location = new Point(16, 16);
            tlpSchedule.Name = "tlpSchedule";
            tlpSchedule.Padding = new Padding(4);
            tlpSchedule.RowCount = 1;
            tlpSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tlpSchedule.Size = new Size(1068, 500);
            tlpSchedule.TabIndex = 0;
            // 
            // ucSunday
            // 
            ucSunday.Dock = DockStyle.Fill;
            ucSunday.Location = new Point(8, 8);
            ucSunday.Name = "ucSunday";
            ucSunday.Size = new Size(144, 484);
            ucSunday.TabIndex = 0;
            // 
            // ucMonday
            // 
            ucMonday.Dock = DockStyle.Fill;
            ucMonday.Location = new Point(159, 8);
            ucMonday.Name = "ucMonday";
            ucMonday.Size = new Size(144, 484);
            ucMonday.TabIndex = 1;
            // 
            // ucTuesday
            // 
            ucTuesday.Dock = DockStyle.Fill;
            ucTuesday.Location = new Point(310, 8);
            ucTuesday.Name = "ucTuesday";
            ucTuesday.Size = new Size(144, 484);
            ucTuesday.TabIndex = 2;
            // 
            // ucWednesday
            // 
            ucWednesday.Dock = DockStyle.Fill;
            ucWednesday.Location = new Point(461, 8);
            ucWednesday.Name = "ucWednesday";
            ucWednesday.Size = new Size(144, 484);
            ucWednesday.TabIndex = 3;
            // 
            // ucThursday
            // 
            ucThursday.Dock = DockStyle.Fill;
            ucThursday.Location = new Point(612, 8);
            ucThursday.Name = "ucThursday";
            ucThursday.Size = new Size(144, 484);
            ucThursday.TabIndex = 4;
            // 
            // ucFriday
            // 
            ucFriday.Dock = DockStyle.Fill;
            ucFriday.Location = new Point(763, 8);
            ucFriday.Name = "ucFriday";
            ucFriday.Size = new Size(144, 484);
            ucFriday.TabIndex = 5;
            // 
            // ucSaturday
            // 
            ucSaturday.Dock = DockStyle.Fill;
            ucSaturday.Location = new Point(914, 8);
            ucSaturday.Name = "ucSaturday";
            ucSaturday.Size = new Size(146, 484);
            ucSaturday.TabIndex = 6;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(btnAddSchedule);
            pnlFooter.Controls.Add(btnDeleteSchedule);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(16, 572);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1068, 62);
            pnlFooter.TabIndex = 1;
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.BackColor = Color.FromArgb(55, 110, 190);
            btnAddSchedule.Cursor = Cursors.Hand;
            btnAddSchedule.FlatAppearance.BorderSize = 0;
            btnAddSchedule.FlatStyle = FlatStyle.Flat;
            btnAddSchedule.Font = new Font("Segoe UI Semibold", 10.5F);
            btnAddSchedule.ForeColor = Color.White;
            btnAddSchedule.Location = new Point(0, 10);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(170, 44);
            btnAddSchedule.TabIndex = 0;
            btnAddSchedule.Tag = "primary";
            btnAddSchedule.Text = "Add Class";
            btnAddSchedule.UseVisualStyleBackColor = false;
            btnAddSchedule.Click += btnAddSchedule_Click;
            // 
            // btnDeleteSchedule
            // 
            btnDeleteSchedule.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteSchedule.Cursor = Cursors.Hand;
            btnDeleteSchedule.FlatAppearance.BorderSize = 0;
            btnDeleteSchedule.FlatStyle = FlatStyle.Flat;
            btnDeleteSchedule.Font = new Font("Segoe UI Semibold", 10.5F);
            btnDeleteSchedule.ForeColor = Color.White;
            btnDeleteSchedule.Location = new Point(182, 10);
            btnDeleteSchedule.Name = "btnDeleteSchedule";
            btnDeleteSchedule.Size = new Size(170, 44);
            btnDeleteSchedule.TabIndex = 1;
            btnDeleteSchedule.Tag = "danger";
            btnDeleteSchedule.Text = "Delete Class";
            btnDeleteSchedule.UseVisualStyleBackColor = false;
            btnDeleteSchedule.Click += btnDeleteSchedule_Click;
            // 
            // ucSchedule
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(pnlListCard);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            Name = "ucSchedule";
            Size = new Size(1100, 750);
            pnlHeader.ResumeLayout(false);
            pnlListCard.ResumeLayout(false);
            tlpSchedule.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlListCard;
        private Panel pnlFooter;

        private Label lblScheduleTitle;
        private Label lblScheduleDescription;

        private TableLayoutPanel tlpSchedule;

        private Button btnAddSchedule;
        private Button btnDeleteSchedule;
        private ucScheduleDay ucSunday;
        private ucScheduleDay ucMonday;
        private ucScheduleDay ucTuesday;
        private ucScheduleDay ucWednesday;
        private ucScheduleDay ucThursday;
        private ucScheduleDay ucFriday;
        private ucScheduleDay ucSaturday;
    }
}
