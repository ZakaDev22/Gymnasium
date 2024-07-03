using System;
using System.Windows.Forms;

namespace Gymnasium
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new TestForm());

            // Application.Run(new ShowManagePeopleForm());


            //Application.Run(new ShowManageUsersForm());


            // Application.Run(new ShowManageMembersForm());


            // Application.Run(new ShowManageInstructorsForms());

            //  Application.Run(new ShowManageSportForms());

            // Application.Run(new ShowManageMemberInstructorForms());

            //   Application.Run(new ShowManageSubscriptionPeroidsForm());

            //  Application.Run(new ShowManagePaymentsForm());

            // Application.Run(new ShowManageEmergencyContactsForm());

            // Application.Run(new ShowManageBeltRankForm());

            // Application.Run(new ShowManageBeltTestsForm());

            //  Application.Run(new ShowMainScreenFormcs());

            //  Application.Run(new ShowFindPersonForm());

            // Application.Run(new ShowManageUsersForm());

            Application.Run(new LoginForm());

            // Application.Run(new AddEditePaymentForm());

        }
    }
}
