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
    public class EmployeeBAL
    {
        EmployeeDAL objVestingDAL = new EmployeeDAL();
        EmployeeBO objEmployeeBO = new EmployeeBO();
        
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING(EmployeeBO objEmployeeBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING(objEmployeeBO);
        }
        public DataSet GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(EmployeeBO objEmployeeBO)
        {
            return objVestingDAL.GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(objEmployeeBO);
        }

        public DataSet GET_Distinct_VestID(EmployeeBO objEmployeeBO)
        {
            return objVestingDAL.GET_Distinct_VestID(objEmployeeBO);
        }

        //--------------------------------------------------
        EmployeeDAL objEmpDAL = new EmployeeDAL();
        public DataSet getEmp(String ecode, String Action)
        {
            return objEmpDAL.getEmp(ecode, Action);
        }
        //public int InsertEmp(EmployeeBO ObjBo)
        //{
        //    return objEmpDAL.InserEmp(ObjBo);
        //}
        public DataSet InsertEmp(EmployeeBO ObjBo)
        {
            return objEmpDAL.InserEmp(ObjBo);
        }
    }
}
