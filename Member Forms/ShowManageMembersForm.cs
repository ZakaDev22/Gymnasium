using Gymnasium.People_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gymnasium.Member_Forms
{
    public partial class ShowManageMembersForm : Form
    {
        public ShowManageMembersForm()
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
                dt = clsMembers.GetPagedMembers(currentPage, pageSize, out totalRecords);
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = clsMembers.GetAllMembers();
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



        private void btnLeft_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (cbFilterBy.SelectedIndex == 6)
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {


            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {




                case "Member ID":
                    FilterColumn = "MemberID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "EmergencyContactID":
                    FilterColumn = "EmergencyContactID";
                    break;

                case "Sport Name":
                    FilterColumn = "SportName";
                    break;

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


            if (FilterColumn == "PersonID" || FilterColumn == "MemberID" || FilterColumn == "EmergencyContactID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbPageSize.SelectedItem);
            LoadPagedData();
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

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2 || cbFilterBy.SelectedIndex == 4)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Handles the Load event of the ShowManageUsersForm control.
        /// Sets the selected index of the cbFilterBy combo box to 0 and checks the rbByPages radio button.
        /// Loads the initial data into the data grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ShowManageMembersForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            rbByPages.Checked = true;
            LoadPagedData();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            ShowAddEditeMembersForm frm = new ShowAddEditeMembersForm();
            frm.ShowDialog();
            LoadPagedData();
        }

        private void memberPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonDetailsForm frm = new ShowPersonDetailsForm((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEditeMembersForm frm = new ShowAddEditeMembersForm();
            frm.ShowDialog();
            LoadPagedData();
        }

        private void updateMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemeberID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            ShowAddEditeMembersForm frm = new ShowAddEditeMembersForm(MemeberID);
            frm.ShowDialog();
            LoadPagedData();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this member?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsMembers.DeleteMember((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Member was deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPagedData();
                }
                else
                    MessageBox.Show("Error, Member was not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Member was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showMemberPeriodsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SHowMemberPeriodsHistoryForm frm = new SHowMemberPeriodsHistoryForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // check if The DataGrid View has Any Row, if not Then This Code Will Not Implemented
            if (dataGridView1.Rows.Count > 0)
            {
                // Set The Enabled Property Of The Context Menu Strip To True
                contextMenuStrip1.Enabled = true;

                int MemberID = (int)dataGridView1.CurrentRow.Cells[0].Value;

                bool MemberActive = clsMembers.IsMemberActive(MemberID);

                SetMemberToInActiveMenuItem.Enabled = MemberActive;

                SetMemberToActiveMenuItem.Enabled = MemberActive == false;
            }
            else
                contextMenuStrip1.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to Set this member to Active AGain?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsMembers.SetMemberAsActiveOrInactive(MemberID, true))
                {
                    MessageBox.Show("Member was  Set To Active  successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPagedData();
                }
                else
                    MessageBox.Show("Error, Member was not Set To Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(" set Member to Active was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            int MemberID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to Set this member to InActive AGain?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsMembers.SetMemberAsActiveOrInactive(MemberID, false))
                {
                    MessageBox.Show("Member was  Set To InActive successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPagedData();
                }
                else
                    MessageBox.Show("Error, Member was not Set To InActive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(" set Member to InActive was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
