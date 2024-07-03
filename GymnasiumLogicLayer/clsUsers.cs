using GymnasiumDataAccess;
using System;
using System.Data;

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

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID,
                                                 this.UserName, this.Password, this.IsActive, this.Permissions);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.PersonID,
                                                 this.UserName, this.Password, this.IsActive, this.Permissions);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();


            }

            return false;
        }

        public static clsUsers FindByID(int UserID)
        {
            int personID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;
            int permissions = 0;


            bool isfound = clsUsersData.GetUserInfoByUserID(UserID, ref personID, ref UserName,
                      ref Password, ref IsActive, ref permissions);

            if (isfound)
            {
                return new clsUsers(UserID, personID, UserName, Password, IsActive, permissions);
            }
            else
            {
                return null;
            }
        }


        public static clsUsers FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;
            int permissions = 0;


            bool isfound = clsUsersData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName,
                      ref Password, ref IsActive, ref permissions);

            if (isfound)
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive, permissions);
            }
            else
            {
                return null;
            }
        }


        public static bool Delete(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool ExistsByID(int UserID)
        {
            return clsUsersData.IsUserExistByUserID(UserID);
        }

        public static bool ExistsByUserName(string UserName)
        {
            return clsUsersData.ExistsByUserName(UserName);
        }


        public static clsUsers IsUserExiste(string UserName, string Password)
        {
            int userID = -1, PersonID = -1;
            bool isActived = false;
            int permissions = 0;

            if (clsUsersData.IsUserExist(UserName, Password, ref userID, ref PersonID, ref isActived, ref permissions))
            {
                return new clsUsers(userID, PersonID, UserName, Password, isActived, permissions);
            }
            else
                return null;
        }

        public static bool ExistsByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A DataTable containing all users.</returns>
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        // New method to get paged users
        public static DataTable GetPagedUsers(int pageNumber, int pageSize, out int totalCount)
        {
            return clsUsersData.GetPagedUsers(pageNumber, pageSize, out totalCount);
        }
    }
}
