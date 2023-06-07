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
    public class vesting_approvalBAL
    {
        vesting_approvalDAL objDAL = new vesting_approvalDAL();
        public DataSet GET_ADMIN_VESTING_FOR_APPROVAL()
        {
            return objDAL.GET_ADMIN_VESTING_FOR_APPROVAL();
        }
        public DataSet GET_ADMIN_VESTING_FOR_APPROVAL_COUNT()
        {
            return objDAL.GET_ADMIN_VESTING_FOR_APPROVAL_COUNT();
        }
        public bool UPDATE_ADMIN_VESTING_APPROVAL(vesting_approvalBO ValBo)
        {
            return objDAL.UPDATE_ADMIN_VESTING_APPROVAL(ValBo);
        }
        public DataSet GET_PRESIDENT_VESTING_FOR_APPROVAL(vesting_approvalBO objBO)
        {
            return objDAL.GET_PRESIDENT_VESTING_FOR_APPROVAL(objBO);
        }
        public DataSet GET_PRESIDENT_VESTING_FOR_APPROVAL_COUNT(PresedentApprovalBO objBO)
        {
            return objDAL.GET_PRESIDENT_VESTING_FOR_APPROVAL_COUNT(objBO);
        }
        public bool UPDATE_PRESIDENT_VESTING_APPROVAL(vesting_approvalBO ValBo)
        {
            return objDAL.UPDATE_PRESIDENT_VESTING_APPROVAL(ValBo);
        }
        public DataSet GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER(exercise_reportBO objhrbo)
        {
            return objDAL.GET_PRESIDENT_VESTING_FOR_APPROVAL_FILTER(objhrbo);
        }

        public DataSet GET_VESTING_AUDIT(vesting_approvalBO ValBo, string Vest_Cycle_Name)
        {
            return objDAL.GET_VESTING_AUDIT(ValBo, Vest_Cycle_Name);
        }
    }
}
