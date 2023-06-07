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
    public class Grant_ReportBAL
    {
        Grant_ReportDAL objDAL = new Grant_ReportDAL();

        public DataSet GET_EMPLOYEE_GRANT_REPORT(Grant_ReportBO objBO)
        {
            return objDAL.GET_EMPLOYEE_GRANT_REPORT(objBO);
        }
    }
}
