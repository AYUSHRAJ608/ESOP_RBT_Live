using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class HRMSIntegrationBO
    {
        public string ECODE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string GENDER { get; set; }
        public string EMP_STATUS { get; set; }
        public string LWD { get; set; }
        public string TNTR { get; set; }
        public string EMP_NAME { get; set; }
        public string DESIGNATION { get; set; }
        public string BANDS { get; set; }
        public string DOJ { get; set; }
        public string LOCATION { get; set; }
        public string DEPARTMENT { get; set; }
        public string FUNCTION { get; set; }
        public string COST_CENTRE { get; set; }
        public string APP_CODE { get; set; }
        public string APPRAISER_NAME { get; set; }
        public string APP_BAND { get; set; }
        public string REV_CODE { get; set; }
        public string REVIEWER_NAME { get; set; }
        public string REV_BAND { get; set; }
        public string HOD_CODE { get; set; }
        public string HOD_NAME { get; set; }
        public string HOD_BAND { get; set; }
        public string BH_CODE { get; set; }
        public string BH_NAME { get; set; }
        public string INTERNAL { get; set; }
        public string EXTERNAL { get; set; }
        public string TOTAL { get; set; }
        public string MAT_MGR_CODE { get; set; }
        public string MAT_MGR_NAME { get; set; }
        public string MAT_REV_CODE { get; set; }
        public string MAT_REV_NAME { get; set; }
        public string Status { get; set; }
        public string EmpStatus { get; set; }
        public class cEmployeeEntityRequest
        {
            public HRMSIntegrationBO EmpEntity { get; set; }
        }
        public class cEmployeeEntityResponse
        {
            public HRMSIntegrationBO EmpEntity { get; set; }
            //public List<cUserEntity> InsertMaster { get; set; }
            public List<HRMSIntegrationBO> lstcEmpEntity = new List<HRMSIntegrationBO>();
        }
    }
}
