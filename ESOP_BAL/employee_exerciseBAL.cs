
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_BO;
using ESOP_DAL;
using System.Data;

namespace ESOP_BAL
{
    public class employee_exerciseBAL
    {
        employee_exerciseDAL objDAL = new employee_exerciseDAL();
        public DataSet GET_EMP_EXERCISE_DATA(employee_exerciseBO objBO)
        {
            return objDAL.GET_EMP_EXERCISE_DATA(objBO);
        }
        public DataSet GET_EMP_BANK_DETAILS(employee_exerciseBO objBO)
        {
            return objDAL.GET_EMP_BANK_DETAILS(objBO);
        }
        public DataSet GET_EMP_DEMAT_DETAILS(employee_exerciseBO objBO)
        {
            return objDAL.GET_EMP_DEMAT_DETAILS(objBO);
        }

        public DataSet GetDematDetails(employee_exerciseBO objBO)
        {
            return objDAL.GetDematDetails(objBO);
        }
        public int INSERT_EMPLOYEE_EXERCISE_TRANSACTION(employee_exerciseBO objBO)
        {
            return objDAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION(objBO);
        }
        public int UPDATE_EMPLOYEE_EXERCISE_TRANSACTION(employee_exerciseBO objBO)
        {
            return objDAL.UPDATE_EMPLOYEE_EXERCISE_TRANSACTION(objBO);
        }
        public void UPDATE_EMPLOYEE_EXERCISE(employee_exerciseBO objBO)
        {
            objDAL.UPDATE_EMPLOYEE_EXERCISE(objBO);
        }
        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(employee_exerciseBO objBO)
        {
            objDAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(objBO);
        }
        public void UPDATE_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(employee_exerciseBO objBO)
        {
            objDAL.UPDATE_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS(objBO);
        }
        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_NEW(employee_exerciseBO objBO)
        {
            objDAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_NEW(objBO);
        }
        public DataSet GET_ECERCISE_WINDOW()
        {
            return objDAL.GET_ECERCISE_WINDOW();
        }
        public int INSERT_EMPLOYEE_EXERCISE_TRANSACTION_SESSION(employee_exerciseBO objBO)
        {
            return objDAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_SESSION(objBO);
        }
        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION(employee_exerciseBO objBO)
        {
            objDAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION(objBO);
        }

        public void INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION_NEW(employee_exerciseBO objBO)
        {
            objDAL.INSERT_EMPLOYEE_EXERCISE_TRANSACTION_DETAILS_SESSION_NEW(objBO);
        }

        public DataSet GET_SESSION(employee_exerciseBO objBO)
        {
            return objDAL.GET_SESSION(objBO);
        }

        public DataSet InsertEmployeeExerRec(employee_exerciseBO objBO)
        {
            return objDAL.InsertEmployeeExerRec(objBO);
        }
        public DataSet GET_EMPLOYEE_EXERCISE_DATA(employee_exerciseBO objBO)
        {
            return objDAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
        }
        public bool update_status(employee_exerciseBO objBO)
        {
            return objDAL.update_status(objBO);
        }
        public bool update_status_1(employee_exerciseBO objBO)
        {
            return objDAL.update_status_1(objBO);
        }
        public DataSet GET_Employee_Admin_Main_Grid()
        {
            return objDAL.GET_Employee_Admin_Main_Grid();
        }
        public DataSet GET_Employee_Admin_Main_Data(string id)
        {
            return objDAL.ESOP_GET_EMPLOYEE_ADMIN_DATA(id);
        }
        public DataSet GET_Employee_Admin_Main_Grid_1()
        {
            return objDAL.GET_Employee_Admin_Main_Grid_1();
        }
        public DataSet GET_Employee_Admin_Main_Grid_NEW()
        {
            return objDAL.GET_Employee_Admin_Main_Grid_NEW();
        }
        public DataSet GET_Employee_Admin_Main_Data_1(string id)
        {
            return objDAL.ESOP_GET_EMPLOYEE_ADMIN_DATA_1(id);
        }
        public DataSet GET_Employee_Admin_Main_Data_2(string id)
        {
            return objDAL.ESOP_GET_EMPLOYEE_ADMIN_DATA_2(id);
        }
        public DataSet GET_Employee_Admin_Main_Data_4(/*string id*/employee_exerciseBO objBO)
        {
            return objDAL.ESOP_GET_EMPLOYEE_ADMIN_DATA_4(objBO);
        }
        public DataSet EMPLOYEE_DETAIL_APPROVAL_DATA()
        {
            return objDAL.EMPLOYEE_DETAIL_APPROVAL_DATA();
        }

        public DataSet GET_EMPLOYEE_SECRETARIAL_DownloadLink(double id)
        {
            return objDAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);
        }
        public DataSet GET_EMPLOYEE_EXERCISE_DATA_NEW(employee_exerciseBO objBO)
        {
            return objDAL.GET_EMPLOYEE_EXERCISE_DATA_NEW(objBO);
        }

        public DataSet GET_Employee_Admin_Main_Grid_2()
        {
            return objDAL.GET_Employee_Admin_Main_Grid_2();
        }

        public DataSet GET_Employee_Admin_Main_Data_NEW(string id)
        {
            return objDAL.ESOP_GET_EMPLOYEE_ADMIN_DATA_NEW(id);
        }

        public DataSet GET_Employee_Exercise_Data_NEW(string id)
        {
            return objDAL.ESOP_GET_Employee_Exercise_Data_NEW(id);
        }

        public DataSet GET_CHECKER_COUNT()
        {
            return objDAL.GET_CHECKER_COUNT(); 
        }
    }
}
