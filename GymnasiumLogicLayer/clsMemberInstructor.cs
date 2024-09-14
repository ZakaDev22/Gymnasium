using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;


namespace GymnasiumLogicLayer
{
    public class clsMemberInstructor
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int InstructorID { get; set; }
        public int MemberID { get; set; }
        public DateTime AssignDate { get; set; }

        public clsMemberInstructor()
        {
            this.InstructorID = -1;
            this.MemberID = -1;
            this.AssignDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }

        public clsMemberInstructor(int instructorID, int memberID, DateTime assignDate)
        {
            InstructorID = instructorID;
            MemberID = memberID;
            AssignDate = assignDate;

            _Mode = enMode.Update;
        }

        private async Task<bool> _AddNewAssignment()
        {
            return await clsMemberInstructorData.AddNewAssignment(this.InstructorID, this.MemberID, this.AssignDate);
        }

        private async Task<bool> _UpdateAssignment()
        {
            return await clsMemberInstructorData.UpdateAssignment(this.InstructorID, this.MemberID, this.AssignDate);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewAssignment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateAssignment();
            }

            return false;
        }

        public static async Task<clsMemberInstructor> FindByID(int instructorID, int memberID)
        {
            DataTable dt = await clsMemberInstructorData.GetAssignmentInfoByID(instructorID, memberID);

            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];
            return new clsMemberInstructor(Convert.ToInt32(dr["InstructorID"]),
                                           Convert.ToInt32(dr["MemberID"]),
                                           Convert.ToDateTime(dr["AssignDate"]));
        }

        public static async Task<bool> Delete(int instructorID, int memberID)
        {
            return await clsMemberInstructorData.DeleteAssignment(instructorID, memberID);
        }

        public static async Task<bool> ExistsByID(int instructorID, int memberID)
        {
            return await clsMemberInstructorData.IsAssignmentExistByID(instructorID, memberID);
        }

        public static async Task<DataTable> GetAllAssignments()
        {
            return await clsMemberInstructorData.GetAllAssignments();
        }

        // New method to get paged member-instructor assignments
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedAssignments(int pageNumber, int pageSize)
        {
            return await clsMemberInstructorData.GetPagedMembersInstructors(pageNumber, pageSize);
        }
    }
}
