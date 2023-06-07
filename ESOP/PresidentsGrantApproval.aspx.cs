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
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Net.Mail;
using System.Net;
//using Microsoft.Office.Interop.Word;

namespace ESOP
{
    public partial class PresidentsGrantApproval : System.Web.UI.Page
    {
        PresedentApprovalBO objbo = new PresedentApprovalBO();
        PresedentApprovalBAL objbal = new PresedentApprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        Grant_CorrectionBO objBO = new Grant_CorrectionBO();
        Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FunGetApprovalRecords();
                bind_PR_all_count();
            }

        }

        public void FunGetApprovalRecords()


        {
            try
            {
                objbo.EMPCODE = Convert.ToString(Session["ECODE"]);
                DataSet ds = new DataSet();
                ds = objbal.FunGetApprovalRecords(objbo);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)

                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrvPendingforApproval.DataSource = ds.Tables[0];
                        GrvPendingforApproval.DataBind();
                        //    ViewState["PendingforApprovalRecords"] = ds.Tables[0];

                        //    GrvPendingforApproval.UseAccessibleHeader = true;
                        //    GrvPendingforApproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        GrvPendingforApproval.DataSource = ds.Tables[0];
                        GrvPendingforApproval.DataBind();
                        btn_bulkApprove.Visible = false;
                        btn_bulkReject.Visible = false;
                        //ViewState["PendingforApprovalRecords"] = null;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GrvApproved.DataSource = ds.Tables[1];
                        GrvApproved.DataBind();
                        //ViewState["ApprovedRecords"] = ds.Tables[1];
                        //GrvApproved.UseAccessibleHeader = true;
                        //GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        GrvApproved.DataSource = ds.Tables[1];
                        GrvApproved.DataBind();
                        //ViewState["ApprovedRecords"] = null;
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        GrvReject.DataSource = ds.Tables[2];
                        GrvReject.DataBind();
                        //ViewState["RejectRecords"] = ds.Tables[2];
                        //GrvReject.UseAccessibleHeader = true;
                        //GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        GrvReject.DataSource = ds.Tables[2];
                        GrvReject.DataBind();
                        //ViewState["RejectRecords"] = null;
                    }
                }
                else
                {
                    GrvPendingforApproval.DataSource = null;
                    GrvPendingforApproval.DataBind();
                    ViewState["PendingforApprovalRecords"] = null;


                    GrvApproved.DataSource = null;
                    GrvApproved.DataBind();
                    ViewState["ApprovedRecords"] = null;

                    GrvReject.DataSource = null;
                    GrvReject.DataBind();
                    ViewState["RejectRecords"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
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
                    DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
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
                else if (e.CommandName != "Page" && e.CommandName != "Sort")
                {

                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int RowIndex = gvr.RowIndex;
                    TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(RowIndex)].FindControl("TxtRemarkPend_Approval");
                    string GrantName = GrvPendingforApproval.DataKeys[RowIndex].Values[3].ToString();
                    objbo.REMARK2 = txt.Text.ToString();
                    objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                    objbo.GrantID = Convert.ToInt32(commandArgs[0]);
                    HiddenField Hdf = GrvPendingforApproval.Rows[RowIndex].FindControl("HiddenField1") as HiddenField;
                    // objbo.LETTERID = Convert.ToInt32(commandArgs[2]);
                    if (Convert.ToBoolean(GrvPendingforApproval.DataKeys[RowIndex].Values[2] == DBNull.Value))
                    {
                    }
                    else
                    {
                        objbo.LETTERID = Convert.ToInt32(GrvPendingforApproval.DataKeys[RowIndex].Values[2]);
                    }

                    string Status1 = "";

                    if (e.CommandName == "Approve")
                    {
                        objbo.Status = "APPROVED_BY_PRESIDENT";
                        Status1 = "Approved";
                        StrMsg = "Records approved successfully!!";
                    }

                    if (e.CommandName == "Reject")
                    {
                        objbo.Status = "REJECTED_BY_PRESIDENT";
                        Status1 = "Rejected";
                        StrMsg = "Records rejected successfully!!";
                    }

                    objbo.proxy = Convert.ToString(Session["Proxy"]);
                    bool retVal = objbal.Update_Status(objbo);
                    if (retVal == true)
                    {
                        //Mail Functionaity--------------------------------------
                        OEMailBO.userName = GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[1].ToString();
                        OEMailBO.RoleName = "President";
                        OEMailBO.Status1 = Status1;
                        DataSet ds = OEMailBAL.GetEMPDetailsPresident(OEMailBO);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string Attachment = "";
                            if (Status1 == "Approved")
                            {
                                //Attachment = GetEmailDoc(OEMailBO.userName, objbo.GrantID);
                                // Attachment = FuncReplaceWord(OEMailBO.userName, objbo.GrantID, objbo.LETTERID);
                                //SendMail(Status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);

                                if (ds.Tables[0].Rows[0]["EMP"].ToString() == "")
                                {
                                    Attachment = Server.MapPath("~/ExcelFormat/User_Manual.xlsx");
                                    SendMail_1(GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[4].ToString(), "New Employee", "New", Attachment, ds.Tables[0].Rows[0]["EMAILID"].ToString(), GrantName, GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[5].ToString());
                                }
                                //Attachment = FuncReplaceWord(OEMailBO.userName, objbo.GrantID, objbo.LETTERID);
                                Attachment = Server.MapPath(Hdf.Value.ToString());
                                SendMail_1(GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[4].ToString(), "Grant", "Approve by president", Attachment, ds.Tables[0].Rows[0]["EMAILID"].ToString(), GrantName, GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[5].ToString());
                            }
                            else
                            {
                                //SendMail(Status1, ds.Tables[1].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                SendMail_1(GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[4].ToString(), "Grant", "Reject by president", Attachment, ds.Tables[0].Rows[0]["EMAILID"].ToString(), GrantName, GrvPendingforApproval.DataKeys[gvr.RowIndex].Values[5].ToString());
                            }

                        }
                        FunGetApprovalRecords();
                        bind_PR_all_count();
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
                    var checkbox = gvrow.FindControl("CheckBox1") as System.Web.UI.WebControls.CheckBox;
                    if (checkbox.Checked)
                    {
                        objbo.GrantID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                        TextBox txt = (TextBox)GrvPendingforApproval.Rows[gvrow.RowIndex].FindControl("TxtRemarkPend_Approval");
                        string GrantName = GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3].ToString();
                        objbo.REMARK2 = txt.Text.ToString();
                        objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                        objbo.Status = "APPROVED_BY_HR";
                        objbo.proxy = Convert.ToString(Session["Proxy"]);
                        HiddenField Hdf = GrvPendingforApproval.Rows[gvrow.RowIndex].FindControl("HiddenField1") as HiddenField;



                        // objbo.LETTERID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);
                        if (Convert.ToBoolean(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2] == DBNull.Value))
                        {
                        }
                        else
                        {
                            objbo.LETTERID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);
                        }
                        //string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");                       
                        bool retVal = objbal.Update_Status(objbo);
                        if (retVal == true)
                        {
                            OEMailBO.RoleName = "President";
                            OEMailBO.userName = GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1].ToString();
                            OEMailBO.Status1 = "Approved";
                            DataSet ds = OEMailBAL.GetEMPDetailsPresident(OEMailBO);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string Attachment = "";
                                //string Attachment = GetEmailDoc(OEMailBO.userName, objbo.GrantID);
                                //string Attachment = FuncReplaceWord(OEMailBO.userName, objbo.GrantID, objbo.LETTERID);
                                //SendMail("Approved", ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                if (ds.Tables[0].Rows[0]["EMP"].ToString() == "")
                                {
                                    Attachment = Server.MapPath("~/ExcelFormat/User_Manual.xlsx");
                                    SendMail_1(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4].ToString(), "New Employee", "New", Attachment, ds.Tables[0].Rows[0]["EMAILID"].ToString(), GrantName, GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[5].ToString());
                                }
                                //Attachment = FuncReplaceWord(OEMailBO.userName, objbo.GrantID, objbo.LETTERID);
                                Attachment = Server.MapPath(Hdf.Value.ToString());
                                SendMail_1(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4].ToString(), "Grant", "Approve by president", Attachment, ds.Tables[0].Rows[0]["EMAILID"].ToString(), GrantName, GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[5].ToString());
                            }
                        }
                    }
                }
                FunGetApprovalRecords();
                bind_PR_all_count();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Grant has been approved.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been approved";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void BtnBulkReject_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                {
                    var checkbox = gvrow.FindControl("CheckBox1") as System.Web.UI.WebControls.CheckBox;
                    if (checkbox.Checked)
                    {
                        objbo.GrantID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                        TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("TxtRemarkPend_Approval");
                        objbo.REMARK2 = txt.Text.ToString();
                        objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                        objbo.Status = "REJECTED_BY_PRESIDENT";
                        objbo.proxy = Convert.ToString(Session["Proxy"]);
                        string GrantName = GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3].ToString();
                        //string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                        bool retVal = objbal.Update_Status(objbo);
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
                                SendMail_1(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4].ToString(), "Grant", "Reject by president", Attachment1, ds.Tables[0].Rows[0]["EMAILID"].ToString(), GrantName, GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[5].ToString());
                            }
                        }
                    }
                }
                FunGetApprovalRecords();
                bind_PR_all_count();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Grant has been rejected, sent to Admin for the correction.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been rejected, sent to Admin for the correction.";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        public void bind_PR_all_count()
        {
            PresidentBO PresidentBO = new PresidentBO();
            PresidentBO.ECode = Convert.ToString(Session["ECODE"]);
            DataSet ds = objbal.Get_President_all_count(PresidentBO);
            if (ds.Tables.Count > 0)
            {
                lbltotal_grant.Text = ds.Tables[0].Rows[0][0].ToString();
                lbl_approved.Text = ds.Tables[2].Rows[0][0].ToString();
                lbl_rejected.Text = ds.Tables[3].Rows[0][0].ToString();
                lbl_approval_pending.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                lbltotal_grant.Text = "0";
                lbl_approved.Text = "0";
                lbl_rejected.Text = "0";
                lbl_approval_pending.Text = "0";
            }
        }

        protected void GrvReject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvReject.PageIndex = e.NewPageIndex;
            if (ViewState["RejectRecords"] != null)
            {
                System.Data.DataTable Dt = (System.Data.DataTable)ViewState["RejectRecords"];
                if (Dt.Rows.Count > 0)
                {
                    GrvReject.DataSource = ViewState["RejectRecords"];
                    GrvReject.DataBind();
                }
            }
            else
                FunGetApprovalRecords();
        }

        protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvApproved.PageIndex = e.NewPageIndex;
            if (ViewState["ApprovedRecords"] != null)
            {
                System.Data.DataTable Dt = (System.Data.DataTable)ViewState["ApprovedRecords"];
                if (Dt.Rows.Count > 0)
                {
                    GrvApproved.DataSource = ViewState["ApprovedRecords"];
                    GrvApproved.DataBind();
                }
            }
            else
                FunGetApprovalRecords();
        }

        protected void GrvPendingforApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvPendingforApproval.PageIndex = e.NewPageIndex;
            if (ViewState["PendingforApprovalRecords"] != null)
            {
                System.Data.DataTable Dt = (System.Data.DataTable)ViewState["PendingforApprovalRecords"];
                if (Dt.Rows.Count > 0)
                {
                    GrvPendingforApproval.DataSource = ViewState["PendingforApprovalRecords"];
                    GrvPendingforApproval.DataBind();
                }
            }
            else
                FunGetApprovalRecords();
        }

        public void SendMail(string status, string Empname, string ToEmailID, string Attachment)
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
                //throw ex;
            }
        }

        public string GetEmailDoc(string EMPcode, int GrantID)
        {
            DataSet ds = new DataSet();
            string FilePath = Server.MapPath(@"~\OutputReport\EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".pdf");
            try
            {

                #region "--------------------Creating RDLC report--------------------------"
                ReportViewer ReportViewer1 = new ReportViewer();
                ReportDataSource rds = new ReportDataSource();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\ReportDesigns\rpt_Mail.rdlc");
                //-----------------------------Image Part---------------------------

                string imageLogo = "";
                string imageFooter = "";
                string imageSign = "";
                string imageDesignation = "";
                ReportParameter rptLogo = null;
                ReportParameter rptFooter = null;
                ReportParameter rptSign = null;
                ReportParameter rptDesignation = null;
                ReportParameter rp = null;
                ReportViewer1.LocalReport.EnableExternalImages = true;

                DataSet DS1 = new DataSet();
                objbo.LETTERNAME = "Grant Letter";
                DS1 = objbal.GetReportDesign(objbo);
                if (DS1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= DS1.Tables[0].Rows.Count - 1; i++)
                    {
                        if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Header")
                        {
                            imageLogo = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                            rptLogo = new ReportParameter("rptLogo", imageLogo);
                        }

                        if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Footer")
                        {
                            imageFooter = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                            rptFooter = new ReportParameter("rptFooter", imageFooter);
                        }

                        if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Signature")
                        {
                            imageSign = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                            rptSign = new ReportParameter("rptScannedSignatureImg", imageSign);
                        }

                        if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Designation")
                        {
                            imageDesignation = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                            rptDesignation = new ReportParameter("rptDesignation", imageDesignation);
                        }

                        if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Content")
                        {
                            rp = new ReportParameter("rptLetterDate", DS1.Tables[0].Rows[i]["PATH"].ToString());
                        }
                    }
                    if (imageLogo == "")
                    {
                        imageLogo = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptLogo = new ReportParameter("rptLogo", imageLogo);
                    }

                    if (imageFooter == "")
                    {
                        imageFooter = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptFooter = new ReportParameter("rptFooter", imageFooter);
                    }

                    if (imageSign == "")
                    {
                        imageSign = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptSign = new ReportParameter("rptScannedSignatureImg", imageSign);
                    }

                    if (imageDesignation == "")
                    {
                        imageDesignation = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptDesignation = new ReportParameter("rptDesignation", imageDesignation);
                    }
                }

                //-----------------------Table Part----------------------
                objbo.EMPCODE = EMPcode.ToString();
                objbo.GrantID = GrantID;
                ds = objbal.GetEmpDetails_AdminPswd(objbo);
                if (ds.Tables.Count > 0)
                {
                    ReportParameter rp1 = new ReportParameter("rptTrancheCode", ds.Tables[0].Rows[0]["grant_name"].ToString());
                    ReportParameter rp2 = new ReportParameter("rptSrNo", ds.Tables[0].Rows[0]["grant_id"].ToString());
                    ReportParameter rp3 = new ReportParameter("rptEmployeeFullName", ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                    ReportParameter rp4 = new ReportParameter("rptEmpCode", ds.Tables[0].Rows[0]["ECODE"].ToString());
                    string[] Firstname = ds.Tables[0].Rows[0]["EMP_NAME"].ToString().Split(new char[] { ' ' });
                    ReportParameter rp5 = new ReportParameter("rptEmplyeeFirstName", Firstname[0].ToString() + ' ' + Firstname[1].ToString());
                    ReportParameter rp6 = new ReportParameter("rptNoOptionsGranted", ds.Tables[0].Rows[0]["no_of_options"].ToString());
                    ReportParameter rp7 = new ReportParameter("rptGrantPrice", ds.Tables[0].Rows[0]["Grant_Price"].ToString());
                    ReportParameter rp8 = new ReportParameter("rptGrantDate", ds.Tables[0].Rows[0]["Grant_Date"].ToString());
                    // ReportParameter rp9 = new ReportParameter("rptDesignation", ds.Tables[0].Rows[0]["rolename"].ToString());
                    ReportParameter rp10 = null;
                    ReportParameter rp11 = null;
                    ReportParameter rp12 = null;

                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        string Type = (i + 1).ToString();
                        switch (Type)
                        {
                            case "1":
                                {
                                    //rp10 = new ReportParameter("rptGrantDate1", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                    rp10 = new ReportParameter("rptGrantDate1", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString());
                                }
                                break;
                            case "2":
                                {
                                    //rp11 = new ReportParameter("rptGrantDate2", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years and the balance");
                                    rp11 = new ReportParameter("rptGrantDate2", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString());

                                }
                                break;
                            case "3":
                                {
                                    // rp12 = new ReportParameter("rptGrantDate3", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                    rp12 = new ReportParameter("rptGrantDate3", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString());
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    if (rp10 == null)
                    {
                        rp10 = new ReportParameter("rptGrantDate1", "");
                    }
                    if (rp11 == null)
                    {
                        rp11 = new ReportParameter("rptGrantDate2", "");
                    }

                    if (rp12 == null)
                    {
                        rp12 = new ReportParameter("rptGrantDate3", "");
                    }

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptLogo, rptFooter, rptSign, rptDesignation, rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp10, rp11, rp12 });
                    rds = new ReportDataSource("DT_GRANT_DETAILS", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.Refresh();
                }

                #endregion

                #region "--------Report download to Application route----------------"

                Microsoft.Reporting.WebForms.Warning[] warnings;
                //string[] streamids;
                //string mimeType;
                //string encoding;
                //string filenameExtension;

                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                if (ReportViewer1.LocalReport.ReportPath != null)
                {
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //byte[] bytes = ReportViewer1.LocalReport.Render(
                    //    "WORD", null, out mimeType, out encoding, out filenameExtension,
                    //    out streamids, out warnings);


                    //HttpContext.Current.Response.Expires = -1;
                    //HttpContext.Current.Response.Cache.SetNoStore();
                    //HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
                    //using (System.IO.FileStream fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Create))
                    //{
                    //    fs.Write(bytes, 0, bytes.Length);
                    //}
                    //HttpContext.Current.Response.ContentType = "application/vnd.ms-word";
                    //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=EmailDoc_EmpId_" + EMPcode.ToString() + ".docx");
                    //HttpContext.Current.Response.WriteFile(FilePath);
                    ////HttpContext.Current.Response.End();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();

                    //Export the RDLC Report to Byte Array.
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);
                    //---------------------------------------------------------------------------------
                    //Download the RDLC Report in Word, Excel, PDF and Image formats.
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.Charset = "";
                    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    //Response.ContentType = contentType;
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=EmailDoc_EmpId_" + EMPcode.ToString() + ".doc");
                    //Response.BinaryWrite(bytes);
                    ////Response.WriteFile(FilePath);
                    //Response.Flush();
                    ////Response.End();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                }

                #endregion
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                // throw ex;
                return FilePath;
            }
            finally
            {

            }
            return FilePath;
        }

        protected void GrvPendingforApproval_PreRender(object sender, EventArgs e)
        {
            objbo.EMPCODE = Convert.ToString(Session["ECODE"]);
            DataSet ds = objbal.FunGetApprovalRecords(objbo);
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvPendingforApproval.UseAccessibleHeader = true;
                GrvPendingforApproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                GrvPendingforApproval.DataSource = ds.Tables[0];
                GrvPendingforApproval.DataBind();


                //  GrvPendingforApproval.UseAccessibleHeader = true;
                //  GrvPendingforApproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            objbo.EMPCODE = Convert.ToString(Session["ECODE"]);
            DataSet ds = objbal.FunGetApprovalRecords(objbo);
            if (ds.Tables[1].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            //else
            //{
            //    GrvApproved.DataSource = ds.Tables[1];
            //    GrvApproved.DataBind();


            //   // GrvApproved.UseAccessibleHeader = true;
            //   // GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
        }

        protected void GrvReject_PreRender(object sender, EventArgs e)
        {
            objbo.EMPCODE = Convert.ToString(Session["ECODE"]);
            DataSet ds = objbal.FunGetApprovalRecords(objbo);
            if (ds.Tables[2].Rows.Count > 0)
            {

                GrvReject.UseAccessibleHeader = true;
                GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            //else
            //{
            //    GrvReject.DataSource = ds.Tables[2];
            //    GrvReject.DataBind();


            //    GrvReject.UseAccessibleHeader = true;
            //    GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
        }


        //public string FuncReplaceWord(string EMPcode, int GrantID, int LetterID)
        //{
        //    string sourceFile = "";
        //    string destinationFile = System.IO.Path.Combine(Server.MapPath("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_GrantID_" + GrantID.ToString() + ".docx"));
        //    string PdfPathOutput = Server.MapPath("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf");

        //    try
        //    {
        //        DataSet Ds1 = new DataSet();
        //        objbo.FILEPATH = "OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_GrantID_" + GrantID.ToString() + ".docx";
        //        objbo.GrantID = GrantID;
        //        objbo.LETTERID = LetterID;
        //        Ds1 = objbal.GetLetterPath(objbo);
        //        if (Ds1.Tables[0].Rows.Count > 0 && Ds1 != null)
        //        {
        //            sourceFile = System.IO.Path.Combine(Server.MapPath(Ds1.Tables[0].Rows[0][0].ToString()));
        //            File.Copy(sourceFile, destinationFile, true);

        //            DataSet ds = new DataSet();
        //            objbo.EMPCODE = EMPcode.ToString();
        //            objbo.GrantID = GrantID;
        //            ds = objbal.report(objbo);
        //            if (ds.Tables.Count > 0)
        //            {
        //                //Editing Docx file with Dynamic data from database.
        //                using (WordprocessingDocument doc =
        //                    WordprocessingDocument.Open(destinationFile, true))
        //                {
        //                    ///////////////////////////////Edit/////////////////////////////
        //                    string docText = null;
        //                    string docP = null;
        //                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
        //                    {
        //                        docText = sr.ReadToEnd();
        //                    }

        //                    //////////////////////////////-Letter Edit Keywords///////////////////////////////
        //                    if (docText.Contains("@Emp_Code"))
        //                    {
        //                        Regex regexText = new Regex("@Emp_Code");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@TodayDate"))
        //                    {
        //                        Regex regexText = new Regex("@TodayDate");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@Emp_Name"))
        //                    {
        //                        Regex regexText = new Regex("@Emp_Name");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
        //                    }

        //                    if (docText.Contains("@Grant_Date"))
        //                    {
        //                        Regex regexText = new Regex("@Grant_Date");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Date"].ToString());
        //                    }
        //                    if (docText.Contains("@Tranch_Name"))
        //                    {
        //                        Regex regexText = new Regex("@Tranch_Name");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_name"].ToString());
        //                    }
        //                    if (docText.Contains("@No_Of_Options"))
        //                    {
        //                        Regex regexText = new Regex("@No_Of_Options");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
        //                    }
        //                    if (docText.Contains("@Share_Price"))
        //                    {
        //                        Regex regexText = new Regex("@Share_Price");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Price"].ToString());
        //                    }
        //                    if (docText.Contains("@SrNo"))
        //                    {
        //                        Regex regexText = new Regex("@SrNo");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_id"].ToString());
        //                    }

        //                    if (docText.Contains("@Title"))
        //                    {
        //                        Regex regexText = new Regex("@Title");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@Band"))
        //                    {
        //                        Regex regexText = new Regex("@Band");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@Designation"))
        //                    {
        //                        Regex regexText = new Regex("@Designation");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@Location"))
        //                    {
        //                        Regex regexText = new Regex("@Location");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@Department"))
        //                    {
        //                        Regex regexText = new Regex("@Department");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@Function"))
        //                    {
        //                        Regex regexText = new Regex("@Function");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    if (docText.Contains("@CostCenter"))
        //                    {
        //                        Regex regexText = new Regex("@CostCenter");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //                    {
        //                        string Type = (i + 1).ToString();
        //                        switch (Type)
        //                        {
        //                            case "1":
        //                                {
        //                                    if (docText.Contains("@Vest_Date1"))
        //                                    {
        //                                        Regex regexText = new Regex("@Vest_Date1");
        //                                        docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString());
        //                                    }
        //                                }
        //                                break;
        //                            case "2":
        //                                {
        //                                    if (docText.Contains("@Vest_Date2"))
        //                                    {
        //                                        Regex regexText = new Regex("@Vest_Date2");
        //                                        docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString());
        //                                    }

        //                                }
        //                                break;
        //                            case "3":
        //                                {
        //                                    if (docText.Contains("@Vest_Date3"))
        //                                    {
        //                                        Regex regexText = new Regex("@Vest_Date3");
        //                                        docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString());
        //                                    }
        //                                }
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                    }



        //                    //////////////////////////////////////////////////////////////////////////s


        //                    if (docText.Contains("No. of Options"))
        //                    {
        //                        Regex regexText = new Regex("No. of Options");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
        //                    }

        //                    if (docText.Contains("In Words"))
        //                    {
        //                        Regex regexText = new Regex("In Words");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_name"].ToString());
        //                    }

        //                    if (docText.Contains("No of Shares"))
        //                    {
        //                        Regex regexText = new Regex("No of Shares");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
        //                    }

        //                    if (docText.Contains("&lt;"))
        //                    {
        //                        Regex regexText = new Regex("&lt;");
        //                        docText = regexText.Replace(docText, "");
        //                    }

        //                    if (docText.Contains("&gt;"))
        //                    {
        //                        Regex regexText = new Regex("&gt;");
        //                        docText = regexText.Replace(docText, "");
        //                    }

        //                    if (docText.Contains("Emp Name"))
        //                    {
        //                        Regex regexText = new Regex("Emp Name");
        //                        docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
        //                    }

        //                    if (docText.Contains("Emp Code"))
        //                    {
        //                        Regex regexText = new Regex("Emp Code");
        //                        docText = regexText.Replace(docText, EMPcode.ToString());
        //                    }

        //                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
        //                    {
        //                        sw.Write(docText);
        //                        sw.Close();
        //                    }
        //                }

        //                //Pdf Generate using Docx file.
        //                using (Process pdfprocess = new Process())
        //                {
        //                    pdfprocess.StartInfo.UseShellExecute = true;
        //                    pdfprocess.StartInfo.LoadUserProfile = true;
        //                    pdfprocess.StartInfo.FileName = "soffice.exe";
        //                    pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + destinationFile;
        //                    pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("OutputReport/");
        //                    pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //                    pdfprocess.Start();
        //                    if (!pdfprocess.WaitForExit(1000 * 60 * 1))
        //                    {
        //                        pdfprocess.Kill();
        //                    }
        //                    pdfprocess.Close();
        //                }


        //                //Password Encrypt//////////////////
        //                string PdfPathInput = destinationFile.Replace(".docx", ".pdf");
        //                if (!File.Exists(PdfPathInput))
        //                {
        //                    return "";
        //                }

        //                using (Stream input = new FileStream(PdfPathInput, FileMode.Open, FileAccess.Read, FileShare.Read))
        //                using (Stream output = new FileStream(PdfPathOutput, FileMode.Create, FileAccess.Write, FileShare.None))
        //                {
        //                    if (!File.Exists(PdfPathOutput))
        //                    {
        //                        return "";
        //                    }
        //                    PdfReader reader = new PdfReader(input);
        //                    PdfEncryptor.Encrypt(reader, output, true, EMPcode, EMPcode, PdfWriter.ALLOW_PRINTING);
        //                    output.Close();
        //                    input.Close();
        //                }

        //            }
        //        }
        //        else
        //        {
        //            Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), "Letter not found for Grant Id-" + GrantID.ToString(), "Letter not found for Grant Id-" + GrantID.ToString());
        //            PdfPathOutput = "";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // throw;
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //        PdfPathOutput = "";
        //    }
        //    return PdfPathOutput;
        //}

        public string FuncReplaceWord(string EMPcode, int GrantID, int LetterID)
        {
            string sourceFile = "";
            string destinationFile = System.IO.Path.Combine(Server.MapPath("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_GrantID_" + GrantID.ToString() + ".docx"));
            string PdfPathOutput = Server.MapPath("OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf");
            string AdminPwd = "";
            try
            {
                DataSet Ds1 = new DataSet();
                objbo.FILEPATH = "OutputReport/EmailDoc_EmpId_" + EMPcode.ToString() + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
                objbo.GrantID = GrantID;
                objbo.LETTERID = LetterID;
                Ds1 = objbal.GetLetterPath(objbo);
                if (Ds1.Tables[0].Rows.Count > 0 && Ds1 != null)
                {
                    sourceFile = System.IO.Path.Combine(Server.MapPath(Ds1.Tables[0].Rows[0][0].ToString()));
                    File.Copy(sourceFile, destinationFile, true);

                    DataSet ds = new DataSet();
                    objbo.EMPCODE = EMPcode.ToString();
                    objbo.GrantID = GrantID;
                    ds = objbal.GetEmpDetails_AdminPswd(objbo);
                    string pan_passward = ds.Tables[0].Rows[0]["PAN_CARD_NUMBER"].ToString();
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            AdminPwd = ds.Tables[2].Rows[0]["PDF_PASSWORD"].ToString();
                        }

                        //Editing Docx file with Dynamic data from database.
                        using (WordprocessingDocument doc =
                            WordprocessingDocument.Open(destinationFile, true))
                        {
                            ///////////////////////////////Edit/////////////////////////////
                            string docText = null;
                            string docP = null;
                            using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                            {
                                docText = sr.ReadToEnd();
                            }

                            //////////////////////////////-Letter Edit Keywords///////////////////////////////
                            if (docText.Contains("@Emp_Code"))
                            {
                                Regex regexText = new Regex("@Emp_Code");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@TodayDate"))
                            {
                                Regex regexText = new Regex("@TodayDate");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Emp_Name"))
                            {
                                Regex regexText = new Regex("@Emp_Name");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                            }

                            if (docText.Contains("@Grant_Date"))
                            {
                                Regex regexText = new Regex("@Grant_Date");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Date"].ToString().Trim());
                            }
                            if (docText.Contains("@Tranch_Name"))
                            {
                                Regex regexText = new Regex("@Tranch_Name");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_name"].ToString());
                            }
                            if (docText.Contains("@No_Of_Options"))
                            {
                                Regex regexText = new Regex("@No_Of_Options");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
                            }
                            if (docText.Contains("@Share_Price"))
                            {
                                Regex regexText = new Regex("@Share_Price");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Price"].ToString());
                            }

                            if (docText.Contains("@FMV_Price"))
                            {
                                Regex regexText = new Regex("@FMV_Price");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["Grant_Price"].ToString());
                            }
                            if (docText.Contains("@SrNo"))
                            {
                                Regex regexText = new Regex("@SrNo");
                                docText = regexText.Replace(docText, Ds1.Tables[1].Rows[0][0].ToString());
                            }

                            if (docText.Contains("@Title"))
                            {
                                Regex regexText = new Regex("@Title");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Band"))
                            {
                                Regex regexText = new Regex("@Band");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Designation"))
                            {
                                Regex regexText = new Regex("@Designation");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Location"))
                            {
                                Regex regexText = new Regex("@Location");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Department"))
                            {
                                Regex regexText = new Regex("@Department");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@Function"))
                            {
                                Regex regexText = new Regex("@Function");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            if (docText.Contains("@CostCenter"))
                            {
                                Regex regexText = new Regex("@CostCenter");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            string Vestdate1 = "";
                            string Vestdate2 = "";
                            string Vestdate3 = "";
                            string Vestdate4 = "";
                            string Vestdate5 = "";
                            string Vestdate6 = "";

                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                string Type = (i + 1).ToString();
                                switch (Type)
                                {
                                    case "1":
                                        {
                                            if (docText.Contains("@Vest_Date1"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date1");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate1 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); //+ " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    case "2":
                                        {
                                            if (docText.Contains("@Vest_Date2"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date2");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years and the balance");
                                                Vestdate2 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }

                                        }
                                        break;
                                    case "3":
                                        {
                                            if (docText.Contains("@Vest_Date3"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date3");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate3 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    case "4":
                                        {
                                            if (docText.Contains("@Vest_Date4"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date4");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate4 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    case "5":
                                        {
                                            if (docText.Contains("@Vest_Date5"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date5");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate5 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }

                                        }
                                        break;
                                    case "6":
                                        {
                                            if (docText.Contains("@Vest_Date6"))
                                            {
                                                //Regex regexText = new Regex("@Vest_Date6");
                                                //docText = regexText.Replace(docText, ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                                                Vestdate6 = ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString(); // + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years";
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }


                            if (Vestdate1 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date1");
                                docText = regexText.Replace(docText, Vestdate1);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date1");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate2 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date2");
                                docText = regexText.Replace(docText, Vestdate2);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date2");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate3 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date3");
                                docText = regexText.Replace(docText, Vestdate3);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date3");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate4 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date4");
                                docText = regexText.Replace(docText, Vestdate4);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date4");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate5 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date5");
                                docText = regexText.Replace(docText, Vestdate5);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date5");
                                docText = regexText.Replace(docText, "");
                            }

                            if (Vestdate6 != "")
                            {
                                Regex regexText = new Regex("@Vest_Date6");
                                docText = regexText.Replace(docText, Vestdate6);
                            }
                            else
                            {
                                Regex regexText = new Regex("@Vest_Date6");
                                docText = regexText.Replace(docText, "");
                            }
                            //////////////////////////////////////////////////////////////////////////s


                            if (docText.Contains("No. of Options"))
                            {
                                Regex regexText = new Regex("No. of Options");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
                            }

                            if (docText.Contains("In Words"))
                            {
                                Regex regexText = new Regex("In Words");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["grant_name"].ToString());
                            }

                            if (docText.Contains("No of Shares"))
                            {
                                Regex regexText = new Regex("No of Shares");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["no_of_options"].ToString());
                            }

                            if (docText.Contains("&lt;"))
                            {
                                Regex regexText = new Regex("&lt;");
                                docText = regexText.Replace(docText, "");
                            }

                            if (docText.Contains("&gt;"))
                            {
                                Regex regexText = new Regex("&gt;");
                                docText = regexText.Replace(docText, "");
                            }

                            if (docText.Contains("Emp Name"))
                            {
                                Regex regexText = new Regex("Emp Name");
                                docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                            }

                            if (docText.Contains("Emp Code"))
                            {
                                Regex regexText = new Regex("Emp Code");
                                docText = regexText.Replace(docText, EMPcode.ToString());
                            }

                            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                            {
                                sw.Write(docText);
                                sw.Close();
                            }
                        }

                        #region pdf generate using docx file.

                        using (Process pdfprocess = new Process())
                        {
                            pdfprocess.StartInfo.UseShellExecute = true;
                            pdfprocess.StartInfo.LoadUserProfile = true;
                            pdfprocess.StartInfo.FileName = "soffice.exe";
                            pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + destinationFile;
                            pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("outputreport/");
                            pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            pdfprocess.Start();
                            if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                            {
                                pdfprocess.Kill();
                            }
                            pdfprocess.Close();
                        }
                        #endregion

                        string PdfPathInput = destinationFile.Replace(".docx", ".pdf");

                        #region "Generate PDF using Interop.Word"
                        //var appWord = new Application();
                        //if (appWord.Documents != null)
                        //{
                        //    var wordDocument = appWord.Documents.Open(destinationFile);
                        //    string pdfDocName = PdfPathInput;
                        //    if (wordDocument != null)
                        //    {
                        //        wordDocument.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                        //        wordDocument.Close();
                        //    }
                        //    appWord.Quit();
                        //}
                        #endregion

                        //Password Encrypt//////////////////

                        if (!File.Exists(PdfPathInput))
                        {
                            return "";
                        }

                        using (Stream input = new FileStream(PdfPathInput, FileMode.Open, FileAccess.Read, FileShare.Read))
                        using (Stream output = new FileStream(PdfPathOutput, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            if (!File.Exists(PdfPathOutput))
                            {
                                return "";
                            }
                            PdfReader reader = new PdfReader(input);
                            //PdfEncryptor.Encrypt(reader, output, true, EMPcode, EMPcode, PdfWriter.ALLOW_PRINTING);
                            PdfEncryptor.Encrypt(reader, output, true, pan_passward, AdminPwd, PdfWriter.ALLOW_PRINTING);
                            output.Close();
                            input.Close();
                        }

                    }
                }
                else
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), "Letter not found for Grant Id-" + GrantID.ToString(), "Letter not found for Grant Id-" + GrantID.ToString());
                    PdfPathOutput = "";
                }

            }
            catch (Exception ex)
            {
                // throw;
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                PdfPathOutput = "";
            }
            return PdfPathOutput;
        }

        public void SendMail_1(string username, string type, string subtype, string Attachment, string Email, string GrantName, string GrantPrice)
        {
            string Mail_Functional = System.Configuration.ConfigurationManager.AppSettings["SendMail_Functionality"];
            if (Mail_Functional == "ON")
            {
                cEmailEntityRequest emailreq = new cEmailEntityRequest();
                EMailBO eMailBO = new EMailBO();
                eMailBO.Attachment = Attachment;

                string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
                string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
                string Mail_To = System.Configuration.ConfigurationManager.AppSettings["Mail_To"];

                OEMailBO.Em_Action = "SendEmail";
                OEMailBO.Em_Type = type;
                OEMailBO.Em_Sub_Type = subtype;
                emailreq.EmailEntity = OEMailBO;
                DataSet ds = OEMailBAL.insertEmail(emailreq);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
                        String SessionCheck = Convert.ToString(Session["UserName"]);
                        String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
                        //body = body.Replace("{{User}}", SessionCheck);
                        body = body.Replace("@To", username);
                        body = body.Replace("@From", Convert.ToString(Session["UserName"]));
                        body = body.Replace("@GrantName", GrantName);
                        body = body.Replace("@FMVPrice", GrantPrice);

                        string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
                        ccMailID = ccMailID.Replace(";", ",");
                        string[] CCMailId = ccMailID.Split(',');
                        string frommailId = UserMailID;// ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
                        string ToMailId = Mail_To;// "Prashant.shinde@cloverinfotech.com";

                        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        message.From = new MailAddress(frommailId);
                        message.To.Add(new MailAddress(ToMailId));
                        foreach (string CCEmail in CCMailId)
                        {
                            if (CCEmail != "")
                            {
                                message.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            }
                        }
                        message.Subject = mailSubject;
                        message.IsBodyHtml = true;
                        message.Body = body;
                        if (!string.IsNullOrEmpty(eMailBO.Attachment))
                        {
                            Attachment atdoc = new Attachment(eMailBO.Attachment);
                            message.Attachments.Add(atdoc);
                        }

                        smtp.Port = 25;
                        smtp.Host = "email.cloverinfotech.com";
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(UserMailID, UserPassword);

                        //Comeented Temporary

                        smtp.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                    //throw ex;
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
            string FileName = "PRESIDENT_REPORT" + DateTime.Now + ".xls";
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

        protected void GrvApproved_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvApproved.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(GrvApproved.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);

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
        }

        protected void GrvReject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvReject.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(GrvReject.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
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
        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";

            string filename = "PRESIDENT_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdData.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A2, 10f, 10f, 10f, 0f);
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
            System.Data.DataTable ds = (System.Data.DataTable)ViewState["GrvPendingforApproval_app_rej"];
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
        protected void lb_download_Click(object sender, EventArgs e)
        {
            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            if (System.IO.File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
            {
                ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                ViewState["filepath"] = filename.Replace("~/", "");
            }
            else
            {

                Common.ShowJavascriptAlert("File is not uploded for selected FMV.");
            }
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                //var  filePath = Request.Form["__EVENTARGUMENT"];
                string filePath = ViewState["filepath"].ToString();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                if (row != null)
                {
                    int rowindex = row.RowIndex;
                    HiddenField Hdf = GrvPendingforApproval.Rows[rowindex].FindControl("HiddenField1") as HiddenField;

                    if (System.IO.Path.GetExtension(Hdf.Value.ToString()).ToString() == ".pdf")
                    {
                        string Path = Hdf.Value.ToString().Replace(".docx", ".pdf");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2('" + Path + "');", true);
                    }
                }
                else
                {
                    Common.ShowJavascriptAlert("File is not uploded");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}