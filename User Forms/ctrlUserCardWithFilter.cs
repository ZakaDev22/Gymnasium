using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gymnasium.User_Forms
{
    public partial class ctrlUserCardWithFilter : UserControl
    {
        public ctrlUserCardWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (cbFilterBy.SelectedIndex)
            {
                // User ID
                case 0:
                    ctrlUserCard1.LoadUserInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;

                // Person ID
                case 1:
                    ctrlUserCard1.LoadUserInfoByPersonID(int.Parse(txtFilterValue.Text.Trim()));
                    break;

            }
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required.");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void ctrlUserCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
            cbFilterBy.SelectedIndex = 0;
        }

        private void ResetInformations()
        {
            txtFilterValue.Clear();
            ctrlUserCard1._ResetUserInfo();
            txtFilterValue.Focus();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetInformations();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                ResetInformations();
            }
        }
    }
}
