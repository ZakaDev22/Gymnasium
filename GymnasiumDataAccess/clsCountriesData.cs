using System;
using System.Data;
using System.Data.SqlClient;

namespace GymnasiumDataAccess
{
    public class clsCountriesData
    {

        // Create a new country
        public static int AddNewCountry(string countryName, string iso3, string iso2)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Countries_AddNewCountry", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CountryName", countryName);
                        command.Parameters.AddWithValue("@ISO3", iso3);
                        command.Parameters.AddWithValue("@ISO2", iso2);

                        connection.Open();
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return -1;
        }

        // Read all countries
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Countries_GetAllCountries", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return dataTable;
        }

        // Read country by CountryID
        public static bool GetCountryInfoByID(int countryID, ref string countryName, ref string iso3, ref string iso2)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_Countries_GetCountryByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CountryID", countryID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countryName = (string)reader["CountryName"];
                            iso3 = (string)reader["ISO3"];
                            iso2 = (string)reader["ISO2"];

                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return isSuccess;
        }



        // Read country by CountryID
        public static bool GetCountryInfoByName(string countryName, ref int countryID, ref string iso3, ref string iso2)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_Countries_GetCountryByName", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@countryName", countryName);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countryID = (int)reader["countryID"];
                            iso3 = (string)reader["ISO3"];
                            iso2 = (string)reader["ISO2"];

                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return isSuccess;
        }

        // Update an existing country
        public static bool UpdateCountry(int countryID, string countryName, string iso3, string iso2)
        {
            short rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Countries_UpdateCountry", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryID", countryID);
                        command.Parameters.AddWithValue("@CountryName", countryName);
                        command.Parameters.AddWithValue("@ISO3", iso3);
                        command.Parameters.AddWithValue("@ISO2", iso2);

                        connection.Open();

                        rowsAffected = (short)command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return rowsAffected > 0;
        }

        // Delete a country by CountryID
        public static bool DeleteCountry(int countryID)
        {
            short rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Countries_DeleteCountry", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CountryID", countryID);

                        connection.Open();
                        rowsAffected = (short)command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return rowsAffected > 0;
        }

        // Check if country exists by CountryID
        public static bool IsCountryExistByID(int countryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Countries_IsCountryExistByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CountryID", countryID);

                        connection.Open();
                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return false;
        }
    }

}
