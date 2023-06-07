using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ESOP_BAL;

namespace ESOP
{
    public partial class EmailLinkApp_Reject : System.Web.UI.Page
    {
        EmailLinkApp_RejectBAL objbal = new EmailLinkApp_RejectBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int GrantID = 0;
                string Status = "";
                string GrantName = "";
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["GrantID"]))
                    {
                        GrantID = Convert.ToInt16(Request.QueryString["GrantID"]);
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["GrantName"]))
                    {
                        GrantName = Request.QueryString["GrantName"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["Status"]))
                    {
                        Status = Request.QueryString["Status"].ToString();
                        FuncApprov_Reject_Status(GrantID, Status, GrantName);
                    }
                }
            }
        }

        public void FuncApprov_Reject_Status(int GrantID, string Status, string GrantName)
        {
            try
            {
                bool retVal = objbal.Update_Status(GrantID, Status, GrantName);
                if (retVal == true)
                {

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

    }
}
