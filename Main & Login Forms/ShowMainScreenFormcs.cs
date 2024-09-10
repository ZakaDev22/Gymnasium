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
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gymnasium
{
    public partial class ShowMainScreenFormcs : Form
    {
        private LoginForm _loginForm;

        public ShowMainScreenFormcs(LoginForm loginForm)
        {
            InitializeComponent();

            _RefreshDashboard();

            _loginForm = loginForm;

        }

        // Refreshes the dashboard by updating the text of various labels to display
        // the count of different entities retrieved from data access classes.
        private async void _RefreshDashboard()
        {
            var PeopleTask = await clsPeople.GetAllPeople(); // Done
            var MembersTask = await clsMembers.GetAllMembers(); // done
            var SubPeriodstask = await clsSubscriptionPeriods.GetAllPeriods(); // done
            var userstask = await clsUsers.GetAllUsers(); // done
            var paymentstask = await clsPayments.GetAllPayments(); // done

            var MembersInstructortask = Task.Run(() => clsMemberInstructor.GetAllAssignments().Rows.Count.ToString());
            var BeltTesttask = Task.Run(() => clsBeltTest.GetAllBeltTests().Rows.Count.ToString());
            var Sportstask = Task.Run(() => clsSports.GetAllSports().Rows.Count.ToString());
            var Instructorstask = Task.Run(() => clsInstructors.GetAllInstructors().Rows.Count.ToString());


            lbPeople.Text = PeopleTask.Rows.Count.ToString();
            lbMembers.Text = MembersTask.Rows.Count.ToString();
            lbSubPeriods.Text = SubPeriodstask.Rows.Count.ToString();
            lbUsers.Text = userstask.Rows.Count.ToString();
            lbPayments.Text = paymentstask.Rows.Count.ToString();

            lbMembersInstructors.Text = MembersInstructortask.Result;
            lbBeltTests.Text = BeltTesttask.Result;
            lbSports.Text = Sportstask.Result;
            lbInstructors.Text = Instructorstask.Result;
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

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            ShowAddEditeMembersForm showAddEditeMembersForm = new ShowAddEditeMembersForm();
            showAddEditeMembersForm.ShowDialog();


        }

        /*This code handles the MouseLeave event on splitContainer2.
        * It adjusts the position of btnFindPerson and btnFindUser based on the SplitterDistance of splitContainer2.
        * If the distance is greater than or equal to 400, it sets their positions to (37, 232) and (37, 285) respectively.
        * If the distance is less than or equal to 400, it sets their positions to (275, 73) and (275, 124) respectively. Additionally,
        * it limits the SplitterDistance to 530 if it exceeds that value in the first condition,
        * and to 317 if it's less than 317 in the second condition. */
        private void splitContainer2_MouseLeave(object sender, EventArgs e)
        {
            if (splitContainer2.SplitterDistance >= 435)
            {

                chkQueckSearch.Checked = false;

                return;
            }

            if (splitContainer2.SplitterDistance <= 435)
            {

                chkQueckSearch.Checked = true;
            }
        }


        private void chkQueckSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQueckSearch.Checked)
            {
                btnExpiredSubscriptions.Location = new Point(160, 20);
                btnFindPerson.Location = new Point(284, 63);
                btnFindUser.Location = new Point(284, 147);
                btnFindMember.Location = new Point(284, 105);

                splitContainer2.SplitterDistance = 317;

                chkQueckSearch.Text = "Quick Search Is ON";
            }
            else
            {
                btnExpiredSubscriptions.Location = new Point(43, 20);
                btnFindPerson.Location = new Point(43, 250);
                btnFindUser.Location = new Point(43, 292);
                btnFindMember.Location = new Point(43, 208);


                splitContainer2.SplitterDistance = 530;

                chkQueckSearch.Text = "Quick Search Is OF";
            }
        }

        private void btnDeletedMembers_Click(object sender, EventArgs e)
        {
            ShowDeletedMembersForm frm = new ShowDeletedMembersForm();
            frm.ShowDialog();
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            ShowFindUserForm showFindUserForm = new ShowFindUserForm();
            showFindUserForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowManageBlackListMembersForm showManageBlackListMembersForm = new ShowManageBlackListMembersForm();
            showManageBlackListMembersForm.ShowDialog();
        }
    }
}
