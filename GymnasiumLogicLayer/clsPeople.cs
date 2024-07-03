using GymnasiumDataAccess;
using System;
using System.Data;

namespace GymnasiumLogicLayer
{
    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public int CountryID { get; set; }

        public clsCountries _CountryInfo;

        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }


        public clsPeople()
        {
            Mode = enMode.AddNew;
        }

        // Parameterized constructor
        public clsPeople(int personID, string firstName,
                         string lastName, string nationalNo, DateTime dateOfBirth, short gender,
                         string address, string phone, string email,
                         string imagePath, int countryID)
        {
            PersonID = personID;
            FirstName = firstName;

            LastName = lastName;
            NationalNo = nationalNo;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            ImagePath = imagePath;
            CountryID = countryID;

            _CountryInfo = clsCountries.FindByID(countryID);

            Mode = enMode.Update;

        }

        // New method to add
        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.AddNewPerson(this.FirstName,
                                                 this.LastName, this.Address, this.Email,
                                                 this.Phone, this.NationalNo, this.DateOfBirth, this.Gender, this.ImagePath, this.CountryID);
            return (this.PersonID != -1);
        }

        // New method to update
        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.PersonID, this.FirstName,
                                                 this.LastName, this.Address, this.Email,
                                                 this.Phone, this.NationalNo, this.DateOfBirth, this.Gender, this.ImagePath, this.CountryID);
        }

        // New method to save
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();


            }

            return false;
        }

        // New method to find person by ID
        public static clsPeople FindByID(int personID)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string nationalNo = string.Empty;
            DateTime dateOfBirth = DateTime.Now;
            short gender = 0;
            string address = string.Empty;
            string phone = string.Empty, email = string.Empty;
            string imagePath = string.Empty;
            int countryID = 0;



            bool isfound = clsPeopleData.GetPersonInfoByID(personID, ref firstName, ref lastName,
                     ref address, ref email, ref phone, ref nationalNo, ref dateOfBirth, ref gender, ref imagePath, ref countryID);

            if (isfound)
            {
                return new clsPeople(personID, firstName, lastName, nationalNo, dateOfBirth, gender, address, phone, email, imagePath, countryID);
            }
            else
            {
                return null;
            }
        }
        // New method to find person by national number
        public static clsPeople FindByNationalNo(string nationalNo)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            int Personid = -1;
            DateTime dateOfBirth = DateTime.Now;
            short gender = 0;
            string address = string.Empty;
            string phone = string.Empty, email = string.Empty;
            string imagePath = string.Empty;
            int countryID = 0;



            bool isfound = clsPeopleData.GetPersonInfoByNationalNo(nationalNo, ref Personid, ref firstName, ref lastName,
                     ref address, ref email, ref phone, ref dateOfBirth, ref gender, ref imagePath, ref countryID);

            if (isfound)
            {
                return new clsPeople(Personid, firstName, lastName, nationalNo, dateOfBirth, gender, address, phone, email, imagePath, countryID);
            }
            else
            {
                return null;
            }
        }

        // New method to delete person
        public static bool Delete(int personID)
        {
            return clsPeopleData.DeletePerson(personID);
        }

        // New method to check if person exists
        public static bool ExistsByID(int personID)
        {
            return clsPeopleData.PersonExists(personID);
        }

        // New method to check if national no exists
        public static bool ExistsByNationalNo(string nationalNo)
        {
            return clsPeopleData.PersonExists(nationalNo);
        }

        // New method to get all people
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }

        // New method to get paged people
        public static DataTable GetPagedPeople(int pageNumber, int pageSize, out int totalCount)
        {
            return clsPeopleData.GetPagedPeople(pageNumber, pageSize, out totalCount);
        }
    }
}
