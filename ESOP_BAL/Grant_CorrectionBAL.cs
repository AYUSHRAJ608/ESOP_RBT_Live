using ESOP;
using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class Grant_CorrectionBAL
    {
        Grant_CorrectionBO objBO = new Grant_CorrectionBO();
        Grant_CorrectionDAL objDAL = new Grant_CorrectionDAL();
        public DataSet Get_correction_records()
        {
            return objDAL.Get_correction_records();
        }

        public bool UpdateGrantcorrection(Grant_CorrectionBO objBO)
        {
            return objDAL.UpdateGrantcorrection(objBO);
        }
        public void DeleteGrantcorrection(Grant_CorrectionBO objBO)
        {
            objDAL.DeleteGrantcorrection(objBO);
        }
        public DataSet GET_GRANT_CORRECTION_AUDIT(Grant_CorrectionBO objBO)
        {
            return objDAL.GET_GRANT_CORRECTION_AUDIT(objBO);
        }
    }
}
