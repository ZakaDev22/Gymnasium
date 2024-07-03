using System;
using System.Data;
using System.Data.SqlClient;

namespace GymnasiumDataAccess
{
    public class clsPeopleData
    {
        public static int AddNewPerson(string firstName, string lastName, string address, string email,
                                   string phone, string nationalNo, DateTime dateOfBirth, short gender,
                                   string imagePath, int countryID)
        {
            // Implement logic to add new person to the database

            int personId = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_People_AddNewPerson", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                if (!string.IsNullOrEmpty(address))
                {
                    command.Parameters.AddWithValue("@Address", address);
                }
                else
                {
                    command.Parameters.AddWithValue("@Address", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(address))
                {
                    command.Parameters.AddWithValue("@Email", email);
                }
                else
                {
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                }
                else
                {
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(nationalNo))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNo);
                }
                else
                {
                    command.Parameters.AddWithValue("@NationalNo", DBNull.Value);
                }


                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                }
                else
                {
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                }

                command.Parameters.AddWithValue("@Gender", gender);

                if (countryID != -1)
                {
                    command.Parameters.AddWithValue("@CountryID", countryID);
                }
                else
                {
                    command.Parameters.AddWithValue("@CountryID", DBNull.Value);
                }

                SqlParameter returnParam = command.Parameters.Add("@NewPersonID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    personId = (int)returnParam.Value;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return personId;
        }

        public static bool UpdatePerson(int personId, string firstName, string lastName, string address, string email,
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

                if (!string.IsNullOrEmpty(address))
                {
                    command.Parameters.AddWithValue("@Address", address);
                }
                else
                {
                    command.Parameters.AddWithValue("@Address", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(address))
                {
                    command.Parameters.AddWithValue("@Email", email);
                }
                else
                {
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                }
                else
                {
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(nationalNo))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNo);
                }
                else
                {
                    command.Parameters.AddWithValue("@NationalNo", DBNull.Value);
                }


                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                }
                else
                {
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                }

                command.Parameters.AddWithValue("@Gender", gender);

                if (countryID != -1)
                {
                    command.Parameters.AddWithValue("@CountryID", countryID);
                }
                else
                {
                    command.Parameters.AddWithValue("@CountryID", DBNull.Value);
                }

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception

                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return rowsAffected > 0;
        }

        public static bool GetPersonInfoByID(int personId, ref string firstName, ref string lastName, ref string address, ref string email,
                                  ref string phone, ref string nationalNo, ref DateTime dateOfBirth, ref short gender,
                                   ref string imagePath, ref int countryID)
        {
            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetPersonInfoByID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // the Bug Is Her To Update => Null Validation. 
                        firstName = (string)reader["FirstName"];

                        lastName = (string)reader["LastName"];
                        nationalNo = reader["NationalNo"] == DBNull.Value ? string.Empty : (string)reader["NationalNo"];
                        dateOfBirth = (DateTime)reader["DateOfBirth"];

                        address = reader["Address"] == DBNull.Value ? string.Empty : (string)reader["Address"];
                        phone = reader["Phone"] == DBNull.Value ? string.Empty : (string)reader["Phone"];
                        email = reader["Email"] == DBNull.Value ? string.Empty : (string)reader["Email"];
                        imagePath = reader["ImagePath"] == DBNull.Value ? string.Empty : (string)reader["ImagePath"];
                        countryID = reader["CountryID"] == DBNull.Value ? -1 : (int)reader["CountryID"];

                        if (reader["Gendor"] != DBNull.Value)
                        {
                            bool IsMaleOrfemale = Convert.ToBoolean(reader["Gendor"]);

                            gender = IsMaleOrfemale ? (short)1 : (short)0;
                        }
                        else
                        {
                            gender = 2;
                        }

                        isSuccess = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception

                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return isSuccess;
        }


        public static bool GetPersonInfoByNationalNo(string nationalNo, ref int personId, ref string firstName, ref string lastName, ref string address, ref string email,
                                  ref string phone, ref DateTime dateOfBirth, ref short gender,
                                   ref string imagePath, ref int countryID)
        {
            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetPersonInfoByNationalNo", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", nationalNo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        personId = (int)reader["PersonID"];
                        firstName = (string)reader["FirstName"];

                        lastName = (string)reader["LastName"];
                        dateOfBirth = (DateTime)reader["DateOfBirth"];

                        address = reader["Address"] == DBNull.Value ? string.Empty : (string)reader["Address"];
                        phone = reader["Phone"] == DBNull.Value ? string.Empty : (string)reader["Phone"];
                        email = reader["Email"] == DBNull.Value ? string.Empty : (string)reader["Email"];
                        imagePath = reader["ImagePath"] == DBNull.Value ? string.Empty : (string)reader["ImagePath"];
                        countryID = reader["CountryID"] == DBNull.Value ? -1 : (int)reader["CountryID"];

                        if (reader["Gendor"] != DBNull.Value)
                        {
                            bool IsMaleOrfemale = Convert.ToBoolean(reader["Gendor"]);

                            gender = IsMaleOrfemale ? (short)1 : (short)0;
                        }
                        else
                        {
                            gender = 2;
                        }

                        isSuccess = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception

                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return isSuccess;
        }


        public static bool DeletePerson(int PersonID)
        {
            // Implement logic to delete person from the database

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Peopel_DeletePerson", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return rowsAffected > 0;
        }

        public static bool PersonExists(int PersonID)
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
                    connection.Open();
                    object result = command.ExecuteScalar();

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

        public static bool PersonExists(string nationalNo)
        {


            // Implement logic to check if person exists by national number in the database

            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                //SqlCommand command = new SqlCommand("sp_People_CheckPersonExistsByNationalNo", connection);
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@NationalNo", nationalNo);

                //SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit);
                //existsParam.Direction = ParameterDirection.Output;
                //command.Parameters.Add(existsParam);

                //try
                //{
                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    exists = (bool)existsParam.Value;
                //}
                //catch (Exception ex)
                //{
                //    // Handle exception

                //    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                //}

                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_People_CheckPersonExistsByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalNo", nationalNo);

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };

                    command.Parameters.Add(returnParameter);
                    command.ExecuteNonQuery();

                    exists = (int)returnParameter.Value == 1;
                }
            }

            return exists;
        }

        public static DataTable GetAllPeople()
        {
            // Implement logic to retrieve all people from the database

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_People_GetAllPeople", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
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
        public static DataTable GetPagedPeople(int pageNumber, int pageSize, out int totalCount)
        {
            DataTable dataTable = new DataTable();
            totalCount = 0;

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

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dataTable.Load(reader);
                        }

                        totalCount = (int)totalParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return dataTable;
        }
    }



}
