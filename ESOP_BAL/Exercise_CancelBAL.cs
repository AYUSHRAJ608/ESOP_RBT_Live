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
    public class Exercise_CancelBAL
    {
        Exercise_CancelDAL objDAL = new Exercise_CancelDAL();
        public DataSet GET_Employee_Exercise_Cancel()
        {
            return objDAL.GET_Employee_Exercise_Cancel();
        }

        public bool Update_Revert(Exercise_BtnRevertBO objBO)
        {
            return objDAL.Update_Revert(objBO);
        }

        public DataSet GET_Employee_Exercise_Reverted()
        {
            return objDAL.GET_Employee_Exercise_Reverted();
        }
    }
}
