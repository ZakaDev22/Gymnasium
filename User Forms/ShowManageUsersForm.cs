using Gymnasium.Global_Classes;
using Gymnasium.People_Forms;
using Gymnasium.User_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gymnasium
{
    public partial class ShowManageUsersForm : Form
    {
        public ShowManageUsersForm()
        {
            InitializeComponent();
            //  LoadPagedData();
        }


        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private DataTable dt;

        private void LoadPagedData()
        {
            // Load the paged data into the data grid view
            if (rbByPages.Checked)
            {
                // Load the paged data
                dt = clsUsers.GetPagedUsers(currentPage, pageSize, out totalRecords);
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = clsUsers.GetAllUsers();
                dataGridView1.DataSource = dt;
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }

            // Set the text of the page number button to the current page number
            btnPageNumber.Text = currentPage.ToString();
        }


        /// <summary>
        /// Updates the enabled state and background color of the pagination buttons based on the current page and total records.
        /// </summary>
        private void UpdatePaginationButtons()
        {
            // Enable the left button if the current page is greater than 1
            btnLeft.Enabled = currentPage > 1;
            // Enable the right button if the current page times the page size is less than the total records
            btnRight.Enabled = currentPage * pageSize < totalRecords;
            // Set the background color of the left button to GreenYellow if it is enabled, otherwise set it to Red
            btnLeft.BackColor = btnLeft.Enabled ? Color.GreenYellow : Color.Red;
            // Set the background color of the right button to GreenYellow if it is enabled, otherwise set it to Red
            btnRight.BackColor = btnRight.Enabled ? Color.GreenYellow : Color.Red;
        }

        private void btnLeft_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPagedData();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage * pageSize < totalRecords)
            {
                currentPage++;
                LoadPagedData();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Permissions":
                    FilterColumn = "Permissions";
                    break;

                //case "Is Active":
                //    FilterColumn = "IsActive";
                //    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lbRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID" || FilterColumn == "UserID" || FilterColumn == "Permissions")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbFilterBy combo box.
        /// Updates the visibility and content of the cbIsActive combo box and txtFilterValue text box based on the selected index.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                cbIsActive.Visible = false;
                txtFilterValue.Visible = false;
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 5)
                {
                    txtFilterValue.Visible = false;
                    cbIsActive.Visible = true;
                    cbIsActive.SelectedIndex = 0;
                }
                else
                {
                    cbIsActive.Visible = false;
                    txtFilterValue.Visible = true;
                    txtFilterValue.Clear();
                    txtFilterValue.Focus();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbByPages_CheckedChanged(object sender, EventArgs e)
        {
            if (rbByPages.Checked)
            {
                cbPageSize.SelectedIndex = 0;
                lbSize.Visible = true;
                cbPageSize.Visible = true;
                btnLeft.Visible = true;
                btnRight.Visible = true;
                btnPageNumber.Visible = true;
            }
            else
            {
                lbSize.Visible = false;
                cbPageSize.Visible = false;
                btnLeft.Visible = false;
                btnRight.Visible = false;
                btnPageNumber.Visible = false;
            }

            LoadPagedData();
        }

        /// <summary>
        /// Handles the Load event of the ShowManageUsersForm control.
        /// Sets the selected index of the cbFilterBy combo box to 0 and checks the rbByPages radio button.
        /// Loads the initial data into the data grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ShowManageUsersForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            rbByPages.Checked = true;
            LoadPagedData();
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbPageSize.Text);
            LoadPagedData();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            short FilterValue = 0;

            //Map Selected Filter to real Column name 
            switch (cbIsActive.Text)
            {

                case "Active.":
                    FilterValue = 1;
                    break;

                case "Not Active.":
                    FilterValue = 0;
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (FilterColumn == "None")
            {
                dt.DefaultView.RowFilter = "";
                lbRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            // if (FilterColumn == "PersonID" || FilterColumn == "UserID" || FilterColumn == "Permissions")
            //in this case we deal with integer not string.

            // in this case there is only true or false Cases Thats Whay I Dont Ned To check With If Statement
            dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            //else
            //    dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2 || cbFilterBy.SelectedIndex == 4)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            ShowAddEditeUserForm frm = new ShowAddEditeUserForm();
            frm.ShowDialog();

            LoadPagedData();

        }

        private void showPersonIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if ((PersonID == 1) && clsGlobal._CurrentUser.PersonID != 1)
            {
                MessageBox.Show($"Error,You Can't See The Admin Person Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if (PersonID == 2 && clsGlobal._CurrentUser.PersonID != 1 && clsGlobal._CurrentUser.PersonID != 2)
            {
                MessageBox.Show($"Error,You Can't See The Admin Person Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowPersonDetailsForm frm = new ShowPersonDetailsForm((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if ((userID == 1) && clsGlobal._CurrentUser.UserID != 1)
            {
                MessageBox.Show($"Error,You Can't See The Admin User Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if (userID == 2 && clsGlobal._CurrentUser.UserID != 1 && clsGlobal._CurrentUser.UserID != 2)
            {
                MessageBox.Show($"Error,You Can't See The Admin User Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowUserInfoForm frm = new ShowUserInfoForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEditeUserForm frm = new ShowAddEditeUserForm();
            frm.ShowDialog();

            LoadPagedData();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            if ((userID == 1) && clsGlobal._CurrentUser.UserID != 1)
            {
                MessageBox.Show($"Error,You Can't See The Admin User Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if (userID == 2 && clsGlobal._CurrentUser.UserID != 1 && clsGlobal._CurrentUser.UserID != 2)
            {
                MessageBox.Show($"Error,You Can't Update The Admin Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowAddEditeUserForm frm = new ShowAddEditeUserForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            LoadPagedData();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if (UserID == 1 || UserID == 2)
            {
                MessageBox.Show($"Error,You Can't Delete The Admin From The System 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("Are You Sure You Want To Delete This User ??", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUsers.Delete(UserID))
                {
                    MessageBox.Show($"Success, User With ID {UserID} Was Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPagedData();
                }
                else
                {
                    MessageBox.Show($"Failed, User With ID {UserID} Was Not Deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Deleting User With ID {UserID} Was Canceled", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            // Make Me And My Brother Admin So That No Other User Can Update Our Information 🤣
            if ((userID == 1) && clsGlobal._CurrentUser.UserID != 1)
            {
                MessageBox.Show($"Error,You Can't Change The Admin Password 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((userID == 2) && clsGlobal._CurrentUser.UserID != 1 && clsGlobal._CurrentUser.UserID != 2)
            {
                MessageBox.Show($"Error,You Can't Change The Admin Password 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowCHangeUserPasswordForm frm = new ShowCHangeUserPasswordForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
