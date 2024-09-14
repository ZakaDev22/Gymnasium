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

        private async Task<bool> _AddNewInstructor()
        {
            this.InstructorID = await clsInstructorsData.AddNewInstructor(this.PersonID, this.Qualification, this.Specialization, this.HireDate, this.Salary, this.IsActive);
            return (this.InstructorID != -1);
        }

        private async Task<bool> _UpdateInstructor()
        {
            return await clsInstructorsData.UpdateInstructor(this.InstructorID, this.PersonID, this.Qualification, this.Specialization, this.HireDate, this.Salary, this.IsActive);
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewInstructor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return await _UpdateInstructor();
            }
            return false;
        }

        public static async Task<clsInstructors> FindByID(int instructorID)
        {
            DataTable dt = await clsInstructorsData.GetInstructorInfoByID(instructorID);
            if (dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            return new clsInstructors(Convert.ToInt32(dr["InstructorID"]),
                                      Convert.ToInt32(dr["PersonID"]),
                                      Convert.ToString(dr["Qualification"]),
                                      Convert.ToString(dr["Specialization"]),
                                      Convert.ToDateTime(dr["HireDate"]),
                                      Convert.ToDecimal(dr["Salary"]),
                                      Convert.ToBoolean(dr["IsActive"]));
        }

        public static async Task<bool> Delete(int instructorID)
        {
            return await clsInstructorsData.DeleteInstructor(instructorID);
        }

        public static async Task<bool> ExistsByID(int instructorID)
        {
            return await clsInstructorsData.InstructorExists(instructorID);
        }

        public static async Task<DataTable> GetAllInstructors()
        {
            return await clsInstructorsData.GetAllInstructors();
        }

        // New method to get paged instructors
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedInstructors(int pageNumber, int pageSize)
        {
            return await clsInstructorsData.GetPagedInstructors(pageNumber, pageSize);
        }
    }
}
