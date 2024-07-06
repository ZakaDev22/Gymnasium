using GymnasiumLogicLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gymnasium.Emergency_Contacts_Forms
{
    public partial class AddEditeEmergencyContactForm : Form
    {
        private clsEmergencyContacts _EmergencyContact;

        public enum enMode { AddNew, Update }

        private enMode _Mode = enMode.AddNew;

        private int _emergencyContactID;

        // create a delegate for the event
        public delegate void EmergencyDataBack(object sender, int EmergencyContactID);
        // create an event
        public event EmergencyDataBack OnEmergencyDataBack;

        public AddEditeEmergencyContactForm()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public AddEditeEmergencyContactForm(int emergencyContactID)
        {
            InitializeComponent();
            _emergencyContactID = emergencyContactID;

            _Mode = enMode.Update;
        }

        private void txtPersonID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPersonID.Text))
            {
                errorProvider1.SetError(txtPersonID, "Person ID is required!");
                txtPersonID.Focus();
                e.Cancel = true;
            }
            else
            {
                if (clsEmergencyContacts.ExistsByIDPersonID(Convert.ToInt32(txtPersonID.Text.Trim())))
                {
                    errorProvider1.SetError(txtPersonID, "Person ID already exists!");
                    txtPersonID.Focus();
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtPersonID, "");
            }
        }

        private void txtPersonID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Name is required!");
                txtName.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtRelationship_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRelationship.Text))
            {
                errorProvider1.SetError(txtRelationship, "Relationship is required!");
                txtRelationship.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtRelationship, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Phone is required!");
                txtPhone.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required!");
                txtEmail.Focus();
                e.Cancel = true;
            }
            else
            {
                if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
                {
                    errorProvider1.SetError(txtEmail, "Invalid Email!");
                    txtEmail.Focus();
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtEmail, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _EmergencyContact.PersonID = Convert.ToInt32(txtPersonID.Text);
            _EmergencyContact.Name = txtName.Text;
            _EmergencyContact.Relationship = txtRelationship.Text;
            _EmergencyContact.Phone = txtPhone.Text;
            _EmergencyContact.Email = txtEmail.Text;

            if (_EmergencyContact.Save())
            {
                MessageBox.Show("Emergency Contact Saved Successfully, \ntap Ok To Close This Form", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // rise the event
                OnEmergencyDataBack?.Invoke(this, _EmergencyContact.EmergencyContactID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed To Save Emergency Contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEditeEmergencyContactForm_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _EmergencyContact = new clsEmergencyContacts();
                return;
            }

            _EmergencyContact = clsEmergencyContacts.FindByID(_emergencyContactID);

            if (_EmergencyContact == null)
            {
                MessageBox.Show("Emergency Contact Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            btnSave.Enabled = false;
            txtPersonID.Text = _EmergencyContact.PersonID.ToString();
            txtName.Text = _EmergencyContact.Name;
            txtRelationship.Text = _EmergencyContact.Relationship;
            txtPhone.Text = _EmergencyContact.Phone;
            txtEmail.Text = _EmergencyContact.Email;

            txtPersonID.Enabled = false;
            txtName.Enabled = false;
            txtRelationship.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
        }
    }
}
