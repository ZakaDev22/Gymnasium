namespace Gymnasium.Instructors_Forms
{
    partial class ShowManageInstructorsForms
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
            this.btnPageNumber = new System.Windows.Forms.Button();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbByPages = new System.Windows.Forms.RadioButton();
            this.rbAllPeople = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnAddIstructor = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
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
            this.btnPageNumber.Location = new System.Drawing.Point(402, 412);
            this.btnPageNumber.Name = "btnPageNumber";
            this.btnPageNumber.Size = new System.Drawing.Size(67, 44);
            this.btnPageNumber.TabIndex = 130;
            this.btnPageNumber.Text = "1";
            this.btnPageNumber.UseVisualStyleBackColor = true;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.Red;
            this.lbRecords.Location = new System.Drawing.Point(116, 419);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(29, 20);
            this.lbRecords.TabIndex = 127;
            this.lbRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 126;
            this.label2.Text = "#Records :";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(287, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 54);
            this.lblTitle.TabIndex = 123;
            this.lblTitle.Text = "Manage Instructos";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.BackColor = System.Drawing.Color.Gold;
            this.lbSize.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSize.ForeColor = System.Drawing.Color.Brown;
            this.lbSize.Location = new System.Drawing.Point(131, 64);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(97, 22);
            this.lbSize.TabIndex = 121;
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
            this.cbPageSize.Location = new System.Drawing.Point(234, 67);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(83, 21);
            this.cbPageSize.TabIndex = 120;
            this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbByPages);
            this.groupBox1.Controls.Add(this.rbAllPeople);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 68);
            this.groupBox1.TabIndex = 119;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(14, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(859, 230);
            this.dataGridView1.TabIndex = 118;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addInstructorToolStripMenuItem,
            this.updateInstructorToolStripMenuItem,
            this.deleteInstructorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 138);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.information;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(211, 32);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // addInstructorToolStripMenuItem
            // 
            this.addInstructorToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.add__1_;
            this.addInstructorToolStripMenuItem.Name = "addInstructorToolStripMenuItem";
            this.addInstructorToolStripMenuItem.Size = new System.Drawing.Size(211, 32);
            this.addInstructorToolStripMenuItem.Text = "Add Instructor";
            this.addInstructorToolStripMenuItem.Click += new System.EventHandler(this.addInstructorToolStripMenuItem_Click);
            // 
            // updateInstructorToolStripMenuItem
            // 
            this.updateInstructorToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.update;
            this.updateInstructorToolStripMenuItem.Name = "updateInstructorToolStripMenuItem";
            this.updateInstructorToolStripMenuItem.Size = new System.Drawing.Size(211, 32);
            this.updateInstructorToolStripMenuItem.Text = "Update Instructor";
            this.updateInstructorToolStripMenuItem.Click += new System.EventHandler(this.updateInstructorToolStripMenuItem_Click);
            // 
            // deleteInstructorToolStripMenuItem
            // 
            this.deleteInstructorToolStripMenuItem.Image = global::Gymnasium.Properties.Resources.Delete;
            this.deleteInstructorToolStripMenuItem.Name = "deleteInstructorToolStripMenuItem";
            this.deleteInstructorToolStripMenuItem.Size = new System.Drawing.Size(211, 32);
            this.deleteInstructorToolStripMenuItem.Text = "Delete Instructor";
            this.deleteInstructorToolStripMenuItem.Click += new System.EventHandler(this.deleteInstructorToolStripMenuItem_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Instructor ID",
            "Person ID",
            "Specialization",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(95, 113);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(182, 23);
            this.cbFilterBy.TabIndex = 117;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(284, 116);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(185, 20);
            this.txtFilterValue.TabIndex = 116;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 115;
            this.label1.Text = "Filter By:";
            // 
            // cbIsActive
            // 
            this.cbIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.ForeColor = System.Drawing.Color.Red;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "None.",
            "Active.",
            "Not Active."});
            this.cbIsActive.Location = new System.Drawing.Point(283, 116);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(116, 21);
            this.cbIsActive.TabIndex = 133;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
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
            this.btnLeft.Location = new System.Drawing.Point(329, 412);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(67, 44);
            this.btnLeft.TabIndex = 129;
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
            this.btnRight.Location = new System.Drawing.Point(475, 412);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(67, 44);
            this.btnRight.TabIndex = 128;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnAddIstructor
            // 
            this.btnAddIstructor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddIstructor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIstructor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddIstructor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddIstructor.FlatAppearance.BorderSize = 3;
            this.btnAddIstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddIstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIstructor.Image = global::Gymnasium.Properties.Resources.Add_Person_40;
            this.btnAddIstructor.Location = new System.Drawing.Point(801, 116);
            this.btnAddIstructor.Name = "btnAddIstructor";
            this.btnAddIstructor.Size = new System.Drawing.Size(72, 54);
            this.btnAddIstructor.TabIndex = 124;
            this.btnAddIstructor.UseVisualStyleBackColor = false;
            this.btnAddIstructor.Click += new System.EventHandler(this.btnAddIstructor_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Gymnasium.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(738, 412);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::Gymnasium.Properties.Resources.Icons_Land_Vista_People_Groups_Military_Personnel_Dark_256;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(599, 4);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(162, 101);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 122;
            this.pbPersonImage.TabStop = false;
            // 
            // ShowManageInstructorsForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 460);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnPageNumber);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddIstructor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.cbPageSize);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Name = "ShowManageInstructorsForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowManageInstructorsForms";
            this.Load += new System.EventHandler(this.ShowManageInstructorsForms_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPageNumber;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddIstructor;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ComboBox cbPageSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbByPages;
        private System.Windows.Forms.RadioButton rbAllPeople;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInstructorToolStripMenuItem;
    }
}