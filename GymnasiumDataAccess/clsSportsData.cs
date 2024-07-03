using System;
using System.Data;
using System.Data.SqlClient;


namespace GymnasiumDataAccess
{
    public class clsSportsData
    {
        public static int AddNewSport(string sportName, string description, float Fess)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Update The Stored Procedure If You Want To Add More Sports To Accespt The New Parameter Fees
                    using (SqlCommand command = new SqlCommand("sp_Sports_AddNewSport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SportName", sportName);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Fees", Fess);

                        connection.Open();
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return -1;
        }

        public static DataTable GetAllSports()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Sports_GetAllSports", connection))
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
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return dataTable;
        }

        // New method to get paged sports
        public static DataTable GetPagedSports(int pageNumber, int pageSize, out int totalCount)
        {
            DataTable dataTable = new DataTable();
            totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetPagedSports", connection))
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

        public static bool GetSportInfoByID(int sportID, ref string sportName, ref string description, ref float fees)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Sports_GetSportByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SportID", sportID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sportName = (string)reader["SportName"];
                                description = (string)reader["Description"];
                                fees = Convert.ToSingle(reader["Fees"]);
                                isSuccess = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isSuccess;
        }

        public static bool FindByName(string sportName, ref int sportID, ref string description, ref float fees)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    // fix the bug is her Data Error Nvarchar To int
                    // update The Bug Is Fixed in 1 min 😎💪✅
                    using (SqlCommand command = new SqlCommand("sp_Sports_GetSportByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SportName", sportName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sportID = Convert.ToInt32(reader["SportID"]);
                                description = (string)reader["Description"];
                                fees = Convert.ToSingle(reader["Fees"]);
                                isSuccess = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isSuccess;
        }

        public static bool UpdateSport(int sportID, string sportName, string description, float fees)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Update This Procedure If You Want To Update Fees
                    using (SqlCommand command = new SqlCommand("sp_Sports_UpdateSport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SportID", sportID);
                        command.Parameters.AddWithValue("@SportName", sportName);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Fees", fees);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return false;
        }

        public static bool DeleteSport(int sportID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Sports_DeleteSport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SportID", sportID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return false;
        }

        public static bool IsSportExistByID(int sportID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Sports_IsSportExistByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SportID", sportID);

                        connection.Open();
                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return false;
        }
    }
}
