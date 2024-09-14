using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsBeltTest
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int BeltTestID { get; set; }
        public int MemberID { get; set; }
        public int RankID { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public int TestedByInstructorID { get; set; }
        public int PaymentID { get; set; }

        public clsBeltTest()
        {
            this.BeltTestID = -1;
            this.MemberID = -1;
            this.RankID = -1;
            this.Result = false;
            this.Date = DateTime.MinValue;
            this.TestedByInstructorID = -1;
            this.PaymentID = -1;

            _Mode = enMode.AddNew;
        }

        private clsBeltTest(int beltTestID, int memberID, int rankID, bool result, DateTime date, int testedByInstructorID, int paymentID)
        {
            this.BeltTestID = beltTestID;
            this.MemberID = memberID;
            this.RankID = rankID;
            this.Result = result;
            this.Date = date;
            this.TestedByInstructorID = testedByInstructorID;
            this.PaymentID = paymentID;

            _Mode = enMode.Update;
        }

        private async Task<bool> _AddNewBeltTest()
        {
            this.BeltTestID = await clsBeltTestData.AddNewBeltTestAsync(this.MemberID, this.RankID, this.Result, this.Date, this.TestedByInstructorID, this.PaymentID);
            return (this.BeltTestID != -1);
        }

        private async Task<bool> _UpdateBeltTest()
        {
            return await clsBeltTestData.UpdateBeltTestAsync(this.BeltTestID, this.MemberID, this.RankID, this.Result, this.Date, this.TestedByInstructorID, this.PaymentID);
        }

        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewBeltTest())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateBeltTest();
            }
            return false;
        }

        public static async Task<clsBeltTest> FindByIDAsync(int beltTestID)
        {
            DataTable dt = await clsBeltTestData.GetBeltTestInfoByIDAsync(beltTestID);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow row = dt.Rows[0];

                return new clsBeltTest(Convert.ToInt32(row["TestID"]),
                                        Convert.ToInt32(row["MemberID"]),
                                        Convert.ToInt32(row["RankID"]),
                                        Convert.ToBoolean(row["Result"]),
                                        Convert.ToDateTime(row["Date"]),
                                        Convert.ToInt32(row["TestedByInstructorID"]),
                                        Convert.ToInt32(row["PaymentID"]));
            }
        }

        public static async Task<bool> DeleteAsync(int beltTestID)
        {
            return await clsBeltTestData.DeleteBeltTestAsync(beltTestID);
        }

        public static async Task<bool> ExistsByIDAsync(int beltTestID)
        {
            return await clsBeltTestData.IsBeltTestExistByIDAsync(beltTestID);
        }

        public static async Task<DataTable> GetAllBeltTests()
        {
            return await clsBeltTestData.GetAllBeltTestsAsync();
        }

        // New method to get paged belt tests
        public static async Task<(DataTable dataTable, int TotalCount)> GetPagedBeltTests(int pageNumber, int pageSize)
        {
            return await clsBeltTestData.GetPagedBeltTestsAsync(pageNumber, pageSize);
        }
    }

}
