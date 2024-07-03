using GymnasiumDataAccess;
using System;
using System.Data;


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

        private clsMemberInstructor(int instructorID, int memberID, DateTime assignDate)
        {
            this.InstructorID = instructorID;
            this.MemberID = memberID;
            this.AssignDate = assignDate;

            _Mode = enMode.Update;
        }

        private bool _AddNewAssignment()
        {
            return clsMemberInstructorData.AddNewAssignment(this.InstructorID, this.MemberID, this.AssignDate);
        }

        private bool _UpdateAssignment()
        {
            return clsMemberInstructorData.UpdateAssignment(this.InstructorID, this.MemberID, this.AssignDate);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAssignment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAssignment();
            }
            return false;
        }

        public static clsMemberInstructor FindByID(int instructorID, int memberID)
        {
            DateTime assignDate = DateTime.MinValue;
            bool isFound = clsMemberInstructorData.GetAssignmentInfoByID(instructorID, memberID, ref assignDate);
            if (isFound)
            {
                return new clsMemberInstructor(instructorID, memberID, assignDate);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int instructorID, int memberID)
        {
            return clsMemberInstructorData.DeleteAssignment(instructorID, memberID);
        }

        public static bool ExistsByID(int instructorID, int memberID)
        {
            return clsMemberInstructorData.IsAssignmentExistByID(instructorID, memberID);
        }

        public static DataTable GetAllAssignments()
        {
            return clsMemberInstructorData.GetAllAssignments();
        }

        // New method to get paged members instructors
        public static DataTable GetPagedMembersInstructors(int pageNumber, int pageSize, out int totalCount)
        {
            return clsMemberInstructorData.GetPagedMembersInstructors(pageNumber, pageSize, out totalCount);
        }
    }
}
