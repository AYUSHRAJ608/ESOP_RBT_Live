using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class GrandCreationBO
    {
        public string GRANT_ID { get; set; }
        public string GRANT_NAME { get; set; }
        public DateTime DATE_OF_GRANT { get; set; }
        public string EMP_ID { get; set; }
        public int FMV_ID { get; set; }
        public int VESTING_ID { get; set; }
        public int NO_OF_OPTION { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public string IS_VISIBLE { get; set; }
        public string REMARK1 { get; set; }
        public string REMARK2 { get; set; }
        public string ErrorString { get; set; }
        public string RecStatus { get; set; }
        public int Role_ID { get; set; }
        public string TAX_REGIME { get; set; }

        //--------------------------------
        public string LAPSE_MONTH { get; set; }
        public string Ecode { get; set; }
        public string Company_name { get; set; }
        public string Gender { get; set; }
        public string Emp_status { get; set; }
        public string Lwd { get; set; }
        public string Tntr { get; set; }
        public string Emp_name { get; set; }
        public string Designation { get; set; }
        public string Bands { get; set; }
        public string Doj { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Function { get; set; }
        public string Cost_centre { get; set; }
        public string App_code { get; set; }
        public string Appraiser_name { get; set; }
        public string App_band { get; set; }
        public string Rev_code { get; set; }
        public string Reviewer_name { get; set; }
        public string Rev_band { get; set; }
        public string Hod_code { get; set; }
        public string Hod_name { get; set; }
        public string Hod_band { get; set; }
        public string Bh_code { get; set; }
        public string Bh_name { get; set; }
        public string Internal { get; set; }
        public string External { get; set; }
        public string Total { get; set; }

        public string EmpUpload_ID { get; set; }
        public string excelDoucmentName { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public bool firstEntry { get; set; }

        public string Nt_ID { get; set; }
        //-------------------------------------
        public string No_Of_Option_Excel { get; set; }
        public decimal Taxable_Income { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public string Key { get; set; }

        public decimal FMV_PRICE { get; set; }
        public Int32 SaleID { get; set; }

        public Int32 ExercisedID { get; set; }
        public string Year_of_Lapse { get; set; }
        public string AGENCY_NAME { get; set; }
    }
}
