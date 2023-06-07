using ESOP_BAL;
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
    public class Secretarial_grant_approvalBAL
    {
        Secretarial_grant_approvalBO objSecbo = new Secretarial_grant_approvalBO();
        Secretarial_grant_approvalDAL SecDAL = new Secretarial_grant_approvalDAL();
        public DataSet get_secretarial_appraval_data(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.get_secretarial_appraval_data(objSecbo);
        }
        public DataSet get_hr_appraval_date_wise(exercise_reportBO objSecbo)
        {
            return SecDAL.get_hr_appraval_date_wise(objSecbo);
        }
        public DataSet get_secretarial_all_count(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.get_secretarial_all_count(objSecbo);
        }

        public bool update_status(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.update_status(objSecbo);
        }
        public bool update_status1(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.update_status1(objSecbo);
        }
        public bool update_status2(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.update_status2(objSecbo);
        }

        public bool update_status_Checker(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.update_status_Checker(objSecbo);
        }
        public bool update_rejected_status(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.update_rejected_status(objSecbo);
        }

        public DataSet get_checker_appraval_date(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.get_checker_appraval_date(objSecbo);
        }
        public DataSet get_chcker_all_count(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.get_checker_all_count(objSecbo);
        }
        public bool update_rejected_status_Checker(Secretarial_grant_approvalBO objSecbo)
        {
            return SecDAL.update_rejected_status_Checker(objSecbo);
        }

    }
}

