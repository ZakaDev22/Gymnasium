using System;
using System.Data;
using System.Data.SqlClient;

namespace GymnasiumDataAccess
{
    public class clsPaymentsData
    {
        public static int AddNewPayment(decimal amount, DateTime date, int memberID)
        {
            int paymentID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_AddNewPayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@MemberID", memberID);

                        // fix the bug is her Data Error Nvarchar To int
                        // Add The Parameter for New Payment ID Her Out Put Parameter

                        SqlParameter returnParam = command.Parameters.Add("@NewPaymentID", SqlDbType.Int);
                        returnParam.Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            paymentID = (int)returnParam.Value;
                        }
                        catch (Exception ex)
                        {
                            // Handle exception
                            clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return paymentID;
        }

        // Get All Payments
        public static DataTable GetAllPayments()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_GetAllPayments", connection))
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

        // New method to get paged payments
        public static DataTable GetPagedPayments(int pageNumber, int pageSize, out int totalCount)
        {
            DataTable dataTable = new DataTable();
            totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_GetPagedPayments", connection))
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

        public static bool GetPaymentInfoByID(int paymentID, ref decimal amount, ref DateTime date, ref int memberID)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_GetPaymentByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);


                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                amount = (decimal)reader["Amount"];
                                date = (DateTime)reader["Date"];
                                memberID = (int)reader["MemberID"];

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

        public static bool GetPaymentInfoByMemberID(int memberID, ref decimal amount, ref DateTime date, ref int paymentID)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_GetPaymentByMemberID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", memberID);


                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                amount = (decimal)reader["Amount"];
                                date = (DateTime)reader["Date"];
                                paymentID = (int)reader["PaymentID"];

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


        public static bool UpdatePayment(int paymentID, decimal amount, DateTime date, int memberID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_UpdatePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@MemberID", memberID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
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

        public static bool DeletePayment(int paymentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_DeletePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
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

        public static bool IsPaymentExistByID(int paymentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Payments_IsPaymentExistByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

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
