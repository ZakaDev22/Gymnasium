using GymnasiumDataAccess;
using System.Data;

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

        private bool _AddNewBeltRank()
        {
            this.RankID = clsBeltRankData.AddNewBeltRank(this.RankName, this.TestFees);
            return (this.RankID != -1);
        }

        private bool _UpdateBeltRank()
        {
            return clsBeltRankData.UpdateBeltRank(this.RankID, this.RankName, this.TestFees);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBeltRank())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBeltRank();
            }
            return false;
        }

        public static clsBeltRanks FindByID(int rankID)
        {
            string rankName = string.Empty;
            decimal testFees = 0m;

            bool isFound = clsBeltRankData.GetBeltRankByID(rankID, ref rankName, ref testFees);

            if (isFound)
            {
                return new clsBeltRanks
                {
                    RankID = rankID,
                    RankName = rankName,
                    TestFees = testFees
                };
            }
            else
            {
                return null;
            }
        }


        public static bool Delete(int rankID)
        {
            return clsBeltRankData.DeleteBeltRank(rankID);
        }

        public static bool ExistsByID(int rankID)
        {
            return clsBeltRankData.IsBeltRankExistByID(rankID);
        }

        public static DataTable GetAllBeltRanks()
        {
            return clsBeltRankData.GetAllBeltRanks();
        }

        // New method to get paged belt ranks
        public static DataTable GetPagedBeltRanks(int pageNumber, int pageSize, out int totalCount)
        {
            return clsBeltRankData.GetPagedBeltRanks(pageNumber, pageSize, out totalCount);
        }
    }
}
