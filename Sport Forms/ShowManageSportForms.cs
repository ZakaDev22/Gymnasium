using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gymnasium.Sport_Forms
{
    public partial class ShowManageSportForms : Form
    {
        public ShowManageSportForms()
        {
            LoadPagedData();
            InitializeComponent();

        }

        private DataTable dt;


        private async void LoadPagedData()
        {

            dt = await clsSports.GetAllSports();
            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Sport ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Sport Name";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Sport Description";
                dataGridView1.Columns[2].Width = 345;

            }

            lbRecords.Text = dt.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
