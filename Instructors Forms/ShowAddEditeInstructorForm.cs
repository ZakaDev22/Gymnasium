using GymnasiumLogicLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gymnasium.Instructors_Forms
{
    public partial class ShowAddEditeInstructorForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int InstructorID = -1;
        clsInstructors _instructor;

        public ShowAddEditeInstructorForm()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }


        // find a way to set btn save to false whene  txt is empty

        public ShowAddEditeInstructorForm(int InstructorID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            this.InstructorID = InstructorID;
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalary.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSalary, "Field is required!");
            }
            else
            {
                errorProvider1.SetError(txtSalary, "");
            }
        }

        private void txtSpecialization_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSpecialization.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSpecialization, "Field is required!");
            }
            else
            {
                errorProvider1.SetError(txtSpecialization, "");
            }
        }

        private void txtQualification_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtQualification.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtQualification, "Field is required!");
            }
            else
            {
                errorProvider1.SetError(txtQualification, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _instructor.PersonID = ctrlPersonInfoCardWithFilter1.PersonID;
            _instructor.Salary = Convert.ToDecimal(txtSalary.Text);
            _instructor.Specialization = txtSpecialization.Text;
            _instructor.Qualification = txtQualification.Text;
            _instructor.IsActive = chkIsActive.Checked;

            if (_instructor.Save())
            {
                MessageBox.Show("Instructor Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbInstructorID.Text = _instructor.InstructorID.ToString();

                _Mode = enMode.Update;

            }
            else
            {
                MessageBox.Show("Instructor Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ShowAddEditeInstructorForm_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _instructor = new clsInstructors();
                ctrlPersonInfoCardWithFilter1.FilterEnabled = true;
                return;
            }

            _instructor = clsInstructors.FindByID(InstructorID);

            if (_instructor == null)
            {
                MessageBox.Show("Instructor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonInfoCardWithFilter1.LoadPersonInfo(_instructor.PersonID);
            ctrlPersonInfoCardWithFilter1.FilterEnabled = false;

            txtSalary.Text = _instructor.Salary.ToString();
            txtSpecialization.Text = _instructor.Specialization;
            txtQualification.Text = _instructor.Qualification;

            chkIsActive.Checked = _instructor.IsActive;
        }

        private void ctrlPersonInfoCardWithFilter1_OnPersonSelected(int PersonID)
        {
            if (PersonID != -1)
            {
                btnSave.Enabled = true;
            }
        }

        private void ctrlPersonInfoCardWithFilter1_OntxtFilterValueEmpty(bool IstxtFilterValueEmpty)
        {
            // when the filter is empty, save button should be disabled

            btnSave.Enabled = IstxtFilterValueEmpty == true ? false : true;
        }
    }
}
