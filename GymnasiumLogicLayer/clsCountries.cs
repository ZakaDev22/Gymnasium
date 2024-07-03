using GymnasiumDataAccess;
using System.Data;

namespace GymnasiumLogicLayer
{
    public class clsCountries
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string ISO3 { get; set; }
        public string ISO2 { get; set; }

        public clsCountries()
        {
            this.CountryID = -1;
            this.CountryName = string.Empty;
            this.ISO3 = string.Empty;
            this.ISO2 = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsCountries(int countryID, string countryName, string iso3, string iso2)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
            this.ISO3 = iso3;
            this.ISO2 = iso2;

            _Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountriesData.AddNewCountry(this.CountryName, this.ISO3, this.ISO2);
            return (this.CountryID != -1);
        }

        private bool _UpdateCountry()
        {
            return clsCountriesData.UpdateCountry(this.CountryID, this.CountryName, this.ISO3, this.ISO2);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCountry();
            }
            return false;
        }

        public static clsCountries FindByID(int countryID)
        {
            string countryName = string.Empty;
            string iso3 = string.Empty;
            string iso2 = string.Empty;

            bool isFound = clsCountriesData.GetCountryInfoByID(countryID, ref countryName, ref iso3, ref iso2);

            if (isFound)
            {
                return new clsCountries(countryID, countryName, iso3, iso2);
            }
            else
            {
                return null;
            }
        }

        public static clsCountries FindByName(string countryName)
        {
            int countryID = -1;
            string iso3 = string.Empty;
            string iso2 = string.Empty;

            bool isFound = clsCountriesData.GetCountryInfoByName(countryName, ref countryID, ref iso3, ref iso2);

            if (isFound)
            {
                return new clsCountries(countryID, countryName, iso3, iso2);
            }
            else
            {
                return null;
            }
        }


        public static bool Delete(int countryID)
        {
            return clsCountriesData.DeleteCountry(countryID);
        }

        public static bool ExistsByID(int countryID)
        {
            return clsCountriesData.IsCountryExistByID(countryID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }
    }
}
