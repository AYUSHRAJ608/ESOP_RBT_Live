using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class Financial_Year : System.Web.UI.Page
    {
        TaxBO taxbo = new TaxBO();
        TaxBAL taxbal = new TaxBAL();
        bool IsPageRefresh = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
                //string strT = 
                //bind_Year_Grid();
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }
                string strF = txtfrom.Text.ToString();
                string strFT = strF + "-" + Request.Form[txtto.UniqueID].ToString();
                string message = "";

                taxbo.ACTION = "Int_Year";
                taxbo.FINANCIAL_YEAR = strFT;
                string strmsg = taxbal.Insert_Financial_Year(taxbo);
                if (strmsg == "exi")
                {
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record already exists";
                    txtfrom.Text = string.Empty;
                }
                else
                {

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record added successfully');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record added successfully";
                    txtfrom.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }
        private void bind_Year_Grid()
        {           
            DataSet ds = taxbal.bind_Year_Grid(taxbo);
            ViewState["check"] = ds.Tables[1].Rows[0][0].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdtax.DataSource = ds.Tables[0];
                grdtax.DataBind();
                // ViewState["Getvaluation"] = ds.Tables[0];

                grdtax.UseAccessibleHeader = true;
                grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;


            }
            else
            {
                grdtax.DataSource = ds.Tables[0];
                grdtax.DataBind();
                //  ViewState["Getvaluation"] = null;

                //grdtax.UseAccessibleHeader = true;
                //grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdtax_PreRender(object sender, EventArgs e)
        {
            DataSet ds = taxbal.bind_Year_Grid(taxbo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdtax.DataSource = ds.Tables[0];
                grdtax.DataBind();

                grdtax.UseAccessibleHeader = true;
                grdtax.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}