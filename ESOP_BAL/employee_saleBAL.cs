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
    public class employee_saleBAL
    {
        employee_saleDAL objDAL = new employee_saleDAL();
        public DataSet GET_EMP_SALE_DATA(employee_saleBO objBO)
        {
            return objDAL.GET_EMP_SALE_DATA(objBO);
        }
        public DataSet GET_EMPLOYEE_SELL_DATA1(employee_saleBO objBO)
        {
            return objDAL.GET_EMPLOYEE_SELL_DATA1(objBO);
        }
        public DataSet InsertEmployeeSaleRec(employee_saleBO objbo)
        {
            return objDAL.InsertEmployeeSaleRec(objbo);
        }


        public DataSet GET_EMP_data(employee_saleBO objBO)
        {
            return objDAL.GET_EMP_data(objBO);
        }
        public int INSERT_EMPLOYEE_SALE_TRANSACTION(employee_saleBO objBO)
        {
            return objDAL.INSERT_EMPLOYEE_SALE_TRANSACTION(objBO);
        }
        public int INSERT_SALE_TRANSACTION_RECEIPT_FILE_PATH(employee_saleBO objBO)
        {
            return objDAL.INSERT_SALE_TRANSACTION_RECEIPT_FILE_PATH(objBO);
        }

        public int INSERT_EMPLOYEE_SALE_TRANSACTION_SESSION(employee_saleBO objBO)
        {
            return objDAL.INSERT_EMPLOYEE_SALE_TRANSACTION_SESSION(objBO);
        }
        public void UPDATE_EMPLOYEE_SALE(employee_saleBO objBO)
        {
            objDAL.UPDATE_EMPLOYEE_SALE(objBO);
        }
        public void INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS(employee_saleBO objBO)
        {
            objDAL.INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS(objBO);
        }

        public void INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS_SESSION(employee_saleBO objBO)
        {
            objDAL.INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS_SESSION(objBO);
        }
        public DataSet GET_EMPLOYEE_SELL_DATA(employee_saleBO objBO)
        {
            return objDAL.GET_EMPLOYEE_SELL_DATA(objBO);
        }

        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA(string ID)
        {
            return objDAL.GET_EMPLOYEE_SELL_DETAILS_DATA(ID);
        }
        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA1(string ID)
        {
            return objDAL.GET_EMPLOYEE_SELL_DETAILS_DATA1(ID);
        }
        public bool update_status(employee_saleBO objBO)
        {
            return objDAL.update_status(objBO);
        }
        public bool update_status1(employee_saleBO objBO)
        {
            return objDAL.update_status1(objBO);
        }
        public bool update_status2(employee_saleBO objBO)
        {
            return objDAL.update_status2(objBO);
        }
        public DataSet GET_SALE_WINDOW()
        {
            return objDAL.GET_SALE_WINDOW();


        }

        public DataSet GET_EMPLOYEE_SELL_DATA_Count(employee_saleBO objBO)
        {
            return objDAL.GET_EMPLOYEE_SELL_DATA_Count(objBO);
        }

        public DataSet USP_GET_EMP_DETAILS_for_sell(EMailBO objEntity)
        {
            return objDAL.USP_GET_EMP_DETAILS_for_sell(objEntity);
        }

        public DataSet GetSalesActiveLetter()
        {
            return objDAL.GetSalesActiveLetter();
        }

        public DataSet GET_SESSION(employee_saleBO objBO)
        {
            return objDAL.GET_SESSION(objBO);
        }
        public DataSet GET_DATA(employee_saleBO objBO)
        {
            return objDAL.GET_SESSION(objBO);
        }

        public DataSet GET_EMP_SALE_DOC(employee_saleBO objBO)
        {
            return objDAL.GET_EMP_SALE_DOC(objBO);
        }
        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA_2(string ID)
        {
            return objDAL.GET_EMPLOYEE_SELL_DETAILS_DATA_2(ID);
        }
        public DataSet GET_EMPLOYEE_SELL_DATA_1(employee_saleBO objBO)
        {
            return objDAL.GET_EMPLOYEE_SELL_DATA_1(objBO);
        }
        public DataSet GET_EMPLOYEE_SELL_DETAILS_DATA_1(string ID)
        {
            return objDAL.GET_EMPLOYEE_SELL_DETAILS_DATA_1(ID);
        }
        public DataSet GET_EMP_SALE_DOC_1(employee_saleBO objBO)
        {
            return objDAL.GET_EMP_SALE_DOC_1(objBO);
        }
    }
}
