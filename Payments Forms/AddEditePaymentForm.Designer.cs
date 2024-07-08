namespace Gymnasium.Payments_Forms
{
    partial class AddEditePaymentForm
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
            this.lbPaymentID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPaymentDate = new System.Windows.Forms.Label();
            this.gbPeriodMonths = new System.Windows.Forms.GroupBox();
            this.rbThreeMonths = new System.Windows.Forms.RadioButton();
            this.rbOneMonth = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlMemberCardInfoWithFilter1 = new Gymnasium.Member_Forms.ctrlMemberCardInfoWithFilter();
            this.groupBox1.SuspendLayout();
            this.gbPeriodMonths.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPaymentID
            // 
            this.lbPaymentID.AutoSize = true;
            this.lbPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentID.ForeColor = System.Drawing.Color.Black;
            this.lbPaymentID.Location = new System.Drawing.Point(196, 41);
            this.lbPaymentID.Name = "lbPaymentID";
            this.lbPaymentID.Size = new System.Drawing.Size(55, 24);
            this.lbPaymentID.TabIndex = 23;
            this.lbPaymentID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(60, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Payment ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(304, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Payment Amount :";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(490, 39);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(159, 26);
            this.txtAmount.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbPaymentDate);
            this.groupBox1.Controls.Add(this.gbPeriodMonths);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbPaymentID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 123);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Informations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(37, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Payment Date :";
            // 
            // lbPaymentDate
            // 
            this.lbPaymentDate.AutoSize = true;
            this.lbPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbPaymentDate.Location = new System.Drawing.Point(196, 77);
            this.lbPaymentDate.Name = "lbPaymentDate";
            this.lbPaymentDate.Size = new System.Drawing.Size(55, 24);
            this.lbPaymentDate.TabIndex = 27;
            this.lbPaymentDate.Text = "[???]";
            // 
            // gbPeriodMonths
            // 
            this.gbPeriodMonths.Controls.Add(this.rbThreeMonths);
            this.gbPeriodMonths.Controls.Add(this.rbOneMonth);
            this.gbPeriodMonths.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gbPeriodMonths.Location = new System.Drawing.Point(674, 25);
            this.gbPeriodMonths.Name = "gbPeriodMonths";
            this.gbPeriodMonths.Size = new System.Drawing.Size(138, 92);
            this.gbPeriodMonths.TabIndex = 26;
            this.gbPeriodMonths.TabStop = false;
            this.gbPeriodMonths.Text = "Period Months";
            // 
            // rbThreeMonths
            // 
            this.rbThreeMonths.AutoSize = true;
            this.rbThreeMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThreeMonths.ForeColor = System.Drawing.Color.Red;
            this.rbThreeMonths.Location = new System.Drawing.Point(22, 52);
            this.rbThreeMonths.Name = "rbThreeMonths";
            this.rbThreeMonths.Size = new System.Drawing.Size(92, 21);
            this.rbThreeMonths.TabIndex = 0;
            this.rbThreeMonths.Text = "3 Months";
            this.rbThreeMonths.UseVisualStyleBackColor = true;
            // 
            // rbOneMonth
            // 
            this.rbOneMonth.AutoSize = true;
            this.rbOneMonth.Checked = true;
            this.rbOneMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOneMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbOneMonth.Location = new System.Drawing.Point(22, 25);
            this.rbOneMonth.Name = "rbOneMonth";
            this.rbOneMonth.Size = new System.Drawing.Size(84, 21);
            this.rbOneMonth.TabIndex = 0;
            this.rbOneMonth.TabStop = true;
            this.rbOneMonth.Text = "1 Month";
            this.rbOneMonth.UseVisualStyleBackColor = true;
            this.rbOneMonth.CheckedChanged += new System.EventHandler(this.rbOneMonth_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::Gymnasium.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(320, 642);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 163;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::Gymnasium.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(454, 642);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 162;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(851, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 693);
            this.panel1.TabIndex = 164;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 693);
            this.panel2.TabIndex = 165;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 10);
            this.panel3.TabIndex = 166;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkRed;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 683);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(841, 10);
            this.panel4.TabIndex = 167;
            // 
            // ctrlMemberCardInfoWithFilter1
            // 
            this.ctrlMemberCardInfoWithFilter1.FilterEnabled = true;
            this.ctrlMemberCardInfoWithFilter1.Location = new System.Drawing.Point(2, 1);
            this.ctrlMemberCardInfoWithFilter1.Name = "ctrlMemberCardInfoWithFilter1";
            this.ctrlMemberCardInfoWithFilter1.Size = new System.Drawing.Size(847, 516);
            this.ctrlMemberCardInfoWithFilter1.TabIndex = 26;
            this.ctrlMemberCardInfoWithFilter1.OnMemberSelected += new System.Action<int>(this.ctrlMemberCardInfoWithFilter1_OnMemberSelected);
            this.ctrlMemberCardInfoWithFilter1.OntxtFilterValueEmpty += new System.Action<bool>(this.ctrlMemberCardInfoWithFilter1_OntxtFilterValueEmpty);
            // 
            // AddEditePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 693);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlMemberCardInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEditePaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditePaymentForm";
            this.Load += new System.EventHandler(this.AddEditePaymentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPeriodMonths.ResumeLayout(false);
            this.gbPeriodMonths.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbPaymentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private Member_Forms.ctrlMemberCardInfoWithFilter ctrlMemberCardInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gbPeriodMonths;
        private System.Windows.Forms.RadioButton rbThreeMonths;
        private System.Windows.Forms.RadioButton rbOneMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPaymentDate;
    }
}