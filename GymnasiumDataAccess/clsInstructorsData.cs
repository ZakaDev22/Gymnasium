using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GymnasiumDataAccess
{
    public class clsInstructorsData
    {
        // Method to check if instructor exists by ID
        // Check if instructor exists by ID
        public static async Task<bool> InstructorExists(int instructorID)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Instructors_CheckIfInstructorExists", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@InstructorID", instructorID);

                SqlParameter returnParam = new SqlParameter
                {
                    Direction = ParameterDirection.ReturnValue
                };
                command.Parameters.Add(returnParam);

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return (int)returnParam.Value == 1;
                }
                catch (Exception ex)
                {
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    return false;
                }
            }


        }

        // Add new instructor
        public static async Task<int> AddNewInstructor(int personID, string qualification, string specialization, DateTime hireDate, decimal salary, bool isActive)
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
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    instructorID = returnParam.Value == DBNull.Value ? -1 : (int)returnParam.Value;
                }
                catch (Exception ex)
                {
                    clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            return instructorID;
        }

        // Update instructor
        public static async Task<bool> UpdateInstructor(int instructorID, int personID, string qualification, string specialization, DateTime hireDate, decimal salary, bool isActive)
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

        // Delete instructor
        public static async Task<bool> DeleteInstructor(int instructorID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Instructors_DeleteInstructor", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@InstructorID", instructorID);

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

        // Get all instructors
        public static async Task<DataTable> GetAllInstructors()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_Instructors_GetAllInstructors", connection))
                {
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
                        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dataTable;
        }

        // Get instructor by ID
        public static async Task<DataTable> GetInstructorInfoByID(int instructorID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_Instructors_GetInstructorByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InstructorID", instructorID);

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
                        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dt;
        }

        // Get paged instructors
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedInstructors(int pageNumber, int pageSize)
        {
            DataTable dataTable = new DataTable();
            int totalCount = 0;

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

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dataTable.Load(reader);
                        }

                        totalCount = totalParam.Value == DBNull.Value ? 0 : (int)totalParam.Value;
                    }
                    catch (Exception ex)
                    {
                        clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return (dataTable, totalCount);
        }

    }
}
