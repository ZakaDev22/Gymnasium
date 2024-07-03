using System;
using System.Windows.Forms;

namespace Gymnasium.User_Forms
{
    public partial class ShowUserInfoForm : Form
    {
        private int _userID;
        public ShowUserInfoForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowUserInfoForm_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_userID);
        }

    }
}
