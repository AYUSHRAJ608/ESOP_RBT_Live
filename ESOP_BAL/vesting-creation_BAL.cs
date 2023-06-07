using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_BO;
using ESOP_DAL;
using System.Data;

namespace ESOP_BAL
{
    public class vesting_creation_BAL
    {
        vesting_creation_DAL objVestingDAL = new vesting_creation_DAL();
        public DataSet GetVestingDuration(vesting_creation_BO vesingBO)
        {
            return objVestingDAL.GetVestingDuration(vesingBO);
        }

        public DataSet GET_VESTING_MASTER_ID()
        {
            return objVestingDAL.GET_VESTING_MASTER_ID();
        }

        public void VESTING_MASTER_INSERT(vesting_creation_BO vesingBO)
        {
            objVestingDAL.VESTING_MASTER_INSERT(vesingBO);
        }

        public DataSet GETVESTINGDETAILS()
        {
            return objVestingDAL.GETVESTINGDETAILS();
        }
        public DataSet GETVESTINGDETAILSBYID(vesting_creation_BO vesingBO)
        {
            return objVestingDAL.GETVESTINGDETAILSBYID(vesingBO);
        }

        public DataSet GET_ADMIN_EMP_STOCK_MAPPING()
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING();
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_DETAILS()
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING_DETAILS();
        }

        public DataSet USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE()
        {
            return objVestingDAL.USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE();
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS(vesting_creation_BO vesingBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS(vesingBO);
        }
        public DataSet CHECK_VESTING_NAME(vesting_creation_BO vesingBO)
        {
            return objVestingDAL.CHECK_VESTING_NAME(vesingBO);
        }
        public void VESTING_MASTER_UPDATE_ACTIVE_STATUS(vesting_creation_BO vesingBO)
        {
            objVestingDAL.VESTING_MASTER_UPDATE_ACTIVE_STATUS(vesingBO);
        }
        public void VESTING_MASTER_DELETE(vesting_creation_BO vesingBO)
        {
            objVestingDAL.VESTING_MASTER_DELETE(vesingBO);
        }
        public DataSet CHECK_GRANT_VID(vesting_creation_BO vesingBO)
        {
            return objVestingDAL.CHECK_GRANT_VID(vesingBO);
        }
        //public DataSet GET_LAPS_EMP_STOCK_MAPPING()
        //{
        //    return objVestingDAL.GET_LAPS_EMP_STOCK();
        //}
        public DataSet ESOP_VESTING_ALL_COUNT()
        {
          return  objVestingDAL.ESOP_VESTING_ALL_COUNT();
        }
        public DataSet FIVE_YEAR_Laps()
        {
            return objVestingDAL.FIVE_YEAR_Laps();
        }
    }
}
