using GymnasiumDataAccess;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GymnasiumLogicLayer
{
    public class clsSports
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public int SportID { get; set; }
        public string SportName { get; set; }
        public string Description { get; set; }

        public float Fees { get; set; }

        public clsSports()
        {
            this.SportID = -1;
            this.SportName = string.Empty;
            this.Description = string.Empty;
            this.Fees = 0;

            _Mode = enMode.AddNew;
        }

        private clsSports(int sportID, string sportName, string description, float fees)
        {
            this.SportID = sportID;
            this.SportName = sportName;
            this.Description = description;
            this.Fees = fees;

            _Mode = enMode.Update;
        }

        private async Task<bool> _AddNewSport()
        {
            this.SportID = await clsSportsData.AddNewSport(this.SportName, this.Description, this.Fees);
            return (this.SportID != -1);
        }

        private async Task<bool> _UpdateSport()
        {
            return await clsSportsData.UpdateSport(this.SportID, this.SportName, this.Description, this.Fees);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewSport())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateSport();
            }
            return false;
        }

        public static async Task<clsSports> FindByID(int sportID)
        {
            DataTable result = await clsSportsData.GetSportInfoByID(sportID);

            if (result.Rows.Count == 0)
                return null;
            else
            {
                DataRow dr = result.Rows[0];

                return new clsSports(Convert.ToInt32(dr["SportID"]),
                                     Convert.ToString(dr["SportName"]),
                                     Convert.ToString(dr["Description"]),
                                     Convert.ToSingle(dr["Fees"]));
            }
        }

        public static async Task<clsSports> FindByName(string sportName)
        {
            DataTable result = await clsSportsData.FindByName(sportName);

            if (result.Rows.Count == 0)
                return null;
            else
            {
                DataRow dr = result.Rows[0];

                return new clsSports(Convert.ToInt32(dr["SportID"]),
                                     Convert.ToString(dr["SportName"]),
                                     Convert.ToString(dr["Description"]),
                                     Convert.ToSingle(dr["Fees"]));
            }
        }

        public static async Task<bool> Delete(int sportID)
        {
            return await clsSportsData.DeleteSport(sportID);
        }

        public static async Task<bool> ExistsByID(int sportID)
        {
            return await clsSportsData.IsSportExistByID(sportID);
        }

        public static async Task<DataTable> GetAllSports()
        {
            return await clsSportsData.GetAllSports();
        }

        // New method to get paged sports
        public static async Task<(DataTable dataTable, int totalCount)> GetPagedSports(int pageNumber, int pageSize)
        {
            return await clsSportsData.GetPagedSports(pageNumber, pageSize);
        }
    }
}
