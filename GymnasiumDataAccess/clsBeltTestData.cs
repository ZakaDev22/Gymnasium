using System;
using System.Data;
using System.Data.SqlClient;

namespace GymnasiumDataAccess
{
    public class clsBeltTestData
    {
        // Create a new belt test
        public static int AddNewBeltTest(int memberID, int rankID, bool result, DateTime date, int testedByInstructorID, int paymentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_BeltTest_AddNewBeltTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@RankID", rankID);
                        command.Parameters.AddWithValue("@Result", result);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@TestedByInstructorID", testedByInstructorID);
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

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

        // Read all belt tests
        public static DataTable GetAllBeltTests()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_BeltTest_GetAllBeltTests", connection))
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

        // New method to get paged belt tests
        public static DataTable GetPagedBeltTests(int pageNumber, int pageSize, out int totalCount)
        {
            DataTable dataTable = new DataTable();
            totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_BeltTest_GetPagedBeltTests", connection))
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

        // Read belt test by TestID
        public static bool GetBeltTestInfoByID(int testID, ref int memberID, ref int rankID, ref bool result, ref DateTime date, ref int testedByInstructorID, ref int paymentID)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_BeltTest_GetBeltTestByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TestID", testID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            memberID = (int)reader["MemberID"];
                            rankID = (int)reader["RankID"];
                            result = (bool)reader["Result"];
                            date = (DateTime)reader["Date"];
                            testedByInstructorID = (int)reader["TestedByInstructorID"];
                            paymentID = (int)reader["PaymentID"];

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

        // Update an existing belt test
        public static bool UpdateBeltTest(int testID, int memberID, int rankID, bool result, DateTime date, int testedByInstructorID, int paymentID)
        {
            short rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_BeltTest_UpdateBeltTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestID", testID);
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@RankID", rankID);
                        command.Parameters.AddWithValue("@Result", result);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@TestedByInstructorID", testedByInstructorID);
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

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

        // Delete a belt test by TestID
        public static bool DeleteBeltTest(int testID)
        {
            short rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_BeltTest_DeleteBeltTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TestID", testID);

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

        // Check if belt test exists by TestID
        public static bool IsBeltTestExistByID(int testID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_BeltTest_IsBeltTestExistByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TestID", testID);

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
