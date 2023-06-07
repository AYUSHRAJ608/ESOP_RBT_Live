using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ESOP_BO
{
    public class EMailBO
    {
        public string EmailTemPath { get; set; }

        public string Attachment { get; set; }
        public string userName { get; set; }
        public string title { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string EmailID { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CaseType { get; set; }
        public string FullName { get; set; }
        public string CCEmailID { get; set; }
        public string Action { get; set; }
        public string FileName { get; set; }

        public string fileUpload { get; set; }

        public string Status1 { get; set; }

        public string FMV_Price { get; set; }


        //-----------------------------------
        public String Em_Sub { get; set; }
        public String Em_ID { get; set; }

        public String Em_Body { get; set; }
        public String Em_Type { get; set; }
        public String Em_Sub_Type { get; set; }
        public String Em_Type_ID { get; set; }
        public String Em_CC_ID { get; set; }
        public String Em_BCC_ID { get; set; }
        public String EM_From_ID { get; set; }
        public String EM_CretaedBy { get; set; }
        public String Em_Action { get; set; }
        public String Em_Status { get; set; }
        //public String Em_GFile { get; set; }

    }
    public class cEmailEntityRequest
    {
        public EMailBO EmailEntity { get; set; }

    }

}

