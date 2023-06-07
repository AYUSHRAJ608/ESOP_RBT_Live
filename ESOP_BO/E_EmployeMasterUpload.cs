using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
public class E_EmployeMasterUpload
{
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

        public string ErrorString { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public bool firstEntry { get; set; }
        public string RecStatus { get; set; }
        public string Nt_ID { get; set; }
        //Added by Bhushan on 16-12-2021 for PAN card update
        public string PanNumber { get; set; }
        //End
    }
}