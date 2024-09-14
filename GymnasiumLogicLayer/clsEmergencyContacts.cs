using GymnasiumDataAccess;
using System;
using System.Data;

using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsEmergencyContacts
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int EmergencyContactID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// if You Want To Use Person Info Directly You Can Use This Property After You Call The Load Person Info Method
        /// </summary>
        public Task<clsPeople> _PersonInfo;

        public clsEmergencyContacts()
        {
            this.EmergencyContactID = -1;
            this.PersonID = -1;
            this.Name = string.Empty;
            this.Relationship = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsEmergencyContacts(int emergencyContactID, int personID, string name, string relationship, string phone, string email)
        {
            this.EmergencyContactID = emergencyContactID;
            this.PersonID = personID;
            this.Name = name;
            this.Relationship = relationship;
            this.Phone = phone;
            this.Email = email;

            _PersonInfo = LoadPersonInfo(personID);

            _Mode = enMode.Update;
        }

        // Separate async method to load the person info
        public async Task<clsPeople> LoadPersonInfo(int personID)
        {
            return await clsPeople.FindByID(personID);
        }

        private async Task<bool> _AddNewEmergencyContact()
        {
            this.EmergencyContactID = await clsEmergencyContactsData.AddNewEmergencyContact(this.PersonID, this.Name, this.Relationship, this.Phone, this.Email);
            return (this.EmergencyContactID != -1);
        }

        private async Task<bool> _UpdateEmergencyContact()
        {
            return await clsEmergencyContactsData.UpdateEmergencyContact(this.EmergencyContactID, this.PersonID, this.Name, this.Relationship, this.Phone, this.Email);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewEmergencyContact())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateEmergencyContact();
            }
            return false;
        }


        public static async Task<clsEmergencyContacts> FindByID(int emergencyContactID)
        {
            DataTable result = await clsEmergencyContactsData.GetEmergencyContactInfoByID(emergencyContactID);

            if (result.Rows.Count == 0)
                return null;
            else
            {
                DataRow dr = result.Rows[0];

                return new clsEmergencyContacts(Convert.ToInt32(dr["EmergencyContactID"]),
                                                Convert.ToInt32(dr["PersonID"]),
                                                Convert.ToString(dr["Name"]),
                                                Convert.ToString(dr["Relationship"]),
                                                Convert.ToString(dr["Phone"]),
                                                Convert.ToString(dr["Email"]));
            }
        }

        public static async Task<bool> Delete(int emergencyContactID)
        {
            return await clsEmergencyContactsData.DeleteEmergencyContact(emergencyContactID);
        }

        public static async Task<bool> ExistsByID(int emergencyContactID)
        {
            return await clsEmergencyContactsData.IsEmergencyContactExistByID(emergencyContactID);
        }

        public static async Task<bool> ExistsByPersonID(int personID)
        {
            return await clsEmergencyContactsData.IsEmergencyContactExistByPersonID(personID);
        }

        public static async Task<DataTable> GetAllEmergencyContacts()
        {
            return await clsEmergencyContactsData.GetAllEmergencyContacts();
        }

        // New method to get paged emergency contacts
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedEmergencyContacts(int pageNumber, int pageSize)
        {
            return await clsEmergencyContactsData.GetPagedEmergencyContacts(pageNumber, pageSize);
        }
    }
}
