using GymnasiumLogicLayer;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymnasium.Member_Forms
{
    public partial class ctrlMemberCardInfoWithFilter : UserControl
    {
        public ctrlMemberCardInfoWithFilter()
        {
            InitializeComponent();
        }

        private clsMembers _Member;

        public event Action<int> OnMemberSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void MemberSelected(int MemberID)
        {
            Action<int> handler = OnMemberSelected;
            if (handler != null)
            {
                handler(MemberID); // Raise the event with the parameter
            }
        }

        // Define a custom event handler delegate with parameters
        public event Action<bool> OntxtFilterValueEmpty;
        // Create a protected method to raise the event with a parameter
        protected virtual void RiseOntxtFilterValueEmpty(bool IstxtFilterValueEmpty)
        {
            Action<bool> handler = OntxtFilterValueEmpty;
            if (handler != null)
            {
                handler(IstxtFilterValueEmpty); // Raise the event with the parameter
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int PersonID
        {
            get { return ctrlPersonInfoCard1.PersonID; }
        }


        public async void LoadMemberInfo(int MemberID)
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = MemberID.ToString();
            await FindNow();

        }

        private async Task FindNow()
        {

            switch (cbFilterBy.Text)
            {

                case "Member ID":
                    _Member = await clsMembers.GetMemberByID(int.Parse(txtFilterValue.Text));
                    break;

                case "Person ID":

                    _Member = await clsMembers.FindMemberByPersonID(int.Parse(txtFilterValue.Text));

                    break;

                default:
                    break;


            }

            if (_Member == null)
            {
                MessageBox.Show("No Member with ID = " + txtFilterValue.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Raise the event with a parameter
                OntxtFilterValueEmpty?.Invoke(true);

                FilterFocus();
                return;
            }

            await ctrlPersonInfoCard1.LoadPersonInfo(_Member.PersonID);

            clsSports _SportInfo = await clsSports.FindByID(_Member.SportID);
            lbSportName.Text = _SportInfo.SportName;
            lbMemberID.Text = _Member.MemberID.ToString();
            lbEmergencyContact.Text = _Member.EmergencyContactID.ToString();
            lbJoinDate.Text = _Member.JoinDate.ToShortDateString();

            lbIsActive.Text = _Member.IsActive == true ? "Yes" : "No";

            if (OnMemberSelected != null)
                // Raise the event with a parameter
                OnMemberSelected(_Member.MemberID);
        }


        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }



        private async void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                ctrlPersonInfoCard1.ResetPersonInfo();

                lbMemberID.Text = "[???]";
                lbEmergencyContact.Text = "[???]";
                lbIsActive.Text = "[???]";
                lbJoinDate.Text = "[???]";
                lbSportName.Text = "[???]";

                OntxtFilterValueEmpty?.Invoke(true);
            }
            else
            {
                if (!await clsMembers.IsMemberExistsByID(int.Parse(txtFilterValue.Text)))
                {
                    errorProvider1.SetError(txtFilterValue, "Member Not Found! , Find A member First");

                    ctrlPersonInfoCard1.ResetPersonInfo();

                    lbMemberID.Text = "[???]";
                    lbEmergencyContact.Text = "[???]";
                    lbIsActive.Text = "[???]";
                    lbJoinDate.Text = "[???]";
                    lbSportName.Text = "[???]";
                    OntxtFilterValueEmpty?.Invoke(true);
                }
                else
                    errorProvider1.SetError(txtFilterValue, null);
            }
        }


        private async void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            await FindNow();
        }

        private void ctrlMemberCardInfoWithFilter_Load(object sender, EventArgs e)
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person Or Member id is selected

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

    }
}
