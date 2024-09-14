using GymnasiumDataAccess;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

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

        private StringBuilder fullName = new StringBuilder();

        public string FullName
        {
            get { return (fullName.Append(FirstName).Append(" ").Append(LastName)).ToString(); }
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

            LoadCountryInfo(countryID);

            Mode = enMode.Update;

        }

        private async void LoadCountryInfo(int CountryID)
        {
            _CountryInfo = await clsCountries.FindByID(CountryID);
        }


        // New method to add
        private async Task<bool> _AddNewPerson()
        {
            // Await the asynchronous method to get the PersonID
            int personId = await clsPeopleData.AddNewPersonAsync(
                this.FirstName,
                this.LastName,
                this.Address,
                this.Email,
                this.Phone,
                this.NationalNo,
                this.DateOfBirth,
                this.Gender,
                this.ImagePath,
                this.CountryID
            );

            // Assign the PersonID to the instance variable
            this.PersonID = personId;

            // Return true if the PersonID is not -1, indicating a successful addition
            return this.PersonID != -1;
        }

        // New method to update
        private async Task<bool> _UpdatePerson()
        {
            return await clsPeopleData.UpdatePerson(this.PersonID, this.FirstName,
                                                 this.LastName, this.Address, this.Email,
                                                 this.Phone, this.NationalNo, this.DateOfBirth, this.Gender, this.ImagePath, this.CountryID);
        }

        // New method to save
        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return await _UpdatePerson();


            }

            return false;
        }

        // New method to find person by ID
        public static async Task<clsPeople> FindByID(int personID)
        {

            DataTable dt = await clsPeopleData.GetPersonInfoByID(personID);

            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow Row = dt.Rows[0];

                return new clsPeople(Convert.ToInt32(Row["PersonID"]),
                                     Convert.ToString(Row["FirstName"]),
                                     Convert.ToString(Row["LastName"]),
                                     Convert.ToString(Row["NationalNo"]),
                                     Convert.ToDateTime(Row["DateOfBirth"]),
                                     Convert.ToInt16(Row["Gendor"]),
                                     Convert.ToString(Row["Address"]),
                                     Convert.ToString(Row["Phone"]),
                                     Convert.ToString(Row["Email"]),
                                     Convert.ToString(Row["ImagePath"]),
                                     Convert.ToInt16(Row["CountryID"]));
            }
        }
        // New method to find person by national number
        public static async Task<clsPeople> FindByNationalNo(string nationalNo)
        {


            DataTable dt = await clsPeopleData.GetPersonInfoByNationalNo(nationalNo);

            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow Row = dt.Rows[0];

                return new clsPeople(Convert.ToInt32(Row["PersonID"]),
                                     Convert.ToString(Row["FirstName"]),
                                     Convert.ToString(Row["LastName"]),
                                     Convert.ToString(Row["NationalNo"]),
                                     Convert.ToDateTime(Row["DateOfBirth"]),
                                     Convert.ToInt16(Row["Gendor"]),
                                     Convert.ToString(Row["Address"]),
                                     Convert.ToString(Row["Phone"]),
                                     Convert.ToString(Row["Email"]),
                                     Convert.ToString(Row["ImagePath"]),
                                     Convert.ToInt16(Row["CountryID"]));
            }
        }

        // New method to delete person
        public static async Task<bool> Delete(int personID)
        {
            return await clsPeopleData.DeletePerson(personID);
        }

        // New method to check if person exists
        public static async Task<bool> ExistsByID(int personID)
        {
            return await clsPeopleData.PersonExists(personID);
        }

        // New method to check if national no exists
        public static async Task<bool> ExistsByNationalNo(string nationalNo)
        {
            return await clsPeopleData.PersonExists(nationalNo);
        }

        // New method to get all people
        public static async Task<DataTable> GetAllPeople()
        {
            return await clsPeopleData.GetAllPeople();
        }

        // New method to get paged people
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedPeople(int pageNumber, int pageSize)
        {
            return await clsPeopleData.GetPagedPeople(pageNumber, pageSize);
        }
    }
}
