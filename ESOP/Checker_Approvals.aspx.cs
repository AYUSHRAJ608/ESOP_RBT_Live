using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;

namespace ESOP
{
    public partial class Checker_Approvals : System.Web.UI.Page
    {
        GrandCreationBAL objbal = new GrandCreationBAL();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataSet ds1 = objBAL.GET_CHECKER_COUNT();

                    if (ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            GrantApprovecount.InnerText = Convert.ToString(ds1.Tables[0].Rows.Count);
                        }
                        else
                        {
                            GrantApprovecount.InnerText = "0";
                        }

                        if (ds1.Tables[1].Rows.Count > 0)
                        {
                            LapseApprovecount.InnerText = Convert.ToString(ds1.Tables[1].Rows.Count);
                        }
                        else
                        {
                            LapseApprovecount.InnerText = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
            }
        }
    }
}