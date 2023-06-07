using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.IO;
using it = iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace ESOP
{
    public partial class AdminGrantUpdation : System.Web.UI.Page
    {
        AdminBO objbo = new AdminBO();
        AdminBAL objbal = new AdminBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();

        GrandCreationBO objbo1 = new GrandCreationBO();
        GrandCreationBAL objbal1 = new GrandCreationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            showmsg.InnerText = "";
            if (!Page.IsPostBack)
            {
                FunGetApprovalRecords();
            }

        }

        public void FunGetApprovalRecords()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objbal.FunGetApprovalRecords();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrvAdminGUP.DataSource = ds.Tables[0];
                    GrvAdminGUP.DataBind();
                    //  ViewState["Admin"] = ds.Tables[0];

                    GrvAdminGUP.UseAccessibleHeader = true;
                    GrvAdminGUP.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
                else
                {
                    GrvAdminGUP.DataSource = ds.Tables[0];
                    GrvAdminGUP.DataBind();
                    // ViewState["Admin"] = null;

                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }

        protected void GrvAdminGUP_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string status1 = "";
                // DataTable ds1 = (DataTable)ViewState["Admin"];
                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                GridViewRow row = GrvAdminGUP.Rows[e.RowIndex];
                if (Convert.ToInt32((row.FindControl("Txt_No_of_Grants") as TextBox).Text) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myalert", "alert('Please enter more than Zero No of Option');", true);
                }
                else
                {
                    objbo.GRANT_ID = Convert.ToInt32(GrvAdminGUP.DataKeys[e.RowIndex].Values[0]);
                    objbo.NO_OF_OPTION = Convert.ToInt32((row.FindControl("Txt_No_of_Grants") as TextBox).Text);
                    //objbo.EMP_ID = (row.FindControl("Txt_EmployeeID") as TextBox).Text;
                    objbo.VID = Convert.ToInt32((row.FindControl("ddlVesting") as DropDownList).SelectedValue);
                    objbo.admin_remark = (row.FindControl("txtremark") as TextBox).Text;
                    objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                    status1 = "Updated";

                    Label empname = (row.FindControl("lblEmployeeName") as Label);
                    Label fmvprice = (row.FindControl("lblGrantPrice") as Label);
                    Label grntname = (row.FindControl("lbltranchcode") as Label);



                    bool val = objbal.UpdateGrant(objbo);
                    if (val == true)
                    {


                        OEMailBO.userName = GrvAdminGUP.DataKeys[row.RowIndex].Values[1].ToString();
                        //Mail Functionaity--------------------------------------
                        DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
                        string userName = ds1.Tables[0].Rows[0]["USERNAME"].ToString();
                        string emailid = ds1.Tables[0].Rows[0]["EMAILID"].ToString();
                        string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                        // DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Updated", grntname.Text, "", "", fmvprice.Text, "", "", empname.Text);
                        }
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully');", true);
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Grant has been updated & send it to Checker for the approval.";
                    }
                    GrvAdminGUP.EditIndex = -1;
                    this.FunGetApprovalRecords();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        public void SendMail_2(string status, string Hrname, string ToEmailID, string Attachment)
        {
            try
            {

                EMailBO eMailBO = new EMailBO();
                EMailBAL eMailBAL = new EMailBAL();
                eMailBO.userName = Hrname;
                eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantUpdation.html");
                eMailBO.EmailID = ToEmailID;//multple mail id
                eMailBO.subject = "ESOP-Grant Updated status by admin.";
                eMailBO.Status1 = status;

                eMailBO.Attachment = Attachment;
                if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
                {
                    string Data = eMailBAL.SendHtmlFormattedEmail(eMailBO);//SUB                               
                    if (!string.IsNullOrEmpty(Data))
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Sucess";
                        eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                    else
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Failed";
                        eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }
        protected void GrvAdminGUP_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GrvAdminGUP.EditIndex = -1;
                FunGetApprovalRecords();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void GrvAdminGUP_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objbo.GRANT_ID = Convert.ToInt32(GrvAdminGUP.DataKeys[e.RowIndex].Values[0]);
                objbal.DeleteGrant(objbo);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record deleted successfully.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant deleted successfully";

                FunGetApprovalRecords();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void GrvAdminGUP_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GrvAdminGUP.EditIndex = e.NewEditIndex;
                FunGetApprovalRecords();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void GrvAdminGUP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GrvAdminGUP.EditIndex == e.Row.RowIndex)
            {
                DataSet ds = objbal1.GetDropDown();
                DropDownList ddlVesting = (e.Row.FindControl("ddlVesting") as DropDownList);
                if (ds.Tables.Count > 0)
                {

                    ddlVesting.Items.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ListItem item = new ListItem();
                        item.Text = row["VNAME"].ToString();
                        item.Value = row["VID"].ToString();
                        if (row["ACTION"].ToString() == "BASE")
                        {
                            item.Attributes.Add("class", "optiongroup1");
                        }
                        else
                        {
                            item.Attributes.Add("class", "optionchild1");
                            item.Attributes.Add("disabled", "disabled");
                        }


                        ddlVesting.Items.Add(item);
                    }
                    //ddlVesting.Items.Insert(0, new ListItem("Select Vesting", "0"));

                }
                string VNAME = DataBinder.Eval(e.Row.DataItem, "VNAME").ToString();
                ddlVesting.Items.FindByText(VNAME).Selected = true;
                //else
                //{

                //}
                //----------------------------------------------------------
                //DropDownList ddlVesting = (e.Row.FindControl("ddlVesting") as DropDownList);
                //DataTable dt = objbal.getvaluedbyddl(objbo);

                //DropDownList1.DataSource = dt;

                //DropDownList1.DataTextField = "Valued_By";
                //DropDownList1.DataValueField = "AGENCY_ID";
                //DropDownList1.DataBind();

                //string Valued_By = DataBinder.Eval(e.Row.DataItem, "Valued_By").ToString();
                //DropDownList1.Items.FindByText(Valued_By).Selected = true;

            }
        }

        protected void GrvAdminGUP_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.FunGetApprovalRecords();
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvAdminGUP.UseAccessibleHeader = true;
                GrvAdminGUP.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvAdminGUP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Grant_CorrectionBO objBO = new Grant_CorrectionBO();
            Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvAdminGUP.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(GrvAdminGUP.DataKeys[index].Values[0]);
                ViewState["grant_id"] = objBO.GRANT_ID;
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);

                ViewState["Emp_filterRec"] = null;
                ViewState["Emp_filterRec"] = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                // ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
        }

        //protected void GrvAdminGUP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        GrvAdminGUP.PageIndex = e.NewPageIndex;
        //        this.FunGetApprovalRecords();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void GrvAdminGUP_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dtrslt = (DataTable)Session["dirStateP"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdrP"]) == "Asc")
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdrP"] = "Desc";
        //        }
        //        else
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //            Session["sortdrP"] = "Asc";
        //        }
        //        GrvAdminGUP.DataSource = dtrslt;
        //        GrvAdminGUP.DataBind();
        //    }
        //}
        //protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdData.PageIndex = e.NewPageIndex;
        //    DataSet ds = (DataSet)ViewState["Emp_filterRec"];
        //    if (ds.Tables.Count > 0)
        //    {
        //        grdData.DataSource = ds.Tables[0];
        //        grdData.DataBind();
        //    }
        //}

        protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_Code = (Label)e.Row.FindControl("lbl_Status");
                if (lbl_Code.Text.Contains("APP"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                }
                else if (lbl_Code.Text.Contains("REJ"))
                {
                    e.Row.BackColor = System.Drawing.Color.BurlyWood;
                }
            }
        }
        protected void imgExportAudit_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(imgExportAudit);
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Grand_Updation" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdData.GridLines = GridLines.Both;
            grdData.HeaderStyle.Font.Bold = true;
            DataTable dt = new DataTable("GridView_Data");

            //var gv = new GridView();

            //dt = (DataTable)ViewState["dtAuditExport"];
            //gv.DataSource = dt;
            //gv.DataBind();
            grdData.RenderControl(htmltextwrtter);
            Response.Output.Write(strwritter.ToString());
            Response.End();
        }
        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";

            string filename = "Grand_Updation" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdData.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            it.Document pdfDoc = new it.Document(it.PageSize.A2, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grdData.AllowPaging = true;
            grdData.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void grdData_PreRender(object sender, EventArgs e)
        {
            //Grant_CorrectionBO objBO = new Grant_CorrectionBO();
            //Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
            //objBO.GRANT_ID = Convert.ToInt32(ViewState["grant_id"]);
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
    }
}