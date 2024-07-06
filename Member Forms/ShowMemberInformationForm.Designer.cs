namespace Gymnasium.Member_Forms
{
    partial class ShowMemberInformationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlMemberCardInfoWithFilter1 = new Gymnasium.Member_Forms.ctrlMemberCardInfoWithFilter();
            this.btnCLose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 552);
            this.panel2.TabIndex = 166;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(868, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 552);
            this.panel1.TabIndex = 167;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 10);
            this.panel3.TabIndex = 168;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkRed;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 542);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(858, 10);
            this.panel4.TabIndex = 169;
            // 
            // ctrlMemberCardInfoWithFilter1
            // 
            this.ctrlMemberCardInfoWithFilter1.FilterEnabled = true;
            this.ctrlMemberCardInfoWithFilter1.Location = new System.Drawing.Point(16, 16);
            this.ctrlMemberCardInfoWithFilter1.Name = "ctrlMemberCardInfoWithFilter1";
            this.ctrlMemberCardInfoWithFilter1.Size = new System.Drawing.Size(852, 516);
            this.ctrlMemberCardInfoWithFilter1.TabIndex = 170;
            // 
            // btnCLose
            // 
            this.btnCLose.BackColor = System.Drawing.Color.Transparent;
            this.btnCLose.BackgroundImage = global::Gymnasium.Properties.Resources.Close_64;
            this.btnCLose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLose.Location = new System.Drawing.Point(809, 16);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(53, 43);
            this.btnCLose.TabIndex = 171;
            this.btnCLose.UseVisualStyleBackColor = false;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // ShowMemberInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 552);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.ctrlMemberCardInfoWithFilter1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowMemberInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowMemberInformationForm";
            this.Load += new System.EventHandler(this.ShowMemberInformationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ctrlMemberCardInfoWithFilter ctrlMemberCardInfoWithFilter1;
        private System.Windows.Forms.Button btnCLose;
    }
}