using ESOP_BO;
using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class exercise_reportBAL
    {
        exercise_reportDAL objDAL = new exercise_reportDAL();
        public DataSet GET_ADMIN_EXERCISE_REPORT(exercise_reportBO objBO)
        {
            return objDAL.GET_ADMIN_EXERCISE_REPORT(objBO);
        }
        public DataSet GET_EMPLOYEE_EXERCISE_REPORT(exercise_reportBO objBO)
        {
            return objDAL.GET_EMPLOYEE_EXERCISE_REPORT(objBO);
        }
        public DataSet ESOP_admin_EXERCISE_REPORT_ALL_COUNT()
        {
            return objDAL.ESOP_admin_EXERCISE_REPORT_ALL_COUNT();
        }
        public DataSet GET_EMPLOYEE_SECRETARIAL_DownloadLink(double id)
        {
            return objDAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);
        }

        public DataSet GetError()
        {
            return objDAL.GetError();
        }

        public DataSet GetDashGrid(exercise_reportBO objEnt)
        {
            return objDAL.GetDashGrid_DAL(objEnt);
        }

        public DataSet GetReportData(string Squery)
        {
            return objDAL.GetReportData(Squery);
        }

    }
}
