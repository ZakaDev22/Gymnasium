using GymnasiumLogicLayer;
using System.Threading.Tasks;
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



        public async void LoadUserInfo(int UserID)
        {
            _User = await clsUsers.FindByID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await _FillUserInfo();
        }

        public async void LoadUserInfoByPersonID(int PersonID)
        {
            _User = await clsUsers.FindUserByPersonID(PersonID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await _FillUserInfo();
        }

        private async Task _FillUserInfo()
        {

            await ctrlPersonInfoCard1.LoadPersonInfo(_User.PersonID);
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
