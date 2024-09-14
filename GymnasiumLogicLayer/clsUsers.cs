using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsUsers
    {
        [Flags]
        public enum enPermissions
        {
            // i have to devide the People Permission To Add Add Update Delete Person Permission By Its Ruls .
            None = 0,
            People = 1 << 0,       // 1
            Users = 1 << 1,    // 2
            Members = 1 << 2, // 4
            Sports = 1 << 3, // 8
            MemberInstructor = 1 << 4, // 16
            SubscriptionPeriods = 1 << 5, // 32
            Payments = 1 << 6, // 64
            EmergencyContacts = 1 << 7, // 128
            BeltRank = 1 << 8, // 256
            BeltTests = 1 << 9, // 512
            Instructors = 1 << 10, // 1024
            ExpiredSubscriptions = 1 << 11, // 2048

            All = People | Users | Members | Sports | MemberInstructor | SubscriptionPeriods | Payments | EmergencyContacts | BeltRank | BeltTests | Instructors | ExpiredSubscriptions

            // Total Permissions = 4095


            // Extend with more permissions as needed
        }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Permissions { get; set; }

        public clsUsers()
        {
            this.UserID = -1; ;
            this.PersonID = -1; ;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
            this.Permissions = 0;

            _Mode = enMode.AddNew;
        }

        private clsUsers(int userID, int personID, string userName, string password, bool isActive, int permissions)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.Permissions = permissions;

            _Mode = enMode.Update;
        }

        // change this methods to User Methods ...

        private async Task<bool> _AddNewUser()
        {
            this.UserID = await clsUsersData.AddNewUser(this.PersonID,
                                                 this.UserName, this.Password, this.IsActive, this.Permissions);
            return (this.UserID != -1);
        }

        private async Task<bool> _UpdateUser()
        {
            return await clsUsersData.UpdateUser(this.UserID, this.PersonID,
                                                 this.UserName, this.Password, this.IsActive, this.Permissions);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return await _UpdateUser();


            }

            return false;
        }

        public static async Task<clsUsers> FindByID(int UserID)
        {
            DataTable dt = await clsUsersData.GetUserInfoByUserID(UserID);

            if (dt.Rows.Count == 0)
                return null;

            else
            {
                DataRow dr = dt.Rows[0];

                return new clsUsers(Convert.ToInt32(dr["UserID"]),
                                    Convert.ToInt32(dr["PersonID"]),
                                    Convert.ToString(dr["UserName"]),
                                    Convert.ToString(dr["Password"]),
                                    Convert.ToBoolean(dr["IsActive"]),
                                    Convert.ToInt32(dr["Permissions"]));
            }
        }


        public static async Task<clsUsers> FindUserByPersonID(int PersonID)
        {
            DataTable dt = await clsUsersData.GetUserInfoByPersonID(PersonID);

            if (dt.Rows.Count == 0)
                return null;

            else
            {
                DataRow dr = dt.Rows[0];

                return new clsUsers(Convert.ToInt32(dr["UserID"]),
                                    Convert.ToInt32(dr["PersonID"]),
                                    Convert.ToString(dr["UserName"]),
                                    Convert.ToString(dr["Password"]),
                                    Convert.ToBoolean(dr["IsActive"]),
                                    Convert.ToInt32(dr["Permissions"]));
            }
        }


        public static async Task<bool> Delete(int UserID)
        {
            return await clsUsersData.DeleteUser(UserID);
        }

        public static async Task<bool> ExistsByID(int UserID)
        {
            return await clsUsersData.IsUserExistByUserID(UserID);
        }

        public static async Task<bool> ExistsByUserName(string UserName)
        {
            return await clsUsersData.ExistsByUserName(UserName);
        }


        public static async Task<clsUsers> IsUserExiste(string UserName, string Password)
        {
            DataTable dt = await clsUsersData.IsUserExist(UserName, Password);

            if (dt.Rows.Count == 0)
                return null;

            else
            {
                DataRow dr = dt.Rows[0];

                return new clsUsers(Convert.ToInt32(dr["UserID"]),
                                    Convert.ToInt32(dr["PersonID"]),
                                    Convert.ToString(dr["UserName"]),
                                    Convert.ToString(dr["Password"]),
                                    Convert.ToBoolean(dr["IsActive"]),
                                    Convert.ToInt32(dr["Permissions"]));
            }
        }

        public static async Task<bool> ExistsByPersonID(int PersonID)
        {
            return await clsUsersData.IsUserExistByPersonID(PersonID);
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A DataTable containing all users.</returns>
        public static async Task<DataTable> GetAllUsers()
        {
            return await clsUsersData.GetAllUsers();
        }

        // New method to get paged users
        public static async Task<(DataTable dataTab, int totalCount)> GetPagedUsers(int pageNumber, int pageSize)
        {
            return await clsUsersData.GetPagedUsers(pageNumber, pageSize);
        }

        public static async Task<bool> SetUserAsActiveOrInactive(int UserID, bool ActiveOrNot)
        {
            return await clsUsersData.SetUserAsActiveOrInactive(UserID, ActiveOrNot);
        }

        // New method to check if member is active
        public static async Task<bool> IsUserActive(int UserID)
        {
            return await clsUsersData.IsUserActive(UserID);
        }
    }
}
