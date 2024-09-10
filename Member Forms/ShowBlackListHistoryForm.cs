using Gymnasium.People_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymnasium.Member_Forms
{
    public partial class ShowBlackListHistoryForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private DataTable dt;

        public ShowBlackListHistoryForm()
        {
            InitializeComponent();

            rbByPages.Checked = true;
        }

        private async Task LoadPagedData()
        {
            // Load the paged data into the data grid view
            if (rbByPages.Checked)
            {
                // Load the paged data
                var tuple = await clsMembers.GetPagedBlackListHistory(currentPage, pageSize);
                totalRecords = tuple.totalCount;
                dt = tuple.dataTable;
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = await clsMembers.GetBlackListHistory();
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

        private async void rbByPages_CheckedChanged(object sender, EventArgs e)
        {

            if (rbByPages.Checked)
            {
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

            await LoadPagedData();
        }

        private async void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbPageSize.SelectedItem);
            await LoadPagedData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
                txtFilterValue.Visible = false;
            else
            {

                txtFilterValue.Visible = true;
                txtFilterValue.Clear();
                txtFilterValue.Focus();


            }
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

                case "Black List History ID":
                    FilterColumn = "BlackListHistoryID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
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


            if (FilterColumn == "BlackListHistoryID" || FilterColumn == "MemberID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private async void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage * pageSize < totalRecords)
            {
                currentPage++;
                await LoadPagedData();
            }
        }

        private async void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await LoadPagedData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowBlackListHistoryForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private async void memberPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeople Person = await clsPeople.FindByID((int)dataGridView1.CurrentRow.Cells[1].Value);
            ShowPersonDetailsForm frm = new ShowPersonDetailsForm(Person.PersonID);
            frm.ShowDialog();
        }

        private void cntxMemberInformations_Click(object sender, EventArgs e)
        {
            ShowMemberInformationForm frm = new ShowMemberInformationForm((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private async void SetMemberToActiveMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            if (MessageBox.Show("Are you sure you want to Set this member to Active AGain?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsMembers.SetMemberAsActiveOrInactive(MemberID, true))
                {
                    MessageBox.Show("Member was  Set To Active  successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPagedData();
                }
                else
                    MessageBox.Show("Error, Member was not Set To Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(" set Member to Active was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void SetMemberToInActiveMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            if (MessageBox.Show("Are you sure you want to Set this member to InActive AGain?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsMembers.SetMemberAsActiveOrInactive(MemberID, false))
                {
                    MessageBox.Show("Member was  Set To InActive successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPagedData();
                }
                else
                    MessageBox.Show("Error, Member was not Set To InActive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(" set Member to InActive was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showMemberPeriodsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SHowMemberPeriodsHistoryForm frm = new SHowMemberPeriodsHistoryForm((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private async void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                // Set The Enabled Property Of The Context Menu Strip To True
                contextMenuStrip1.Enabled = true;

                int MemberID = (int)dataGridView1.CurrentRow.Cells[0].Value;

                bool MemberActive = await clsMembers.IsMemberActive(MemberID);

                SetMemberToInActiveMenuItem.Enabled = MemberActive;

                SetMemberToActiveMenuItem.Enabled = MemberActive == false;
            }
            else
                contextMenuStrip1.Enabled = false;
        }
    }
}
