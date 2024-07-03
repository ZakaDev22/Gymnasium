using GymnasiumDataAccess;
using System.Data;

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

        private bool _AddNewSport()
        {
            this.SportID = clsSportsData.AddNewSport(this.SportName, this.Description, this.Fees);
            return (this.SportID != -1);
        }

        private bool _UpdateSport()
        {
            return clsSportsData.UpdateSport(this.SportID, this.SportName, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSport())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSport();
            }
            return false;
        }

        public static clsSports FindByID(int sportID)
        {
            string sportName = string.Empty;
            string description = string.Empty;
            float fees = 0;

            bool isFound = clsSportsData.GetSportInfoByID(sportID, ref sportName, ref description, ref fees);

            if (isFound)
            {
                return new clsSports(sportID, sportName, description, fees);
            }
            else
            {
                return null;
            }
        }

        public static clsSports FindByName(string sportName)
        {
            int SportID = -1;
            string description = string.Empty;
            float fees = 0;

            bool isFound = clsSportsData.FindByName(sportName, ref SportID, ref description, ref fees);

            if (isFound)
            {
                return new clsSports(SportID, sportName, description, fees);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int sportID)
        {
            return clsSportsData.DeleteSport(sportID);
        }

        public static bool ExistsByID(int sportID)
        {
            return clsSportsData.IsSportExistByID(sportID);
        }

        public static DataTable GetAllSports()
        {
            return clsSportsData.GetAllSports();
        }

        // New method to get paged sports
        public static DataTable GetPagedSports(int pageNumber, int pageSize, out int totalCount)
        {
            return clsSportsData.GetPagedSports(pageNumber, pageSize, out totalCount);
        }
    }
}
