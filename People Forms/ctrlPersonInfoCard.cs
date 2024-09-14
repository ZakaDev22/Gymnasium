using Gymnasium.Global_Classes;
using Gymnasium.Properties;
using GymnasiumLogicLayer;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ctrlPersonInfoCard : UserControl
    {
        public ctrlPersonInfoCard()
        {
            InitializeComponent();
        }

        private clsPeople _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPeople SelectedPersonInfo
        {
            get { return _Person; }
        }


        public async Task LoadPersonInfo(int PersonID)
        {
            _Person = await clsPeople.FindByID(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();

                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public async Task LoadPersonInfo(string NationalNo)
        {
            _Person = await clsPeople.FindByNationalNo(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();

                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {

            if (_Person.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private async void _FillPersonInfo()
        {
            _LoadPersonImage();

            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            clsCountries _Country = await clsCountries.FindByID(_Person.CountryID);
            lblCountry.Text = _Country.CountryName;
            lblAddress.Text = _Person.Address;
        }

        public void ResetPersonInfo()
        {

            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGendor.Image = Resources.Male_512;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
            llEditPersonInfo.Enabled = false;

        }


        private async void llEditPersonInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID == 1 && clsGlobal._CurrentUser.UserID != 1)
            {
                MessageBox.Show($"Error,You Can't Edit The Admin User Information 😎💪🙄🤣🤣", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowAddEditePersonForm frm = new ShowAddEditePersonForm(_PersonID);
            frm.ShowDialog();

            await LoadPersonInfo(_PersonID);
        }
    }
}
