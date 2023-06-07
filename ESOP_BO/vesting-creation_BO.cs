using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class vesting_creation_BO
    {
        public int ID { get; set; }
        public int YEAR { get; set; }
        public string YEAR_DESC { get; set; }
        public int VID { get; set; }

        public string VNAME { get; set; }
        public int VCYCLE { get; set; }
        public string VCYCLENAME { get; set; }
        public int PERCENTAGE { get; set; }
        public int DURATION { get; set; }
        public string GRANT_NAME { get; set; }

        public string CREATEDBY { get; set; }
        public string ISACTIVE { get; set; }
        public string MODIFIEDBY { get; set; }

        //--------------------------------

        public string ECODE { get; set; }
        public string ENAME { get; set; }
        public string _GRANT_NAME { get; set; }

        public string VESTING_NAME { get; set; }
        public string VESTING_DETAIL_CODE { get; set; }
        public string VESTING_DATE { get; set; }
        public double NO_OF_VESTING { get; set; }
        public string ADMIN_VESTING_REMARK { get; set; }
        public string PR_VESTING_REMARK { get; set; }
        public string Status { get; set; }

        public double EXERCISE_FMV_PRICE { get; set; }
        public string EXERCISE_DATE { get; set; }
        public string EXERCISE_APPRV_DATE { get; set; }
        public double NO_OF_EXERCISE { get; set; }
        public string EXERCISE_BY { get; set; }
        public string EXERCISE_STATUS { get; set; }
        public double TAXABLE_INCOME { get; set; }


        public double _SALE_FMV_PRICE { get; set; }
        public double _NO_OF_SALE { get; set; }
        public string _SALE_DATE { get; set; }
        public string SALE_APPRV_DATE { get; set; }
        public string SALE_BY { get; set; }
        public string SALE_STATUS { get; set; }

        public double LBV { get; set; }
        public double LAV { get; set; }
        public double TOTAL_LAPSED { get; set; }
        public string ErrorString { get; set; }
        public string RecStatus { get; set; }
        public int LAPSE_MONTH { get; set; }



    }
}
