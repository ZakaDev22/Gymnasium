using GymnasiumDataAccess;
using System;
using System.Data;

namespace GymnasiumLogicLayer
{
    public class clsMembers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MemberID { get; set; }
        public int PersonID { get; set; }
        public int SportID { get; set; }
        public int EmergencyContactID { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }

        public clsPeople _PersonInfo;

        public clsSports _SportInfo;

        // Empty constructor
        public clsMembers()
        {
            Mode = enMode.AddNew;
        }

        // Parameterized constructor
        public clsMembers(int memberID, int personID, int sportID, int emergencyContactID, DateTime joinDate, bool isActive)
        {
            MemberID = memberID;
            PersonID = personID;
            SportID = sportID;
            EmergencyContactID = emergencyContactID;
            JoinDate = joinDate;
            IsActive = isActive;

            _PersonInfo = clsPeople.FindByID(PersonID);
            _SportInfo = clsSports.FindByID(SportID);

            Mode = enMode.Update;
        }



        // Data Access Methods
        private bool _AddNewMember()
        {
            // Implement logic to add new member to the database
            // throw new NotImplementedException

            this.MemberID = clsMembersData.AddNewMember(this.PersonID, this.SportID, this.EmergencyContactID, this.JoinDate, this.IsActive);

            return this.MemberID != -1;
        }

        private bool _UpdateMember()
        {
            // Implement logic to update existing member in the database
            // throw new NotImplementedException();

            return clsMembersData.UpdateMember(this.MemberID, this.PersonID, this.SportID, this.EmergencyContactID, this.JoinDate, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewMember())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateMember();


            }

            return false;
        }


        public static bool DeleteMember(int memberID)
        {
            // Implement logic to delete member from the database
            //  throw new NotImplementedException();

            return clsMembersData.DeleteMember(memberID);
        }

        public static DataTable GetAllMembers()
        {
            return clsMembersData.GetAllMembers();
        }

        // New method to get paged members
        public static DataTable GetPagedMembers(int pageNumber, int pageSize, out int totalCount)
        {
            return clsMembersData.GetPagedMembers(pageNumber, pageSize, out totalCount);
        }

        public static bool IsMemberExistsByID(int memberID)
        {
            // Implement logic to check if member exists by ID in the database
            // throw new NotImplementedException();

            return clsMembersData.IsMemberExistsByID(memberID);
        }

        public static bool IsMemberExistsByPersnonID(int PersonID)
        {
            // Implement logic to check if member exists by ID in the database
            // throw new NotImplementedException();

            return clsMembersData.IsMemberExistsByPersonID(PersonID);
        }

        public static clsMembers GetMemberByID(int MemberID)
        {
            // Implement logic to retrieve all members from the database
            // throw new NotImplementedException();

            int personID = -1;
            int sportID = -1;
            int emergencyContactID = -1;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            bool isfound = clsMembersData.GetMemberInfoByID(MemberID, ref personID, ref sportID,
                          ref emergencyContactID, ref joinDate, ref isActive);

            if (isfound)
            {
                return new clsMembers(MemberID, personID, sportID, emergencyContactID, joinDate, isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsMembers FindMemberByPersonID(int PersonID)
        {
            // Implement logic to retrieve all members from the database
            // throw new NotImplementedException();

            int Memberid = -1;
            int sportID = -1;
            int emergencyContactID = -1;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            bool isfound = clsMembersData.FindMemberByPersonID(PersonID, ref Memberid, ref sportID,
                          ref emergencyContactID, ref joinDate, ref isActive);

            if (isfound)
            {
                return new clsMembers(Memberid, PersonID, sportID, emergencyContactID, joinDate, isActive);
            }
            else
            {
                return null;
            }
        }

        public static bool SetMemberAsActiveOrInactive(int memberID, bool ActiveOrNot)
        {
            // Implement logic to set member as Active Or inactive in the database
            // throw new NotImplementedException();

            return clsMembersData.SetMemberAsActiveOrInactive(memberID, ActiveOrNot);
        }

        // New method to check if member is active
        public static bool IsMemberActive(int memberID)
        {

            return clsMembersData.IsMemberActive(memberID);
        }
    }
}
