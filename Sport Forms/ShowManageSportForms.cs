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
            InitializeComponent();
            LoadPagedData();
        }
        //=========================================================

        //private int currentPage = 1;
        //private int pageSize = 10;
        //private int totalRecords = 0;
        private DataTable dt;


        private void LoadPagedData()
        {
            // dt = clsUsers.GetPagedUsers(currentPage, pageSize, out totalRecords);

            dt = clsSports.GetAllSports();
            dataGridView1.DataSource = dt;

            // Update Hidders. for Every column

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Sport ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Sport Name";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Sport Description";
                dataGridView1.Columns[2].Width = 345;

            }
        }


        private void ShowManageSportForms_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
