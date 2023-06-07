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
    public class TaxBAL
    {
        TaxBO objbo = new TaxBO();
        TaxDAL objdal = new TaxDAL();
        public DataSet gettaxdata(TaxBO objBo)
        {
            return objdal.gettaxdata(objBo);
        }

        //Added by Krutika on 02-01-23
        public DataSet getTaxRegimedata(TaxBO objBo)
        {
            return objdal.getTaxRegimedata(objBo);
        }
        //End

        public DataSet bind_Year_Grid(TaxBO objBo)
        {
            return objdal.bind_Year_Grid(objBo);
        }
        public DataSet GET_F_YEAR_TAX_DATA(TaxBO objbo)    //public string GET_F_YEAR_TAX_DATA(TaxBO objbo)
        {
            return objdal.GET_F_YEAR_TAX_DATA(objbo);
        }
        public DataSet Fill_Financial_Year()
        {
            return objdal.Fill_Financial_Year();
        }
        public DataSet Fill_Financial_Year_DDL()
        {
            return objdal.Fill_Financial_Year_DDL();
        }
        public bool Insert_tax(TaxBO objbo)
        {
            return objdal.Insert_tax(objbo);
        }
        public string Insert_Financial_Year(TaxBO objbo)
        {
            return objdal.Insert_Financial_Year(objbo);
        }       
        public bool taxDelete(TaxBO objbo)
        {
            return objdal.taxDelete(objbo);
        }
        public DataSet taxcount()
        {
            return objdal.taxcount();
        }
    }
}
