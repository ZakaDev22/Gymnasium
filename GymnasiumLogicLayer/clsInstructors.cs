using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsInstructors
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InstructorID { get; set; }
        public int PersonID { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        public Task<clsPeople> _PersonInfo;

        public clsInstructors()
        {
            Mode = enMode.AddNew;
        }

        public clsInstructors(int instructorID, int personID, string qualification, string specialization, DateTime hireDate, decimal salary, bool isActive)
        {
            InstructorID = instructorID;
            PersonID = personID;
            Qualification = qualification;
            Specialization = specialization;
            HireDate = hireDate;
            Salary = salary;
            IsActive = isActive;

            _PersonInfo = LoadPersonInfoAsync(PersonID);

            Mode = enMode.Update;
        }

        // Separate async method to load the person info
        public async Task<clsPeople> LoadPersonInfoAsync(int personID)
        {
            return await clsPeople.FindByID(personID);
        }

        private bool _AddNewInstructor()
        {
            this.InstructorID = clsInstructorsData.AddNewInstructor(this.PersonID, this.Qualification, this.Specialization, this.HireDate, this.Salary, this.IsActive);
            return (this.InstructorID != -1);
        }

        private bool _UpdateInstructor()
        {
            return clsInstructorsData.UpdateInstructor(this.InstructorID, this.PersonID, this.Qualification, this.Specialization, this.HireDate, this.Salary, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInstructor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateInstructor();
            }
            return false;
        }

        public static clsInstructors FindByID(int instructorID)
        {
            int personID = 0;
            string qualification = string.Empty;
            string specialization = string.Empty;
            DateTime hireDate = DateTime.Now;
            decimal salary = 0;
            bool isActive = false;

            bool isFound = clsInstructorsData.GetInstructorInfoByID(instructorID, ref personID, ref qualification, ref specialization, ref hireDate, ref salary, ref isActive);

            if (isFound)
            {
                return new clsInstructors(instructorID, personID, qualification, specialization, hireDate, salary, isActive);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int instructorID)
        {
            return clsInstructorsData.DeleteInstructor(instructorID);
        }

        public static bool ExistsByID(int instructorID)
        {
            return clsInstructorsData.InstructorExists(instructorID);
        }

        public static DataTable GetAllInstructors()
        {
            return clsInstructorsData.GetAllInstructors();
        }

        // New method to get paged instructors
        public static DataTable GetPagedInstructors(int pageNumber, int pageSize, out int totalCount)
        {
            return clsInstructorsData.GetPagedInstructors(pageNumber, pageSize, out totalCount);
        }
    }
}
