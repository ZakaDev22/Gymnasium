using Gymnasium.Global_Classes;
using GymnasiumLogicLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gymnasium.User_Forms
{
    public partial class ShowCHangeUserPasswordForm : Form
    {
        private int UserID = -1;
        private clsUsers _User;

        public ShowCHangeUserPasswordForm(int UserID)
        {
            InitializeComponent();

            this.UserID = UserID;
        }


        private async void ShowCHangeUserPasswordForm_Load(object sender, EventArgs e)
        {
            _User = await clsUsers.FindByID(UserID);

            if (_User != null)
            {
                txtCurrentPassword.Select();

                ctrlUserCard1.LoadUserInfo(UserID);
            }
            else
            {
                MessageBox.Show($"This Form Will Be Closed because User with ID {UserID} is Not Found",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text.Length != 64)
            {
                if (clsUtil.ComputeHash(txtCurrentPassword.Text) != _User.Password)
                {
                    e.Cancel = true;
                    txtCurrentPassword.Focus();
                    errorProvider1.SetError(txtCurrentPassword, "You Have To Set The Current Password ❓");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtCurrentPassword, "");
                }
            }
            else
            {
                if (txtCurrentPassword.Text != _User.Password)
                {
                    e.Cancel = true;
                    txtCurrentPassword.Focus();
                    errorProvider1.SetError(txtCurrentPassword, "You Have To Set The Current Password ❓");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtCurrentPassword, "");
                }
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider1.SetError(txtNewPassword, "You Have To Set The New Password ❓");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "The New Password Should Match The New Password ❗");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if The Current User Is CHanging His Password So That We DOnt Have To Encrypt it Only Once
            if (_User.Password != txtNewPassword.Text)
                _User.Password = clsUtil.ComputeHash(txtNewPassword.Text);

            if (await _User.Save())
            {
                MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed To Change Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
