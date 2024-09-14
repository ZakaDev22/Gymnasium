using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

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

        private async Task<bool> _AddNewCountry()
        {
            this.CountryID = await clsCountriesData.AddNewCountryAsync(this.CountryName, this.ISO3, this.ISO2);
            return (this.CountryID != -1);
        }

        private async Task<bool> _UpdateCountry()
        {
            return await clsCountriesData.UpdateCountryAsync(this.CountryID, this.CountryName, this.ISO3, this.ISO2);
        }

        public async Task<bool> SaveAsunc()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewCountry())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateCountry();
            }
            return false;
        }

        public static async Task<clsCountries> FindByID(int countryID)
        {
            DataTable dt = await clsCountriesData.GetCountryInfoByIDAsync(countryID);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow row = dt.Rows[0];

                return new clsCountries(Convert.ToInt32(row["CountryID"]),
                                        Convert.ToString(row["CountryName"]),
                                        Convert.ToString(row["ISO3"]),
                                        Convert.ToString(row["ISO2"]));
            }
        }

        public static async Task<clsCountries> FindByName(string countryName)
        {
            DataTable dt = await clsCountriesData.GetCountryInfoByNameAsync(countryName);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow row = dt.Rows[0];

                return new clsCountries(Convert.ToInt32(row["CountryID"]),
                                        Convert.ToString(row["CountryName"]),
                                        Convert.ToString(row["ISO3"]),
                                        Convert.ToString(row["ISO2"]));
            }
        }


        public static async Task<bool> DeleteAsync(int countryID)
        {
            return await clsCountriesData.DeleteCountryAsync(countryID);
        }

        public static async Task<bool> ExistsByIDAsync(int countryID)
        {
            return await clsCountriesData.IsCountryExistByIDAsync(countryID);
        }

        public static async Task<DataTable> GetAllCountries()
        {
            return await clsCountriesData.GetAllCountriesAsync();
        }
    }
}
