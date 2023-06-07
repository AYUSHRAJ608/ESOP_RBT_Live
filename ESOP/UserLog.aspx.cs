
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using ESOP_BAL;
using ESOP_BO;

namespace ESOP
{
    public partial class UserLog : System.Web.UI.Page
    {
        UserBO objcUserEntity = new UserBO();
        UserBAL objcUserBAL = new UserBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllUsers();
        }

        private void GetAllUsers()
        {
            try
            {
                
                DataSet ds = objcUserBAL.GetAllUsers();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["mydataset"] = ds;
                    grdapproval.DataSource = ds.Tables[0];
                    grdapproval.DataBind();

                }
                else
                {
                    grdapproval.DataSource = ds.Tables[0];
                    grdapproval.DataBind();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        protected void grdapproval_PreRender(object sender, EventArgs e)
        {

            DataSet ds = objcUserBAL.GetAllUsers();
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdapproval.UseAccessibleHeader = true;
                grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdapproval.Rows[index];
                objcUserEntity.EmpID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);

                DataSet ds = objcUserBAL.GetUser(objcUserEntity);
                ViewState["data1"] = null;

                ViewState["data1"] = ds.Tables[0];
                //if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
        }
        protected void grdData_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["data1"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    grdData.UseAccessibleHeader = true;
                    grdData.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Emp_filterRec"];
            if (ds.Tables.Count > 0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
            }
        }
    }
}