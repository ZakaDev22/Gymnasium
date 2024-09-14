using System;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ShowPersonDetailsForm : Form
    {
        public ShowPersonDetailsForm(int PersonID)
        {
            InitializeComponent();

            _LoadPersonInfoByPersonID(PersonID);
        }

        public ShowPersonDetailsForm(string NationalNo)
        {
            InitializeComponent();

            _LoadPersonInfoByNationaNo(NationalNo);
        }

        private async void _LoadPersonInfoByPersonID(int PersonID)
        {
            await ctrlPersonInfoCard1.LoadPersonInfo(PersonID);
        }

        private async void _LoadPersonInfoByNationaNo(string NationalNo)
        {
            await ctrlPersonInfoCard1.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
