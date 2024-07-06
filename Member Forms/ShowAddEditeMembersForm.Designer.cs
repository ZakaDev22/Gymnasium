namespace Gymnasium.Member_Forms
{
    partial class ShowAddEditeMembersForm
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
            this.lblMemberID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtEmergencyContact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSports = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlPersonInfoCardWithFilter1 = new Gymnasium.People_Forms.ctrlPersonInfoCardWithFilter();
            this.lbPaumentID2 = new System.Windows.Forms.Label();
            this.lbPaymentID = new System.Windows.Forms.Label();
            this.pcPaymentID = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbSportFees = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddNewEmergencyContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPaymentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMemberID
            // 
            this.lblMemberID.AutoSize = true;
            this.lblMemberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberID.Location = new System.Drawing.Point(230, 428);
            this.lblMemberID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberID.Name = "lblMemberID";
            this.lblMemberID.Size = new System.Drawing.Size(39, 20);
            this.lblMemberID.TabIndex = 142;
            this.lblMemberID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(81, 428);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 141;
            this.label4.Text = "MemberID :";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(227, 545);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(121, 29);
            this.chkIsActive.TabIndex = 140;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = false;
            // 
            // txtEmergencyContact
            // 
            this.txtEmergencyContact.Location = new System.Drawing.Point(227, 469);
            this.txtEmergencyContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmergencyContact.MaxLength = 50;
            this.txtEmergencyContact.Name = "txtEmergencyContact";
            this.txtEmergencyContact.Size = new System.Drawing.Size(167, 20);
            this.txtEmergencyContact.TabIndex = 131;
            this.txtEmergencyContact.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmergencyContact_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 469);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 133;
            this.label1.Text = "Emergency Contact :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(120, 513);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 134;
            this.label2.Text = "Sport :";
            // 
            // cbSports
            // 
            this.cbSports.FormattingEnabled = true;
            this.cbSports.Location = new System.Drawing.Point(227, 512);
            this.cbSports.Name = "cbSports";
            this.cbSports.Size = new System.Drawing.Size(168, 21);
            this.cbSports.TabIndex = 145;
            this.cbSports.SelectedIndexChanged += new System.EventHandler(this.cbSports_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 100;
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gymnasium.Properties.Resources.Person_322;
            this.pictureBox2.Location = new System.Drawing.Point(190, 428);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 143;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Gymnasium.Properties.Resources.ApplicationTitle;
            this.pictureBox8.Location = new System.Drawing.Point(189, 467);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 136;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Gymnasium.Properties.Resources.Password_321;
            this.pictureBox3.Location = new System.Drawing.Point(190, 513);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 135;
            this.pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::Gymnasium.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(502, 534);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 121;
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
            this.btnSave.Location = new System.Drawing.Point(647, 534);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 120;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlPersonInfoCardWithFilter1
            // 
            this.ctrlPersonInfoCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoCardWithFilter1.Location = new System.Drawing.Point(23, 23);
            this.ctrlPersonInfoCardWithFilter1.Name = "ctrlPersonInfoCardWithFilter1";
            this.ctrlPersonInfoCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonInfoCardWithFilter1.Size = new System.Drawing.Size(837, 399);
            this.ctrlPersonInfoCardWithFilter1.TabIndex = 146;
            this.ctrlPersonInfoCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonInfoCardWithFilter1_OnPersonSelected);
            this.ctrlPersonInfoCardWithFilter1.OntxtFilterValueEmpty += new System.Action<bool>(this.ctrlPersonInfoCardWithFilter1_OntxtFilterValueEmpty);
            // 
            // lbPaumentID2
            // 
            this.lbPaumentID2.AutoSize = true;
            this.lbPaumentID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaumentID2.ForeColor = System.Drawing.Color.Red;
            this.lbPaumentID2.Location = new System.Drawing.Point(623, 428);
            this.lbPaumentID2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPaumentID2.Name = "lbPaumentID2";
            this.lbPaumentID2.Size = new System.Drawing.Size(112, 20);
            this.lbPaumentID2.TabIndex = 141;
            this.lbPaumentID2.Text = "Payment ID :";
            this.lbPaumentID2.Visible = false;
            // 
            // lbPaymentID
            // 
            this.lbPaymentID.AutoSize = true;
            this.lbPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentID.Location = new System.Drawing.Point(782, 428);
            this.lbPaymentID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPaymentID.Name = "lbPaymentID";
            this.lbPaymentID.Size = new System.Drawing.Size(39, 20);
            this.lbPaymentID.TabIndex = 142;
            this.lbPaymentID.Text = "???";
            this.lbPaymentID.Visible = false;
            // 
            // pcPaymentID
            // 
            this.pcPaymentID.Image = global::Gymnasium.Properties.Resources.Country_32;
            this.pcPaymentID.Location = new System.Drawing.Point(742, 428);
            this.pcPaymentID.Name = "pcPaymentID";
            this.pcPaymentID.Size = new System.Drawing.Size(31, 26);
            this.pcPaymentID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcPaymentID.TabIndex = 143;
            this.pcPaymentID.TabStop = false;
            this.pcPaymentID.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(386, 428);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 141;
            this.label7.Text = "Sport Fees  :";
            // 
            // lbSportFees
            // 
            this.lbSportFees.AutoSize = true;
            this.lbSportFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSportFees.Location = new System.Drawing.Point(545, 428);
            this.lbSportFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSportFees.Name = "lbSportFees";
            this.lbSportFees.Size = new System.Drawing.Size(39, 20);
            this.lbSportFees.TabIndex = 142;
            this.lbSportFees.Text = "???";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Gymnasium.Properties.Resources.payment;
            this.pictureBox5.Location = new System.Drawing.Point(505, 428);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 143;
            this.pictureBox5.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 10);
            this.panel3.TabIndex = 172;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(862, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 585);
            this.panel1.TabIndex = 174;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 585);
            this.panel2.TabIndex = 175;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 585);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(852, 10);
            this.panel4.TabIndex = 176;
            // 
            // btnAddNewEmergencyContact
            // 
            this.btnAddNewEmergencyContact.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddNewEmergencyContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewEmergencyContact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewEmergencyContact.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewEmergencyContact.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddNewEmergencyContact.Image = global::Gymnasium.Properties.Resources.AddPerson_32;
            this.btnAddNewEmergencyContact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewEmergencyContact.Location = new System.Drawing.Point(402, 465);
            this.btnAddNewEmergencyContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewEmergencyContact.Name = "btnAddNewEmergencyContact";
            this.btnAddNewEmergencyContact.Size = new System.Drawing.Size(163, 31);
            this.btnAddNewEmergencyContact.TabIndex = 177;
            this.btnAddNewEmergencyContact.Text = "Add New Cntact";
            this.btnAddNewEmergencyContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewEmergencyContact.UseVisualStyleBackColor = false;
            this.btnAddNewEmergencyContact.Click += new System.EventHandler(this.btnAddNewEmergencyContact_Click);
            // 
            // ShowAddEditeMembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 595);
            this.Controls.Add(this.btnAddNewEmergencyContact);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ctrlPersonInfoCardWithFilter1);
            this.Controls.Add(this.cbSports);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.lbSportFees);
            this.Controls.Add(this.pcPaymentID);
            this.Controls.Add(this.lbPaymentID);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMemberID);
            this.Controls.Add(this.lbPaumentID2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtEmergencyContact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowAddEditeMembersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowAddEditeForm";
            this.Load += new System.EventHandler(this.ShowAddEditeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPaymentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMemberID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtEmergencyContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cbSports;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private People_Forms.ctrlPersonInfoCardWithFilter ctrlPersonInfoCardWithFilter1;
        private System.Windows.Forms.PictureBox pcPaymentID;
        private System.Windows.Forms.Label lbPaymentID;
        private System.Windows.Forms.Label lbPaumentID2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lbSportFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddNewEmergencyContact;
    }
}