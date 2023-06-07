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
    public class HrapprovalBAL
    {
        HrapprovalBO objhrbo = new HrapprovalBO();
        HrapprovalDAL HRVDAL = new HrapprovalDAL();
        public DataSet get_hr_appraval_date(HrapprovalBO objhrbo)
        {
            return HRVDAL.get_hr_appraval_date(objhrbo);
        }
        public DataSet get_hr_appraval_date_wise(exercise_reportBO objhrbo)
        {
            return HRVDAL.get_hr_appraval_date_wise(objhrbo);
        }
        public DataSet get_hr_all_count(HrapprovalBO objhrbo)
        {
            return HRVDAL.get_hr_all_count(objhrbo);
        }

        public bool update_status(HrapprovalBO objhrbo)
        {
            return HRVDAL.update_status(objhrbo);
        }
        public bool update_status1(HrapprovalBO objhrbo)
        {
            return HRVDAL.update_status1(objhrbo);
        }
        public bool update_status2(HrapprovalBO objhrbo)
        {
            return HRVDAL.update_status2(objhrbo);
        }

        public bool update_status_Checker(HrapprovalBO objhrbo)
        {
            return HRVDAL.update_status_Checker(objhrbo);
        }
        public bool update_rejected_status(HrapprovalBO objhrbo)
        {
            return HRVDAL.update_rejected_status(objhrbo);
        }

        public DataSet get_checker_appraval_date(HrapprovalBO objhrbo)
        {
            return HRVDAL.get_checker_appraval_date(objhrbo);
        }
        public DataSet get_chcker_all_count(HrapprovalBO objhrbo)
        {
            return HRVDAL.get_checker_all_count(objhrbo);
        }
        public bool update_rejected_status_Checker(HrapprovalBO objhrbo)
        {
            return HRVDAL.update_rejected_status_Checker(objhrbo);
        }
        public DataSet get_chcker_all_count_Lapse(HrapprovalBO objhrbo)
        {
            return HRVDAL.get_chcker_all_count_Lapse(objhrbo);
        }
        public DataSet get_checker_approval_date_lapse(HrapprovalBO objhrbo)
        {
            return HRVDAL.get_checker_approval_date_lapse(objhrbo);
        }
    }
}
