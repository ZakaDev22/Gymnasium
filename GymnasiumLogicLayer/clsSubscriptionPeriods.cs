using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

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

        private async Task<bool> _AddNewPeriod()
        {
            this.PeriodID = await clsSubscriptionPeriodsData.AddNewPeriod(this.StartDate, this.EndDate, this.Fees, this.Paid, this.MemberID, this.PaymentID);
            return (this.PeriodID != -1);
        }

        private async Task<bool> _UpdatePeriod()
        {
            return await clsSubscriptionPeriodsData.UpdatePeriod(this.PeriodID, this.StartDate, this.EndDate, this.Fees, this.Paid, this.MemberID, this.PaymentID);
        }

        public async Task<bool> Save()
        {
            try
            {
                switch (_Mode)
                {
                    case enMode.AddNew:
                        if (await _AddNewPeriod())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return await _UpdatePeriod();
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as needed
                clsGlobalForDataAccess.LogExseptionsToLogerViewr(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

            return false;
        }

        // New method to get period
        public static async Task<clsSubscriptionPeriods> FindByID(int periodID)
        {
            DataTable dt = await clsSubscriptionPeriodsData.GetPeriodInfoByID(periodID);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow Row = dt.Rows[0];

                return new clsSubscriptionPeriods(Convert.ToInt32(Row["PeriodID"]),
                                                  Convert.ToDateTime(Row["StartDate"]),
                                                  Convert.ToDateTime(Row["EndDate"]),
                                                  Convert.ToDecimal(Row["Fees"]),
                                                  Convert.ToBoolean(Row["Paid"]),
                                                  Convert.ToInt32(Row["MemberID"]),
                                                  Convert.ToInt32(Row["PaymentID"]));
            }

        }

        // New method to delete period
        public static async Task<bool> Delete(int periodID)
        {
            return await clsSubscriptionPeriodsData.DeletePeriod(periodID);
        }

        // New method to check if period exists
        public static async Task<bool> ExistsByID(int periodID)
        {
            return await clsSubscriptionPeriodsData.IsPeriodExistByID(periodID);
        }

        // New method to get all subscription periods
        public static async Task<DataTable> GetAllPeriods()
        {
            return await clsSubscriptionPeriodsData.GetAllPeriods();
        }

        public static async Task<DataTable> GetAllExpiredSubscriptions()
        {
            return await clsSubscriptionPeriodsData.GetAllExpiredSubscriptions();
        }

        // New method to get paged subscription periods
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedSubscriptionPeriods(int pageNumber, int pageSize)
        {
            return await clsSubscriptionPeriodsData.GetPagedSubscriptionPeriods(pageNumber, pageSize);
        }

        public static async Task<bool> SetPeriodInActive(int PeriodID)
        {
            return await clsSubscriptionPeriodsData.SetPeriodInActive(PeriodID);
        }

        public static async Task<DataTable> GetAllMemberPeriodsByMemberID(int MemberID)
        {
            return await clsSubscriptionPeriodsData.GetAllMemberPeriodsByMemberID(MemberID);
        }
    }
}
