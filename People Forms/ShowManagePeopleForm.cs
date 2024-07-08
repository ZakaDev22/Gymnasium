using Gymnasium.Global_Classes;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ShowManagePeopleForm : Form
    {
        public ShowManagePeopleForm()
        {
            InitializeComponent();
            rbByPages.Checked = true;
            LoadPagedData();
        }


        private int currentPage = 1;
        private int pageSize = 8;
        private int totalRecords = 0;
        private DataTable dt;

        private void LoadPagedData()
        {
            // Load the paged data into the data grid view
            if (rbByPages.Checked)
            {
                // Load the paged data
                dt = clsPeople.GetPagedPeople(currentPage, pageSize, out totalRecords);
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = clsPeople.GetAllPeople();
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


        /// <summary>
        /// Handles the CheckedChanged event of the rbByPages control.
        /// Updates the visibility and data of the pagination controls based on the checked state of the control.
        /// Calls the LoadPagedData method to load the paged data into the data grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPagedData();
            }
        }

        // Handles the Click event of the btnRight control.
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage * pageSize < totalRecords)
            {
                currentPage++;
                LoadPagedData();
            }
        }

        /// <summary>
        /// Handles the Load event of the ShowManagePeopleForm control.
        /// Sets the selected index of the cbFilterBy combo box to 0 and checks the rbByPages radio button.
        /// Loads the initial data into the data grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ShowManagePeopleForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbPageSize.Text);
            LoadPagedData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterValue.Visible = false;
            }
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
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;


                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "Gendor";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
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


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {


            // Check if the pressed key is Enter (character code 13)
            //if (e.KeyChar == (char)13)
            //{

            //    btnFind.PerformClick();
            //}

            //this will allow only digits if person id is selected
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 6)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            ShowAddEditePersonForm frm = new ShowAddEditePersonForm();
            frm.ShowDialog();

            LoadPagedData();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEditePersonForm frm = new ShowAddEditePersonForm();
            frm.ShowDialog();

            LoadPagedData();
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[0].Value;


            if ((PersonID == 1) && clsGlobal._CurrentUser.PersonID != 1)
            {
                MessageBox.Show($"Error,You Can't See The Admin User Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make Me The Admin So That NoOther User Can See Our Information 🤣
            if (PersonID == 2 && clsGlobal._CurrentUser.PersonID != 2 && (clsGlobal._CurrentUser.PersonID != 1))
            {
                MessageBox.Show($"Error,You Can't See The Admin Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowAddEditePersonForm frm = new ShowAddEditePersonForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            LoadPagedData();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            // Make Me And My Brother Admin So That No One Can Delete Us From The System 🤣
            if (PersonID == 1 || PersonID == 2)
            {
                MessageBox.Show($"Error,You Can't Delete The Admin 😎💪🙄🤣🤣 \n Person With ID {PersonID} Is Was Not Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are You Sure You Want To Delete This Person", "Confirm",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPeople.Delete(PersonID))
                {
                    MessageBox.Show($"Person With ID {PersonID} Was Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadPagedData();
                }
                else
                    MessageBox.Show($"Error, Person With ID {PersonID} Was Not Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[0].Value;


            if ((PersonID == 1) && clsGlobal._CurrentUser.PersonID != 1)
            {
                MessageBox.Show($"Error,You Can't See The Admin User Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make Me The Admin So That NoOther User Can See Our Information 🤣
            if (PersonID == 2 && clsGlobal._CurrentUser.PersonID != 2 && (clsGlobal._CurrentUser.PersonID != 1))
            {
                MessageBox.Show($"Error,You Can't See The Admin Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowPersonDetailsForm frm = new ShowPersonDetailsForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();


        }
    }
}
