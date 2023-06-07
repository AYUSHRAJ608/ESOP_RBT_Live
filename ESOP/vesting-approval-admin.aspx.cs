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
using Microsoft.Reporting.WebForms;
using System.IO;
using it = iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace ESOP
{
    public partial class vesting_approval_admin : System.Web.UI.Page
    {
        vesting_approvalBAL objBAL = new vesting_approvalBAL();
        vesting_approvalBO objBO = new vesting_approvalBO();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GET_ADMIN_VESTING_FOR_APPROVAL();
                GET_ADMIN_VESTING_FOR_APPROVAL_COUNT();
            }

        }

        public void GET_ADMIN_VESTING_FOR_APPROVAL()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objBAL.GET_ADMIN_VESTING_FOR_APPROVAL();
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrvPendingforApproval.DataSource = ds.Tables[0];
                        GrvPendingforApproval.DataBind();
                    }
                    else
                    {
                        GrvPendingforApproval.DataSource = ds.Tables[0];
                        GrvPendingforApproval.DataBind();
                        btn_bulkApprove.Visible = false;
                        // btn_bulkReject.Visible = false;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GrvApproved.DataSource = ds.Tables[1];
                        GrvApproved.DataBind();
                    }
                    else
                    {
                        GrvApproved.DataSource = ds.Tables[1];
                        GrvApproved.DataBind();

                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        GrvReject.DataSource = ds.Tables[2];
                        GrvReject.DataBind();

                    }
                    else
                    {
                        GrvReject.DataSource = ds.Tables[2];
                        GrvReject.DataBind();
                    }
                }
                else
                {
                    GrvPendingforApproval.DataSource = ds.Tables[0]; ;
                    GrvPendingforApproval.DataBind();
                    //ViewState["PendingforApprovalRecords"] = null;


                    GrvApproved.DataSource = ds.Tables[1];
                    GrvApproved.DataBind();
                    //ViewState["ApprovedRecords"] = null;

                    GrvReject.DataSource = ds.Tables[2];
                    GrvReject.DataBind();
                    //ViewState["RejectRecords"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void GrvPendingforApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string StrMsg = "";
                if (e.CommandName == "Audit")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GrvPendingforApproval.Rows[index];
                    objBO.GRANT_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[index].Values[0]);
                    Session["GRANT_ID"] = objBO.GRANT_ID;
                    string Vest_Cycle_Name = Convert.ToString(GrvPendingforApproval.DataKeys[index].Values[3]);
                    Session["Vest_Cycle_Name"] = Vest_Cycle_Name;
                    DataSet ds = objBAL.GET_VESTING_AUDIT(objBO, Vest_Cycle_Name);

                    ViewState["GrvPendingforApproval_app_rej"] = null;

                    ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdData.DataSource = ds.Tables[0];
                        grdData.DataBind();
                        // ViewState["dtAuditExport"] = ds.Tables[0];
                    }
                    // ViewState["Emp_filterRec"] = ds;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
                }
                else if (e.CommandName != "Page" && e.CommandName != "Sort")
                {
                    string commandArg = e.CommandArgument.ToString();
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int RowIndex = gvr.RowIndex;
                    TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(RowIndex)].FindControl("TxtRemarkPend_Approval");

                    string Status1 = "";

                    if (e.CommandName == "Approve")
                    {
                        objBO.STATUS = "APPROVED_BY_ADMIN";
                        StrMsg = "Vesting has been approved, sent to President for the approval.";
                        Status1 = "APPROVED_BY_ADMIN";
                    }

                    if (e.CommandName == "Reject")
                    {
                        TextBox TxtRemarkPend_Approval1 = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(RowIndex)].FindControl("TxtRemarkPend_Approval");
                        if (TxtRemarkPend_Approval1.Text != "")
                        {

                            objBO.STATUS = "REJECTED_BY_ADMIN";
                            StrMsg = "Vesting has been rejected, sent to Admin for the correction.";
                            Status1 = "REJECTED_BY_ADMIN";
                        }
                        else
                        {
                            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                            showmsg.InnerText = "Please Enter the reason for rejection.";
                            return;
                        }
                    }
                    objBO.ADMIN_VESTING_REMARK = TxtRemarkPend_Approval.Text.ToString();
                    objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                    objBO.GRANT_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[0].ToString());
                    objBO.V_DETAIL_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[1].ToString());
                    objBO.PROXY = Convert.ToString(Session["Proxy"]);
                    bool retVal = objBAL.UPDATE_ADMIN_VESTING_APPROVAL(objBO);
                    if (retVal == true)
                    {
                        //Mail Functionaity--------------------------------------
                        OEMailBO.userName = GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[2].ToString();
                        OEMailBO.RoleName = "President";
                        OEMailBO.Status1 = Status1;
                        DataSet ds = OEMailBAL.GetEMPDetailsPresident(OEMailBO);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string Attachment = "";
                            if (Status1 == "APPROVED_BY_ADMIN")
                            {
                                // Attachment = GetEmailDoc(OEMailBO.userName, objbo.GrantID);
                                //SendMail(Status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Vesting", "Vesting Approved By Admin", "", "", "", "", "", "", "");

                            }
                            else
                            {
                                //SendMail(Status1, ds.Tables[1].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Vesting", "Vesting Rejected by Admin", "", "", "", "", "", "", "");
                            }

                        }
                        GET_ADMIN_VESTING_FOR_APPROVAL();
                        GET_ADMIN_VESTING_FOR_APPROVAL_COUNT();
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + StrMsg + "');", true);
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = StrMsg;
                    }

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }

        }

        protected void BtnBulkApprove_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                {
                    var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                    if (checkbox.Checked)
                    {
                        objBO.GRANT_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                        objBO.V_DETAIL_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1]);
                        TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[gvrow.RowIndex].FindControl("TxtRemarkPend_Approval");
                        objBO.ADMIN_VESTING_REMARK = TxtRemarkPend_Approval.Text.ToString();
                        objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        objBO.STATUS = "APPROVED_BY_ADMIN";
                        objBO.PROXY = Convert.ToString(Session["Proxy"]);
                        // string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                        bool retVal = objBAL.UPDATE_ADMIN_VESTING_APPROVAL(objBO);
                        if (retVal == true)
                        {
                            OEMailBO.RoleName = "President";
                            OEMailBO.userName = GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1].ToString();
                            OEMailBO.Status1 = "Approved";
                            DataSet ds = OEMailBAL.GetEMPDetailsPresident(OEMailBO);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string Attachment = "";
                                //SendMail("Approved", ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Vesting", "Vesting Approved By Admin", "", "", "", "", "", "", "");
                            }
                        }
                    }
                }
                GET_ADMIN_VESTING_FOR_APPROVAL();
                GET_ADMIN_VESTING_FOR_APPROVAL_COUNT();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Vesting has been approved, sent to President for the approval.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Vesting has been approved, sent to President for the approval.";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void BtnBulkReject_Click(object sender, EventArgs e)
        {
            try
            {


                foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                {
                    var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                    if (checkbox.Checked)
                    {
                        objBO.GRANT_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                        objBO.V_DETAIL_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1]);
                        TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[gvrow.RowIndex].FindControl("TxtRemarkPend_Approval");
                        objBO.ADMIN_VESTING_REMARK = TxtRemarkPend_Approval.Text.ToString();
                        objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                        objBO.STATUS = "REJECTED_BY_ADMIN";
                        objBO.PROXY = Convert.ToString(Session["Proxy"]);
                        //string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                        bool retVal = objBAL.UPDATE_ADMIN_VESTING_APPROVAL(objBO);
                        if (retVal == true)
                        {
                            OEMailBO.userName = GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1].ToString();
                            OEMailBO.RoleName = "President";
                            OEMailBO.Status1 = "Rejected";
                            DataSet ds = OEMailBAL.GetEMPDetailsPresident(OEMailBO);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string Attachment1 = "";
                                //SendMail("Rejected", ds.Tables[1].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment1);
                                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Vesting", "Vesting Rejected by Admin", "", "", "", "", "", "", "");
                            }
                        }
                    }
                }
                GET_ADMIN_VESTING_FOR_APPROVAL();
                GET_ADMIN_VESTING_FOR_APPROVAL_COUNT();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Vesting has been rejected, sent to Admin for the correction.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Vesting has been rejected, sent to Admin for the correction.";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        public void GET_ADMIN_VESTING_FOR_APPROVAL_COUNT()
        {
            DataSet ds = objBAL.GET_ADMIN_VESTING_FOR_APPROVAL_COUNT();
            if (ds.Tables.Count > 0)
            {
                lbltotal_grant.Text = ds.Tables[0].Rows[0][0].ToString();
                lbl_approved.Text = ds.Tables[2].Rows[0][0].ToString();
               // lbl_rejected.Text = ds.Tables[3].Rows[0][0].ToString();
                lbl_approval_pending.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                lbltotal_grant.Text = "0";
                lbl_approved.Text = "0";
               // lbl_rejected.Text = "0";
                lbl_approval_pending.Text = "0";
            }
        }

        public void SendMail_1(string status, string Empname, string ToEmailID, string Attachment)
        {
            try
            {

                EMailBO eMailBO = new EMailBO();
                EMailBAL eMailBAL = new EMailBAL();
                eMailBO.userName = Empname;
                if (status == "Approved")
                {
                    eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantApproval.html");
                }
                else
                {
                    eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantReject.html");
                }

                eMailBO.EmailID = ToEmailID;//multple mail id
                eMailBO.subject = "ESOP-Grant " + status + " status by President.";
                eMailBO.Status1 = status;

                eMailBO.Attachment = Attachment;
                if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
                {
                    string Data = eMailBAL.SendHtmlFormattedEmail(eMailBO);//SUB                               
                    if (!string.IsNullOrEmpty(Data))
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Sucess";
                        eMailBO.CreatedBy = Session["Ecode"].ToString();
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                    else
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Failed";
                        eMailBO.CreatedBy = Session["Ecode"].ToString();
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

        //////////////////public string GetEmailDoc(string EMPcode, int GrantID)
        //////////////////{
        //////////////////    DataSet ds = new DataSet();
        //////////////////    string FilePath = Server.MapPath(@"~\OutputReport\EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".doc");
        //////////////////    try
        //////////////////    {

        //////////////////        #region "--------------------Creating RDLC report--------------------------"
        //////////////////        ReportViewer ReportViewer1 = new ReportViewer();
        //////////////////        ReportDataSource rds = new ReportDataSource();
        //////////////////        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //////////////////        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\ReportDesigns\rpt_Mail.rdlc");

        //////////////////        //-----------------------Table Part----------------------
        //////////////////        ReportViewer1.LocalReport.EnableExternalImages = true;
        //////////////////        string imageLogo = new Uri(Server.MapPath("~/img/HDFCErgoLogo.png")).AbsoluteUri;
        //////////////////        ReportParameter rptLogo = new ReportParameter("rptLogo", imageLogo);
        //////////////////        objbo.EMPCODE = EMPcode.ToString();
        //////////////////        objbo.GrantID = GrantID;
        //////////////////        ds = objbal.report(objbo);
        //////////////////        if (ds.Tables.Count > 0)
        //////////////////        {
        //////////////////            ReportParameter rp = new ReportParameter("rptLetterDate", DateTime.Now.ToString("dd-MM-yyyy"));
        //////////////////            ReportParameter rp1 = new ReportParameter("rptTrancheCode", ds.Tables[0].Rows[0]["grant_name"].ToString());
        //////////////////            ReportParameter rp2 = new ReportParameter("rptSrNo", ds.Tables[0].Rows[0]["grant_id"].ToString());
        //////////////////            ReportParameter rp3 = new ReportParameter("rptEmployeeFullName", ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
        //////////////////            ReportParameter rp4 = new ReportParameter("rptEmpCode", ds.Tables[0].Rows[0]["ECODE"].ToString());
        //////////////////            string[] Firstname = ds.Tables[0].Rows[0]["EMP_NAME"].ToString().Split(new char[] { ' ' });
        //////////////////            ReportParameter rp5 = new ReportParameter("rptEmplyeeFirstName", Firstname[1].ToString());
        //////////////////            ReportParameter rp6 = new ReportParameter("rptNoOptionsGranted", ds.Tables[0].Rows[0]["no_of_options"].ToString());
        //////////////////            ReportParameter rp7 = new ReportParameter("rptGrantPrice", ds.Tables[0].Rows[0]["Grant_Price"].ToString());
        //////////////////            ReportParameter rp8 = new ReportParameter("rptGrantDate", ds.Tables[0].Rows[0]["Grant_Date"].ToString());
        //////////////////            ReportParameter rp9 = new ReportParameter("rptDesignation", ds.Tables[0].Rows[0]["rolename"].ToString());
        //////////////////            ReportParameter rp10;
        //////////////////            ReportParameter rp11;
        //////////////////            ReportParameter rp12;
        //////////////////            if (Convert.ToString(ds.Tables[1].Rows[0]["VESTING_DATE"]) != "")
        //////////////////            {
        //////////////////                rp10 = new ReportParameter("rptGrantDate1", ds.Tables[1].Rows[0]["VESTING_DATE"].ToString());
        //////////////////            }
        //////////////////            else
        //////////////////            {
        //////////////////                rp10 = new ReportParameter("rptGrantDate1", "");
        //////////////////            }
        //////////////////            if (Convert.ToString(ds.Tables[1].Rows[1]["VESTING_DATE"]) != "")
        //////////////////            {
        //////////////////                rp11 = new ReportParameter("rptGrantDate2", ds.Tables[1].Rows[1]["VESTING_DATE"].ToString());
        //////////////////            }
        //////////////////            else
        //////////////////            {
        //////////////////                rp11 = new ReportParameter("rptGrantDate2", "");
        //////////////////            }

        //////////////////            if (Convert.ToString(ds.Tables[1].Rows[2]["VESTING_DATE"]) != "")
        //////////////////            {
        //////////////////                rp12 = new ReportParameter("rptGrantDate3", ds.Tables[1].Rows[2]["VESTING_DATE"].ToString());
        //////////////////            }
        //////////////////            else
        //////////////////            {
        //////////////////                rp12 = new ReportParameter("rptGrantDate3", "");
        //////////////////            }

        //////////////////            ReportViewer1.LocalReport.DataSources.Clear();
        //////////////////            ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptLogo, rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12 });
        //////////////////            rds = new ReportDataSource("DT_GRANT_DETAILS", ds.Tables[0]);
        //////////////////            ReportViewer1.LocalReport.DataSources.Add(rds);
        //////////////////            ReportViewer1.LocalReport.Refresh();
        //////////////////        }

        //////////////////        #endregion

        //////////////////        #region "--------Report download to Application route----------------"

        //////////////////        Microsoft.Reporting.WebForms.Warning[] warnings;
        //////////////////        //string[] streamids;
        //////////////////        //string mimeType;
        //////////////////        //string encoding;
        //////////////////        //string filenameExtension;

        //////////////////        string[] streamIds;
        //////////////////        string contentType;
        //////////////////        string encoding;
        //////////////////        string extension;

        //////////////////        if (ReportViewer1.LocalReport.ReportPath != null)
        //////////////////        {
        //////////////////            //ReportViewer1.LocalReport.EnableExternalImages = true;
        //////////////////            //byte[] bytes = ReportViewer1.LocalReport.Render(
        //////////////////            //    "WORD", null, out mimeType, out encoding, out filenameExtension,
        //////////////////            //    out streamids, out warnings);


        //////////////////            //HttpContext.Current.Response.Expires = -1;
        //////////////////            //HttpContext.Current.Response.Cache.SetNoStore();
        //////////////////            //HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
        //////////////////            //using (System.IO.FileStream fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Create))
        //////////////////            //{
        //////////////////            //    fs.Write(bytes, 0, bytes.Length);
        //////////////////            //}
        //////////////////            //HttpContext.Current.Response.ContentType = "application/vnd.ms-word";
        //////////////////            //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=EmailDoc_EmpId_" + EMPcode.ToString() + ".docx");
        //////////////////            //HttpContext.Current.Response.WriteFile(FilePath);
        //////////////////            ////HttpContext.Current.Response.End();
        //////////////////            //HttpContext.Current.ApplicationInstance.CompleteRequest();

        //////////////////            //Export the RDLC Report to Byte Array.
        //////////////////            ReportViewer1.LocalReport.EnableExternalImages = true;
        //////////////////            byte[] bytes = ReportViewer1.LocalReport.Render("WORD", null, out contentType, out encoding, out extension, out streamIds, out warnings);
        //////////////////            //---------------------------------------------------------------------------------
        //////////////////            //Download the RDLC Report in Word, Excel, PDF and Image formats.
        //////////////////            //Response.Clear();
        //////////////////            //Response.Buffer = true;
        //////////////////            //Response.Charset = "";
        //////////////////            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //////////////////            using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
        //////////////////            {
        //////////////////                fs.Write(bytes, 0, bytes.Length);
        //////////////////            }
        //////////////////            //Response.ContentType = contentType;
        //////////////////            //Response.AppendHeader("Content-Disposition", "attachment; filename=EmailDoc_EmpId_" + EMPcode.ToString() + ".doc");
        //////////////////            //Response.BinaryWrite(bytes);
        //////////////////            ////Response.WriteFile(FilePath);
        //////////////////            //Response.Flush();
        //////////////////            ////Response.End();
        //////////////////            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        //////////////////        }

        //////////////////        #endregion
        //////////////////    }
        //////////////////    catch (Exception ex)
        //////////////////    {

        //////////////////        return FilePath;
        //////////////////    }
        //////////////////    finally
        //////////////////    {

        //////////////////    }
        //////////////////    return FilePath;
        //////////////////}

        protected void GrvPendingforApproval_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_ADMIN_VESTING_FOR_APPROVAL();
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvPendingforApproval.UseAccessibleHeader = true;
                GrvPendingforApproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_ADMIN_VESTING_FOR_APPROVAL();
            if (ds.Tables[1].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvReject_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_ADMIN_VESTING_FOR_APPROVAL();
            if (ds.Tables[2].Rows.Count > 0)
            {

                GrvReject.UseAccessibleHeader = true;
                GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GrvApproved_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvApproved.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(GrvApproved.DataKeys[index].Values[0]);
                string Vest_Cycle_Name = Convert.ToString(GrvApproved.DataKeys[index].Values[3]);
                DataSet ds = objBAL.GET_VESTING_AUDIT(objBO, Vest_Cycle_Name);


                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];


                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
        }

        protected void GrvReject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvReject.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(GrvReject.DataKeys[index].Values[0]);


                string Vest_Cycle_Name = Convert.ToString(GrvReject.DataKeys[index].Values[3]);


                DataSet ds = objBAL.GET_VESTING_AUDIT(objBO, Vest_Cycle_Name);
                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];
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
            string FileName = "VESTING_REPORT" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //grdData.GridLines = GridLines.Both;
            //grdData.HeaderStyle.Font.Bold = true;
            //DataTable dt = new DataTable("GridView_Data");

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

            string filename = "VESTING_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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

            DataTable ds = (DataTable)ViewState["GrvPendingforApproval_app_rej"];
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