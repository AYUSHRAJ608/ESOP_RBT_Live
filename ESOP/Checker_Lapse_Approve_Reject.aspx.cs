using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using it = iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;

namespace ESOP
{
    public partial class Checker_Lapse_Approve_Reject : System.Web.UI.Page
    {
        HrapprovalBO objbo = new HrapprovalBO();
        HrapprovalBAL objbal = new HrapprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        Grant_CorrectionBO objBO = new Grant_CorrectionBO();
        Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
        PresidentBO PresidentBO = new PresidentBO();
        PresidentBAL PresidentBAL = new PresidentBAL();
        CultureInfo CInfo = new CultureInfo("hi-IN");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bind_approval_data_checker();
                //bind_checker_all_count();
            }

            bind_approval_data_checker();
            bind_checker_all_count();
        }

        private void bind_checker_all_count()
        {
            DataSet ds = objbal.get_chcker_all_count_Lapse(objbo);
            if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
            {
                lbl_approved.Text = ds.Tables[2].Rows[0][0].ToString();
                lbl_rejected.Text = ds.Tables[3].Rows[0][0].ToString();
                lbl_approval_pending.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                lbl_approved.Text = "0";
                lbl_rejected.Text = "0";
                lbl_approval_pending.Text = "0";
            }
        }

        private void bind_approval_data_checker()
        {
            try
            {
                DataSet ds = objbal.get_checker_approval_date_lapse(objbo);

                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdpendingapproval.DataSource = ds.Tables[0];
                        grdpendingapproval.DataBind();
                    }
                    else
                    {
                        grdpendingapproval.DataSource = ds.Tables[0];
                        grdpendingapproval.DataBind();
                        btn_bulkApprove.Visible = false;
                        btn_bulkReject.Visible = false;

                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        grdapproval.DataSource = ds.Tables[1];
                        grdapproval.DataBind();
                    }
                    else
                    {
                        grdapproval.DataSource = ds.Tables[1];
                        grdapproval.DataBind();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        grdreject.DataSource = ds.Tables[2];
                        grdreject.DataBind();
                    }
                    else
                    {
                        grdreject.DataSource = ds.Tables[2];
                        grdreject.DataBind();
                    }
                }
                else
                {
                    grdpendingapproval.DataSource = null;
                    grdpendingapproval.DataBind();
                    ViewState["PendingforApprovalRecords"] = null;


                    grdapproval.DataSource = null;
                    grdapproval.DataBind();
                    ViewState["ApprovedRecords"] = null;

                    grdreject.DataSource = null;
                    grdreject.DataBind();
                    ViewState["RejectRecords"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }


        public void SendMail_2(string status, string Empname, string ToEmailID, string Attachment)
        {
            try
            {

                EMailBO eMailBO = new EMailBO();
                EMailBAL eMailBAL = new EMailBAL();
                if (status == "Approved")
                {
                    eMailBO.userName = Empname;
                    eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/HRApproval.html");
                    eMailBO.EmailID = ToEmailID;//multple mail id
                    eMailBO.subject = "ESOP-Grant approved by HR.";
                    eMailBO.Status1 = status;
                }
                else
                {
                    eMailBO.userName = Empname;
                    eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/HRReject.html");
                    eMailBO.EmailID = ToEmailID;//multple mail id
                    eMailBO.subject = "ESOP-Grant rejected by HR.";
                    eMailBO.Status1 = status;

                }
                eMailBO.Attachment = ""; //Attachment;
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

        protected void BtnGrvReject_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
                int rowindex = row.RowIndex;

                CheckBox Chk = (CheckBox)row.FindControl("chk");

                if (Chk.Checked)
                {
                    Label txt = (Label)row.FindControl("lblLBV");
                    string LBV = txt.Text.Replace(",", "");

                    Label txt1 = (Label)row.FindControl("lblLAV");
                    string LAV = txt1.Text.Replace(",", "");

                    TextBox txt2 = (TextBox)row.FindControl("TxtRemark");
                    string Remark = txt2.Text.Replace(",", "");

                    //Label txt3 = (Label)gvrow.FindControl("lblLapseDate");
                    //string LapseDate = txt3.Text.Replace(",", "");

                    if (/*(Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV)) != 0 && (Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV)) != 0 &&*/
                        Convert.ToString(Remark) != "")
                    {
                        HiddenField HdID = (HiddenField)row.FindControl("Hd_Id");
                        HdID.Value = HdID.Value.ToString().Replace(",", "");

                        HiddenField HdGrantID = (HiddenField)row.FindControl("hdnGrantID");
                        HdGrantID.Value = HdGrantID.Value.ToString().Replace(",", "");

                        HiddenField hdVestingID = (HiddenField)row.FindControl("hdnVestingID");
                        hdVestingID.Value = hdVestingID.Value.ToString().Replace(",", "");

                        HiddenField HdEmpCode = (HiddenField)row.FindControl("HdEmpCode");
                        HdEmpCode.Value = HdEmpCode.Value.ToString().Replace(",", "");

                        PresidentBO.Action = "REJECTED_BY_CHECKER";
                        PresidentBO.GRANT_ID = HdGrantID.Value.ToString().Trim();
                        PresidentBO.V_ID = HdID.Value.ToString().Trim();
                        PresidentBO.VestingD_ID = hdVestingID.Value.ToString().Trim();
                        PresidentBO.LBV = Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV);
                        PresidentBO.LAV = Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV);
                        PresidentBO.Remark = Convert.ToString(Remark).Trim();
                        //PresidentBO.LapseDate = DateTime.ParseExact(LapseDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                        PresidentBO.ECode = Convert.ToString(HdEmpCode.Value).Trim();
                        bool retVal = PresidentBAL.UPDATE_LAPS_CHECKER(PresidentBO);
                    }
                    bind_approval_data_checker();
                    bind_checker_all_count();
                }
                else
                {
                    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Please check atleast one checkbox";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void BtnGrvApprove_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
                int rowindex = row.RowIndex;

                CheckBox Chk = (CheckBox)row.FindControl("chk");

                if (Chk.Checked)
                {
                    Label txt = (Label)row.FindControl("lblLBV");
                    string LBV = txt.Text.Replace(",", "");

                    Label txt1 = (Label)row.FindControl("lblLAV");
                    string LAV = txt1.Text.Replace(",", "");

                    TextBox txt2 = (TextBox)row.FindControl("TxtRemark");
                    string Remark = txt2.Text.Replace(",", "");

                    Label txt3 = (Label)row.FindControl("lblLapseDate");
                    string LapseDate = txt3.Text.Replace(",", "");

                    if (/*(Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV)) != 0 && (Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV)) != 0 &&*/
                        Convert.ToString(Remark) != "" && Convert.ToString(LapseDate) != "")
                    {
                        HiddenField HdID = (HiddenField)row.FindControl("Hd_Id");
                        HdID.Value = HdID.Value.ToString().Replace(",", "");

                        HiddenField HdGrantID = (HiddenField)row.FindControl("hdnGrantID");
                        HdGrantID.Value = HdGrantID.Value.ToString().Replace(",", "");

                        HiddenField hdVestingID = (HiddenField)row.FindControl("hdnVestingID");
                        hdVestingID.Value = hdVestingID.Value.ToString().Replace(",", "");

                        HiddenField HdEmpCode = (HiddenField)row.FindControl("HdEmpCode");
                        HdEmpCode.Value = HdEmpCode.Value.ToString().Replace(",", "");

                        PresidentBO.Action = "APPROVED_BY_CHECKER";
                        PresidentBO.GRANT_ID = HdGrantID.Value.ToString().Trim();
                        PresidentBO.V_ID = HdID.Value.ToString().Trim();
                        PresidentBO.VestingD_ID = hdVestingID.Value.ToString().Trim();
                        PresidentBO.LBV = Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV);
                        PresidentBO.LAV = Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV);
                        PresidentBO.Remark = Convert.ToString(Remark).Trim();
                        PresidentBO.LapseDate = DateTime.ParseExact(LapseDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                        PresidentBO.ECode = Convert.ToString(HdEmpCode.Value).Trim();
                        bool retVal = PresidentBAL.UPDATE_LAPS_CHECKER(PresidentBO);
                    }
                    bind_approval_data_checker();
                    bind_checker_all_count();
                }
                else
                {
                    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Please check atleast one checkbox";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btn_bulkReject_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in grdpendingapproval.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        var checkbox = gvrow.FindControl("chk") as CheckBox;

                        if (checkbox.Checked)
                        {
                            Label txt = (Label)gvrow.FindControl("lblLBV");
                            string LBV = txt.Text.Replace(",", "");

                            Label txt1 = (Label)gvrow.FindControl("lblLAV");
                            string LAV = txt1.Text.Replace(",", "");

                            TextBox txt2 = (TextBox)gvrow.FindControl("TxtRemark");
                            string Remark = txt2.Text.Replace(",", "");

                            //Label txt3 = (Label)gvrow.FindControl("lblLapseDate");
                            //string LapseDate = txt3.Text.Replace(",", "");

                            if (/*(Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV)) != 0 && (Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV)) != 0 &&*/
                                Convert.ToString(Remark) != "")
                            {
                                HiddenField HdID = (HiddenField)gvrow.FindControl("Hd_Id");
                                HdID.Value = HdID.Value.ToString().Replace(",", "");

                                HiddenField HdGrantID = (HiddenField)gvrow.FindControl("hdnGrantID");
                                HdGrantID.Value = HdGrantID.Value.ToString().Replace(",", "");

                                HiddenField hdVestingID = (HiddenField)gvrow.FindControl("hdnVestingID");
                                hdVestingID.Value = hdVestingID.Value.ToString().Replace(",", "");

                                HiddenField HdEmpCode = (HiddenField)gvrow.FindControl("HdEmpCode");
                                HdEmpCode.Value = HdEmpCode.Value.ToString().Replace(",", "");

                                PresidentBO.Action = "REJECTED_BY_CHECKER";
                                PresidentBO.GRANT_ID = HdGrantID.Value.ToString().Trim();
                                PresidentBO.V_ID = HdID.Value.ToString().Trim();
                                PresidentBO.VestingD_ID = hdVestingID.Value.ToString().Trim();
                                PresidentBO.LBV = Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV);
                                PresidentBO.LAV = Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV);
                                PresidentBO.Remark = Convert.ToString(Remark).Trim();
                                //PresidentBO.LapseDate = DateTime.ParseExact(LapseDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                                PresidentBO.ECode = Convert.ToString(HdEmpCode.Value).Trim();
                                bool retVal = PresidentBAL.UPDATE_LAPS_CHECKER(PresidentBO);
                            }
                        }
                    }
                }
                bind_approval_data_checker();
                bind_checker_all_count();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in grdpendingapproval.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        var checkbox = gvrow.FindControl("chk") as CheckBox;

                        if (checkbox.Checked)
                        {
                            Label txt = (Label)gvrow.FindControl("lblLBV");
                            string LBV = txt.Text.Replace(",", "");

                            Label txt1 = (Label)gvrow.FindControl("lblLAV");
                            string LAV = txt1.Text.Replace(",", "");

                            TextBox txt2 = (TextBox)gvrow.FindControl("TxtRemark");
                            string Remark = txt2.Text.Replace(",", "");

                            Label txt3 = (Label)gvrow.FindControl("lblLapseDate");
                            string LapseDate = txt3.Text.Replace(",", "");

                            if (/*(Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV)) != 0 && (Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV)) != 0 &&*/
                                Convert.ToString(Remark) != "" && Convert.ToString(LapseDate) != "")
                            {
                                HiddenField HdID = (HiddenField)gvrow.FindControl("Hd_Id");
                                HdID.Value = HdID.Value.ToString().Replace(",", "");

                                HiddenField HdGrantID = (HiddenField)gvrow.FindControl("hdnGrantID");
                                HdGrantID.Value = HdGrantID.Value.ToString().Replace(",", "");

                                HiddenField hdVestingID = (HiddenField)gvrow.FindControl("hdnVestingID");
                                hdVestingID.Value = hdVestingID.Value.ToString().Replace(",", "");

                                HiddenField HdEmpCode = (HiddenField)gvrow.FindControl("HdEmpCode");
                                HdEmpCode.Value = HdEmpCode.Value.ToString().Replace(",", "");

                                PresidentBO.Action = "APPROVED_BY_CHECKER";
                                PresidentBO.GRANT_ID = HdGrantID.Value.ToString().Trim();
                                PresidentBO.V_ID = HdID.Value.ToString().Trim();
                                PresidentBO.VestingD_ID = hdVestingID.Value.ToString().Trim();
                                PresidentBO.LBV = Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV);
                                PresidentBO.LAV = Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV);
                                PresidentBO.Remark = Convert.ToString(Remark).Trim();
                                PresidentBO.LapseDate = DateTime.ParseExact(LapseDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                PresidentBO.ECode = Convert.ToString(HdEmpCode.Value).Trim();
                                bool retVal = PresidentBAL.UPDATE_LAPS_CHECKER(PresidentBO);
                            }
                        }
                    }
                }
                bind_approval_data_checker();
                bind_checker_all_count();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdpendingapproval_PreRender(object sender, EventArgs e)
        {
            //DataSet ds = objbal.get_hr_appraval_date(objbo);
            DataSet ds = objbal.get_checker_approval_date_lapse(objbo);

            if (ds.Tables[0].Rows.Count > 0)
            {

                grdpendingapproval.UseAccessibleHeader = true;
                grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdpendingapproval.DataSource = ds.Tables[0];
                grdpendingapproval.DataBind();


                //grdpendingapproval.UseAccessibleHeader = true;
                //grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdapproval_PreRender(object sender, EventArgs e)
        {
            //DataSet ds = objbal.get_hr_appraval_date(objbo);
            DataSet ds = objbal.get_checker_approval_date_lapse(objbo);

            if (ds.Tables[1].Rows.Count > 0)
            {

                grdapproval.UseAccessibleHeader = true;
                grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdreject_PreRender(object sender, EventArgs e)
        {
            //DataSet ds = objbal.get_hr_appraval_date(objbo);
            DataSet ds = objbal.get_checker_approval_date_lapse(objbo);

            if (ds.Tables[2].Rows.Count > 0)
            {
                grdreject.UseAccessibleHeader = true;
                grdreject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            //else
            //{
            //    grdreject.DataSource = ds.Tables[2];
            //    grdreject.DataBind();


            //    grdreject.UseAccessibleHeader = true;
            //    grdreject.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}

        }

        //protected void grdapproval_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dtrslt = (DataTable)Session["dirState"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdr"]) == "Asc")
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdr"] = "Desc";
        //        }
        //        else
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //            Session["sortdr"] = "Asc";
        //        }
        //        grdapproval.DataSource = dtrslt;
        //        grdapproval.DataBind();


        //    }
        //}

        //protected void grdreject_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dtrslt = (DataTable)Session["dirStateR"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdrR"]) == "Asc")
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdrR"] = "Desc";
        //        }
        //        else
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //            Session["sortdrR"] = "Asc";
        //        }
        //        grdreject.DataSource = dtrslt;
        //        grdreject.DataBind();


        //    }
        //}

        //protected void grdpendingapproval_Sorting(object sender, GridViewSortEventArgs e)
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
        //        grdpendingapproval.DataSource = dtrslt;
        //        grdpendingapproval.DataBind();


        //    }
        //}

        //protected void grdpendingapproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        grdpendingapproval.PageIndex = e.NewPageIndex;
        //        this.bind_approval_data_hr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void grdapproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        grdapproval.PageIndex = e.NewPageIndex;
        //        this.bind_approval_data_hr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void grdreject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        grdreject.PageIndex = e.NewPageIndex;
        //        this.bind_approval_data_hr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void SendMail_1(string username, string type)
        {
            cEmailEntityRequest emailreq = new cEmailEntityRequest();

            OEMailBO.Em_Action = "SendEmail";
            OEMailBO.Em_Type = "Grant";
            OEMailBO.Em_Sub_Type = type;
            emailreq.EmailEntity = OEMailBO;
            DataSet ds = OEMailBAL.insertEmail(emailreq);

            String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
            String SessionCheck = Convert.ToString(Session["UserName"]);
            String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
            //body = body.Replace("{{User}}", SessionCheck);
            body = body.Replace("{{To}}", username);
            body = body.Replace("{{UserName}}", Convert.ToString(Session["UserName"]));

            string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
            ccMailID = ccMailID.Replace(";", ",");
            string frommailId = ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
            string ToMailId = "Prashant.shinde@cloverinfotech.com";

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(frommailId);
            message.To.Add(new MailAddress(ToMailId));
            //message.CC.Add(ccMailID);
            message.Subject = mailSubject;
            message.IsBodyHtml = true;
            message.Body = body;

            smtp.Port = 25;
            smtp.Host = "email.cloverinfotech.com";
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("Prashant.shinde@cloverinfotech.com", "Shinde1234#");

            //Comeented Temporary
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }


        }

        protected void grdpendingapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdpendingapproval.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdpendingapproval.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
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
            if (e.CommandName == "download")
            {
                try
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string hd = (gvr.FindControl("HiddenField1") as HiddenField).Value;
                    string LtrFile = hd.ToString();

                    string filePath = Server.MapPath(LtrFile);
                    if (File.Exists(filePath))
                    {
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                        return;
                    }
                }
                catch (Exception)
                {
                }

            }
        }

        protected void grdapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdapproval.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
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

        protected void grdreject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdreject.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdreject.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
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
        protected void imgExportAudit_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(imgExportAudit);
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "HR_REPORT" + DateTime.Now + ".xls";
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

            string filename = "HR_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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
        protected void TxtLAV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
                int rowindex = row.RowIndex;

                HiddenField IsExpanded = row.FindControl("IsExpanded") as HiddenField;
                if (Request.Form[IsExpanded.UniqueID] != null)
                {
                    IsExpanded.Value = Request.Form[IsExpanded.UniqueID].Replace(",", "");
                }

                TextBox TxtLAV = (TextBox)row.FindControl("TxtLAV");
                //double VESTED_PENDING = Convert.ToDouble(row.Cells[4].Text.ToString());
                //double EXERCISED_PENDING = Convert.ToDouble(row.Cells[5].Text.ToString());

                Label VESTED_PENDING_1 = (Label)row.FindControl("lblVESTED_PENDING");
                Label EXERCISED_PENDING_1 = (Label)row.FindControl("lblEXERCISED_PENDING");

                //if (Convert.ToDouble(TxtLAV.Text) > (EXERCISED_PENDING))
                //TxtLAV.Text = TxtLAV.Text.Replace(",","");
                TxtLAV.Text = TxtLAV.Text.Substring(TxtLAV.Text.IndexOf(',') + 1);
                if ((Convert.ToString(TxtLAV.Text) == "" ? 0 : (Convert.ToDouble(TxtLAV.Text))) > Convert.ToInt32((EXERCISED_PENDING_1.Text)))
                {
                    Common.ShowJavascriptAlert("No.of LAV to be can not greater than : " + (EXERCISED_PENDING_1.Text));
                    int x = 0;
                    TxtLAV.Text = Convert.ToString(x);
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }

        protected void TxtLBV_TextChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
                int rowindex = row.RowIndex;

                TextBox TxtLBV = (TextBox)row.FindControl("TxtLBV");
                //double VESTED_PENDING = Convert.ToDouble(row.Cells[4].Text.ToString());
                //double EXERCISED_PENDING = Convert.ToDouble(row.Cells[5].Text.ToString());

                Label VESTED_PENDING_1 = (Label)row.FindControl("lblVESTED_PENDING");
                Label EXERCISED_PENDING_1 = (Label)row.FindControl("lblEXERCISED_PENDING");


                //if (Convert.ToDouble(TxtLAV.Text) > (EXERCISED_PENDING))
                TxtLBV.Text = TxtLBV.Text.Replace(",", "");
                if ((Convert.ToString(TxtLBV.Text) == "" ? 0 : (Convert.ToDouble(TxtLBV.Text))) > Convert.ToInt32((VESTED_PENDING_1.Text)))
                {
                    Common.ShowJavascriptAlert("No.of LBV to be can not greater than : " + (VESTED_PENDING_1.Text));
                    //TxtLBV.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }
    }
}