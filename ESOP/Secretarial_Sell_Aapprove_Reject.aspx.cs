using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;
using System.Data;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using Ionic.Zip;
using System.Collections.Generic;

namespace ESOP
{
    public partial class Secretarial_Sell_Aapprove_Reject : System.Web.UI.Page
    {
        employee_saleBO objBO = new employee_saleBO();
        employee_saleBAL objBAL = new employee_saleBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GET_EMPLOYEE_SELL_DATA();
            }

        }

        protected void GET_EMPLOYEE_SELL_DATA()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objBAL.GET_EMPLOYEE_SELL_DATA_1(objBO);

                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdMain.DataSource = ds.Tables[0];
                        grdMain.DataBind();
                        btn_BulkApprove.Visible = true;
                        //btn_BulkReject.Visible = true;
                    }
                    else
                    {
                        grdMain.DataSource = ds.Tables[0];
                        grdMain.DataBind();
                        btn_BulkApprove.Visible = false;
                        //btn_BulkReject.Visible = false;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GrvApproved.DataSource = ds.Tables[1];
                        GrvApproved.DataBind();
                        ViewState["Approved"] = ds.Tables[1];
                    }
                    else
                    {
                        GrvApproved.DataSource = ds.Tables[1];
                        GrvApproved.DataBind();
                        ViewState["Approved"] = null;
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

                    //GrvApproved.DataSource = ds.Tables[1];
                    //GrvApproved.DataBind();

                    //GrvReject.DataSource = ds.Tables[2];
                    //GrvReject.DataBind();
                }
                ViewState["Emp_filterRec"] = ds;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void GrvPFADB(object sender, GridViewRowEventArgs e)
        {
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain.Rows.Count; i++)
                {
                    //double id = grdMain.DataKeys[i].Values[0].ToString();

                    //Label No_of_Sale = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(i)].Cells[7].FindControl("lblOptions");
                    //string test = No_of_Sale.Text;

                    string id = (grdMain.DataKeys[i].Values[0].ToString());
                    ds = objBAL.GET_EMPLOYEE_SELL_DETAILS_DATA_1(id);
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }
        }

        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    var checkbox = grdMain.Rows[i].FindControl("chk") as CheckBox;
                    if (checkbox.Checked)
                    {
                        flag = true;
                    }
                    //GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    //foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    //{
                    //    if (gvrow.RowType == DataControlRowType.DataRow)
                    //    {
                    //        var checkbox = gvrow.FindControl("chk") as CheckBox;
                    //        if (checkbox.Checked)
                    //        {
                    //            flag = true;
                    //        }
                    //    }
                    //}
                }

                if (flag == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast One check should be selected!!!');", true);
                    return;
                }


                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    var checkbox = grdMain.Rows[i].FindControl("chk") as CheckBox;

                    if (checkbox.Checked)
                    {
                        TextBox TxtRemarkPend_Approval = (TextBox)grdMain.Rows[i].FindControl("TxtRemarkPend_Approval");
                        GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                        foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                        {
                            if (gvrow.RowType == DataControlRowType.DataRow)
                            {
                                //TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[15].FindControl("TxtRemarkPend_Approval");
                                Label No_of_Sale = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[10].FindControl("lblOptions");

                                //TextBox TxtRemarkPend_Approval = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("TxtRemarkPend_Approval");
                                //Label No_of_Sale = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("lblOptions");

                                string ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                                string VESTING_DETAIL_ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1]);
                                string SID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);

                                objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                                objBO.DPID = ID;
                                objBO.Remark = TxtRemarkPend_Approval.Text.Replace(",", "");
                                objBO.Status = "APPROVED_BY_SECRETARIAL";
                                //Added by Bhushan on 09-12-2022
                                objBO.APPROVE_STATUS = "Approved";
                                //End
                                objBO.CLIENT_ID = SID;
                                bool val = objBAL.update_status(objBO);

                                if (val == true)
                                {
                                    objBO.Status = "APPROVED_BY_SECRETARIAL";

                                    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                                    objBO.VESTING_DETAIL_ID = Convert.ToInt32(VESTING_DETAIL_ID);
                                    objBO.OPTION_SALE = Convert.ToDouble(No_of_Sale.Text);

                                    objBAL.UPDATE_EMPLOYEE_SALE(objBO);
                                    OEMailBO.RoleName = "EMP";
                                    // OEMailBO.userName = gv.DataKeys[clickedRow.RowIndex].Values[3].ToString();
                                    OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3]);

                                    // OEMailBO.userName = ecode;

                                    DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);

                                    string email2 = "";
                                    if (ds.Tables[0].Rows.Count == 1)
                                    {
                                        email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                                    }
                                    else
                                    {
                                        email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                                    }


                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                        // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Approved Sell by Admin", "", email2, "", "", "", "", "");

                                    }
                                }
                            }
                        }
                    }

                }
                GET_EMPLOYEE_SELL_DATA();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sell has been approved!!');", true);

                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Sale has been approved.";
            }
            catch (Exception ex)

            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;

            }
        }

        protected void btn_bulkReject_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    var checkbox = grdMain.Rows[i].FindControl("chk") as CheckBox;
                    if (checkbox.Checked)
                    {
                        flag = true;
                    }
                    //GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    //foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    //{
                    //    if (gvrow.RowType == DataControlRowType.DataRow)
                    //    {
                    //        var checkbox = gvrow.FindControl("chk") as CheckBox;
                    //        if (checkbox.Checked)
                    //        {
                    //            flag = true;
                    //        }
                    //    }
                    //}
                }

                if (flag == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast One check should be selected!!!');", true);
                    return;
                }

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    var checkbox = grdMain.Rows[i].FindControl("chk") as CheckBox;
                    TextBox TxtRemarkPend_Approval = (TextBox)grdMain.Rows[i].FindControl("TxtRemarkPend_Approval");
                    if (checkbox.Checked)
                    {
                        GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                        foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                        {
                            if (gvrow.RowType == DataControlRowType.DataRow)
                            {
                                //TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[15].FindControl("TxtRemarkPend_Approval");
                                Label No_of_Sale = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[10].FindControl("lblOptions");

                                //TextBox TxtRemarkPend_Approval = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("TxtRemarkPend_Approval");
                                //Label No_of_Sale = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("lblOptions");

                                string ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                                string VESTING_DETAIL_ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1]);
                                string SID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);

                                objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                                objBO.DPID = ID;
                                objBO.Remark = TxtRemarkPend_Approval.Text.Replace(",", "");
                                objBO.Status = "REJECTED_BY_SECRETARIAL";
                                objBO.CLIENT_ID = SID;
                                bool val = objBAL.update_status(objBO);
                                if (val == true)
                                {
                                    Label L1 = (Label)grdMain.Rows[i].FindControl("lblSALE_OFFER_FILE_PATH");
                                    Label L2 = (Label)grdMain.Rows[i].FindControl("lblSALE_DECLARATION_FILE_PATH");
                                    Label L3 = (Label)grdMain.Rows[i].FindControl("lblSALE_TRANSACTION_RECEIPT_FILE_PATH");
                                    if (File.Exists(Server.MapPath(L1.Text)))
                                    {
                                        File.Delete(Server.MapPath(L1.Text));
                                    }
                                    if (File.Exists(Server.MapPath(L2.Text)))
                                    {
                                        File.Delete(Server.MapPath(L2.Text));
                                    }
                                    if (File.Exists(Server.MapPath(L3.Text)))
                                    {
                                        File.Delete(Server.MapPath(L3.Text));
                                    }

                                    OEMailBO.RoleName = "EMP";
                                    // OEMailBO.userName = gv.DataKeys[clickedRow.RowIndex].Values[3].ToString();
                                    OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3]);

                                    // OEMailBO.userName = ecode;

                                    DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);

                                    string email2 = "";
                                    if (ds.Tables[0].Rows.Count == 1)
                                    {
                                        email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                                    }
                                    else
                                    {
                                        email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                                    }


                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Rejected Sell by Admin", "", email2, "", "", "", "", "");

                                    }
                                }
                            }
                        }
                    }
                }
                GET_EMPLOYEE_SELL_DATA();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sell has been rejected!!');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Sale has been rejected.";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;

            }
        }


        protected void grdMain_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_EMPLOYEE_SELL_DATA_1(objBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdMain.UseAccessibleHeader = true;
                grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grdData.PageIndex = e.NewPageIndex;
            //DataSet ds = (DataSet)ViewState["Emp_filterRec"];
            //if (ds.Tables.Count > 0)
            //{
            //    grdData.DataSource = ds.Tables[0];
            //    grdData.DataBind();
            //}
        }

        protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Download")
                {
                    string commandArg = e.CommandArgument.ToString();
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    string ECODE = Convert.ToString(gv1.DataKeys[rowIndex].Values[0]);

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                        zip.AddDirectoryByName(ECODE + "Sales_Doc_All");

                        objBO.ECODE = Convert.ToString(ECODE);

                        DataSet ds = objBAL.GET_EMP_SALE_DOC_1(objBO);

                        for (int i = 2; i <= 4; i++)
                        {
                            string filePath = ds.Tables[0].Rows[0][i].ToString();
                            filePath = Server.MapPath(ds.Tables[0].Rows[0][i].ToString());
                            zip.AddFile(filePath, ECODE + "Sales_Doc_All");
                        }
                        Response.Clear();
                        Response.BufferOutput = false;
                        string zipName = String.Format("{0}_SALES_DOC_{1}.zip", ECODE, DateTime.Now.ToString("dd-MMM-yyyy"));
                        Response.ContentType = "application/zip";
                        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                        zip.Save(Response.OutputStream);
                        Response.End();
                    }
                }

                if (e.CommandName == "Approve")
                {
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView GrvPendingforApproval = (GridView)gvr.FindControl("GrvPendingforApproval");
                    TextBox TxtRemarkPend_Approval = (TextBox)gvr.FindControl("TxtRemarkPend_Approval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            //TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[15].FindControl("TxtRemarkPend_Approval");
                            Label No_of_Sale = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[10].FindControl("lblOptions");

                            //TextBox TxtRemarkPend_Approval = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("TxtRemarkPend_Approval");
                            //Label No_of_Sale = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("lblOptions");

                            string ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                            string VESTING_DETAIL_ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1]);
                            string SID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);

                            objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                            objBO.DPID = ID;
                            objBO.Remark = TxtRemarkPend_Approval.Text.Replace(",", "");
                            objBO.Status = "APPROVED_BY_SECRETARIAL";
                            objBO.APPROVE_STATUS = "Approved";
                            objBO.CLIENT_ID = SID;
                            bool val = objBAL.update_status(objBO);

                            if (val == true)
                            {
                                objBO.Status = "APPROVED_BY_SECRETARIAL";

                                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                                objBO.VESTING_DETAIL_ID = Convert.ToInt32(VESTING_DETAIL_ID);
                                objBO.OPTION_SALE = Convert.ToDouble(No_of_Sale.Text);

                                objBAL.UPDATE_EMPLOYEE_SALE(objBO);
                                OEMailBO.RoleName = "EMP";
                                // OEMailBO.userName = gv.DataKeys[clickedRow.RowIndex].Values[3].ToString();
                                OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3]);

                                // OEMailBO.userName = ecode;

                                DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);

                                string email2 = "";
                                if (ds.Tables[0].Rows.Count == 1)
                                {
                                    email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                                }
                                else
                                {
                                    email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                                }


                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                    // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Approved Sell by Admin", "", email2, "", "", "", "", "");

                                }
                            }
                        }
                    }

                    GET_EMPLOYEE_SELL_DATA();
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Sale has been approved.";
                }
                if (e.CommandName == "Reject")
                {
                    string commandArg = e.CommandArgument.ToString();
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView GrvPendingforApproval = (GridView)gvr.FindControl("GrvPendingforApproval");
                    TextBox TxtRemarkPend_Approval = (TextBox)gvr.FindControl("TxtRemarkPend_Approval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            //TextBox TxtRemarkPend_Approval = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[15].FindControl("TxtRemarkPend_Approval");
                            Label No_of_Sale = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[10].FindControl("lblOptions");

                            //TextBox TxtRemarkPend_Approval = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("TxtRemarkPend_Approval");
                            //Label No_of_Sale = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("lblOptions");

                            string ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                            string VESTING_DETAIL_ID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[1]);
                            string SID = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);

                            objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                            objBO.DPID = ID;
                            objBO.Remark = TxtRemarkPend_Approval.Text.Replace(",", "");
                            objBO.Status = "REJECTED_BY_SECRETARIAL";
                            objBO.CLIENT_ID = SID;
                            bool val = objBAL.update_status(objBO);
                            if (val == true)
                            {
                                Label L1 = (Label)grdMain.Rows[rowIndex].FindControl("lblSALE_OFFER_FILE_PATH");
                                Label L2 = (Label)grdMain.Rows[rowIndex].FindControl("lblSALE_DECLARATION_FILE_PATH");
                                Label L3 = (Label)grdMain.Rows[rowIndex].FindControl("lblSALE_TRANSACTION_RECEIPT_FILE_PATH");
                                if (File.Exists(Server.MapPath(L1.Text)))
                                {
                                    File.Delete(Server.MapPath(L1.Text));
                                }
                                if (File.Exists(Server.MapPath(L2.Text)))
                                {
                                    File.Delete(Server.MapPath(L2.Text));
                                }
                                if (File.Exists(Server.MapPath(L3.Text)))
                                {
                                    File.Delete(Server.MapPath(L3.Text));
                                }

                                OEMailBO.RoleName = "EMP";
                                // OEMailBO.userName = gv.DataKeys[clickedRow.RowIndex].Values[3].ToString();
                                OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3]);

                                // OEMailBO.userName = ecode;

                                DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);

                                string email2 = "";
                                if (ds.Tables[0].Rows.Count == 1)
                                {
                                    email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                                }
                                else
                                {
                                    email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                                }


                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Rejected Sell by Admin", "", email2, "", "", "", "", "");

                                }
                            }
                        }
                    }
                    GET_EMPLOYEE_SELL_DATA();
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Sale has been rejected.";
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
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //GridViewRow row = GrvPendingforApproval.Rows[index];
                    //objBO.GRANT_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[index].Values[0]);
                    //string Vest_Cycle_Name = Convert.ToString(GrvPendingforApproval.DataKeys[index].Values[3]);
                    //DataSet ds = objBAL.GET_VESTING_AUDIT(objBO, Vest_Cycle_Name);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    grdData.DataSource = ds.Tables[0];
                    //    grdData.DataBind();
                    //}
                    //ViewState["Emp_filterRec"] = ds;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
                }
                else if (e.CommandName != "Page" && e.CommandName != "Sort")
                {
                    string commandArg = e.CommandArgument.ToString();
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    //GridView GrvIn = (GridView)gvr.FindControl("GrvPendingforApproval");
                    GridView GrvIn = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");
                    TextBox TxtRemarkPend_Approval = (TextBox)gvr.FindControl("TxtRemarkPend_Approval");
                    string ID = Convert.ToString(GrvIn.DataKeys[rowIndex].Values[0]);
                    Label No_of_Sale = (Label)GrvIn.Rows[Convert.ToInt32(rowIndex)].FindControl("lblOptions");
                    string VESTING_DETAIL_ID = Convert.ToString(GrvIn.DataKeys[rowIndex].Values[1]);
                    string SID = Convert.ToString(GrvIn.DataKeys[rowIndex].Values[2]);

                    objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                    objBO.DPID = ID;
                    objBO.Remark = TxtRemarkPend_Approval.Text.Replace(",", "");
                    objBO.CLIENT_ID = SID;
                    string Status1 = "";

                    //Commented by Krutika on 20-02-23
                    //if (e.CommandName == "Approve")
                    //{
                    //    objBO.Status = "APPROVED_BY_SECRETARIAL";
                    //    StrMsg = "Sale has been approved!!";
                    //    Status1 = "APPROVED_BY_SECRETARIAL";

                    //}

                    //if (e.CommandName == "Reject")
                    //{
                    //    objBO.Status = "REJECTED_BY_SECRETARIAL";
                    //    StrMsg = "Sale has been rejected!!";
                    //    Status1 = "REJECTED_BY_SECRETARIAL";

                    //    //GridView GrvPendingforApproval = sender as GridView;
                    //    //GridViewRow ParentGVRow = GrvPendingforApproval.NamingContainer as GridViewRow;
                    //    //string strType = DataBinder.Eval(ParentGVRow.DataItem, "SALE_DECLARATION_FILE_PATH").ToString();


                    //}

                    //bool val = objBAL.update_status(objBO);

                    //if (e.CommandName == "Approve")
                    //{
                    //    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    //    objBO.VESTING_DETAIL_ID = Convert.ToInt32(VESTING_DETAIL_ID);
                    //    objBO.OPTION_SALE = Convert.ToDouble(No_of_Sale.Text);

                    //    objBAL.UPDATE_EMPLOYEE_SALE(objBO);

                    //}

                    ////if (val == true)
                    ////{
                    ////    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + StrMsg + "');", true);
                    ////    GET_EMPLOYEE_SELL_DATA();
                    ////}
                    //if (val == true)
                    //{
                    //    GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    //    int rowIndex1 = gvr.RowIndex;

                    //    GridView gv11 = (GridView)sender;
                    //    OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[3].ToString());


                    //    OEMailBO.RoleName = "EMP";
                    //    // OEMailBO.userName = ecode;

                    //    DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);

                    //    string email2 = "";
                    //    if (ds.Tables[0].Rows.Count == 1)
                    //    {
                    //        email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                    //    }
                    //    else
                    //    {
                    //        email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                    //    }


                    //    string Attachment = "";
                    //    if (Status1 == "APPROVED_BY_SECRETARIAL")
                    //    {
                    //        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Approved Sell by Admin", "", email2, "", "", "", "", "");

                    //    }
                    //    else
                    //    {
                    //        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Rejected Sell by Admin", "", email2, "", "", "", "", "");

                    //    }
                    //End

                    //Added by Krutika on 20-02-23
                    //Not required here as Approve button is getting triggered on Main grid
                    //Approve code to be changes in Main grid RowCommand

                    //if (e.CommandName == "Approve")
                    //{
                    //    foreach (GridViewRow gvrow in GrvIn.Rows)
                    //    {
                    //        if (gvrow.RowType == DataControlRowType.DataRow)
                    //        {
                    //            objBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                    //            objBO.DPID = ID;
                    //            objBO.Remark = TxtRemarkPend_Approval.Text.Replace(",", "");
                    //            objBO.Status = "APPROVED_BY_SECRETARIAL";
                    //            //Added by Bhushan on 09-12-2022
                    //            objBO.APPROVE_STATUS = "Approved";
                    //            //End
                    //            objBO.CLIENT_ID = SID;
                    //            bool val = objBAL.update_status(objBO);

                    //            if (val == true)
                    //            {
                    //                objBO.Status = "APPROVED_BY_SECRETARIAL";

                    //                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    //                objBO.VESTING_DETAIL_ID = Convert.ToInt32(VESTING_DETAIL_ID);
                    //                objBO.OPTION_SALE = Convert.ToDouble(No_of_Sale.Text);

                    //                objBAL.UPDATE_EMPLOYEE_SALE(objBO);
                    //                OEMailBO.RoleName = "EMP";
                    //                // OEMailBO.userName = gv.DataKeys[clickedRow.RowIndex].Values[3].ToString();
                    //                OEMailBO.userName = Convert.ToString(gv1.DataKeys[rowIndex].Values[3]);

                    //                // OEMailBO.userName = ecode;

                    //                DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);

                    //                string email2 = "";
                    //                if (ds.Tables[0].Rows.Count == 1)
                    //                {
                    //                    email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                    //                }
                    //                else
                    //                {
                    //                    email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                    //                }


                    //                if (ds.Tables[0].Rows.Count > 0)
                    //                {
                    //                    //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                    //                    // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
                    //                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Sell", "Approved Sell by Admin", "", email2, "", "", "", "", "");

                    //                }
                    //            }
                    //            //End

                    //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + StrMsg + "');", true);
                    //            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //            showmsg.InnerText = StrMsg;
                    //        }
                    //    }
                               
                    //    GET_EMPLOYEE_SELL_DATA();
                    //}
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }



        protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvApproved.PageIndex = e.NewPageIndex;
            if (ViewState["Approved"] != null)
            {
                GrvApproved.DataSource = ViewState["Approved"];
                GrvApproved.DataBind();
            }

        }

        protected void GrvApproved_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                GrvApproved.PageIndex = 0;
            }
            else if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else if (ViewState["SortDirection"].ToString() == "DESC")
            {
                ViewState["SortDirection"] = "ASC";
            }
            ViewState["SortExpression"] = e.SortExpression;

            DataTable dt = (DataTable)ViewState["Approved"];
            if (dt != null)
            {
                dt.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + ViewState["SortDirection"].ToString();
                GrvApproved.DataSource = dt;
                GrvApproved.DataBind();
            }
        }

        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_EMPLOYEE_SELL_DATA(objBO);
            if (ds.Tables[1].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvReject_PreRender(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objBAL.GET_EMPLOYEE_SELL_DATA(objBO);
            if (ds.Tables[2].Rows.Count > 0)
            {
                GrvReject.UseAccessibleHeader = true;
                GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void lb_download_Click(object sender, EventArgs e)
        {
            //    using (ZipFile zip = new ZipFile())
            //    {
            //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            //        zip.AddDirectoryByName("Files");

            //    }


            //    string filename = (sender as LinkButton).CommandArgument;
            //    string filePath = Server.MapPath(filename);
            //    if (System.IO.File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
            //        ViewState["filepath"] = filename.Replace("~/", "");
            //    }
            //    else
            //    {
            //        Common.ShowJavascriptAlert("Documents Not exist in folder");
            //    }
        }


    }
}