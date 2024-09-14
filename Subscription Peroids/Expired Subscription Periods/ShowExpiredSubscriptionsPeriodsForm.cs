using Gymnasium.Member_Forms;
using Gymnasium.Payments_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gymnasium.Subscription_Peroids.Expired_Subscriptions
{
    public partial class ShowExpiredSubscriptionsPeriodsForm : Form
    {
        public ShowExpiredSubscriptionsPeriodsForm()
        {
            InitializeComponent();

            LoadPagedData();
        }

        private DataTable dt;

        private async void LoadPagedData()
        {
            // Load the paged data into the data grid view

            // Load all data
            dt = await clsSubscriptionPeriods.GetAllExpiredSubscriptions();
            dataGridView1.DataSource = dt;
            lbRecords.Text = dataGridView1.RowCount.ToString();


            if (dataGridView1.Rows.Count > 0)
            {
                cbFilterBy.Enabled = true;

                lbNoExpired.Visible = false;

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
            else
            {
                cbFilterBy.Enabled = false;

                lbNoExpired.Visible = true;
            }


        }

        private void ShowExpiredSubscriptionsPeriodsForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                cbIsPaid.Visible = false;
                txtFilterValue.Visible = false;
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 4)
                {
                    txtFilterValue.Visible = false;
                    cbIsPaid.Visible = true;
                    cbIsPaid.SelectedIndex = 0;
                }
                else
                {
                    cbIsPaid.Visible = false;
                    txtFilterValue.Visible = true;
                    txtFilterValue.Clear();
                    txtFilterValue.Focus();
                }

            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    FilterColumn = "PeriodID";
                    break;

                case 2:
                    FilterColumn = "MemberID";
                    break;


                case 3:
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


            //  if (FilterColumn == "PeriodID" || FilterColumn == "PeriodID" || FilterColumn == "PaymentID")
            //in this case we deal with integer not string.

            dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            //else
            //    dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void cbIsPaid_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "Paid";
            short FilterValue = 0;

            //Map Selected Filter to real Column name 
            switch (cbIsPaid.Text)
            {

                case "Yes.":
                    FilterValue = 1;
                    break;

                case "No.":
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

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2 || cbFilterBy.SelectedIndex == 3)
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void showMemberDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dataGridView1.CurrentRow.Cells[5].Value;

            ShowMemberInformationForm frm = new ShowMemberInformationForm(MemberID);
            frm.ShowDialog();
        }


        // Handles the Opening event of the contextMenuStrip1 control.
        // It retrieves the MemberID from the current row of dataGridView1,
        // checks if the member is active using clsMembers.IsMemberActive method,
        // sets the setMemberInActiveToolStripMenuItem.Enabled property based on the MemberActive status,
        // and sets the renweMemberSubscriptionToolStripMenuItem.Enabled property accordingly.
        private async void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            // check if The DataGrid View has Any Row, if not Then This Code Will Not Implemented
            if (dataGridView1.Rows.Count > 0)
            {
                // Set The Enabled Property Of The Context Menu Strip To True
                contextMenuStrip1.Enabled = true;

                // check if This Period Already InActive, if true Then Set Both Of Set Member Active And Renew Subscription Options To Inactive
                bool result = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value);
                if (result != true)
                {
                    setMemberInActiveToolStripMenuItem.Enabled = false;
                    renweMemberSubscriptionToolStripMenuItem.Enabled = false;

                    return;
                }

                int MemberID = (int)dataGridView1.CurrentRow.Cells[5].Value;

                bool MemberActive = await clsMembers.IsMemberActive(MemberID);

                setMemberInActiveToolStripMenuItem.Enabled = MemberActive;

                renweMemberSubscriptionToolStripMenuItem.Enabled = MemberActive == false;
            }
            else
                contextMenuStrip1.Enabled = false;
        }

        private void showPaymnetDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PaymentID = (int)dataGridView1.CurrentRow.Cells[6].Value;

            AddEditePaymentForm frm = new AddEditePaymentForm(PaymentID);
            frm.ShowDialog();
        }

        // Handles the Click event of the renweMemberSubscriptionToolStripMenuItem control.
        // Retrieves the MemberID from the current row of dataGridView1,
        // Gets the sport fees for the member,
        // Asks for confirmation to set the member as active again,
        // If confirmed, sets the member as active, shows success message, opens a payment form,
        // Sets the old subscription period to inactive, shows appropriate messages,
        // Otherwise, shows cancellation message.
        private async void renweMemberSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dataGridView1.CurrentRow.Cells[5].Value;

            // Get The Sport Fees That The Member Should Pay
            var Member = await clsMembers.GetMemberByID(MemberID);

            await Member.LoadPersonInfoAsync(Member.PersonID);

            float Fess = Member._SportInfo.Fees;

            if (MessageBox.Show("Are you sure you want to set this member as Active Again ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsMembers.SetMemberAsActiveOrInactive(MemberID, true))
                {
                    MessageBox.Show("Member was set to active successfully,\n Complete The New Payment And Renew The Subscription.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // call Payment Form After Set The Member As Active Again ANd Get A New Payment With A New Subscription Period. 
                    AddEditePaymentForm frm = new AddEditePaymentForm(MemberID, Fess);
                    frm.ShowDialog();

                    // Set The Old Period To InActive

                    if (await clsSubscriptionPeriods.SetPeriodInActive((int)dataGridView1.CurrentRow.Cells[0].Value))

                        MessageBox.Show("The Old Period Is Now Inactive.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error, The Old Period Is Not Inactive Yet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    LoadPagedData();
                }
                else
                {
                    MessageBox.Show("Error, Member was not set to inactive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Setting member as inactive was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void setMemberInActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dataGridView1.CurrentRow.Cells[5].Value;

            if (MessageBox.Show("Are you sure you want to set this member as inactive?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (await clsMembers.SetMemberAsActiveOrInactive(MemberID, false))
                {
                    MessageBox.Show("Member was set to inactive successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPagedData();
                }
                else
                {
                    MessageBox.Show("Error, Member was not set to inactive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Setting member as inactive was Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showMemberHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SHowMemberPeriodsHistoryForm frm = new SHowMemberPeriodsHistoryForm((int)dataGridView1.CurrentRow.Cells[5].Value);
            frm.ShowDialog();
        }
    }
}
