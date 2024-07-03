using System;
using System.Data;
using System.Data.SqlClient;

namespace GymnasiumDataAccess
{
    public class clsInstructorsData
    {
        // Method to check if instructor exists by ID
        public static bool InstructorExists(int instructorID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Instructors_CheckIfInstructorExists", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@InstructorID", instructorID);

                SqlParameter returnParam = new SqlParameter();
                returnParam.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    int result = (int)returnParam.Value;
                    exists = (result == 1);
                }
                catch (Exception ex)
                {
                    // Handle exception
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return exists;
        }

        // Add other methods for Add, Update, Delete, GetAll, GetByID similarly

        public static int AddNewInstructor(int personID, string qualification, string specialization, DateTime hireDate, decimal salary, bool isActive)
        {
            int instructorID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Instructors_AddNewInstructor", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@Qualification", qualification);
                command.Parameters.AddWithValue("@Specialization", specialization);
                command.Parameters.AddWithValue("@HireDate", hireDate);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@IsActive", isActive);

                SqlParameter returnParam = command.Parameters.Add("@InstructorID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    instructorID = (int)returnParam.Value;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return instructorID;
        }

        // Add Update, Delete, GetByID, GetAll methods here similarly

        public static bool UpdateInstructor(int instructorID, int personID, string qualification, string specialization, DateTime hireDate, decimal salary, bool isActive)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Instructors_UpdateInstructor", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@InstructorID", instructorID);
                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@Qualification", qualification);
                command.Parameters.AddWithValue("@Specialization", specialization);
                command.Parameters.AddWithValue("@HireDate", hireDate);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@IsActive", isActive);

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

        public static bool DeleteInstructor(int instructorID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Instructors_DeleteInstructor", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@InstructorID", instructorID);

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

        public static DataTable GetAllInstructors()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_Instructors_GetAllInstructors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dataTable;
        }

        public static bool GetInstructorInfoByID(int instructorID, ref int personID, ref string qualification, ref string specialization, ref DateTime hireDate, ref decimal salary, ref bool isActive)
        {
            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_Instructors_GetInstructorByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", instructorID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = Convert.ToInt32(reader["PersonID"]);
                                qualification = reader["Qualification"].ToString();
                                specialization = reader["Specialization"].ToString();
                                hireDate = Convert.ToDateTime(reader["HireDate"]);
                                salary = Convert.ToDecimal(reader["Salary"]);
                                isActive = Convert.ToBoolean(reader["IsActive"]);

                                isSuccess = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isSuccess;
        }

        // New method to get paged instructors
        public static DataTable GetPagedInstructors(int pageNumber, int pageSize, out int totalCount)
        {
            DataTable dataTable = new DataTable();
            totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Instructors_GetPagedInstructors", connection))
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
