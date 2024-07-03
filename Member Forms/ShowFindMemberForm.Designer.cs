namespace Gymnasium.Member_Forms
{
    partial class ShowFindMemberForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlMemberCardInfoWithFilter1 = new Gymnasium.Member_Forms.ctrlMemberCardInfoWithFilter();
            this.btnCLose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LawnGreen;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 632);
            this.panel2.TabIndex = 173;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LawnGreen;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 622);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(880, 10);
            this.panel4.TabIndex = 175;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LawnGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(880, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 622);
            this.panel1.TabIndex = 176;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LawnGreen;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 10);
            this.panel3.TabIndex = 177;
            // 
            // ctrlMemberCardInfoWithFilter1
            // 
            this.ctrlMemberCardInfoWithFilter1.FilterEnabled = true;
            this.ctrlMemberCardInfoWithFilter1.Location = new System.Drawing.Point(16, 62);
            this.ctrlMemberCardInfoWithFilter1.Name = "ctrlMemberCardInfoWithFilter1";
            this.ctrlMemberCardInfoWithFilter1.Size = new System.Drawing.Size(853, 516);
            this.ctrlMemberCardInfoWithFilter1.TabIndex = 178;
            // 
            // btnCLose
            // 
            this.btnCLose.BackColor = System.Drawing.Color.Transparent;
            this.btnCLose.BackgroundImage = global::Gymnasium.Properties.Resources.Close_64;
            this.btnCLose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLose.Location = new System.Drawing.Point(821, 16);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(53, 43);
            this.btnCLose.TabIndex = 179;
            this.btnCLose.UseVisualStyleBackColor = false;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(310, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(283, 39);
            this.lblTitle.TabIndex = 180;
            this.lblTitle.Text = "Find Member Info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowFindMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 632);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.ctrlMemberCardInfoWithFilter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowFindMemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowFindMemberForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private ctrlMemberCardInfoWithFilter ctrlMemberCardInfoWithFilter1;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.Label lblTitle;
    }
}