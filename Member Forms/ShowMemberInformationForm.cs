using System;
using System.Windows.Forms;

namespace Gymnasium.Member_Forms
{
    public partial class ShowMemberInformationForm : Form
    {
        private int _MemberID;

        public ShowMemberInformationForm(int MemberID)
        {
            InitializeComponent();

            _MemberID = MemberID;
        }

        private void ShowMemberInformationForm_Load(object sender, EventArgs e)
        {
            ctrlMemberCardInfoWithFilter1.LoadMemberInfo(_MemberID);

            ctrlMemberCardInfoWithFilter1.FilterEnabled = false;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
