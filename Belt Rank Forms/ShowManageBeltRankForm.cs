using GymnasiumLogicLayer;
using System.Data;
using System.Windows.Forms;

namespace Gymnasium.Belt_Rank_Forms
{
    public partial class ShowManageBeltRankForm : Form
    {
        public ShowManageBeltRankForm()
        {
            InitializeComponent();
            LoadPagedData();
        }


        private async void LoadPagedData()
        {
            DataTable dt = await clsBeltRanks.GetAllBeltRanks();
            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Rank ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Rank Name";
                dataGridView1.Columns[1].Width = 140;

                dataGridView1.Columns[2].HeaderText = "Rank Fees";
                dataGridView1.Columns[2].Width = 100;
            }

            lbRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
