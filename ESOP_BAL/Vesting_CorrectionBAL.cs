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
  public  class Vesting_CorrectionBAL
    {
        Vesting_CorrectionBO objBO = new Vesting_CorrectionBO();
        Vesting_CorrectionDAL objDAL = new Vesting_CorrectionDAL();
        public DataSet Get_vesting_correction_records()
        {
            return objDAL.Get_vesting_correction_records();
        }

        public bool UpdateVestingcorrection(Vesting_CorrectionBO objBO)
        {
            return objDAL.UpdateVestingcorrection(objBO);
        }
        public void DeleteVestingcorrection(Vesting_CorrectionBO objBO)
        {
            objDAL.DeleteVestingcorrection(objBO);
        }
    }
}
