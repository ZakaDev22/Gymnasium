using Gymnasium.Global_Classes;
using GymnasiumLogicLayer;
using System;
using System.Windows.Forms;

namespace Gymnasium
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredentialFromRegistry(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUsers User;

            // Check If The Lenght Is 64 To Know If The Current User Has Remember Me or He Want To Write The Password By Himself
            if (txtPassword.Text.Length != 64)
            {
                User = await clsUsers.IsUserExiste(txtUserName.Text, clsUtil.ComputeHash(txtPassword.Text));
            }
            else
            {
                User = await clsUsers.IsUserExiste(txtUserName.Text, txtPassword.Text);
            }

            //User = clsUsers.IsUserExiste(txtUserName.Text, txtPassword.Text);

            if (User != null)
            {
                if (User.IsActive == true)
                {
                    clsGlobal._CurrentUser = User;

                    if (chkRememberMe.Checked)
                    {


                        if (txtPassword.Text.Length != 64)
                            clsGlobal.RememberUsernameAndPasswordUsingRegistry(txtUserName.Text.Trim(), clsUtil.ComputeHash(txtPassword.Text.Trim()));
                        else
                            clsGlobal.RememberUsernameAndPasswordUsingRegistry(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                    }
                    else
                    {

                        clsGlobal.RememberUsernameAndPasswordUsingRegistry("", "");

                    }

                    ShowMainScreenFormcs frm = new ShowMainScreenFormcs(this);
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This Account Is Not Active, Please Connect Your Admin", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalide UserName Or Password!", "Wrong Credentials",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Please Enter Your UserName");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Please Enter Your Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }
    }
}
