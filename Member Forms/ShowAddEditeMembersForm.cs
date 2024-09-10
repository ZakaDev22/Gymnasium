using Gymnasium.Emergency_Contacts_Forms;
using Gymnasium.Payments_Forms;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gymnasium.Member_Forms
{
    public partial class ShowAddEditeMembersForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int MemberID = -1;
        clsMembers _Member;
        private int _PaymentID = -1;

        private float SportFees = 0;

        public ShowAddEditeMembersForm()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public ShowAddEditeMembersForm(int memberID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            MemberID = memberID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHeck If The Selected Member Already Has A Memmbership With The Same PersonID
            if (_Mode == enMode.AddNew && await clsMembers.IsMemberExistsByPersnonID(ctrlPersonInfoCardWithFilter1.PersonID) == true)
            {
                MessageBox.Show("Selected Person already has a member, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoCardWithFilter1.FilterFocus();
                return;
            }

            _Member.PersonID = ctrlPersonInfoCardWithFilter1.PersonID;

            // Check If The Input EmergencyContact ID Is A Valid One Or Not <<<--===================
            _Member.EmergencyContactID = Convert.ToInt32(txtEmergencyContact.Text);

            _Member.IsActive = chkIsActive.Checked;

            // find the new bug is her
            _Member.SportID = clsSports.FindByName(cbSports.Text).SportID;

            _Member.JoinDate = DateTime.Now;

            if (await _Member.Save())
            {
                MessageBox.Show("Success, saving member Was DOne Successfully. \n Now Add Payment For The New Member", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMemberID.Text = _Member.MemberID.ToString();

                if (_Mode == enMode.AddNew)
                {
                    AddEditePaymentForm frm = new AddEditePaymentForm(_Member.MemberID, SportFees);
                    frm.DataBack += PaymentDataBack;
                    frm.ShowDialog();
                }

                //change form mode to update.
                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Error while saving member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void _FillSportComboBoxWithData()
        {
            DataTable dt = clsSports.GetAllSports();

            foreach (DataRow row in dt.Rows)
            {
                cbSports.Items.Add(row["SportName"]);
            }
        }


        private async void ShowAddEditeForm_Load(object sender, EventArgs e)
        {
            _FillSportComboBoxWithData();
            cbSports.SelectedIndex = 2;
            SportFees = clsSports.FindByName(cbSports.Text).Fees;
            lbSportFees.Text = SportFees.ToString();

            if (_Mode == enMode.AddNew)
            {
                _Member = new clsMembers();
                ctrlPersonInfoCardWithFilter1.FilterEnabled = true;
                return;
            }

            _Member = await clsMembers.GetMemberByID(MemberID);
            await _Member.FillPersonANdSportInformationAsync();

            if (_Member == null)
            {
                MessageBox.Show("Member not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Load Member Person Info And Set The Filter To False To Not CHange The Person Of The Memeber
            ctrlPersonInfoCardWithFilter1.LoadPersonInfo(_Member.PersonID);
            ctrlPersonInfoCardWithFilter1.FilterEnabled = false;

            lblMemberID.Text = _Member.MemberID.ToString();
            txtEmergencyContact.Text = _Member.EmergencyContactID.ToString();

            cbSports.FindString(_Member._SportInfo.SportName);

            // lbPaymentID.Text = clsPayments.FindByMemberID(_Member.MemberID).PaymentID.ToString() ?? "0";

            chkIsActive.Checked = _Member.IsActive;

        }

        private void txtEmergencyContact_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmergencyContact.Text))
            {
                errorProvider1.SetError(txtEmergencyContact, "Emergency Contact is required");
                e.Cancel = true;
                txtEmergencyContact.Focus();
            }
            else
            {
                if (!clsEmergencyContacts.ExistsByID(Convert.ToInt32(txtEmergencyContact.Text)))
                {
                    errorProvider1.SetError(txtEmergencyContact, "Emergency Contact IS Not exists Add One First");
                    e.Cancel = true;
                    txtEmergencyContact.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtEmergencyContact, "");
                }

            }
        }



        private void PaymentDataBack(int PaymentID)
        {
            if (PaymentID != -1)
            {
                btnSave.Enabled = false;

                lbPaumentID2.Visible = true;
                pcPaymentID.Visible = true;
                lbPaymentID.Visible = true;

                ctrlPersonInfoCardWithFilter1.FilterEnabled = false;
                txtEmergencyContact.Enabled = false;
                _PaymentID = PaymentID;
                lbPaymentID.Text = PaymentID.ToString();

            }

        }

        private void cbSports_SelectedIndexChanged(object sender, EventArgs e)
        {
            SportFees = clsSports.FindByName(cbSports.Text).Fees;
            lbSportFees.Text = SportFees.ToString();
        }

        // Sets the text of the txtEmergencyContact control to the string representation of the EmergencyContactID.
        // set btn Add New Emergency Contact enabled to false To Not Let The User Add Another Emergency Contact 
        private void OnEmergencyContactDataBack(object obj, int EmergencyContactID)
        {
            txtEmergencyContact.Text = EmergencyContactID.ToString();

            btnAddNewEmergencyContact.Enabled = false;
        }

        //This code defines a button click event handler that creates a new instance of the AddEditeEmergencyContactForm form,
        //subscribes to its OnEmergencyDataBack event with the method OnEmergencyContactDataBack, and then shows the form as a dialog box.
        private void btnAddNewEmergencyContact_Click(object sender, EventArgs e)
        {
            AddEditeEmergencyContactForm frm = new AddEditeEmergencyContactForm();
            frm.OnEmergencyDataBack += OnEmergencyContactDataBack;
            frm.ShowDialog();
        }

        private void ctrlPersonInfoCardWithFilter1_OnAddNewPerson(bool obj)
        {
            // CHeck If We Add New Person From Add New Button So That We Tel This Form To Perform The Search Button Without Let The User To Click It
            if (obj)
                ctrlPersonInfoCardWithFilter1.PerformSearchClick();
        }

        private void ctrlPersonInfoCardWithFilter1_OnPersonSelected_1(int obj)
        {
            if (obj != -1)
                btnSave.Enabled = true;
        }

        private void ctrlPersonInfoCardWithFilter1_OntxtFilterValueEmpty_1(bool obj)
        {
            btnSave.Enabled = obj == true ? false : true;
        }
    }
}
