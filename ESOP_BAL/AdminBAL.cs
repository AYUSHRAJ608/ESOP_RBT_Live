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
    public class AdminBAL
    {
        AdminBO AdminBO = new AdminBO();
        AdminDAL AdminDAL = new AdminDAL();
        public DataSet FunGetApprovalRecords()
        {
            return AdminDAL.FunGetApprovalRecords();
        }

        public bool UpdateGrant(AdminBO objbo)
        {
            return AdminDAL.UpdateGrant(objbo);
        }
        public void DeleteGrant(AdminBO objbo)
        {
            AdminDAL.GrantDelete(objbo);
        }

        public DataSet ESOP_GET_ADMIN_GRANT_UPDATION_COUNT()
        {
            return AdminDAL.ESOP_GET_ADMIN_GRANT_UPDATION_COUNT();
        }
    }
}
