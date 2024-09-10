using GymnasiumLogicLayer;
using System;
using System.Windows.Forms;

namespace Gymnasium.Member_Instructor_Forms
{
    public partial class ShowAddEditeMemberInstructorForm : Form
    {
        public enum enAddEdite { Addnew = 0, Update = 1 }
        private enAddEdite _Mode = enAddEdite.Addnew;

        private clsMemberInstructor MembersInstructors;

        private int _instructorID = -1;
        private int _MemberID = -1;

        public ShowAddEditeMemberInstructorForm()
        {
            InitializeComponent();

            _Mode = enAddEdite.Addnew;
        }

        public ShowAddEditeMemberInstructorForm(int instructorID, int memberID)
        {
            InitializeComponent();

            _Mode = enAddEdite.Update;

            _instructorID = instructorID;
            _MemberID = memberID;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtMemberID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMemberID, "Enter Member ID");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMemberID, "");
            }
        }

        private void txtMemberID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!await clsMembers.IsMemberExistsByID(Convert.ToInt32(txtMemberID.Text)))
            {
                MessageBox.Show("No Member with ID = " + txtMemberID.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsInstructors.ExistsByID(Convert.ToInt32(txtInstructo.Text)))
            {
                MessageBox.Show("No Instructor with ID = " + txtInstructo.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsMemberInstructor.ExistsByID(Convert.ToInt32(txtInstructo.Text), Convert.ToInt32(txtMemberID.Text)))
            {
                MessageBox.Show("This Assignment  With Member ID = " + txtMemberID.Text + " And " + "Instructor ID = " + txtInstructo.Text + " Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MembersInstructors.MemberID = Convert.ToInt32(txtMemberID.Text);
            MembersInstructors.InstructorID = Convert.ToInt32(txtInstructo.Text);

            if (MembersInstructors.Save())
            {
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                lbTitle.Text = $"Update Assignment with Member ID {MembersInstructors.MemberID} and Instructor ID {MembersInstructors.InstructorID}";
            }

            else
            {
                MessageBox.Show("Failed to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAddEditeMemberInstructorForm_Load(object sender, EventArgs e)
        {
            if (_Mode == enAddEdite.Addnew)
            {
                MembersInstructors = new clsMemberInstructor();
                btnSave.Enabled = true;
                txtMemberID.Focus();
                return;
            }

            MembersInstructors = clsMemberInstructor.FindByID(this._instructorID, this._MemberID);

            if (MembersInstructors == null)
            {
                MessageBox.Show("No Assignment with ID = " + this._MemberID + " - " + this._instructorID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            txtMemberID.Text = MembersInstructors.MemberID.ToString();
            txtInstructo.Text = MembersInstructors.InstructorID.ToString();

            txtInstructo.Enabled = false;
            txtMemberID.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}
