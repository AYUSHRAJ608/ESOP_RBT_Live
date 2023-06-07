
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
    public class PresidentBAL
    {
        PresidentDAL objVestingDAL = new PresidentDAL();
        PresidentBO objEmployeeBO = new PresidentBO();
        
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING(objPresidentBO);
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(objPresidentBO);
        }

        public DataSet GET_Distinct_VestID(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_Distinct_VestID(objPresidentBO);
        }
        public DataSet GET_ExportToExcel_Data(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ExportToExcel_Data(objPresidentBO);
        }
    
        public DataSet GET_All_Data(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_All_Data(objPresidentBO);
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_1(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING_1(objPresidentBO);
        }
        public bool UPDATE_LAPS(PresidentBO objPresidentBO)
        {
            return objVestingDAL.UPDATE_LAPS(objPresidentBO);
        }

        public bool UPDATE_LAPS_CHECKER(PresidentBO objPresidentBO)
        {
            return objVestingDAL.UPDATE_LAPS_CHECKER(objPresidentBO);
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_2(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING_2(objPresidentBO);
        }
        public DataSet GET_ESOP_STATUS(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ESOP_STATUS(objPresidentBO);
        }
        public DataSet GET_ESOP_STATUS_BANDWISE(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_ESOP_STATUS_BANDWISE(objPresidentBO);
        }
        public DataSet GET_LAPSE_LIST(PresidentBO objPresidentBO)
        {
            return objVestingDAL.GET_LAPSE_LIST(objPresidentBO);
        }
    }
}
