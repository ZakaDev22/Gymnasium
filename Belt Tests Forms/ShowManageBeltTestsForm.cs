using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gymnasium.Belt_Tests_Forms
{
    public partial class ShowManageBeltTestsForm : Form
    {
        public ShowManageBeltTestsForm()
        {
            InitializeComponent();
        }

        //=========================================================

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
                dt = clsBeltTest.GetPagedBeltTests(currentPage, pageSize, out totalRecords);
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = clsBeltTest.GetAllBeltTests();
                dataGridView1.DataSource = dt;
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Test ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Member ID";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Rank ID";
                dataGridView1.Columns[2].Width = 110;

                dataGridView1.Columns[3].HeaderText = "Is Pass";
                dataGridView1.Columns[3].Width = 60;

                dataGridView1.Columns[4].HeaderText = "Test Date";
                dataGridView1.Columns[4].Width = 130;

                dataGridView1.Columns[5].HeaderText = "Instructor ID";
                dataGridView1.Columns[5].Width = 110;

                //dataGridView1.Columns[6].HeaderText = "Payment ID";
                //dataGridView1.Columns[6].Width = 110;

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


        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "Test ID":
                    FilterColumn = "TestID";
                    break;

                case "Member ID":
                    FilterColumn = "MemberID";
                    break;

                case "Rank ID":
                    FilterColumn = "RankID";
                    break;

                case "Instructor ID":
                    FilterColumn = "TestedByInstructorID";
                    break;

                case "Payment ID":
                    FilterColumn = "PaymentID";
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


            if (FilterColumn == "TestID" || FilterColumn == "MemberID" || FilterColumn == "RankID" ||
                FilterColumn == "TestedByInstructorID" || FilterColumn == "PaymentID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

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

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbPageSize.SelectedItem);
            LoadPagedData();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Result";
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

        private void ShowManageBeltTestsForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            rbByPages.Checked = true;
        }
    }
}
