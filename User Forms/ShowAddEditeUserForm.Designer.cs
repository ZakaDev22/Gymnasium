namespace Gymnasium.User_Forms
{
    partial class ShowAddEditeUserForm
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
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnPersonInfoNext = new System.Windows.Forms.Button();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMemberInstruct = new System.Windows.Forms.CheckBox();
            this.chkSubPeriod = new System.Windows.Forms.CheckBox();
            this.chkBeltTests = new System.Windows.Forms.CheckBox();
            this.chkBeltRank = new System.Windows.Forms.CheckBox();
            this.chkEmergContc = new System.Windows.Forms.CheckBox();
            this.chkPayments = new System.Windows.Forms.CheckBox();
            this.chkInstructors = new System.Windows.Forms.CheckBox();
            this.chkExpiredSubscriptions = new System.Windows.Forms.CheckBox();
            this.chkSports = new System.Windows.Forms.CheckBox();
            this.chkPeople = new System.Windows.Forms.CheckBox();
            this.chkMembers = new System.Windows.Forms.CheckBox();
            this.chkUsers = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonInfoCardWithFilter1 = new Gymnasium.People_Forms.ctrlPersonInfoCardWithFilter();
            this.tcUserInfo.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tpPersonalInfo);
            this.tcUserInfo.Controls.Add(this.tpLoginInfo);
            this.tcUserInfo.Location = new System.Drawing.Point(6, 67);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(863, 498);
            this.tcUserInfo.TabIndex = 118;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.ctrlPersonInfoCardWithFilter1);
            this.tpPersonalInfo.Controls.Add(this.btnPersonInfoNext);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(855, 472);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnPersonInfoNext
            // 
            this.btnPersonInfoNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersonInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPersonInfoNext.Image = global::Gymnasium.Properties.Resources.Next_32;
            this.btnPersonInfoNext.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPersonInfoNext.Location = new System.Drawing.Point(711, 420);
            this.btnPersonInfoNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPersonInfoNext.Name = "btnPersonInfoNext";
            this.btnPersonInfoNext.Size = new System.Drawing.Size(126, 37);
            this.btnPersonInfoNext.TabIndex = 119;
            this.btnPersonInfoNext.Text = "Next";
            this.btnPersonInfoNext.UseVisualStyleBackColor = true;
            this.btnPersonInfoNext.Click += new System.EventHandler(this.btnPersonInfoNext_Click);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.Controls.Add(this.groupBox1);
            this.tpLoginInfo.Controls.Add(this.pictureBox2);
            this.tpLoginInfo.Controls.Add(this.lblUserID);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.chkIsActive);
            this.tpLoginInfo.Controls.Add(this.txtUserName);
            this.tpLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.label1);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Controls.Add(this.pictureBox8);
            this.tpLoginInfo.Controls.Add(this.pictureBox3);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(855, 472);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "LoginInfo";
            this.tpLoginInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.groupBox1.Controls.Add(this.chkMemberInstruct);
            this.groupBox1.Controls.Add(this.chkSubPeriod);
            this.groupBox1.Controls.Add(this.chkBeltTests);
            this.groupBox1.Controls.Add(this.chkBeltRank);
            this.groupBox1.Controls.Add(this.chkEmergContc);
            this.groupBox1.Controls.Add(this.chkPayments);
            this.groupBox1.Controls.Add(this.chkInstructors);
            this.groupBox1.Controls.Add(this.chkExpiredSubscriptions);
            this.groupBox1.Controls.Add(this.chkSports);
            this.groupBox1.Controls.Add(this.chkPeople);
            this.groupBox1.Controls.Add(this.chkMembers);
            this.groupBox1.Controls.Add(this.chkUsers);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(428, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 451);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissions";
            // 
            // chkMemberInstruct
            // 
            this.chkMemberInstruct.AutoSize = true;
            this.chkMemberInstruct.BackColor = System.Drawing.Color.Gainsboro;
            this.chkMemberInstruct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMemberInstruct.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMemberInstruct.ForeColor = System.Drawing.Color.Crimson;
            this.chkMemberInstruct.Location = new System.Drawing.Point(27, 249);
            this.chkMemberInstruct.Name = "chkMemberInstruct";
            this.chkMemberInstruct.Size = new System.Drawing.Size(189, 32);
            this.chkMemberInstruct.TabIndex = 2;
            this.chkMemberInstruct.Text = "Memb.Instruct";
            this.chkMemberInstruct.UseVisualStyleBackColor = false;
            this.chkMemberInstruct.CheckedChanged += new System.EventHandler(this.chkMemberInstruct_CheckedChanged);
            // 
            // chkSubPeriod
            // 
            this.chkSubPeriod.AutoSize = true;
            this.chkSubPeriod.BackColor = System.Drawing.Color.Gainsboro;
            this.chkSubPeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSubPeriod.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubPeriod.ForeColor = System.Drawing.Color.Crimson;
            this.chkSubPeriod.Location = new System.Drawing.Point(27, 287);
            this.chkSubPeriod.Name = "chkSubPeriod";
            this.chkSubPeriod.Size = new System.Drawing.Size(157, 32);
            this.chkSubPeriod.TabIndex = 2;
            this.chkSubPeriod.Text = "Sub.Periods";
            this.chkSubPeriod.UseVisualStyleBackColor = false;
            this.chkSubPeriod.CheckedChanged += new System.EventHandler(this.chkSubPeriod_CheckedChanged);
            // 
            // chkBeltTests
            // 
            this.chkBeltTests.AutoSize = true;
            this.chkBeltTests.BackColor = System.Drawing.Color.Gainsboro;
            this.chkBeltTests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkBeltTests.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBeltTests.ForeColor = System.Drawing.Color.Crimson;
            this.chkBeltTests.Location = new System.Drawing.Point(258, 401);
            this.chkBeltTests.Name = "chkBeltTests";
            this.chkBeltTests.Size = new System.Drawing.Size(132, 32);
            this.chkBeltTests.TabIndex = 2;
            this.chkBeltTests.Text = "Belt Tests";
            this.chkBeltTests.UseVisualStyleBackColor = false;
            this.chkBeltTests.CheckedChanged += new System.EventHandler(this.chkBeltTests_CheckedChanged);
            // 
            // chkBeltRank
            // 
            this.chkBeltRank.AutoSize = true;
            this.chkBeltRank.BackColor = System.Drawing.Color.Gainsboro;
            this.chkBeltRank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkBeltRank.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBeltRank.ForeColor = System.Drawing.Color.Crimson;
            this.chkBeltRank.Location = new System.Drawing.Point(27, 401);
            this.chkBeltRank.Name = "chkBeltRank";
            this.chkBeltRank.Size = new System.Drawing.Size(132, 32);
            this.chkBeltRank.TabIndex = 2;
            this.chkBeltRank.Text = "Belt Rank";
            this.chkBeltRank.UseVisualStyleBackColor = false;
            this.chkBeltRank.CheckedChanged += new System.EventHandler(this.chkBeltRank_CheckedChanged);
            // 
            // chkEmergContc
            // 
            this.chkEmergContc.AutoSize = true;
            this.chkEmergContc.BackColor = System.Drawing.Color.Gainsboro;
            this.chkEmergContc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEmergContc.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmergContc.ForeColor = System.Drawing.Color.Crimson;
            this.chkEmergContc.Location = new System.Drawing.Point(27, 363);
            this.chkEmergContc.Name = "chkEmergContc";
            this.chkEmergContc.Size = new System.Drawing.Size(186, 32);
            this.chkEmergContc.TabIndex = 2;
            this.chkEmergContc.Text = "Emrg.Contacts";
            this.chkEmergContc.UseVisualStyleBackColor = false;
            this.chkEmergContc.CheckedChanged += new System.EventHandler(this.chkEmergContc_CheckedChanged);
            // 
            // chkPayments
            // 
            this.chkPayments.AutoSize = true;
            this.chkPayments.BackColor = System.Drawing.Color.Gainsboro;
            this.chkPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPayments.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPayments.ForeColor = System.Drawing.Color.Crimson;
            this.chkPayments.Location = new System.Drawing.Point(27, 325);
            this.chkPayments.Name = "chkPayments";
            this.chkPayments.Size = new System.Drawing.Size(135, 32);
            this.chkPayments.TabIndex = 2;
            this.chkPayments.Text = "Payments";
            this.chkPayments.UseVisualStyleBackColor = false;
            this.chkPayments.CheckedChanged += new System.EventHandler(this.chkPayments_CheckedChanged);
            // 
            // chkInstructors
            // 
            this.chkInstructors.AutoSize = true;
            this.chkInstructors.BackColor = System.Drawing.Color.Gainsboro;
            this.chkInstructors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkInstructors.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInstructors.ForeColor = System.Drawing.Color.Crimson;
            this.chkInstructors.Location = new System.Drawing.Point(258, 249);
            this.chkInstructors.Name = "chkInstructors";
            this.chkInstructors.Size = new System.Drawing.Size(147, 32);
            this.chkInstructors.TabIndex = 2;
            this.chkInstructors.Text = "Instructors";
            this.chkInstructors.UseVisualStyleBackColor = false;
            this.chkInstructors.CheckedChanged += new System.EventHandler(this.chkInstructors_CheckedChanged);
            // 
            // chkExpiredSubscriptions
            // 
            this.chkExpiredSubscriptions.AutoSize = true;
            this.chkExpiredSubscriptions.BackColor = System.Drawing.Color.Gainsboro;
            this.chkExpiredSubscriptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkExpiredSubscriptions.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExpiredSubscriptions.ForeColor = System.Drawing.Color.Crimson;
            this.chkExpiredSubscriptions.Location = new System.Drawing.Point(27, 135);
            this.chkExpiredSubscriptions.Name = "chkExpiredSubscriptions";
            this.chkExpiredSubscriptions.Size = new System.Drawing.Size(260, 32);
            this.chkExpiredSubscriptions.TabIndex = 2;
            this.chkExpiredSubscriptions.Text = "Expired Subscriptions";
            this.chkExpiredSubscriptions.UseVisualStyleBackColor = false;
            this.chkExpiredSubscriptions.CheckedChanged += new System.EventHandler(this.chkExpiredSubscriptions_CheckedChanged);
            // 
            // chkSports
            // 
            this.chkSports.AutoSize = true;
            this.chkSports.BackColor = System.Drawing.Color.Gainsboro;
            this.chkSports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSports.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSports.ForeColor = System.Drawing.Color.Crimson;
            this.chkSports.Location = new System.Drawing.Point(27, 211);
            this.chkSports.Name = "chkSports";
            this.chkSports.Size = new System.Drawing.Size(100, 32);
            this.chkSports.TabIndex = 2;
            this.chkSports.Text = "Sports";
            this.chkSports.UseVisualStyleBackColor = false;
            this.chkSports.CheckedChanged += new System.EventHandler(this.chkSports_CheckedChanged);
            // 
            // chkPeople
            // 
            this.chkPeople.AutoSize = true;
            this.chkPeople.BackColor = System.Drawing.Color.Gainsboro;
            this.chkPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPeople.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPeople.ForeColor = System.Drawing.Color.Crimson;
            this.chkPeople.Location = new System.Drawing.Point(27, 97);
            this.chkPeople.Name = "chkPeople";
            this.chkPeople.Size = new System.Drawing.Size(103, 32);
            this.chkPeople.TabIndex = 2;
            this.chkPeople.Text = "People";
            this.chkPeople.UseVisualStyleBackColor = false;
            this.chkPeople.CheckedChanged += new System.EventHandler(this.chkPeople_CheckedChanged);
            // 
            // chkMembers
            // 
            this.chkMembers.AutoSize = true;
            this.chkMembers.BackColor = System.Drawing.Color.Gainsboro;
            this.chkMembers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMembers.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMembers.ForeColor = System.Drawing.Color.Crimson;
            this.chkMembers.Location = new System.Drawing.Point(27, 173);
            this.chkMembers.Name = "chkMembers";
            this.chkMembers.Size = new System.Drawing.Size(131, 32);
            this.chkMembers.TabIndex = 2;
            this.chkMembers.Text = "Members";
            this.chkMembers.UseVisualStyleBackColor = false;
            this.chkMembers.CheckedChanged += new System.EventHandler(this.chkMembers_CheckedChanged);
            // 
            // chkUsers
            // 
            this.chkUsers.AutoSize = true;
            this.chkUsers.BackColor = System.Drawing.Color.Gainsboro;
            this.chkUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUsers.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsers.ForeColor = System.Drawing.Color.Crimson;
            this.chkUsers.Location = new System.Drawing.Point(258, 97);
            this.chkUsers.Name = "chkUsers";
            this.chkUsers.Size = new System.Drawing.Size(88, 32);
            this.chkUsers.TabIndex = 2;
            this.chkUsers.Text = "Users";
            this.chkUsers.UseVisualStyleBackColor = false;
            this.chkUsers.CheckedChanged += new System.EventHandler(this.chkUsers_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-16, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(479, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "-------------------------------------------------------------------";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Gainsboro;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.Crimson;
            this.chkAll.Location = new System.Drawing.Point(127, 28);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(59, 32);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gymnasium.Properties.Resources.Person_322;
            this.pictureBox2.Location = new System.Drawing.Point(193, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 130;
            this.pictureBox2.TabStop = false;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(233, 58);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(39, 20);
            this.lblUserID.TabIndex = 129;
            this.lblUserID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 128;
            this.label4.Text = "UserID:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(193, 229);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(121, 29);
            this.chkIsActive.TabIndex = 127;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(231, 96);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(167, 20);
            this.txtUserName.TabIndex = 118;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(231, 168);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(167, 20);
            this.txtConfirmPassword.TabIndex = 124;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 120;
            this.label1.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 125;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 121;
            this.label2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(231, 132);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 119;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gymnasium.Properties.Resources.Password_321;
            this.pictureBox1.Location = new System.Drawing.Point(193, 168);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Gymnasium.Properties.Resources.ApplicationTitle;
            this.pictureBox8.Location = new System.Drawing.Point(193, 94);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 123;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Gymnasium.Properties.Resources.Password_321;
            this.pictureBox3.Location = new System.Drawing.Point(193, 131);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 122;
            this.pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::Gymnasium.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(607, 569);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 120;
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
            this.btnSave.Location = new System.Drawing.Point(741, 569);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 119;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(281, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 54);
            this.lblTitle.TabIndex = 121;
            this.lblTitle.Text = "Add New Users";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonInfoCardWithFilter1
            // 
            this.ctrlPersonInfoCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoCardWithFilter1.Location = new System.Drawing.Point(12, 13);
            this.ctrlPersonInfoCardWithFilter1.Name = "ctrlPersonInfoCardWithFilter1";
            this.ctrlPersonInfoCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonInfoCardWithFilter1.Size = new System.Drawing.Size(837, 399);
            this.ctrlPersonInfoCardWithFilter1.TabIndex = 120;
            // 
            // ShowAddEditeUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 614);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowAddEditeUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowChangeUserPasswordForm";
            this.Load += new System.EventHandler(this.ShowAddEditeUserForm_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.Button btnPersonInfoNext;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private People_Forms.ctrlPersonInfoCardWithFilter ctrlPersonInfoCardWithFilter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSports;
        private System.Windows.Forms.CheckBox chkPeople;
        private System.Windows.Forms.CheckBox chkMembers;
        private System.Windows.Forms.CheckBox chkUsers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkMemberInstruct;
        private System.Windows.Forms.CheckBox chkSubPeriod;
        private System.Windows.Forms.CheckBox chkBeltRank;
        private System.Windows.Forms.CheckBox chkEmergContc;
        private System.Windows.Forms.CheckBox chkPayments;
        private System.Windows.Forms.CheckBox chkBeltTests;
        private System.Windows.Forms.CheckBox chkInstructors;
        private System.Windows.Forms.CheckBox chkExpiredSubscriptions;
    }
}