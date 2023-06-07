using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class TaxBO
    {
        public int ID { get; set; }
        public string INCOME_RANGE_FROM { get; set; }
        public string YEAR { get; set; }
        public string ACTION { get; set; }
        public string FINANCIAL_YEAR { get; set; }
        public string INCOME_RANGE_TO { get; set; }
        public string TAX_RATE { get; set; }

        //Added by Krutika on 02-01-23
        public string TAX_REGIME { get; set; }
        //End

        public DateTime CREATEDDATE { get; set; }
        public DateTime MODIFIEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public string ISDELETED { get; set; }

        public string ISACTIVE { get; set; }


    }
}
