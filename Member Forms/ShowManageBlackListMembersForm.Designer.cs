namespace Gymnasium.Member_Forms
{
    partial class ShowManageBlackListMembersForm
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbByPages = new System.Windows.Forms.RadioButton();
            this.rbAllPeople = new System.Windows.Forms.RadioButton();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPageNumber = new System.Windows.Forms.Button();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.memberPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.SetMemberToNormalList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.SetMemberToActiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetMemberToInActiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showMemberPeriodsHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(842, 10);
            this.panel3.TabIndex = 169;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(832, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 494);
            this.panel1.TabIndex = 170;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 494);
            this.panel2.TabIndex = 171;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 494);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(822, 10);
            this.panel4.TabIndex = 172;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(266, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 54);
            this.lblTitle.TabIndex = 179;
            this.lblTitle.Text = "Manage Black List Members";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.BackColor = System.Drawing.Color.Gold;
            this.lbSize.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSize.ForeColor = System.Drawing.Color.Brown;
            this.lbSize.Location = new System.Drawing.Point(158, 84);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(97, 22);
            this.lbSize.TabIndex = 178;
            this.lbSize.Text = "Page Size :";
            // 
            // cbPageSize
            // 
            this.cbPageSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPageSize.ForeColor = System.Drawing.Color.Red;
            this.cbPageSize.FormattingEnabled = true;
            this.cbPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "100",
            "500",
            "1000",
            "1500"});
            this.cbPageSize.Location = new System.Drawing.Point(261, 87);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(83, 21);
            this.cbPageSize.TabIndex = 177;
            this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbByPages);
            this.groupBox1.Controls.Add(this.rbAllPeople);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(41, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 68);
            this.groupBox1.TabIndex = 176;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage By";
            // 
            // rbByPages
            // 
            this.rbByPages.AutoSize = true;
            this.rbByPages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbByPages.ForeColor = System.Drawing.Color.Teal;
            this.rbByPages.Location = new System.Drawing.Point(17, 42);
            this.rbByPages.Name = "rbByPages";
            this.rbByPages.Size = new System.Drawing.Size(81, 22);
            this.rbByPages.TabIndex = 1;
            this.rbByPages.TabStop = true;
            this.rbByPages.Text = "By Pages";
            this.rbByPages.UseVisualStyleBackColor = true;
            this.rbByPages.CheckedChanged += new System.EventHandler(this.rbByPages_CheckedChanged);
            // 
            // rbAllPeople
            // 
            this.rbAllPeople.AutoSize = true;
            this.rbAllPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAllPeople.ForeColor = System.Drawing.Color.Teal;
            this.rbAllPeople.Location = new System.Drawing.Point(17, 20);
            this.rbAllPeople.Name = "rbAllPeople";
            this.rbAllPeople.Size = new System.Drawing.Size(89, 22);
            this.rbAllPeople.TabIndex = 0;
            this.rbAllPeople.TabStop = true;
            this.rbAllPeople.Text = "All People";
            this.rbAllPeople.UseVisualStyleBackColor = true;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Member ID",
            "Person ID",
            "Full Name",
            "Sport Name"});
            this.cbFilterBy.Location = new System.Drawing.Point(122, 133);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(182, 23);
            this.cbFilterBy.TabIndex = 175;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(311, 136);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(185, 20);
            this.txtFilterValue.TabIndex = 174;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 173;
            this.label1.Text = "Filter By:";
            // 
            // btnPageNumber
            // 
            this.btnPageNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPageNumber.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnPageNumber.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPageNumber.FlatAppearance.BorderSize = 3;
            this.btnPageNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPageNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPageNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPageNumber.Location = new System.Drawing.Point(359, 444);
            this.btnPageNumber.Name = "btnPageNumber";
            this.btnPageNumber.Size = new System.Drawing.Size(67, 44);
            this.btnPageNumber.TabIndex = 186;
            this.btnPageNumber.Text = "1";
            this.btnPageNumber.UseVisualStyleBackColor = true;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Red;
            this.lbRecords.Location = new System.Drawing.Point(143, 451);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(29, 20);
            this.lbRecords.TabIndex = 183;
            this.lbRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 182;
            this.label2.Text = "#Records :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(41, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(745, 230);
            this.dataGridView1.TabIndex = 187;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberPersonDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addMemberToolStripMenuItem,
            this.updateMemberToolStripMenuItem,
            this.deleteMemberToolStripMenuItem,
            this.toolStripMenuItem2,
            this.SetMemberToNormalList,
            this.toolStripMenuItem4,
            this.SetMemberToActiveMenuItem,
            this.SetMemberToInActiveMenuItem,
            this.toolStripSeparator1,
            this.showMemberPeriodsHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(301, 306);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // memberPersonDetailsToolStripMenuItem
            // 
            this.memberPersonDetailsToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.information;
            this.memberPersonDetailsToolStripMenuItem.Name = "memberPersonDetailsToolStripMenuItem";
            this.memberPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.memberPersonDetailsToolStripMenuItem.Text = "Member Person Details";
            this.memberPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.memberPersonDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(297, 6);
            // 
            // addMemberToolStripMenuItem
            // 
            this.addMemberToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.add__1_;
            this.addMemberToolStripMenuItem.Name = "addMemberToolStripMenuItem";
            this.addMemberToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.addMemberToolStripMenuItem.Text = "Add Member";
            this.addMemberToolStripMenuItem.Click += new System.EventHandler(this.addMemberToolStripMenuItem_Click);
            // 
            // updateMemberToolStripMenuItem
            // 
            this.updateMemberToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.update;
            this.updateMemberToolStripMenuItem.Name = "updateMemberToolStripMenuItem";
            this.updateMemberToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.updateMemberToolStripMenuItem.Text = "Update Member";
            this.updateMemberToolStripMenuItem.Click += new System.EventHandler(this.updateMemberToolStripMenuItem_Click);
            // 
            // deleteMemberToolStripMenuItem
            // 
            this.deleteMemberToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.Delete;
            this.deleteMemberToolStripMenuItem.Name = "deleteMemberToolStripMenuItem";
            this.deleteMemberToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.deleteMemberToolStripMenuItem.Text = "Delete Member";
            this.deleteMemberToolStripMenuItem.Click += new System.EventHandler(this.deleteMemberToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(297, 6);
            // 
            // SetMemberToNormalList
            // 
            this.SetMemberToNormalList.Image = global::Gymnasium.Properties.Resources.on_off;
            this.SetMemberToNormalList.Name = "SetMemberToNormalList";
            this.SetMemberToNormalList.Size = new System.Drawing.Size(300, 32);
            this.SetMemberToNormalList.Text = "Set Member To Normal List";
            this.SetMemberToNormalList.Click += new System.EventHandler(this.SetMemberToNormalList_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(297, 6);
            // 
            // SetMemberToActiveMenuItem
            // 
            this.SetMemberToActiveMenuItem.Image = global::Gymnasium.Properties.Resources.Aniket_Suvarna_Box_Regular_Bx_checkbox_checked_32;
            this.SetMemberToActiveMenuItem.Name = "SetMemberToActiveMenuItem";
            this.SetMemberToActiveMenuItem.Size = new System.Drawing.Size(300, 32);
            this.SetMemberToActiveMenuItem.Text = "Set Member To Active";
            this.SetMemberToActiveMenuItem.Click += new System.EventHandler(this.SetMemberToActiveMenuItem_Click);
            // 
            // SetMemberToInActiveMenuItem
            // 
            this.SetMemberToInActiveMenuItem.Image = global::Gymnasium.Properties.Resources.Saki_NuoveXT_2_Actions_stop_32;
            this.SetMemberToInActiveMenuItem.Name = "SetMemberToInActiveMenuItem";
            this.SetMemberToInActiveMenuItem.Size = new System.Drawing.Size(300, 32);
            this.SetMemberToInActiveMenuItem.Text = "Set Member To InActive";
            this.SetMemberToInActiveMenuItem.Click += new System.EventHandler(this.SetMemberToInActiveMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(297, 6);
            // 
            // showMemberPeriodsHistoryToolStripMenuItem
            // 
            this.showMemberPeriodsHistoryToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.history;
            this.showMemberPeriodsHistoryToolStripMenuItem.Name = "showMemberPeriodsHistoryToolStripMenuItem";
            this.showMemberPeriodsHistoryToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.showMemberPeriodsHistoryToolStripMenuItem.Text = "Show Member Periods History";
            this.showMemberPeriodsHistoryToolStripMenuItem.Click += new System.EventHandler(this.showMemberPeriodsHistoryToolStripMenuItem_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = global::Gymnasium.Properties.Resources.Hopstarter_Button_Button_Previous_72;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeft.Location = new System.Drawing.Point(286, 445);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(67, 44);
            this.btnLeft.TabIndex = 185;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = global::Gymnasium.Properties.Resources.Hopstarter_Button_Button_Next_72;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRight.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRight.Location = new System.Drawing.Point(432, 444);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(67, 44);
            this.btnRight.TabIndex = 184;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Gymnasium.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(651, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 181;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ShowManageBlackListMembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 504);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPageNumber);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.cbPageSize);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowManageBlackListMembersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowManageBlackListMembersForm";
            this.Load += new System.EventHandler(this.ShowManageBlackListMembersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ComboBox cbPageSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbByPages;
        private System.Windows.Forms.RadioButton rbAllPeople;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPageNumber;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem memberPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SetMemberToNormalList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem SetMemberToActiveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetMemberToInActiveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showMemberPeriodsHistoryToolStripMenuItem;
    }
}