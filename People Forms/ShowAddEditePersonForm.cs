using Gymnasium.Properties;
using GymnasiumLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ShowAddEditePersonForm : Form
    {

        public enum EnMode { AddNew = 0, Update = 1, };

        private EnMode _Mode;

        private int _PersonID = -1;

        clsPeople _Person;

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public ShowAddEditePersonForm()
        {
            InitializeComponent();

            _Mode = EnMode.AddNew;
        }

        public ShowAddEditePersonForm(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = EnMode.Update;
        }



        private void _FillCountriesInComboBox()
        {
            DataTable CountryTable = clsCountries.GetAllCountries();

            foreach (DataRow Row in CountryTable.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }
        }

        private async void ShowAddEditePersonForm_Load(object sender, EventArgs e)
        {
            _FillCountriesInComboBox();

            rbMale.Checked = true;

            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);

            cbCountries.SelectedIndex = cbCountries.FindString("Morocco");

            lnkRemoveImage.Visible = (pictureBox1.ImageLocation != null);

            if (_Mode == EnMode.AddNew)
            {
                lbAddEditePerson.Text = "Add New Person :-)";
                _Person = new clsPeople();
                return;
            }

            // the bag is here for update 
            _Person = await clsPeople.FindByID(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"this Form Will Be Closed Because  Contact With {_Person.PersonID} Is Not Found :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbAddEditePerson.Text = $"Edite Person With ID {_Person.PersonID} :-)";
            lbPersonID.Text = _PersonID.ToString();

            txtFirstName.Text = _Person.FirstName;

            txtLastName.Text = _Person.LastName;
            dateTimePicker1.Value = _Person.DateOfBirth;
            txtNationalNo.Text = _Person.NationalNo;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            cbCountries.SelectedIndex = (_Person.CountryID - 1);

            rbMale.Checked = _Person.Gender == 0 ? true : false;
            rbFemale.Checked = rbMale.Checked == false ? true : false;

            if (_Person.ImagePath != "")
                pictureBox1.Load(_Person.ImagePath);

            lnkRemoveImage.Visible = (_Person.ImagePath != "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
                pictureBox1.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
                pictureBox1.Image = Resources.Female_512;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCLose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error! Some Fields Are Not Valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int CountryID = clsCountries.FindByName(cbCountries.Text).CountryID;

            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;

            _Person.NationalNo = txtNationalNo.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.Phone = txtPhone.Text;
            _Person.CountryID = CountryID;

            _Person.Gender = rbMale.Checked == true ? (short)0 : (short)1;

            if (pictureBox1.ImageLocation != null)
                _Person.ImagePath = pictureBox1.ImageLocation;
            else
                _Person.ImagePath = "";

            if (await _Person.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error! : Data Is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _Mode = EnMode.Update;

            lbAddEditePerson.Text = $"Edite Person With ID {_Person.PersonID}";
            lbPersonID.Text = _Person.PersonID.ToString();
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "Invalid, This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            };
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, "Invalid, This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            };
        }

        private async void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && await clsPeople.ExistsByNationalNo(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validate email format
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Invalid, This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            };
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedFilePath);
                lnkRemoveImage.Visible = true;
                // ...
            }
        }

        private void lnkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;



            if (rbMale.Checked)
                pictureBox1.Image = Resources.Male_512;
            else
                pictureBox1.Image = Resources.Female_512;

            lnkRemoveImage.Visible = false;
        }
    }
}
