using GymnasiumDataAccess;
using System.Data;


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

        public clsPeople _PersonInfo;

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

            _PersonInfo = clsPeople.FindByID(personID);

            _Mode = enMode.Update;
        }

        private bool _AddNewEmergencyContact()
        {
            this.EmergencyContactID = clsEmergencyContactsData.AddNewEmergencyContact(this.PersonID, this.Name, this.Relationship, this.Phone, this.Email);
            return (this.EmergencyContactID != -1);
        }

        private bool _UpdateEmergencyContact()
        {
            return clsEmergencyContactsData.UpdateEmergencyContact(this.EmergencyContactID, this.PersonID, this.Name, this.Relationship, this.Phone, this.Email);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmergencyContact())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateEmergencyContact();
            }
            return false;
        }

        public static clsEmergencyContacts FindByID(int emergencyContactID)
        {
            int personID = -1;
            string name = string.Empty;
            string relationship = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;

            bool isFound = clsEmergencyContactsData.GetEmergencyContactInfoByID(emergencyContactID, ref personID, ref name, ref relationship, ref phone, ref email);

            if (isFound)
            {
                return new clsEmergencyContacts(emergencyContactID, personID, name, relationship, phone, email);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int emergencyContactID)
        {
            return clsEmergencyContactsData.DeleteEmergencyContact(emergencyContactID);
        }

        public static bool ExistsByID(int emergencyContactID)
        {
            return clsEmergencyContactsData.IsEmergencyContactExistByID(emergencyContactID);
        }

        public static bool ExistsByIDPersonID(int PersonID)
        {
            return clsEmergencyContactsData.IsEmergencyContactExistByPersonID(PersonID);
        }


        public static DataTable GetAllEmergencyContacts()
        {
            return clsEmergencyContactsData.GetAllEmergencyContacts();
        }

        // New method to get paged emergency contacts
        public static DataTable GetPagedEmergencyContacts(int pageNumber, int pageSize, out int totalCount)
        {
            return clsEmergencyContactsData.GetPagedEmergencyContacts(pageNumber, pageSize, out totalCount);
        }
    }
}
