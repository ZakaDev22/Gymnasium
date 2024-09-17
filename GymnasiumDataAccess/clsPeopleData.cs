using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GymnasiumDataAccess
{
    public class clsPeopleData
    {

        public static async Task<int> AddNewPersonAsync(string firstName, string lastName, string address, string email,
                                    string phone, string nationalNo, DateTime dateOfBirth, short gender,
                                    string imagePath, int countryID)
        {
            int personId = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_People_AddNewPerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                command.Parameters.AddWithValue("@NationalNo", string.IsNullOrEmpty(nationalNo) ? (object)DBNull.Value : nationalNo);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@CountryID", countryID == -1 ? (object)DBNull.Value : countryID);

                SqlParameter returnParam = command.Parameters.Add("@NewPersonID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    personId = (int)returnParam.Value;
                }
                catch (Exception ex)
                {
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return personId;
        }
        public async static Task<bool> UpdatePerson(int personId, string firstName, string lastName, string address, string email,
                                    string phone, string nationalNo, DateTime dateOfBirth, short gender,
                                    string imagePath, int countryID)
        {
            // Implement logic to update existing person in the database

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_People_UpdatePerson", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                command.Parameters.AddWithValue("@NationalNo", string.IsNullOrEmpty(nationalNo) ? (object)DBNull.Value : nationalNo);

                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@CountryID", countryID != -1 ? (object)countryID : DBNull.Value);

                try
                {
                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
                catch (Exception ex)
                {
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    return false;
                }
            }

        }

        // finish the people methos to accept the async await concepts

        public static async Task<DataTable> GetPersonInfoByID(int personId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetPersonInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", personId);

                    try
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle exception

                        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dt;
        }


        public static async Task<DataTable> GetPersonInfoByNationalNo(string nationalNo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetPersonInfoByNationalNo", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", nationalNo);

                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception

                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return dt;
        }


        public static async Task<bool> DeletePerson(int PersonID)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Peopel_DeletePerson", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    return false;
                }
            }
        }

        public static async Task<bool> PersonExists(int PersonID)
        {
            // Implement logic to check if person exists by ID in the database

            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_People_CheckPersonExistsByID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    await connection.OpenAsync();
                    object result = await command.ExecuteScalarAsync();

                    if (result != null && Convert.ToInt32(result) > 0)
                    {
                        isExist = true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return isExist;
        }

        public static async Task<bool> PersonExists(string nationalNo)
        {

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {



                    using (SqlCommand command = new SqlCommand("sp_People_CheckPersonExistsByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", nationalNo);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);

                        try
                        {
                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();

                            return (int)returnParameter.Value == 1;
                        }
                        catch (Exception ex)
                        {
                            clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        public static async Task<DataTable> GetAllPeople()
        {
            // Implement logic to retrieve all people from the database

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_People_GetAllPeople", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }


                }
                catch (Exception ex)
                {
                    // Handle exception

                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return dataTable;
        }

        // New method to get paged people
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedPeople(int pageNumber, int pageSize)
        {
            DataTable dataTable = new DataTable();
            int totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_People_GetPagedPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@PageSize", pageSize);

                        SqlParameter totalParam = new SqlParameter("@TotalCount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(totalParam);

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dataTable.Load(reader);
                        }

                        totalCount = totalParam.Value == DBNull.Value ? 0 : (int)totalParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return (dataTable, totalCount);
        }
    }



}
