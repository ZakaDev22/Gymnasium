using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsPayments
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int MemberID { get; set; }

        public clsPayments()
        {
            this.PaymentID = -1;
            this.Amount = 0;
            this.Date = DateTime.MinValue;
            this.MemberID = -1;

            _Mode = enMode.AddNew;
        }

        private clsPayments(int paymentID, decimal amount, DateTime date, int memberID)
        {
            this.PaymentID = paymentID;
            this.Amount = amount;
            this.Date = date;
            this.MemberID = memberID;

            _Mode = enMode.Update;
        }

        private async Task<bool> _AddNewPayment()
        {
            this.PaymentID = await clsPaymentsData.AddNewPayment(this.Amount, this.Date, this.MemberID);
            return (this.PaymentID != -1);
        }

        private async Task<bool> _UpdatePayment()
        {
            return await clsPaymentsData.UpdatePayment(this.PaymentID, this.Amount, this.Date, this.MemberID);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewPayment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdatePayment();
            }
            return false;
        }

        // New method to find payment by ID
        public static async Task<clsPayments> FindByID(int paymentID)
        {

            DataTable dt = await clsPaymentsData.GetPaymentInfoByID(paymentID);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow dr = dt.Rows[0];

                return new clsPayments(Convert.ToInt32(dr["PaymentID"]),
                                       Convert.ToDecimal(dr["Amount"]),
                                       Convert.ToDateTime(dr["Date"]),
                                       Convert.ToInt32(dr["MemberID"]));
            }

        }

        public static async Task<clsPayments> FindByMemberID(int MemberID)
        {
            DataTable dt = await clsPaymentsData.GetPaymentInfoByMemberID(MemberID);

            if (dt.Rows.Count == 0)
                return null;
            else
            {
                DataRow dr = dt.Rows[0];

                return new clsPayments(Convert.ToInt32(dr["PaymentID"]),
                                       Convert.ToDecimal(dr["Amount"]),
                                       Convert.ToDateTime(dr["Date"]),
                                       Convert.ToInt32(dr["MemberID"]));
            }
        }

        // New method to delete payment
        public static async Task<bool> Delete(int paymentID)
        {
            return await clsPaymentsData.DeletePayment(paymentID);
        }

        // New method to check if payment exists by ID
        public static async Task<bool> ExistsByID(int paymentID)
        {
            return await clsPaymentsData.IsPaymentExistByID(paymentID);
        }

        // New method to get all payments
        public static async Task<DataTable> GetAllPayments()
        {
            return await clsPaymentsData.GetAllPayments();
        }

        // New method to get paged payments
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedPayments(int pageNumber, int pageSize)
        {
            return await clsPaymentsData.GetPagedPayments(pageNumber, pageSize);
        }


        // New method to get all payments per each month
        public static async Task<DataTable> GetAllPaymentsPerEachMonth(int Year)
        {
            return await clsPaymentsData.GetAllPaymentsPerEachMonth(Year);
        }



    }
}
