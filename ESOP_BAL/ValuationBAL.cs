
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
    public class ValuationBAL
    {
        ValuationBO objbo = new ValuationBO();
        ValuationDAL ValuationDAL = new ValuationDAL();
        public DataSet getAgency(ValuationBO objbo)
        {
            return ValuationDAL.getAgency(objbo);
        }

        public DataSet ESOP_GET_SRCH_FILTER(ValuationBO objbo)
        {
            return ValuationDAL.ESOP_GET_SRCH_FILTER(objbo);
        }

        public string Insert_Valuation(ValuationBO objbo)
        {
            return ValuationDAL.Insert_Valuation(objbo);
        }



        public string valuationDelete(ValuationBO objbo)
        {
            return ValuationDAL.valuationDelete(objbo);
        }

        public DataSet ESOP_GET_VALUATION_ALL_COUNT()
        {
            return ValuationDAL.ESOP_GET_VALUATION_ALL_COUNT();
        }
        public DataSet Insert_PDF_Password(ValuationBO objbo)
        {
            return ValuationDAL.Insert_PDF_Password(objbo);
        }
        public DataSet Insert_Yrs_Lapse(ValuationBO objbo)
        {
            return ValuationDAL.Insert_Yrs_Lapse(objbo);
        }

        public DataSet GET_AUDIT()
        {
            return ValuationDAL.ESOP_AUDIT();
        }
        public DataSet GET_Yrs_lapsedata()
        {
            return ValuationDAL.GET_Yrs_lapsedata();
        }
        public DataSet GET_DROPDOWN()
        {
            return ValuationDAL.GET_DROPDOWN();
        }
    }
}
