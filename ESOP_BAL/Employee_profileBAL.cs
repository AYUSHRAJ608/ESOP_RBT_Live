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
    public class Employee_profileBAL
    {
        Employee_profileBO objbo = new Employee_profileBO();
        Employee_profileDAL objdal = new Employee_profileDAL();
        public DataSet get_empbank_detail(Employee_profileBO objbo)
        {
            return objdal.get_empbank_detail(objbo);
        }
        public DataSet CHECK_activeinactive_status(Employee_profileBO objbo)
        {
            return objdal.CHECK_activeinactive_status(objbo);
        }

        public bool Insert_Emp_bankDetail(Employee_profileBO objbo)
        {
            return objdal.Insert_Emp_bankDetail(objbo);
        }

        public bool Insert_Emp_DmatDetail(Employee_profileBO objbo)
        {
            return objdal.Insert_Emp_DmatDetail(objbo);
        }
        public void Update_Emp_Active_Status(Employee_profileBO objbo)
        {
            objdal.Update_Emp_Active_Status(objbo);
        }


        public void Update_Emp_Dmat_Active_Status(Employee_profileBO objbo)
        {
            objdal.Update_Emp_Dmat_Active_Status(objbo);
        }

        public void Update_Emp_Profile_Status(Employee_profileBO objbo)
        {
            objdal.Update_Emp_Profile_Status(objbo);
        }

        public DataSet GET_LAPS_EMP_STOCK_MAPPING(Employee_profileBO objbo)
        {
            return objdal.GET_LAPS_EMP_STOCK(objbo);
        }
    }
}
