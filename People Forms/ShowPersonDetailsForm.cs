using System;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ShowPersonDetailsForm : Form
    {
        public ShowPersonDetailsForm(int PersonID)
        {
            InitializeComponent();

            ctrlPersonInfoCard1.LoadPersonInfo(PersonID);
        }

        public ShowPersonDetailsForm(string NationalNo)
        {
            InitializeComponent();

            ctrlPersonInfoCard1.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
