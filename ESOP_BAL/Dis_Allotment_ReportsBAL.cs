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
    public class Dis_Allotment_ReportsBAL
    {
        Dis_Allotment_ReportsDAL objDisDAL = new Dis_Allotment_ReportsDAL();
        public DataSet GET_ADMIN_SALE_REPORT(Dis_Allotment_ReportsBO objDisBO)
        {
            return objDisDAL.GET_ADMIN_SALE_REPORT(objDisBO);
        }
        public DataSet GET_EMPLOYEE_SALE_REPORT(Dis_Allotment_ReportsBO objDisBO)
        {
            return objDisDAL.GET_EMPLOYEE_SALE_REPORT(objDisBO);
        }
        public DataSet ESOP_GET_ADMIN_SALE_report_COUNT()
        {
            return objDisDAL.ESOP_GET_ADMIN_SALE_report_COUNT();
        }
    }
}
