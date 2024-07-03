namespace Gymnasium.Subscription_Peroids.Expired_Subscriptions
{
    partial class ShowExpiredSubscriptionsPeriodsForm
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
            this.cbIsPaid = new System.Windows.Forms.ComboBox();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.showMemberDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPaymnetDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMemberInActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renweMemberSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMemberHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbNoExpired = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIsPaid
            // 
            this.cbIsPaid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIsPaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsPaid.ForeColor = System.Drawing.Color.Red;
            this.cbIsPaid.FormattingEnabled = true;
            this.cbIsPaid.Items.AddRange(new object[] {
            "None",
            "Yes.",
            "No."});
            this.cbIsPaid.Location = new System.Drawing.Point(296, 134);
            this.cbIsPaid.Name = "cbIsPaid";
            this.cbIsPaid.Size = new System.Drawing.Size(116, 21);
            this.cbIsPaid.TabIndex = 149;
            this.cbIsPaid.SelectedIndexChanged += new System.EventHandler(this.cbIsPaid_SelectedIndexChanged);
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Red;
            this.lbRecords.Location = new System.Drawing.Point(128, 437);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(29, 20);
            this.lbRecords.TabIndex = 145;
            this.lbRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 144;
            this.label2.Text = "#Records :";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(164, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(482, 54);
            this.lblTitle.TabIndex = 142;
            this.lblTitle.Text = "Expired Subscription Peroids";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dataGridView1.Location = new System.Drawing.Point(48, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(804, 230);
            this.dataGridView1.TabIndex = 137;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Period ID",
            "Member ID",
            " Payment ID",
            " Is Paid"});
            this.cbFilterBy.Location = new System.Drawing.Point(107, 131);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(182, 23);
            this.cbFilterBy.TabIndex = 136;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(296, 134);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(185, 20);
            this.txtFilterValue.TabIndex = 135;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 134;
            this.label1.Text = "Filter By:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Peru;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 488);
            this.panel2.TabIndex = 166;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(889, 10);
            this.panel3.TabIndex = 167;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(889, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 478);
            this.panel1.TabIndex = 168;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Peru;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 478);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(879, 10);
            this.panel4.TabIndex = 169;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMemberDetailsToolStripMenuItem,
            this.showPaymnetDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.setMemberInActiveToolStripMenuItem,
            this.renweMemberSubscriptionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showMemberHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(262, 176);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(258, 6);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Gymnasium.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(717, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 143;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::Gymnasium.Properties.Resources.expired;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(665, 27);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(216, 159);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonImage.TabIndex = 141;
            this.pbPersonImage.TabStop = false;
            // 
            // showMemberDetailsToolStripMenuItem
            // 
            this.showMemberDetailsToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.information;
            this.showMemberDetailsToolStripMenuItem.Name = "showMemberDetailsToolStripMenuItem";
            this.showMemberDetailsToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.showMemberDetailsToolStripMenuItem.Text = "Show Member Details";
            this.showMemberDetailsToolStripMenuItem.Click += new System.EventHandler(this.showMemberDetailsToolStripMenuItem_Click);
            // 
            // showPaymnetDetailsToolStripMenuItem
            // 
            this.showPaymnetDetailsToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.information;
            this.showPaymnetDetailsToolStripMenuItem.Name = "showPaymnetDetailsToolStripMenuItem";
            this.showPaymnetDetailsToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.showPaymnetDetailsToolStripMenuItem.Text = "Show Paymnet Details";
            this.showPaymnetDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPaymnetDetailsToolStripMenuItem_Click);
            // 
            // setMemberInActiveToolStripMenuItem
            // 
            this.setMemberInActiveToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.Saki_NuoveXT_2_Actions_stop_32;
            this.setMemberInActiveToolStripMenuItem.Name = "setMemberInActiveToolStripMenuItem";
            this.setMemberInActiveToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.setMemberInActiveToolStripMenuItem.Text = "Set Member InActive";
            this.setMemberInActiveToolStripMenuItem.Click += new System.EventHandler(this.setMemberInActiveToolStripMenuItem_Click);
            // 
            // renweMemberSubscriptionToolStripMenuItem
            // 
            this.renweMemberSubscriptionToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.Aniket_Suvarna_Box_Regular_Bx_checkbox_checked_32;
            this.renweMemberSubscriptionToolStripMenuItem.Name = "renweMemberSubscriptionToolStripMenuItem";
            this.renweMemberSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.renweMemberSubscriptionToolStripMenuItem.Text = "Renwe Member Subscription";
            this.renweMemberSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.renweMemberSubscriptionToolStripMenuItem_Click);
            // 
            // showMemberHistoryToolStripMenuItem
            // 
            this.showMemberHistoryToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.history;
            this.showMemberHistoryToolStripMenuItem.Name = "showMemberHistoryToolStripMenuItem";
            this.showMemberHistoryToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.showMemberHistoryToolStripMenuItem.Text = "Show Member History";
            this.showMemberHistoryToolStripMenuItem.Click += new System.EventHandler(this.showMemberHistoryToolStripMenuItem_Click);
            // 
            // lbNoExpired
            // 
            this.lbNoExpired.AutoSize = true;
            this.lbNoExpired.BackColor = System.Drawing.Color.Gold;
            this.lbNoExpired.Font = new System.Drawing.Font("NSimSun", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoExpired.Location = new System.Drawing.Point(205, 291);
            this.lbNoExpired.Name = "lbNoExpired";
            this.lbNoExpired.Size = new System.Drawing.Size(504, 21);
            this.lbNoExpired.TabIndex = 171;
            this.lbNoExpired.Text = "No Expired Subscription Periods ✅✅✅😎💪";
            this.lbNoExpired.Visible = false;
            // 
            // ShowExpiredSubscriptionsPeriodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 488);
            this.Controls.Add(this.lbNoExpired);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbIsPaid);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowExpiredSubscriptionsPeriodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowExpiredSubscriptionsPeriodsForm";
            this.Load += new System.EventHandler(this.ShowExpiredSubscriptionsPeriodsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsPaid;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showMemberDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPaymnetDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setMemberInActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renweMemberSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showMemberHistoryToolStripMenuItem;
        private System.Windows.Forms.Label lbNoExpired;
    }
}