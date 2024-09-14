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

        /// <summary>
        /// if You Want To Use Person Info Directly You Can Use This Property After You Call The Load Person Info Method
        /// </summary>
        public Task<clsPeople> _PersonInfo;

        /// <summary>
        /// if You Want To Use Person Info Directly You Can Use This Property After You Call The Load Sport Info Method
        /// </summary>
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

            LoadSportInfoAsync(sportID);
            _PersonInfo = LoadPersonInfoAsync(PersonID);

            Mode = enMode.Update;
        }

        public async Task<clsPeople> LoadPersonInfoAsync(int personID)
        {
            return await clsPeople.FindByID(personID);
        }

        public async void LoadSportInfoAsync(int SportID)
        {
            _SportInfo = await clsSports.FindByID(SportID);
        }

        // Data Access Methods
        private async Task<bool> _AddNewMember()
        {
            this.MemberID = await clsMembersData.AddNewMember(this.PersonID, this.SportID, this.EmergencyContactID, this.JoinDate, this.IsActive);

            return this.MemberID != -1;
        }

        private async Task<bool> _UpdateMember()
        {
            return await clsMembersData.UpdateMember(this.MemberID, this.PersonID, this.SportID, this.EmergencyContactID, this.JoinDate, this.IsActive);
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewMember())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return await _UpdateMember();


            }

            return false;
        }


        public static async Task<bool> DeleteMember(int memberID)
        {
            return await clsMembersData.DeleteMember(memberID);
        }

        // Set The Old Member To In Deleted In Case He Return To The Gym After  Months
        public static async Task<bool> SetMemberToInDeleted(int memberID)
        {
            return await clsMembersData.SetMemberToInDeleted(memberID);
        }

        public static async Task<DataTable> GetAllMembers()
        {
            return await clsMembersData.GetAllMembers();
        }

        // New method to get paged members
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedMembers(int pageNumber, int pageSize)
        {
            return await clsMembersData.GetPagedMembers(pageNumber, pageSize);
        }

        // Get Deleted Members
        public static async Task<DataTable> GetAllDeletedMembers()
        {
            return await clsMembersData.GetAllDeletedMembers();
        }

        // New method to get paged Deleted members
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedDeletedMembers(int pageNumber, int pageSize)
        {
            return await clsMembersData.GetPagedDeletedMembers(pageNumber, pageSize);
        }

        public static async Task<bool> IsMemberExistsByID(int memberID)
        {
            return await clsMembersData.IsMemberExistsByID(memberID);
        }

        public static async Task<bool> IsMemberExistsByPersnonID(int PersonID)
        {
            return await clsMembersData.IsMemberExistsByPersonID(PersonID);
        }

        public static async Task<clsMembers> GetMemberByID(int MemberID)
        {

            DataTable dt = await clsMembersData.GetMemberInfoByID(MemberID);

            if (dt.Rows.Count == 0)
                return null;

            else
            {
                DataRow dr = dt.Rows[0];

                return new clsMembers(Convert.ToInt32(dr["MemberID"]),
                                      Convert.ToInt32(dr["PersonID"]),
                                      Convert.ToInt32(dr["SportID"]),
                                      Convert.ToInt32(dr["EmergencyContactID"]),
                                      Convert.ToDateTime(dr["JoinDate"]),
                                      Convert.ToBoolean(dr["IsActive"]));
            }

        }

        public static async Task<clsMembers> FindMemberByPersonID(int PersonID)
        {

            DataTable dt = await clsMembersData.FindMemberByPersonID(PersonID);

            if (dt.Rows.Count == 0)
                return null;

            else
            {
                DataRow dr = dt.Rows[0];

                return new clsMembers(Convert.ToInt32(dr["MemberID"]),
                                      Convert.ToInt32(dr["PersonID"]),
                                      Convert.ToInt32(dr["SportID"]),
                                      Convert.ToInt32(dr["EmergencyContactID"]),
                                      Convert.ToDateTime(dr["JoinDate"]),
                                      Convert.ToBoolean(dr["IsActive"]));
            }
        }

        public static async Task<bool> SetMemberAsActiveOrInactive(int memberID, bool ActiveOrNot)
        {
            return await clsMembersData.SetMemberAsActiveOrInactive(memberID, ActiveOrNot);
        }

        // New method to check if member is active
        public static async Task<bool> IsMemberActive(int memberID)
        {
            return await clsMembersData.IsMemberActive(memberID);
        }

        public static async Task<DataTable> GetAllBlackListMembers()
        {
            return await clsMembersData.GetAllBlackListMembers();
        }

        public static async Task<(DataTable dataTable, int totalCount)> GetPagedBlackListMembers(int pageNumber, int pageSize)
        {
            return await clsMembersData.GetBlackListPagedMembers(pageNumber, pageSize);
        }

        public static async Task<bool> SetMemberInBlackList(int memberID)
        {
            // check if The Member Is Already In Black List history if no then we have
            // to put him in Black List History Or Update hi In Black List History If its true
            bool IsExist = await IsMemberInBlackListHistory(memberID);

            return await clsMembersData.SetMemberInBlackList(memberID, IsExist);
        }

        public static async Task<bool> SetMemberToNormalList(int memberID)
        {
            return await clsMembersData.SetMemberToNormalList(memberID);
        }

        public static async Task<bool> IsMemberInBlackList(int memberID)
        {
            return await clsMembersData.IsMemberInBlackList(memberID);
        }

        public static async Task<bool> IsMemberInBlackListHistory(int memberID)
        {
            return await clsMembersData.IsMemberInBlackListHistory(memberID);
        }

        public static async Task<DataTable> GetBlackListHistory()
        {
            return await clsMembersData.GetBlackListHistory();
        }

        public static async Task<(DataTable dataTable, int totalCount)> GetPagedBlackListHistory(int pageNumber, int pageSize)
        {
            return await clsMembersData.GetPagedBlackListHistory(pageNumber, pageSize);
        }
    }
}
