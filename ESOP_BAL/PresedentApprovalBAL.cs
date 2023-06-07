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
    public class PresedentApprovalBAL
    {
        PresedentApprovalBO objbo = new PresedentApprovalBO();

        PresedentApprovalDAL PresedentApprovalDAL = new PresedentApprovalDAL();
        public DataSet FunGetApprovalRecords(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.FunGetApprovalRecords(objbo);
        }

        public DataSet FunGetApprovalRecords_Filter(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.FunGetApprovalRecords_Filter(objbo);
        }
       
        public DataSet GET_EMPLOYEE_GRANT_REPORT(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.GET_EMPLOYEE_GRANT_REPORT(objbo);
        }
        public DataSet Get_President_all_count(PresidentBO PresidentBO)
        {
            return PresedentApprovalDAL.Get_President_all_count(PresidentBO);
        }

        public bool Update_Status(PresedentApprovalBO objbo)
        {
           return PresedentApprovalDAL.UpdateStatus(objbo);
        }

        public DataSet GetEmpDetails_AdminPswd(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.GetEmpDetails_AdminPswd(objbo);
        }

        public DataSet GetLetterPath(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.GetLetterPath(objbo);
        }

        public DataSet GetReportDesign(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.GetReportDesign(objbo);
        }

        public void valuationDelete(PresedentApprovalBO objbo)
        {
            //ValuationDAL.valuationDelete(objbo);
        }
        public DataSet GetLetterPathCancel(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.GetLetterPathCancel(objbo);
        }
        public DataSet ESOP_QUARTERLY_REPORT(exercise_reportBO objhrbo)
        {
            return PresedentApprovalDAL.ESOP_QUARTERLY_REPORT(objhrbo);
        }
        public DataSet GET_ALL_EMPLOYEE_DETAIL_REPORT(PresedentApprovalBO objbo)
        {
            return PresedentApprovalDAL.GET_ALL_EMPLOYEE_DETAIL_REPORT(objbo);
        }
    }
}
