using GymnasiumLogicLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ctrlPersonInfoCardWithFilter : UserControl
    {
        public ctrlPersonInfoCardWithFilter()
        {
            InitializeComponent();

        }

        // modifiy this part to suit your needs and delete the old delegate // Add New Method Of Delegate That You Learned
        //public delegate void DataBackEvent(object sender, int PersonID);
        //public event DataBackEvent DataBack;

        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        // Define a custom event handler delegate with parameters
        public event Action<bool> OntxtFilterValueEmpty;
        // Create a protected method to raise the event with a parameter
        protected virtual void RiseOntxtFilterValueEmpty(bool IsTxtFilterValueEmpty)
        {
            Action<bool> handler = OntxtFilterValueEmpty;
            if (handler != null)
            {
                handler(IsTxtFilterValueEmpty); // Raise the event with the parameter
            }
        }

        // try The New Way Of The Events  To OverRide This Tow Old Ways Of The Events Event If It Works


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
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



        public clsPeople SelectedPersonInfo
        {
            get { return ctrlPersonInfoCard1.SelectedPersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonInfoCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "National No.":
                    ctrlPersonInfoCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonInfoCard1.PersonID);
        }


        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonInfoCard1.LoadPersonInfo(PersonID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }


        // Handles the event when the text in the txtFilterValue control changes. 
        // Resets person information if the text is empty, and raises the OntxtFilterValueEmpty event with the appropriate parameters.
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                ctrlPersonInfoCard1.ResetPersonInfo();

                // Raise the event
                if (OntxtFilterValueEmpty != null)
                {
                    OntxtFilterValueEmpty?.Invoke(true);
                }
            }

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            ShowAddEditePersonForm frm1 = new ShowAddEditePersonForm();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void ctrlPersonInfoCardWithFilter_Load(object sender, EventArgs e)
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();

        }

        private void txtFilterValue_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();

        }
    }
}
