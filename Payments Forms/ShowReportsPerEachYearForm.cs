﻿using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymnasium.Payments_Forms
{
    public partial class ShowReportsPerEachYearForm : Form
    {
        private DataTable dt;
        private int Year = 2024;

        public ShowReportsPerEachYearForm()
        {
            InitializeComponent();

        }

        private async Task _LoadData()
        {
            dt = await clsPayments.GetAllPaymentsPerEachMonth(Year);
            djvReports.DataSource = dt;

            if (djvReports.RowCount > 0)
            {
                djvReports.Columns[0].HeaderText = "Month Name";
                djvReports.Columns[0].Width = 140;

                djvReports.Columns[1].HeaderText = "Total Amount";
                djvReports.Columns[1].Width = 160;

                djvReports.Columns[2].HeaderText = "Average Amount Per Month";
                djvReports.Columns[2].Width = 160;
            }


            lbTotal.Text = djvReports.Rows.Count.ToString();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private async void ShowReportsPerEachYearForm_Load(object sender, EventArgs e)
        {
            txtFilterValue.Text = Year.ToString();

            await _LoadData();
        }

        private async void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            Year = Convert.ToInt32(txtFilterValue.Text);

            await _LoadData();
        }
    }
}
