using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gymnasium.Payments_Forms
{
    public partial class ShowManagePaymentsForm : Form
    {
        public ShowManagePaymentsForm()
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
                dt = clsPayments.GetPagedPayments(currentPage, pageSize, out totalRecords);
                dataGridView1.DataSource = dt;
                UpdatePaginationButtons();
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                // Load all data
                dt = clsPayments.GetAllPayments();
                dataGridView1.DataSource = dt;
                lbRecords.Text = dataGridView1.RowCount.ToString();
            }

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Payment ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Amount";
                dataGridView1.Columns[1].Width = 150;

                dataGridView1.Columns[2].HeaderText = "Payment Date";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Member ID";
                dataGridView1.Columns[3].Width = 120;

                // Set the text of the page number button to the current page number
                btnPageNumber.Text = currentPage.ToString();
            }
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




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbPageSize.SelectedItem);
            LoadPagedData();
        }

        private void ShowManagePaymentsForm_Load(object sender, EventArgs e)
        {
            rbByPages.Checked = true;
        }

        private void showPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int paymentID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            AddEditePaymentForm showPaymentDetailsForm = new AddEditePaymentForm(paymentID);
            showPaymentDetailsForm.ShowDialog();
        }
    }
}
