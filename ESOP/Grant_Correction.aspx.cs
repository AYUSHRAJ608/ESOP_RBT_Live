using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
using it = iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace ESOP
{
    public partial class Grant_Correction : System.Web.UI.Page
    {
        Grant_CorrectionBO objBO = new Grant_CorrectionBO();
        Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();

        GrandCreationBO objbo1 = new GrandCreationBO();
        GrandCreationBAL objbal1 = new GrandCreationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_correction_records();
            }
        }

        private void Get_correction_records()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objBAL.Get_correction_records();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdgrntcorrection.DataSource = ds.Tables[0];
                    grdgrntcorrection.DataBind();

                    //   Session["Getgrantcorrection"] = ds.Tables[0];

                    grdgrntcorrection.UseAccessibleHeader = true;
                    grdgrntcorrection.HeaderRow.TableSection = TableRowSection.TableHeader;
                    btn_bulkApprove.Visible = true;
                    btn_bulkReject.Visible = true;
                }
                else
                {
                    // lbldisplay.Visible = true;
                    // lbldisplay.Text = "No Record Found";
                    grdgrntcorrection.DataSource = ds.Tables[0];
                    grdgrntcorrection.DataBind();
                    //lbldisplay.Visible = true;
                    //lbldisplay.Text = "No Record Found";
                    //  Session["Getgrantcorrection"] = null;
                    btn_bulkApprove.Visible = false;
                    btn_bulkReject.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdgrntcorrection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdgrntcorrection.EditIndex = e.NewEditIndex;
                Get_correction_records();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdgrntcorrection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdgrntcorrection.PageIndex = e.NewPageIndex;
                this.Get_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdgrntcorrection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string status1 = "";
                // DataTable ds1 = (DataTable)Session["Getgrantcorrection"];
                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                GridViewRow row = grdgrntcorrection.Rows[e.RowIndex];
                objBO.GRANT_ID = Convert.ToInt32(grdgrntcorrection.DataKeys[e.RowIndex].Values[0]);
                objBO.NO_OF_OPTION = Convert.ToInt32((row.FindControl("txtoption") as TextBox).Text);
                ///objBO.Emp_code = Convert.ToString(grdgrntcorrection.DataKeys[e.RowIndex].Values[1]);
                //objBO.Emp_name = ((row.FindControl("txtename") as TextBox).Text);
                objBO.VID = Convert.ToInt32((row.FindControl("ddlVesting") as DropDownList).SelectedValue);
                objBO.admin_remark = (row.FindControl("txtremark") as TextBox).Text;
                //objBO.FMV_PRICE = Convert.ToInt32((row.FindControl("txtprice") as TextBox).Text);
                objBO.UPDATED_BY = Convert.ToString(Session["ECode"]);
                status1 = "Updated";


                Label empname = (row.FindControl("lblname") as Label);
                Label fmvprice = (row.FindControl("lblprice") as Label);
                Label grntname = (row.FindControl("lbltranchcode") as Label);

                bool val = objBAL.UpdateGrantcorrection(objBO);

                if (val == true)
                {

                    OEMailBO.userName = grdgrntcorrection.DataKeys[row.RowIndex].Values[1].ToString();
                    //Mail Functionaity--------------------------------------
                    DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
                    string userName = Convert.ToString(ds1.Tables[0].Rows[0]["USERNAME"]);
                    string emailid = Convert.ToString(ds1.Tables[0].Rows[0]["EMAILID"]);
                    // string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                    string Attachment = "";

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        //SendMail(status1, userName, emailid, Attachment);
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), userName, "Grant", "Correction in rejected grant", grntname.Text, "", "", fmvprice.Text, "", "", empname.Text);
                    }
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Grant has been Updated, sent to HR Head for the approval.');", true);

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Grant has been Updated, sent to Checker for the approval.";
                }
                grdgrntcorrection.EditIndex = -1;
                this.Get_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }


        public void SendMail_1(string status, string Hrname, string ToEmailID, string Attachment)
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
                        eMailBO.CreatedBy = Convert.ToString(Session["ECode"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                    else
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Failed";
                        eMailBO.CreatedBy = Convert.ToString(Session["ECode"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void grdgrntcorrection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdgrntcorrection.EditIndex = -1;
                Get_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdgrntcorrection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objBO.GRANT_ID = Convert.ToInt32(grdgrntcorrection.DataKeys[e.RowIndex].Values[0]);
                objBAL.DeleteGrantcorrection(objBO);

                //SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), "", "Grant", "Grant Updated", "", "");

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Grant deleted successfully.');", true);


                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant deleted successfully.";

                Get_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdgrntcorrection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grdgrntcorrection.EditIndex == e.Row.RowIndex)
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

        protected void grdgrntcorrection_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.Get_correction_records();
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdgrntcorrection.UseAccessibleHeader = true;
                grdgrntcorrection.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                //lbldisplay.Visible = true;
                //
                //lbldisplay.Text = "No Record Found";
            }
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            //objBO.GRANT_ID = Convert.ToInt32(grdgrntcorrection.DataKeys[e.RowIndex].Values[0]);
            //DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
        }

        protected void grdgrntcorrection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdgrntcorrection.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdgrntcorrection.DataKeys[index].Values[0]);
                ViewState["grant_id"] = objBO.GRANT_ID;
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);

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
            string FileName = "Grand Correction" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdData.GridLines = GridLines.Both;
            grdData.HeaderStyle.Font.Bold = true;
            //DataTable dt = new DataTable("GridView_Data");

            //var gv = new GridView();

            //dt = (DataTable)ViewState["dtAuditExport"];
            //gv.DataSource = dt;
            //gv.DataBind();
            grdData.RenderControl(htmltextwrtter);
            Response.Output.Write(strwritter.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        private void ExportGridToPDF()
        {

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //grdData.AllowPaging = false;
            //grdData.DataBind();
            //grdData.RenderControl(hw);
            //grdData.HeaderRow.Style.Add("width", "15%");
            //grdData.HeaderRow.Style.Add("font-size", "10px");
            //grdData.Style.Add("text-decoration", "none");
            //grdData.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            //grdData.Style.Add("font-size", "8px");
            //StringReader sr = new StringReader(sw.ToString());
            //it.Document pdfDoc = new it.Document(it.PageSize.A2, 7f, 7f, 7f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();

            Response.ContentType = "application/pdf";
            string filename = "Grand_Correction" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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

        protected void btnExportPDF_Click1(object sender, ImageClickEventArgs e)
        {
            ExportGridToPDF();
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
        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in grdgrntcorrection.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        var checkbox = gvrow.FindControl("chk") as CheckBox;

                        if (checkbox.Checked)
                        {
                            string status1 = "";
                            DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            objBO.GRANT_ID = Convert.ToInt32(grdgrntcorrection.DataKeys[gvrow.RowIndex].Values[0]);

                            Control C = gvrow.Cells[6].Controls[1];

                            if (C.GetType() == typeof(TextBox))
                            {
                                objBO.NO_OF_OPTION = Convert.ToInt32((gvrow.FindControl("txtoption") as TextBox).Text);
                            }
                            else
                            {
                                objBO.NO_OF_OPTION = Convert.ToInt32((gvrow.FindControl("lbloption") as Label).Text);
                            }

                            Control C1 = gvrow.Cells[8].Controls[1];
                            if (C1.GetType() == typeof(DropDownList))
                            {
                                objBO.VID = Convert.ToInt32((gvrow.FindControl("ddlVesting") as DropDownList).SelectedValue);
                            }

                            else
                            {
                                //objBO.VID = Convert.ToInt32((gvrow.FindControl("lblVesting") as Label).Text);
                                objBO.VID = 0;
                            }

                            Control C2 = gvrow.Cells[10].Controls[1];
                            if (C2.GetType() == typeof(TextBox))
                            {
                                objBO.admin_remark = (gvrow.FindControl("txtremark") as TextBox).Text;
                            }
                            else
                            {
                                objBO.admin_remark = Convert.ToString((gvrow.FindControl("lblADMIN_GRANT_CORRECTION_REJECTION_REMARK") as Label).Text);
                            }

                            objBO.UPDATED_BY = Convert.ToString(Session["ECode"]);
                            status1 = "Updated";


                            Label empname = (gvrow.FindControl("lblname") as Label);
                            Label fmvprice = (gvrow.FindControl("lblprice") as Label);
                            Label grntname = (gvrow.FindControl("lbltranchcode") as Label);

                            bool val = objBAL.UpdateGrantcorrection(objBO);

                            if (val == true)
                            {

                                OEMailBO.userName = grdgrntcorrection.DataKeys[gvrow.RowIndex].Values[1].ToString();
                                //Mail Functionaity--------------------------------------
                                DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
                                string userName = Convert.ToString(ds1.Tables[0].Rows[0]["USERNAME"]);
                                string emailid = Convert.ToString(ds1.Tables[0].Rows[0]["EMAILID"]);
                                string Attachment = "";

                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), userName, "Grant", "Correction in rejected grant", grntname.Text, "", "", fmvprice.Text, "", "", empname.Text);
                                }

                            }
                        }
                    }
                }
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been Updated, sent to Checker for the approval.";
                grdgrntcorrection.EditIndex = -1;
                this.Get_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }
        protected void btn_bulkReject_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in grdgrntcorrection.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        var checkbox = gvrow.FindControl("chk") as CheckBox;

                        if (checkbox.Checked)
                        {
                            objBO.GRANT_ID = Convert.ToInt32(grdgrntcorrection.DataKeys[gvrow.RowIndex].Values[0]);
                            objBAL.DeleteGrantcorrection(objBO);

                        }
                    }
                }

                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant deleted successfully.";

                Get_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }
    }
}