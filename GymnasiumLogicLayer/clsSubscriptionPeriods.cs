using GymnasiumDataAccess;
using System;
using System.Data;

namespace GymnasiumLogicLayer
{
    public class clsSubscriptionPeriods
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int PeriodID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Fees { get; set; }
        public bool Paid { get; set; }
        public int MemberID { get; set; }
        public int PaymentID { get; set; }

        public clsSubscriptionPeriods()
        {
            this.PeriodID = -1;
            this.StartDate = DateTime.MinValue;
            this.EndDate = DateTime.MinValue;
            this.Fees = 0;
            this.Paid = false;
            this.MemberID = -1;
            this.PaymentID = -1;

            _Mode = enMode.AddNew;
        }

        private clsSubscriptionPeriods(int periodID, DateTime startDate, DateTime endDate, decimal fees, bool paid, int memberID, int paymentID)
        {
            this.PeriodID = periodID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Fees = fees;
            this.Paid = paid;
            this.MemberID = memberID;
            this.PaymentID = paymentID;

            _Mode = enMode.Update;
        }

        private bool _AddNewPeriod()
        {
            this.PeriodID = clsSubscriptionPeriodsData.AddNewPeriod(this.StartDate, this.EndDate, this.Fees, this.Paid, this.MemberID, this.PaymentID);
            return (this.PeriodID != -1);
        }

        private bool _UpdatePeriod()
        {
            return clsSubscriptionPeriodsData.UpdatePeriod(this.PeriodID, this.StartDate, this.EndDate, this.Fees, this.Paid, this.MemberID, this.PaymentID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPeriod())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePeriod();
            }
            return false;
        }

        // New method to get period
        public static clsSubscriptionPeriods FindByID(int periodID)
        {
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            decimal fees = 0;
            bool paid = false;
            int memberID = -1;
            int paymentID = -1;

            bool isFound = clsSubscriptionPeriodsData.GetPeriodInfoByID(periodID, ref startDate, ref endDate, ref fees, ref paid, ref memberID, ref paymentID);

            if (isFound)
            {
                return new clsSubscriptionPeriods(periodID, startDate, endDate, fees, paid, memberID, paymentID);
            }
            else
            {
                return null;
            }
        }

        // New method to delete period
        public static bool Delete(int periodID)
        {
            return clsSubscriptionPeriodsData.DeletePeriod(periodID);
        }

        // New method to check if period exists
        public static bool ExistsByID(int periodID)
        {
            return clsSubscriptionPeriodsData.IsPeriodExistByID(periodID);
        }

        // New method to get all subscription periods
        public static DataTable GetAllPeriods()
        {
            return clsSubscriptionPeriodsData.GetAllPeriods();
        }

        public static DataTable GetAllExpiredSubscriptions()
        {
            return clsSubscriptionPeriodsData.GetAllExpiredSubscriptions();
        }

        // New method to get paged subscription periods
        public static DataTable GetPagedSubscriptionPeriods(int pageNumber, int pageSize, out int totalCount)
        {
            return clsSubscriptionPeriodsData.GetPagedSubscriptionPeriods(pageNumber, pageSize, out totalCount);
        }

        public static bool SetPeriodInActive(int PeriodID)
        {
            return clsSubscriptionPeriodsData.SetPeriodInActive(PeriodID);
        }

        public static DataTable GetAllMemberPeriodsByMemberID(int MemberID)
        {
            return clsSubscriptionPeriodsData.GetAllMemberPeriodsByMemberID(MemberID);
        }
    }
}
