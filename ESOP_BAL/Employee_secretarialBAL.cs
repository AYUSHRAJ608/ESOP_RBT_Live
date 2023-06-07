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
    public class Employee_secretarialBAL
    {
        Employee_SecretarialBO objBO = new Employee_SecretarialBO();
        Employee_secretarialDAL objDAL = new Employee_secretarialDAL();
        public DataSet GET_Employee_Secretarial_Main_Data(string id)
        {
            return objDAL.ESOP_GET_EMPLOYEE_SECRETARIAL_DATA(id);
        }
        public bool update_status(Employee_SecretarialBO objBO)
        {
            return objDAL.update_status(objBO);
        }
        public DataSet GET_Employee_Secretarial_Main_Grid()
        {
            return objDAL.GET_Employee_Secretarial_Main_Grid();
        }
        public DataSet GET_Employee_Secretarial_Approve_Reject_Data()
        {
            return objDAL.ESOP_GET_EMPLOYEE_SECRETARIAL_Approvr_Reject();
        }
        public DataSet GET_EMPLOYEE_SECRETARIAL_DownloadLink(double id)
        {
            return objDAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);
        }

        public DataSet USP_GET_EMP_DETAILS_for_sell(EMailBO objEntity)
        {
            return objDAL.USP_GET_EMP_DETAILS_for_sell(objEntity);
        }
    }
}
