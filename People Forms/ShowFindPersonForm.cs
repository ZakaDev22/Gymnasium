using System;
using System.Windows.Forms;

namespace Gymnasium.People_Forms
{
    public partial class ShowFindPersonForm : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public ShowFindPersonForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            // Trigger the event to send data back to the caller form.
            DataBack?.Invoke(this, ctrlPersonInfoCardWithFilter1.PersonID);

            this.Close();
        }

        private void ctrlPersonInfoCardWithFilter1_OnPersonSelected(int obj)
        {

        }
    }
}
