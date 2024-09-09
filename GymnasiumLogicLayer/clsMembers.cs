using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

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

        public Task<clsPeople> _PersonInfo;

        public clsSports _SportInfo;
        // public Task<clsSports> _SportInfo;

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
            this.MemberID = clsMembersData.AddNewMember(this.PersonID, this.SportID, this.EmergencyContactID, this.JoinDate, this.IsActive);

            return this.MemberID != -1;
        }

        private bool _UpdateMember()
        {
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
            return clsMembersData.DeleteMember(memberID);
        }

        // Set The Old Member To In Deleted In Case He Return To The Gym After  Months
        public static bool SetMemberToInDeleted(int memberID)
        {
            return clsMembersData.SetMemberToInDeleted(memberID);
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

        // Get Deleted Members
        public static DataTable GetAllDeletedMembers()
        {
            return clsMembersData.GetAllDeletedMembers();
        }

        // New method to get paged Deleted members
        public static DataTable GetPagedDeletedMembers(int pageNumber, int pageSize, out int totalCount)
        {
            return clsMembersData.GetPagedDeletedMembers(pageNumber, pageSize, out totalCount);
        }

        public static bool IsMemberExistsByID(int memberID)
        {
            return clsMembersData.IsMemberExistsByID(memberID);
        }

        public static bool IsMemberExistsByPersnonID(int PersonID)
        {
            return clsMembersData.IsMemberExistsByPersonID(PersonID);
        }

        public static clsMembers GetMemberByID(int MemberID)
        {
            int personID = -1;
            int sportID = -1;
            int emergencyContactID = -1;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            bool isfound = clsMembersData.GetMemberInfoByID(MemberID, ref personID, ref sportID,
                          ref emergencyContactID, ref joinDate, ref isActive);

            if (isfound)
                return new clsMembers(MemberID, personID, sportID, emergencyContactID, joinDate, isActive);
            else
                return null;
        }

        public static clsMembers FindMemberByPersonID(int PersonID)
        {
            int Memberid = -1;
            int sportID = -1;
            int emergencyContactID = -1;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            bool isfound = clsMembersData.FindMemberByPersonID(PersonID, ref Memberid, ref sportID,
                          ref emergencyContactID, ref joinDate, ref isActive);

            if (isfound)
                return new clsMembers(Memberid, PersonID, sportID, emergencyContactID, joinDate, isActive);
            else
                return null;
        }

        public static bool SetMemberAsActiveOrInactive(int memberID, bool ActiveOrNot)
        {
            return clsMembersData.SetMemberAsActiveOrInactive(memberID, ActiveOrNot);
        }

        // New method to check if member is active
        public static bool IsMemberActive(int memberID)
        {
            return clsMembersData.IsMemberActive(memberID);
        }

        public static DataTable GetAllBlackListMembers()
        {
            return clsMembersData.GetAllBlackListMembers();
        }

        public static DataTable GetPagedBlackListMembers(int pageNumber, int pageSize, out int totalCount)
        {
            return clsMembersData.GetBlackListPagedMembers(pageNumber, pageSize, out totalCount);
        }

        public static bool SetMemberInBlackList(int memberID)
        {
            bool IsExiste = false;

            if (IsMemberInBlackListHistory(memberID))
                IsExiste = true;
            else
                IsExiste = false;

            return clsMembersData.SetMemberInBlackList(memberID, IsExiste);
        }

        public static bool SetMemberToNormalList(int memberID)
        {
            return clsMembersData.SetMemberToNormalList(memberID);
        }

        public static bool IsMemberInBlackList(int memberID)
        {
            return clsMembersData.IsMemberInBlackList(memberID);
        }

        public static bool IsMemberInBlackListHistory(int memberID)
        {
            return clsMembersData.IsMemberInBlackListHistory(memberID);
        }

        public static DataTable GetBlackListHistory()
        {
            return clsMembersData.GetBlackListHistory();
        }

        public static DataTable GetPagedBlackListHistory(int pageNumber, int pageSize, out int totalCount)
        {
            return clsMembersData.GetPagedBlackListHistory(pageNumber, pageSize, out totalCount);
        }
    }
}
