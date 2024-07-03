using Gymnasium.Belt_Rank_Forms;
using Gymnasium.Belt_Tests_Forms;
using Gymnasium.Emergency_Contacts_Forms;
using Gymnasium.Global_Classes;
using Gymnasium.Instructors_Forms;
using Gymnasium.Member_Forms;
using Gymnasium.Member_Instructor_Forms;
using Gymnasium.Payments_Forms;
using Gymnasium.People_Forms;
using Gymnasium.Sport_Forms;
using Gymnasium.Subscription_Peroids;
using Gymnasium.Subscription_Peroids.Expired_Subscriptions;
using Gymnasium.User_Forms;
using GymnasiumLogicLayer;
using System;
using System.Windows.Forms;


namespace Gymnasium
{
    public partial class ShowMainScreenFormcs : Form
    {
        private LoginForm _loginForm;

        private ShowManagePeopleForm _Form;

        public ShowMainScreenFormcs(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        // Refreshes the dashboard by updating the text of various labels to display
        // the count of different entities retrieved from data access classes.
        private void _RefreshDashboard()
        {
            lbPeople.Text = clsPeople.GetAllPeople().Rows.Count.ToString();
            lbMembers.Text = clsMembers.GetAllMembers().Rows.Count.ToString();
            lbUsers.Text = clsUsers.GetAllUsers().Rows.Count.ToString();
            lbPayments.Text = clsPayments.GetAllPayments().Rows.Count.ToString();
            lbMembersInstructors.Text = clsMemberInstructor.GetAllAssignments().Rows.Count.ToString();
            lbBeltTests.Text = clsBeltTest.GetAllBeltTests().Rows.Count.ToString();
            lbSports.Text = clsSports.GetAllSports().Rows.Count.ToString();
            lbSubPeriods.Text = clsSubscriptionPeriods.GetAllPeriods().Rows.Count.ToString();
            lbInstructors.Text = clsInstructors.GetAllInstructors().Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnClick.Top = btnDashboard.Top;

            _RefreshDashboard();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 1))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnPeople.Top;

            ShowManagePeopleForm frm = new ShowManagePeopleForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 2))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnUsers.Top;

            ShowManageUsersForm frm = new ShowManageUsersForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 4))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnMembers.Top;

            ShowManageMembersForm frm = new ShowManageMembersForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnSports_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 8))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnSports.Top;

            ShowManageSportForms showManageSportForms = new ShowManageSportForms();
            showManageSportForms.Show();

            btnDashboard.PerformClick();
        }

        private void btnMemberInstructor_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 16))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnMemberInstructor.Top;

            ShowManageMemberInstructorForms frm = new ShowManageMemberInstructorForms();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnSubPeriods_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 32))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnSubPeriods.Top;

            ShowManageSubscriptionPeroidsForm frm = new ShowManageSubscriptionPeroidsForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 64))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnPayments.Top;

            ShowManagePaymentsForm frm = new ShowManagePaymentsForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnEmergencyContact_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 128))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnEmergencyContact.Top;

            ShowManageEmergencyContactsForm frm = new ShowManageEmergencyContactsForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnbeltRanks_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 256))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnbeltRanks.Top;

            ShowManageBeltRankForm frm = new ShowManageBeltRankForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnBeltTest_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 512))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnBeltTest.Top;

            ShowManageBeltTestsForm frm = new ShowManageBeltTestsForm();
            frm.Show();

            btnDashboard.PerformClick();
        }

        // Logs out the current user by setting _CurrentUser to null, closing the current form, and showing the login form.
        private void LogOut()
        {
            clsGlobal._CurrentUser = null;

            this.Close();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserInfoForm frm = new ShowUserInfoForm(clsGlobal._CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void personDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPersonDetailsForm frm = new ShowPersonDetailsForm(clsGlobal._CurrentUser.PersonID);
            frm.ShowDialog();
        }

        private void cHangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCHangeUserPasswordForm frm = new ShowCHangeUserPasswordForm(clsGlobal._CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void ShowMainScreenFormcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm.Show();
        }

        private void ShowMainScreenFormcs_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 1024))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            pnClick.Top = btnInstructors.Top;

            ShowManageInstructorsForms frm = new ShowManageInstructorsForms();
            frm.Show();

            btnDashboard.PerformClick();
        }

        private void btnExpiredSubscriptions_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsUserHaveThisPermission(clsGlobal._CurrentUser.Permissions, 2048))
            {
                MessageBox.Show("You don't have permission to access this Future Action,\n Please Contact Your Administrator !",
                                                                "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ShowExpiredSubscriptionsPeriodsForm frm = new ShowExpiredSubscriptionsPeriodsForm();
            frm.Show();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            ShowFindPersonForm showFindPersonForm = new ShowFindPersonForm();
            showFindPersonForm.ShowDialog();
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            ShowFindMemberForm showFindMemberForm = new ShowFindMemberForm();
            showFindMemberForm.ShowDialog();
        }
    }
}
