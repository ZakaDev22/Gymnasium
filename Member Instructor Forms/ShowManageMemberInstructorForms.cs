using Gymnasium.People_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gymnasium.Member_Instructor_Forms
{
    public partial class ShowManageMemberInstructorForms : Form
    {
        public ShowManageMemberInstructorForms()
        {
            InitializeComponent();
            LoadPagedData();
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
                dt = clsMemberInstructor.GetPagedMembersInstructors(currentPage, pageSize, out totalRecords);
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = clsMemberInstructor.GetAllAssignments();
                dataGridView1.DataSource = dt;
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Member ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Instructor ID";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "Assign Date";
                dataGridView1.Columns[2].Width = 150;
            }

            // Set the text of the page number button to the current page number
            btnPageNumber.Text = currentPage.ToString();
        }

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

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterValue.Clear();
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
                case "Member ID":
                    FilterColumn = "MemberID";
                    break;



                case "Instructor ID":
                    FilterColumn = "InstructorID";
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


            // if (FilterColumn == "MemberID" || FilterColumn == "InstructorID")
            //in this case we deal with integer not string.

            dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            //else
            //    dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ShowManageMemberInstructorForms_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            rbByPages.Checked = true;
        }

        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            ShowAddEditeMemberInstructorForm frm = new ShowAddEditeMemberInstructorForm();
            frm.ShowDialog();

            LoadPagedData();
        }

        private async void memberPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Member = await clsMembers.GetMemberByID((int)dataGridView1.CurrentRow.Cells[0].Value);
            ShowPersonDetailsForm frm = new ShowPersonDetailsForm(Member.PersonID);
            frm.ShowDialog();
        }

        private void instructorPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonDetailsForm frm = new ShowPersonDetailsForm(clsInstructors.FindByID((int)dataGridView1.CurrentRow.Cells[1].Value).PersonID);
            frm.ShowDialog();
        }

        private void addAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEditeMemberInstructorForm frm = new ShowAddEditeMemberInstructorForm();
            frm.ShowDialog();

            LoadPagedData();
        }

        private void updateAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEditeMemberInstructorForm frm = new ShowAddEditeMemberInstructorForm(((int)dataGridView1.CurrentRow.Cells[1].Value), ((int)dataGridView1.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void deleteAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int memberID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int instructorID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            if (MessageBox.Show("Are you sure you want to delete this Assignment?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsMemberInstructor.Delete(instructorID, memberID))
                {
                    MessageBox.Show("Assignment was deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPagedData();
                }
                else
                    MessageBox.Show("Error, Assignment was not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Deleting Assignment was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }


}
