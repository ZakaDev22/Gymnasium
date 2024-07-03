using GymnasiumLogicLayer;
using System;
using System.Windows.Forms;

namespace Gymnasium
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPeople.GetAllPeople();

            bool found = clsPeople.ExistsByNationalNo("N1");

            if (found)
                label1.Text = "Found";

            else
                label1.Text = "NotFound";


        }
    }
}
