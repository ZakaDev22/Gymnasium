using GymnasiumLogicLayer;
using System;
using System.Windows.Forms;

namespace Gymnasium.Subscription_Peroids
{
    public partial class AddEditeSubscriptionPeriodForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _MemberID;
        private int _PaymentID;
        private decimal _Amount;
        private short _SubMonths = 1;
        private int _SubscriptionPeriodID = -1;
        private clsSubscriptionPeriods _SubscriptionPeriod;

        public delegate void CloseFormDataBack(object sender, bool IsClosed);
        public event CloseFormDataBack OnClosingSubForm;

        public AddEditeSubscriptionPeriodForm(int memberID, int paymentID, decimal amount, short subMonths)
        {
            InitializeComponent();

            _MemberID = memberID;
            _PaymentID = paymentID;
            _Amount = amount;
            _SubMonths = subMonths;

            _Mode = enMode.AddNew;
        }


        public AddEditeSubscriptionPeriodForm(int SubscriptionPeriodID)
        {
            InitializeComponent();

            _SubscriptionPeriodID = SubscriptionPeriodID;
            _Mode = enMode.Update;
        }


        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void AddEditeSubscriptionPeriodForm_Load(object sender, System.EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _SubscriptionPeriod = new clsSubscriptionPeriods();

                lbMemberID.Text = _MemberID.ToString();
                lbPaymentID.Text = _PaymentID.ToString();
                lbSubscriptionFees.Text = _Amount.ToString();
                lbStartDate.Text = DateTime.Now.ToShortDateString();
                lbEndDate.Text = DateTime.Now.AddMonths(_SubMonths).ToShortDateString();

                return;

            }

            _SubscriptionPeriod = clsSubscriptionPeriods.FindByID(_SubscriptionPeriodID);

            if (_SubscriptionPeriod == null)
            {
                MessageBox.Show("No Subscription Period With ID = " + _SubscriptionPeriodID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbSubPeriodID.Text = _SubscriptionPeriod.PeriodID.ToString();
            lbMemberID.Text = _SubscriptionPeriod.MemberID.ToString();
            lbPaymentID.Text = _SubscriptionPeriod.PaymentID.ToString();
            lbSubscriptionFees.Text = _SubscriptionPeriod.Fees.ToString();
            lbStartDate.Text = _SubscriptionPeriod.StartDate.ToShortDateString();
            lbEndDate.Text = _SubscriptionPeriod.EndDate.ToShortDateString();
            chkIsPaid.Checked = _SubscriptionPeriod.Paid;

            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SubscriptionPeriod.MemberID = _MemberID;
            _SubscriptionPeriod.PaymentID = _PaymentID;
            _SubscriptionPeriod.Fees = _Amount;
            _SubscriptionPeriod.StartDate = DateTime.Now;
            _SubscriptionPeriod.EndDate = DateTime.Now.AddMonths(_SubMonths);
            _SubscriptionPeriod.Paid = chkIsPaid.Checked;

            if (_SubscriptionPeriod.Save())
            {

                MessageBox.Show("Subscription Period Added Successfully \n tap Ok To Close The Form Directly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbSubPeriodID.Text = _SubscriptionPeriod.PeriodID.ToString();

                _Mode = enMode.Update;

                btnSave.Enabled = false;

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed To Add Subscription Period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEditeSubscriptionPeriodForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // rising the event to Tell The Payment form That The Form Is Closing
            OnClosingSubForm?.Invoke(this, true);
        }
    }
}
