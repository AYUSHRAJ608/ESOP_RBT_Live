using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using System.Data;
using ESOP_BO;


namespace ESOP
{
    public partial class approval : System.Web.UI.Page
    {
        PresedentApprovalBAL objbal = new PresedentApprovalBAL();
        vesting_approvalBAL objBAL = new vesting_approvalBAL();
        PresedentApprovalBO objbo = new PresedentApprovalBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            FMVCreationBAL FMVBAL = new FMVCreationBAL();
            vesting_creation_BAL vestbal = new vesting_creation_BAL();

            objbo.EMPCODE = Convert.ToString(Session["ECODE"]);
            DataSet ds1 = objBAL.GET_PRESIDENT_VESTING_FOR_APPROVAL_COUNT(objbo);
            if (ds1.Tables.Count > 0)
            {
                //lbltotal_grant.Text = ds.Tables[0].Rows[0][0].ToString();
                //grantapproval.InnerText = ds1.Tables[2].Rows[0][0].ToString();
                //lbl_rejected.Text = ds.Tables[3].Rows[0][0].ToString();
                vestingapproval.InnerText = ds1.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                vestingapproval.InnerText = "0";
            }

            PresidentBO PresidentBO = new PresidentBO();
            PresidentBO.ECode = Convert.ToString(Session["ECODE"]);
            DataSet ds = objbal.Get_President_all_count(PresidentBO);
            if (ds.Tables.Count > 0)
            {
                //lbltotal_grant.Text = ds.Tables[0].Rows[0][0].ToString();
                //vestingapproval.InnerText = ds.Tables[2].Rows[0][0].ToString();
                //lbl_rejected.Text = ds.Tables[3].Rows[0][0].ToString();
              ////  grantapproval.InnerText = ds.Tables[1].Rows[0][0].ToString();
            }
            else
            {
               //// grantapproval.InnerText = "0";
            }
        }
    }
}