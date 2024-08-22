using GymnasiumDataAccess;
using System;
using System.Data;

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

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentsData.AddNewPayment(this.Amount, this.Date, this.MemberID);
            return (this.PaymentID != -1);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentsData.UpdatePayment(this.PaymentID, this.Amount, this.Date, this.MemberID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePayment();
            }
            return false;
        }

        // New method to find payment by ID
        public static clsPayments FindByID(int paymentID)
        {
            decimal amount = 0;
            DateTime date = DateTime.MinValue;
            int memberID = -1;

            bool isFound = clsPaymentsData.GetPaymentInfoByID(paymentID, ref amount, ref date, ref memberID);

            if (isFound)
            {
                return new clsPayments(paymentID, amount, date, memberID);
            }
            else
            {
                return null;
            }
        }

        public static clsPayments FindByMemberID(int MemberID)
        {
            decimal amount = 0;
            DateTime date = DateTime.MinValue;
            int PaymentID = -1;

            bool isFound = clsPaymentsData.GetPaymentInfoByMemberID(MemberID, ref amount, ref date, ref PaymentID);

            if (isFound)
            {
                return new clsPayments(PaymentID, amount, date, MemberID);
            }
            else
            {
                return null;
            }
        }

        // New method to delete payment
        public static bool Delete(int paymentID)
        {
            return clsPaymentsData.DeletePayment(paymentID);
        }

        // New method to check if payment exists by ID
        public static bool ExistsByID(int paymentID)
        {
            return clsPaymentsData.IsPaymentExistByID(paymentID);
        }

        // New method to get all payments
        public static DataTable GetAllPayments()
        {
            return clsPaymentsData.GetAllPayments();
        }

        // New method to get paged payments
        public static DataTable GetPagedPayments(int pageNumber, int pageSize, out int totalCount)
        {
            return clsPaymentsData.GetPagedPayments(pageNumber, pageSize, out totalCount);
        }


        // New method to get all payments per each month
        public static DataTable GetAllPaymentsPerEachMonth(int Year)
        {
            return clsPaymentsData.GetAllPaymentsPerEachMonth(Year);
        }



    }
}
