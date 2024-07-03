using GymnasiumDataAccess;
using System;
using System.Data;

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

        private bool _AddNewBeltTest()
        {
            this.BeltTestID = clsBeltTestData.AddNewBeltTest(this.MemberID, this.RankID, this.Result, this.Date, this.TestedByInstructorID, this.PaymentID);
            return (this.BeltTestID != -1);
        }

        private bool _UpdateBeltTest()
        {
            return clsBeltTestData.UpdateBeltTest(this.BeltTestID, this.MemberID, this.RankID, this.Result, this.Date, this.TestedByInstructorID, this.PaymentID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBeltTest())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBeltTest();
            }
            return false;
        }

        public static clsBeltTest FindByID(int beltTestID)
        {
            int memberID = -1;
            int rankID = -1;
            bool result = false;
            DateTime date = DateTime.MinValue;
            int testedByInstructorID = -1;
            int paymentID = -1;

            bool isFound = clsBeltTestData.GetBeltTestInfoByID(beltTestID, ref memberID, ref rankID, ref result, ref date, ref testedByInstructorID, ref paymentID);

            if (isFound)
            {
                return new clsBeltTest(beltTestID, memberID, rankID, result, date, testedByInstructorID, paymentID);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int beltTestID)
        {
            return clsBeltTestData.DeleteBeltTest(beltTestID);
        }

        public static bool ExistsByID(int beltTestID)
        {
            return clsBeltTestData.IsBeltTestExistByID(beltTestID);
        }

        public static DataTable GetAllBeltTests()
        {
            return clsBeltTestData.GetAllBeltTests();
        }

        // New method to get paged belt tests
        public static DataTable GetPagedBeltTests(int pageNumber, int pageSize, out int totalCount)
        {
            return clsBeltTestData.GetPagedBeltTests(pageNumber, pageSize, out totalCount);
        }
    }

}
