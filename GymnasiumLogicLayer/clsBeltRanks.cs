using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsBeltRanks
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int RankID { get; set; }
        public string RankName { get; set; }
        public decimal TestFees { get; set; }

        public clsBeltRanks()
        {
            this.RankID = -1;
            this.RankName = string.Empty;
            this.TestFees = 0m;

            _Mode = enMode.AddNew;
        }

        private clsBeltRanks(int rankID, string rankName, decimal testFees)
        {
            this.RankID = rankID;
            this.RankName = rankName;
            this.TestFees = testFees;

            _Mode |= enMode.Update;
        }

        private async Task<bool> _AddNewBeltRankAsync()
        {
            this.RankID = await clsBeltRankData.AddNewBeltRank(this.RankName, this.TestFees);
            return (this.RankID != -1);
        }

        private async Task<bool> _UpdateBeltRankAsync()
        {
            return await clsBeltRankData.UpdateBeltRank(this.RankID, this.RankName, this.TestFees);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewBeltRankAsync())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateBeltRankAsync();
            }
            return false;
        }

        public static async Task<clsBeltRanks> FindByIDAsync(int rankID)
        {
            DataTable dt = await clsBeltRankData.GetBeltRankByID(rankID);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow row = dt.Rows[0];

                return new clsBeltRanks(Convert.ToInt32(row["RankID"]),
                                        Convert.ToString(row["RankName"]),
                                        Convert.ToDecimal(row["TestFees"]));
            }
        }

        public static async Task<bool> DeleteByIDAsync(int rankID)
        {
            return await clsBeltRankData.DeleteBeltRank(rankID);
        }

        public static async Task<bool> ExistsByIDAsync(int rankID)
        {
            return await clsBeltRankData.IsBeltRankExistByID(rankID);
        }

        public static async Task<DataTable> GetAllBeltRanks()
        {
            return await clsBeltRankData.GetAllBeltRanks();
        }

        // New method to get paged belt ranks
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedBeltRanks(int pageNumber, int pageSize)
        {
            return await clsBeltRankData.GetPagedBeltRanksAsync(pageNumber, pageSize);
        }
    }
}
