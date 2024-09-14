using Gymnasium.Payments_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymnasium.Member_Forms
{
    public partial class SHowMemberPeriodsHistoryForm : Form
    {
        private int _memberId;
        private DataTable dt;

        public SHowMemberPeriodsHistoryForm(int memberId)
        {
            InitializeComponent();
            _memberId = memberId;

            ctrlMemberCardInfoWithFilter1.LoadMemberInfo(_memberId);
            ctrlMemberCardInfoWithFilter1.FilterEnabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task _RefreshDataGrideView()
        {
            dt = await clsSubscriptionPeriods.GetAllMemberPeriodsByMemberID(_memberId);

            dataGridView1.DataSource = dt;


            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Period ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Start Date";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "End Date";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Fees";
                dataGridView1.Columns[3].Width = 90;

                dataGridView1.Columns[4].HeaderText = "Is Paid";
                dataGridView1.Columns[4].Width = 60;

                dataGridView1.Columns[5].HeaderText = "Member ID";
                dataGridView1.Columns[5].Width = 90;

                dataGridView1.Columns[6].HeaderText = "Payment ID";
                dataGridView1.Columns[6].Width = 90;

                dataGridView1.Columns[7].HeaderText = "Is Active Period";
                dataGridView1.Columns[7].Width = 90;
            }

            lbRecords.Text = dt.Rows.Count.ToString();
        }

        private async void SHowMemberPeriodsHistoryForm_Load(object sender, EventArgs e)
        {
            await _RefreshDataGrideView();
        }

        private void showPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditePaymentForm addEditePaymentForm = new AddEditePaymentForm((int)dataGridView1.CurrentRow.Cells[6].Value);
            addEditePaymentForm.ShowDialog();
        }
    }
}
