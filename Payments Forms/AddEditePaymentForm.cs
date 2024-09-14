using Gymnasium.Subscription_Peroids;
using GymnasiumLogicLayer;
using System;
using System.Windows.Forms;

namespace Gymnasium.Payments_Forms
{
    public partial class AddEditePaymentForm : Form
    {
        public delegate void DataBackEventHandler(int PaymentID);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _MemberID;
        private int _PaymentID;
        private float _Amount;
        private short _SubMonths = 1;
        private decimal _FinalAmount = 0;
        private clsPayments _Payment;

        // call This Constructor To Se The Payment Information
        public AddEditePaymentForm(int PaymentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;
            _Mode = enMode.Update;
        }

        //call This COnstructor To Add New Payment
        public AddEditePaymentForm(int MemberID, float Amount)
        {
            InitializeComponent();
            _MemberID = MemberID;
            _Amount = Amount;
            _Mode = enMode.AddNew;
        }

        private void SetFormForAddNewPayments()
        {
            _Payment = new clsPayments();

            ctrlMemberCardInfoWithFilter1.LoadMemberInfo(_MemberID);
            ctrlMemberCardInfoWithFilter1.Enabled = false;

            txtAmount.Text = _Amount.ToString();
            txtAmount.Enabled = false;

            lbPaymentDate.Text = DateTime.Now.ToShortDateString();

        }

        private async void SetFormForUpdatePayments()
        {
            _Payment = await clsPayments.FindByID(_PaymentID);

            ctrlMemberCardInfoWithFilter1.LoadMemberInfo(_Payment.MemberID);
            ctrlMemberCardInfoWithFilter1.FilterEnabled = false;

            txtAmount.Text = _Payment.Amount.ToString();
            txtAmount.Enabled = false;

            lbPaymentID.Text = _Payment.PaymentID.ToString();
            lbPaymentDate.Text = _Payment.Date.ToShortDateString();

            if (_Payment.Amount < 150)
                rbOneMonth.Checked = true;
            else
                rbThreeMonths.Checked = true;

            rbOneMonth.Enabled = false;
            rbThreeMonths.Enabled = false;

            btnSave.Enabled = false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlMemberCardInfoWithFilter1_OnMemberSelected(int obj)
        {
            if (obj != -1)
                btnSave.Enabled = true;
        }

        private void ctrlMemberCardInfoWithFilter1_OntxtFilterValueEmpty(bool obj)
        {
            btnSave.Enabled = obj == true ? false : true;
        }

        // Handles the closing of a subform event.
        // Closes the form if the IsSubscriptionFormClosed parameter is true.
        private void Fm_OnClosingSubForm(object sender, bool IsSubscriptionFormClosed)
        {
            if (IsSubscriptionFormClosed)
                this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Payment.MemberID = _MemberID;
            _Payment.Date = DateTime.Now;

            _FinalAmount = (Convert.ToDecimal(txtAmount.Text) * _SubMonths);
            _Payment.Amount = _FinalAmount;

            if (await _Payment.Save())
            {

                lbPaymentID.Text = _Payment.PaymentID.ToString();

                DataBack?.Invoke(_Payment.PaymentID);

                btnSave.Enabled = false;

                if (_Mode == enMode.AddNew)
                {
                    MessageBox.Show("Saved Successfully n \n Now Go To Finish The Subscription Period", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AddEditeSubscriptionPeriodForm frm = new AddEditeSubscriptionPeriodForm(_Payment.MemberID, _Payment.PaymentID, _FinalAmount, _SubMonths);
                    frm.OnClosingSubForm += Fm_OnClosingSubForm;
                    frm.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Failed to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddEditePaymentForm_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
                SetFormForAddNewPayments();
            else
                SetFormForUpdatePayments();
        }


        private void rbOneMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOneMonth.Checked)
                _SubMonths = 1;
            else
                _SubMonths = 3;
        }
    }
}
