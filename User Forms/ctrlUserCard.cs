using GymnasiumLogicLayer;
using System.Windows.Forms;

namespace Gymnasium.User_Forms
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private clsUsers _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }



        public void LoadUserInfo(int UserID)
        {
            _User = clsUsers.FindByID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        public void LoadUserInfoByPersonID(int PersonID)
        {
            _User = clsUsers.FindUserByPersonID(PersonID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {

            ctrlPersonInfoCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }

        public void _ResetUserInfo()
        {

            ctrlPersonInfoCard1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }


    }
}
