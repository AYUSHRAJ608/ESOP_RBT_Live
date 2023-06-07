using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace ESOP
{
    public partial class PDFPassword : System.Web.UI.Page
    {
        ValuationBO objbo = new ValuationBO();
        ValuationBAL objbal = new ValuationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_Data();
                Get_DropDown();
            }


        }

        protected void Get_DropDown()
        {
            DataSet ds = objbal.GET_DROPDOWN();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlEmpPass.DataSource = ds.Tables[0];
                ddlEmpPass.DataBind();
                ddlEmpPass.DataTextField = "ID_PROOF";
                ddlEmpPass.DataValueField = "ID_PROOF";
                ddlEmpPass.DataBind();
                ddlEmpPass.Items.Insert(0, new ListItem("Select ID PROOF", "0"));

            }
        }
        protected void Get_Data()
        {
            DataSet ds = objbal.GET_AUDIT();

            ViewState["Emp_filterRec"] = null;
            ViewState["Emp_filterRec"] = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
                // ViewState["dtAuditExport"] = ds.Tables[0];
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string message = "";
                bool Flag;

                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());


                Flag = IsPasswordStrong(txtPassword_1.Text.ToString());
                if (!Flag)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number and 1 Special character!!');", true);
                    txtPassword_1.Focus();
                    return;
                }

                objbo.AGENCY_NAME = txtPassword_1.Text;
                // objbo.AGENCY_ADDRESS = ddlEmpPass.Text.ToString();
                objbo.AGENCY_ADDRESS = ddlEmpPass.SelectedIndex.ToString();
                objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                DataSet strmsg = objbal.Insert_PDF_Password(objbo);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record added successfully.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Password Updated successfully";

                txtPassword_1.Text = "";
                ddlEmpPass.SelectedIndex = 0;
                Get_Data();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }

        }

        protected void btnAudit_Click(object sender, EventArgs e)
        {
            DataSet ds = objbal.GET_AUDIT();

            ViewState["Emp_filterRec"] = null;
            ViewState["Emp_filterRec"] = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
                // ViewState["dtAuditExport"] = ds.Tables[0];
            }
            //ViewState["Emp_filterRec"] = ds;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
        }
        protected void grdData_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["Emp_filterRec"];
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        public static bool IsPasswordStrong(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$");
        }
    }
}