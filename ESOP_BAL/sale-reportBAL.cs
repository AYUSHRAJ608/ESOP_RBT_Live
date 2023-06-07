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
    public class sale_reportBAL
    {
        sale_reportDAL objDAL = new sale_reportDAL();
        public DataSet GET_ADMIN_SALE_REPORT(sale_reportBO objBO)
        {
            return objDAL.GET_ADMIN_SALE_REPORT(objBO);
        }
        public DataSet GET_EMPLOYEE_SALE_REPORT(sale_reportBO objBO)
        {
            return objDAL.GET_EMPLOYEE_SALE_REPORT(objBO);
        }
        public DataSet ESOP_GET_ADMIN_SALE_report_COUNT()
        {
            return objDAL.ESOP_GET_ADMIN_SALE_report_COUNT();
        }

        
    }
}
