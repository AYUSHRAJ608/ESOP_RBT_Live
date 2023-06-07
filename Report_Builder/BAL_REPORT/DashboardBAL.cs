using DAL_REPORT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entity_REPORT;

namespace BAL_REPORT
{
    public class DashboardBAL
    {
        DashboardDAL objDashDAL = new DashboardDAL();
        public void GetConnString(string key)
        {
            objDashDAL.GetConnString(key);
        }
        public DataSet GetDashGrid(EDashboard objEnt)
        {
            return objDashDAL.GetDashGrid_DAL(objEnt);
        }
        public DataSet GetReportData(EDashboard objEnt)
        {
            return objDashDAL.GetReportData_DAL(objEnt);
        }
    }
}
