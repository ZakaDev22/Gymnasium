using System;
using System.Data;
using System.Data.SqlClient;

namespace GymnasiumDataAccess
{
    public class clsUsersData
    {

        // Create a new user
        public static int AddNewUser(int personID, string userName, string passwordHash, bool isActive, int permissions)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", passwordHash);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Permissions", permissions);

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

        // Read all users
        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_GetAllUsers", connection))
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

        // get paged users
        public static DataTable GetPagedUsers(int pageNumber, int pageSize, out int totalCount)
        {
            DataTable dataTable = new DataTable();
            totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_GetPagedUsers", connection))
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


        // Read user by UserID

        public static bool GetUserInfoByUserID(int userID, ref int personID, ref string userName,
                                                    ref string password, ref bool isActive, ref int permissions)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_Users_GetUserByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@userID", userID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personID = (int)reader["PersonID"];

                            userName = (string)reader["UserName"];
                            password = (string)reader["Password"];
                            isActive = (bool)reader["IsActive"];
                            permissions = (int)reader["Permissions"];

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

        public static bool GetUserInfoByPersonID(int personID, ref int userID, ref string userName,
                                                  ref string password, ref bool isActive, ref int permissions)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_Users_GetUserByPersonID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", personID);


                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = (int)reader["UserID"];

                            userName = (string)reader["UserName"];
                            password = (string)reader["Password"];
                            isActive = (bool)reader["IsActive"];
                            permissions = (int)reader["Permissions"];

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


        // Update an existing user
        public static bool UpdateUser(int userID, int personID, string userName, string passwordHash, bool isActive, int permissions)
        {
            short RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Permissions", permissions);

                        connection.Open();

                        RowEffected = (short)command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return RowEffected > 0;
        }

        // Delete a user by UserID
        public static bool DeleteUser(int userID)
        {
            short RowEffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", userID);

                        connection.Open();
                        RowEffected = (short)command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }


            return RowEffected > 0;
        }

        // Check if user exists by UserID
        public static bool IsUserExistByUserID(int userID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_IsUserExistByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", userID);

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

        //public static bool IsUserExist(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActived, ref int Permissions)
        //{

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //        {
        //            connection.Open();

        //            // the bug is in This code in the stored procedure
        //            using (SqlCommand command = new SqlCommand("sp_Users_IsUserExistByUserNameAndPassword", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;

        //                command.Parameters.AddWithValue("@UserName", UserName);
        //                command.Parameters.AddWithValue("@Password", Password);

        //                using (SqlDataReader Reader = command.ExecuteReader())
        //                {

        //                    if (Reader.Read())
        //                    {

        //                        UserID = (int)Reader["UserID"];
        //                        PersonID = (int)Reader["PersonID"];
        //                        IsActived = Convert.ToBoolean(Reader["IsActive"]);
        //                        Permissions = (int)Reader["Permissions"];

        //                        return true;
        //                    }


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
        //    }

        //    return false;
        //}

        // Check if user exists by UserID

        public static bool IsUserExist(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActived, ref int Permissions)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    // i use The Old Pattern In This Example Cuz The Stored Procedure is not working Right Now Fix It Latter !!!

                    string query = @"SELECT UserID, PersonID, IsActive, Permissions
                                            FROM Users
                                             WHERE UserName = @UserName AND Password = @Password";

                    // "sp_Users_IsUserExistByUserNameAndPassword"
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                UserID = (int)Reader["UserID"];
                                PersonID = (int)Reader["PersonID"];
                                IsActived = Convert.ToBoolean(Reader["IsActive"]);
                                Permissions = (int)Reader["Permissions"];

                                return true;
                            }
                            else
                            {
                                // Log to understand why Reader.Read() returned false
                                clsGlobalForDataAccess.LogExseptionsToLogerViewr("No rows found", System.Diagnostics.EventLogEntryType.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return false;
        }


        public static bool ExistsByUserName(string UserName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_IsUserExistByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

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



        // Check if user exists by PersonID
        public static bool IsUserExistByPersonID(int personID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Users_IsUserExistByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

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
