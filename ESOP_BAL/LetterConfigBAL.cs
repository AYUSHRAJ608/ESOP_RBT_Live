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
    public class LetterConfigBAL
    {
        LetterConfigBO objbo = new LetterConfigBO();
        LetterConfigDAL LetterConfigDAL = new LetterConfigDAL();
        public DataSet FunGetLetterConfig()
        {
            return LetterConfigDAL.FunGetLetterConfig();
        }


        public bool Update_Status(LetterConfigBO objbo)
        {
            return LetterConfigDAL.UpdateStatus(objbo);
        }

        public DataSet report(LetterConfigBO objbo)
        {
            return LetterConfigDAL.report(objbo);
        }

        public DataSet GetReportDesign(LetterConfigBO objbo)
        {
            return LetterConfigDAL.GetReportDesign(objbo);
        }

        public void valuationDelete(LetterConfigBO objbo)
        {
            //ValuationDAL.valuationDelete(objbo);
        }

        public DataSet ESOP_GET_LETTER_CONFIGURATION_COUNT()
        {
            return LetterConfigDAL.ESOP_GET_LETTER_CONFIGURATION_COUNT();
        }
    }
}
