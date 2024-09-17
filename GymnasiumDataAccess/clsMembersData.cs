using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GymnasiumDataAccess
{
    public class clsMembersData
    {

        public static async Task<int> AddNewMember(int personID, int sportID, int emergencyContactID, DateTime joinDate, bool isActive)
        {
            int memberID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_AddNewMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@SportID", sportID);
                        command.Parameters.AddWithValue("@EmergencyContactID", emergencyContactID);
                        command.Parameters.AddWithValue("@JoinDate", joinDate);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        SqlParameter returnParam = command.Parameters.Add("@MemberID", SqlDbType.Int);
                        returnParam.Direction = ParameterDirection.Output;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        memberID = returnParam.Value == DBNull.Value ? 0 : (int)returnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            return memberID;
        }


        public static async Task<bool> UpdateMember(int memberID, int personID, int sportID, int emergencyContactID, DateTime joinDate, bool isActive)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_UpdateMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@SportID", sportID);
                        command.Parameters.AddWithValue("@EmergencyContactID", emergencyContactID);
                        command.Parameters.AddWithValue("@JoinDate", joinDate);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        await connection.OpenAsync();
                        return await command.ExecuteNonQueryAsync() > 0;// command.ExecuteNonQueryAsync().Result;

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

        public static async Task<DataTable> GetMemberInfoByID(int memberID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_Members_GetMemberByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MemberID", memberID);

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

        public static async Task<DataTable> FindMemberByPersonID(int personID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_Members_FindMemberByPersonID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personID);

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


        public static async Task<bool> DeleteMember(int memberID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_Members_DeleteMember", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MemberID", memberID);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

        }

        public static async Task<bool> SetMemberToInDeleted(int memberID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_SetToInDeleted", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        await connection.OpenAsync();
                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

        }

        public static async Task<bool> SetMemberAsActiveOrInactive(int memberID, bool isActiveOrNot)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_SetMemberAsActiveOrInactive", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        command.Parameters.AddWithValue("@Result", isActiveOrNot);

                        await connection.OpenAsync();
                        return await command.ExecuteNonQueryAsync() > 0;
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

        public static async Task<bool> IsMemberActive(int memberID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_IsMemberActive", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            return reader.HasRows;
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

        /// <summary>
        /// Checks if a member exists by the provided PersonID.
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns> false.
        public static async Task<bool> IsMemberExistsByID(int memberID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("sp_Members_IsMemberExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        SqlParameter returnParam = command.Parameters.Add("@IsExiste", SqlDbType.Bit);
                        returnParam.Direction = ParameterDirection.Output;

                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();

                        return Convert.ToBoolean(returnParam.Value);
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


        /// <summary>
        /// Checks if a member exists by the provided PersonID.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        // 
        public static async Task<bool> IsMemberExistsByPersonID(int PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    SqlCommand command = new SqlCommand("sp_Members_IsMemberExistsByPersonID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    SqlParameter returnParam = command.Parameters.Add("@IsExiste", SqlDbType.Bit);
                    returnParam.Direction = ParameterDirection.Output;

                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();

                    return Convert.ToBoolean(returnParam.Value);

                }
            }
            catch (Exception ex)
            {
                // Handle exception
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

        }


        public static async Task<DataTable> GetAllMembers()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetAllMembers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
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

        public static async Task<DataTable> GetAllDeletedMembers()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetAllDeletedMembers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

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

        public static async Task<DataTable> GetAllBlackListMembers()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetAllBlackListMembers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

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


        // New method to get paged members
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedMembers(int pageNumber, int pageSize)
        {
            DataTable dataTable = new DataTable();
            int totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetPagedMembers", connection))
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

        // New method to get paged Deleted members
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedDeletedMembers(int pageNumber, int pageSize)
        {
            DataTable dataTable = new DataTable();
            int totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetPagedDeletedMembers", connection))
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

        public static async Task<(DataTable dataTable, int totalCount)> GetBlackListPagedMembers(int pageNumber, int pageSize)
        {
            DataTable dataTable = new DataTable();
            int totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetBlackListPagedMembers", connection))
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

        public static async Task<bool> SetMemberInBlackList(int memberID, bool IsExeste)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_SetMemberInBlackList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@IsExist", IsExeste);

                        await connection.OpenAsync();
                        return await command.ExecuteNonQueryAsync() > 0;
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

        public static async Task<bool> SetMemberToNormalList(int memberID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_SetMemberToNormalList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        await connection.OpenAsync();
                        return await command.ExecuteNonQueryAsync() > 0;
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

        public static async Task<bool> IsMemberInBlackList(int memberID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_IsMemberInBlackList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            return reader.HasRows;
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

        public static async Task<bool> IsMemberInBlackListHistory(int memberID)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_IsMemberInBlackListHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            return reader.HasRows;
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

        public static async Task<DataTable> GetBlackListHistory()
        {

            DataTable dataTable;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Members_GetBlackListHistory", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dataTable = new DataTable();

                        dataTable.Load(reader);
                    }
                }

            }


            return dataTable;
        }

        // New method to get paged members
        public static async Task<(DataTable DataTable, int totalCount)> GetPagedBlackListHistory(int pageNumber, int pageSize)
        {
            DataTable dataTable = new DataTable();
            int totalCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_Members_GetPagedBlackListHistory", connection))
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

