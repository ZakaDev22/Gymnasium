using Gymnasium.Global_Classes;
using GymnasiumLogicLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gymnasium.User_Forms
{
    public partial class ShowAddEditeUserForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUsers _User;
        private int _Permissions = 0;


        public ShowAddEditeUserForm()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public ShowAddEditeUserForm(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonInfoCardWithFilter1.PersonID != -1)
            {

                if (clsUsers.ExistsByID(ctrlPersonInfoCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonInfoCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoCardWithFilter1.FilterFocus();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPersonInfoCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();

            _User.IsActive = chkIsActive.Checked;

            _User.Permissions = _Permissions;

            // check if The Current User Is CHanging His Password So That We DOnt Have To Encrypt it Only Once 
            if (_User.Password != txtPassword.Text.Trim())
            {
                _User.Password = clsUtil.ComputeHash(txtPassword.Text.Trim());
            }


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUsers();

                tpLoginInfo.Enabled = false;

                ctrlPersonInfoCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;


        }

        private void _LoadData()
        {

            _User = clsUsers.FindByID(_UserID);
            ctrlPersonInfoCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrlPersonInfoCardWithFilter1.LoadPersonInfo(_User.PersonID);

            if (_User.Permissions == 4092)
            {
                chkAll.Checked = true;
            }
            else
            {
                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 1))
                {
                    chkPeople.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 2))
                {
                    chkUsers.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 4))
                {
                    chkMembers.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 8))
                {
                    chkSports.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 16))
                {
                    chkMemberInstruct.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 32))
                {
                    chkSubPeriod.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 64))
                {
                    chkPayments.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 128))
                {
                    chkEmergContc.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 256))
                {
                    chkBeltRank.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 512))
                {
                    chkBeltTests.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 1024))
                {
                    chkInstructors.Checked = true;
                }

                if (clsValidation.IsUserHaveThisPermission(_User.Permissions, 2048))
                {
                    chkExpiredSubscriptions.Checked = true;
                }
            }
        }

        private void ShowAddEditeUserForm_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            };

            // incase of add new  make sure not to use anothers user name
            if (_Mode == enMode.AddNew)
            {

                if (clsUsers.ExistsByUserName(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUsers.ExistsByUserName(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                _Permissions = 4095;

                chkPeople.Checked = true;
                chkUsers.Checked = true;
                chkMembers.Checked = true;
                chkSports.Checked = true;
                chkMemberInstruct.Checked = true;
                chkSubPeriod.Checked = true;
                chkPayments.Checked = true;
                chkEmergContc.Checked = true;
                chkBeltRank.Checked = true;
                chkBeltTests.Checked = true;
                chkInstructors.Checked = true;
                chkExpiredSubscriptions.Checked = true;

                chkPeople.Enabled = false;
                chkUsers.Enabled = false;
                chkMembers.Enabled = false;
                chkSports.Enabled = false;
                chkMemberInstruct.Enabled = false;
                chkSubPeriod.Enabled = false;
                chkPayments.Enabled = false;
                chkEmergContc.Enabled = false;
                chkBeltRank.Enabled = false;
                chkBeltTests.Enabled = false;
                chkInstructors.Enabled = false;
                chkExpiredSubscriptions.Enabled = false;

            }
            else
            {
                _Permissions = 4095;

                chkPeople.Checked = false;
                chkUsers.Checked = false;
                chkMembers.Checked = false;
                chkSports.Checked = false;
                chkMemberInstruct.Checked = false;
                chkSubPeriod.Checked = false;
                chkPayments.Checked = false;
                chkEmergContc.Checked = false;
                chkBeltRank.Checked = false;
                chkBeltTests.Checked = false;
                chkInstructors.Checked = false;
                chkExpiredSubscriptions.Checked = false;

                chkPeople.Enabled = true;
                chkUsers.Enabled = true;
                chkMembers.Enabled = true;
                chkSports.Enabled = true;
                chkMemberInstruct.Enabled = true;
                chkSubPeriod.Enabled = true;
                chkPayments.Enabled = true;
                chkEmergContc.Enabled = true;
                chkBeltRank.Enabled = true;
                chkBeltTests.Enabled = true;
                chkInstructors.Enabled = true;
                chkExpiredSubscriptions.Enabled = true;
            }
        }

        private void chkPeople_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.People;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 1)
                    _Permissions -= (int)clsUsers.enPermissions.People;
            }
        }

        private void chkUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.Users;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 2)
                    _Permissions -= (int)clsUsers.enPermissions.Users;
            }
        }

        private void chkMembers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.Members;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 4)
                    _Permissions -= (int)clsUsers.enPermissions.Members;
            }
        }

        private void chkSports_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.Sports;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 8)
                    _Permissions -= (int)clsUsers.enPermissions.Sports;
            }
        }

        private void chkMemberInstruct_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.MemberInstructor;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 16)
                    _Permissions -= (int)clsUsers.enPermissions.MemberInstructor;
            }
        }

        private void chkSubPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.SubscriptionPeriods;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 32)
                    _Permissions -= (int)clsUsers.enPermissions.SubscriptionPeriods;
            }
        }

        private void chkPayments_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.Payments;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 64)
                    _Permissions -= (int)clsUsers.enPermissions.Payments;
            }
        }

        private void chkEmergContc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.EmergencyContacts;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 128)
                    _Permissions -= (int)clsUsers.enPermissions.EmergencyContacts;
            }
        }

        private void chkBeltRank_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.BeltRank;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 256)
                    _Permissions -= (int)clsUsers.enPermissions.BeltRank;
            }
        }

        private void chkBeltTests_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.BeltTests;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 512)
                    _Permissions -= (int)clsUsers.enPermissions.BeltTests;
            }
        }

        private void chkExpiredSubscriptions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.ExpiredSubscriptions;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 2048)
                    _Permissions -= (int)clsUsers.enPermissions.ExpiredSubscriptions;
            }
        }

        private void chkInstructors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                return;
            }

            if (chkPeople.Checked)
            {
                _Permissions += (int)clsUsers.enPermissions.Instructors;
            }
            else
            {
                if (_Permissions != 0 || _Permissions != 1024)
                    _Permissions -= (int)clsUsers.enPermissions.Instructors;
            }
        }

        // finise the Other Permissions With Same Logic In Chk People
    }
}
