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
using System.Drawing;
using System.Net;
using Ionic.Zip;

namespace ESOP
{
    public partial class Admin_Exercise_Approve_Reject_New : System.Web.UI.Page
    {
        employee_exerciseBO objBO = new employee_exerciseBO();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GET_Employee_Secretarial_Approve_Reject_Data();
                BindMainGrid();
            }
            

        }
        private void BindMainGrid()
        {
            try
            {
                DataSet ds = new DataSet();
                //DataSet ds = objBAL.GET_Employee_Admin_Main_Grid();
                //ds = objBAL.GET_Employee_Admin_Main_Grid_1();

                ds = objBAL.GET_Employee_Admin_Main_Grid_NEW();

                //Added by Krutika on 06-02-23                
                //string id = "";
                //DataSet ds1 = new DataSet();
                //ds1 = objBAL.GET_Employee_Admin_Main_Data_NEW(id);
                //End

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Commented by Krutika on 06-02-23
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    //End
                    btn_BulkApprove.Visible = true;
                    btn_BulkReject.Visible = true;
                }
                else
                {
                    //Commented by Krutika on 06-02-23
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    //End
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;
                }

                //GrvPendingforApproval.DataSource = ds1.Tables[0];
                //GrvPendingforApproval.DataBind();
                //ViewState["PendingExercise"] = ds1.Tables[0];
                //End
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        public void GET_Employee_Secretarial_Approve_Reject_Data()
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
                ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA_NEW(objBO);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GrvApproved.DataSource = ds.Tables[1];
                    GrvApproved.DataBind();
                    btn_BulkApprove.Visible = false;
                    ViewState["Approved"] = ds.Tables[1];
                    btn_BulkReject.Visible = false;

                }
                else
                {
                    GrvApproved.DataSource = ds.Tables[1];
                    GrvApproved.DataBind();
                    ViewState["Approved"] = null;
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;

                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    GrvReject.DataSource = ds.Tables[2];
                    GrvReject.DataBind();
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;
                }
                else
                {
                    GrvReject.DataSource = ds.Tables[2];
                    GrvReject.DataBind();
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                //Commented by Krutika on 06-02-23
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    //End
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;
                            if (checkbox.Checked)
                            {
                                flag = true;
                            }
                        }
                    }

                    if (flag == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast One check should be selected!!!');", true);
                        return;
                    }

                    //Commented by Krutika on 06-02-23
                    //for (int i = 0; i < grdMain.Rows.Count; i++)
                    //{
                    //    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    //End
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;

                            if (checkbox.Checked)
                            {
                                objBO.id = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                                objBO.etid = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);
                                objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                                TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[11].FindControl("txt_remark");
                                objBO.remark = txt.Text.Replace(",", "");
                                //Added by Bhushan on 02-02-2023 for Tax Master CR
                                TextBox txtPerqAmt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[12].FindControl("txt_PerqAmt");
                                txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");

                                if (txtPerqAmt.Text == "")
                                {
                                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                    showmsg.InnerText = "Please Enter Perq tax amount";
                                    return;
                                }
                                else
                                {
                                    objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(txtPerqAmt.Text.Replace(",", ""));
                                    Label lblTotalAmt = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[13].FindControl("lblTotal_Amount");
                                    objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmt.Text.Replace(",", ""));
                                    //End
                                    objBO.detail_status = "APPROVED_BY_ADMIN";
                                    //bool val = objBAL.update_status(objBO);
                                    bool val = objBAL.update_status_1(objBO);
                                }
                            }
                        }
                    }

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record Approved successfully!.";
                    GET_Employee_Secretarial_Approve_Reject_Data();
                    BindMainGrid();
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
                bool flag = false;
                //Commented by Krutika on 06-02-23
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    //End
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;
                            if (checkbox.Checked)
                            {
                                flag = true;
                            }
                        }
                    }

                    if (flag == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast One check should be selected!!!');", true);
                        return;
                    }

                    //Commented by Krutika on 06-02-23
                    //for (int i = 0; i < grdMain.Rows.Count; i++)
                    //{
                    //    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    //End
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {

                            {
                                objBO.id = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                                objBO.etid = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);
                                objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                                TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[11].FindControl("txt_remark");
                                objBO.remark = txt.Text.Replace(",", "");
                                //Added by Bhushan on 02-02-2023 for Tax Master CR
                                TextBox txtPerqAmt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[12].FindControl("txt_PerqAmt");
                                txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");

                                if (txtPerqAmt.Text == "")
                                {
                                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                    showmsg.InnerText = "Please Enter Perq tax amount";
                                    return;
                                }
                                else
                                {
                                    objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(txtPerqAmt.Text.Replace(",", ""));
                                    Label lblTotalAmt = (Label)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[13].FindControl("lblTotal_Amount");
                                    objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmt.Text.Replace(",", ""));
                                    //End
                                    objBO.detail_status = "REJECTED_BY_ADMIN";
                                }
                                //bool val = objBAL.update_status(objBO);
                                bool val = objBAL.update_status_1(objBO);
                                if (val == true)
                                {
                                    OEMailBO.RoleName = "EMP";
                                    OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4]);

                                    Employee_secretarialBAL objBAL_BAL = new Employee_secretarialBAL();
                                    DataSet ds1 = objBAL_BAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                                    string email2 = "";
                                    if (ds1.Tables[0].Rows.Count == 1)
                                    {
                                        email2 = ds1.Tables[0].Rows[0]["EMAILID"].ToString();
                                    }
                                    else
                                    {
                                        email2 = (ds1.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds1.Tables[0].Rows[1]["EMAILID"].ToString());
                                    }

                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Exercise Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                                    }
                                }
                            }
                        }
                    }
                    GET_Employee_Secretarial_Approve_Reject_Data();
                    BindMainGrid();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Exercise has been rejected!!');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Exercise has been rejected.";

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        //protected void GrvPFADB(object sender, GridViewRowEventArgs e)                                //Commented by Krutika on 03-02-23
        //Commented by Krutika on 03-02-23
        //protected void grdMain_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;

        //    DataSet ds = new DataSet();
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        for (int i = 0; i <= grdMain.Rows.Count; i++)
        //        {
        //            string id = (grdMain.DataKeys[i].Values[0].ToString());
        //            ds = objBAL.GET_Employee_Admin_Main_Data_NEW(id);

        //            GrvPendingforApproval.DataSource = ds.Tables[0];
        //            GrvPendingforApproval.DataBind();
        //        }
        //        ViewState["PendingExercise"] = ds.Tables[0];                                                       //Added by Bhushan on 02-02-2023

        //    }
        //}
        //End
        protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Approve")
                {
                    int rowindex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow main = grdMain.Rows[rowindex];
                    GridView child = main.FindControl("GrvPendingforApproval") as GridView;
                    foreach (GridViewRow childrow in child.Rows)
                    {
                        GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                        int rowIndex = gvr.RowIndex;

                        GridView gv1 = (GridView)sender;
                        double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                        string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                        double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                        // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                        objBO.id = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                        objBO.etid = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);
                        objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                        TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[11].FindControl("txt_remark");
                        objBO.remark = txt.Text.Replace(",", "");
                        //Added by Bhushan on 14-02-2023 for Tax Master CR
                        TextBox txtPerqAmt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[12].FindControl("txt_PerqAmt");
                        txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");

                        if (txtPerqAmt.Text == "")
                        {
                            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                            showmsg.InnerText = "Please Enter Perq tax amount";
                            return;
                        }
                        else
                        {
                            objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(txtPerqAmt.Text.Replace(",", ""));
                            Label lblTotalAmt = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[13].FindControl("lblTotal_Amount");
                            objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmt.Text.Replace(",", ""));
                            //End
                            objBO.detail_status = "APPROVED_BY_ADMIN";
                            //bool val = objBAL.update_status(objBO);
                            bool val = objBAL.update_status_1(objBO);

                            if (val == true)
                            {
                                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                showmsg.InnerText = "Record Approved successfully!.";
                                GET_Employee_Secretarial_Approve_Reject_Data();
                                BindMainGrid();
                            }
                        }

                    }

                }
                if (e.CommandName == "Reject")
                {
                    for (int i = 0; i <= grdMain.Rows.Count; i++)
                    {
                        GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                        int rowIndex = gvr.RowIndex;
                        GridView gv1 = (GridView)sender;
                        double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                        string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                        double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                        // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                        objBO.id = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                        objBO.etid = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);
                        objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                        TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[11].FindControl("txt_remark");
                        objBO.remark = txt.Text.Replace(",", "");
                        //Added by Bhushan on 14-02-2023 for Tax Master CR
                        TextBox txtPerqAmt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[12].FindControl("txt_PerqAmt");
                        txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");

                        if (txtPerqAmt.Text == "")
                        {
                            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                            showmsg.InnerText = "Please Enter Perq tax amount";
                            return;
                        }
                        else
                        {
                            objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(txtPerqAmt.Text.Replace(",", ""));
                            Label lblTotalAmt = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[13].FindControl("lblTotal_Amount");
                            objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmt.Text.Replace(",", ""));
                            //End
                            objBO.detail_status = "REJECTED_BY_ADMIN";
                            //bool val = objBAL.update_status(objBO);
                            bool val = objBAL.update_status_1(objBO);
                            if (val == true)
                            {
                                GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                                int rowIndex1 = gvr.RowIndex;

                                GridView gv11 = (GridView)sender;
                                OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[4].ToString());

                                OEMailBO.RoleName = "EMP";
                                // OEMailBO.userName = ecode;

                                Employee_secretarialBAL objBAL_BAL = new Employee_secretarialBAL();
                                DataSet ds = objBAL_BAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                                string email2 = "";
                                if (ds.Tables[0].Rows.Count == 1)
                                {
                                    email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                                }
                                else
                                {
                                    email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                                }

                                string Attachment = "";
                                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                            }
                        }

                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Record Rejected successfully!.";
                        GET_Employee_Secretarial_Approve_Reject_Data();
                        BindMainGrid();
                    }
                }
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    // End
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            TextBox txt = (TextBox)gvrow.FindControl("txt_remark");
                            string disply = txt.Text;
                            // TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                            txt.Text = string.Empty;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }


        }
        /*
        protected void GrvPendingforApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Approve")
                {
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    int rowIndex = gvr.RowIndex;

                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                    double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                    // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                    objBO.id = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    objBO.etid = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);
                    objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[11].FindControl("txt_remark");
                    objBO.remark = txt.Text.Replace(",", "");
                    //Added by Bhushan on 14-02-2023 for Tax Master CR
                    TextBox txtPerqAmt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[12].FindControl("txt_PerqAmt");
                    txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");

                    if (txtPerqAmt.Text == "")
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Please Enter Perq tax amount";
                        return;
                    }
                    else
                    {
                        objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(txtPerqAmt.Text.Replace(",", ""));
                        Label lblTotalAmt = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[13].FindControl("lblTotal_Amount");
                        objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmt.Text.Replace(",", ""));
                        //End
                        objBO.detail_status = "APPROVED_BY_ADMIN";
                        //bool val = objBAL.update_status(objBO);
                        bool val = objBAL.update_status_1(objBO);

                        if (val == true)
                        {
                            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                            showmsg.InnerText = "Record Approved successfully!.";
                            GET_Employee_Secretarial_Approve_Reject_Data();
                            BindMainGrid();
                        }
                    }
                }
                if (e.CommandName == "Reject")
                {
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                    double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                    // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                    objBO.id = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    objBO.etid = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);
                    objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[11].FindControl("txt_remark");
                    objBO.remark = txt.Text.Replace(",", "");
                    //Added by Bhushan on 14-02-2023 for Tax Master CR
                    TextBox txtPerqAmt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[12].FindControl("txt_PerqAmt");
                    txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");

                    if (txtPerqAmt.Text == "")
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Please Enter Perq tax amount";
                        return;
                    }
                    else
                    {
                        objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(txtPerqAmt.Text.Replace(",", ""));
                        Label lblTotalAmt = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].Cells[13].FindControl("lblTotal_Amount");
                        objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmt.Text.Replace(",", ""));
                        //End
                        objBO.detail_status = "REJECTED_BY_ADMIN";
                        //bool val = objBAL.update_status(objBO);
                        bool val = objBAL.update_status_1(objBO);
                        if (val == true)
                        {
                            GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                            int rowIndex1 = gvr.RowIndex;

                            GridView gv11 = (GridView)sender;
                            OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[4].ToString());

                            OEMailBO.RoleName = "EMP";
                            // OEMailBO.userName = ecode;

                            Employee_secretarialBAL objBAL_BAL = new Employee_secretarialBAL();
                            DataSet ds = objBAL_BAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                            string email2 = "";
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                            }
                            else
                            {
                                email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                            }

                            string Attachment = "";
                            SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                        }
                    }

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record Rejected successfully!.";
                    GET_Employee_Secretarial_Approve_Reject_Data();
                    BindMainGrid();
                }

                //Commented by Krutika on 06-02-23
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    // End
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            TextBox txt = (TextBox)gvrow.FindControl("txt_remark");
                            string disply = txt.Text;
                            // TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                            txt.Text = string.Empty;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        */
        protected void lnkBank_Statement_ServerClick(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Uploaded_Files/");

            bool FileExists = Directory.EnumerateFileSystemEntries(path).Any();

            if (FileExists == true)
            {
                var directory = new DirectoryInfo(path);
                var myFile = (from f in directory.GetFiles()
                              orderby f.LastWriteTime descending
                              select f).First().ToString();


                string filePath = Server.MapPath("~/Uploaded_Files/" + myFile);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
                // or...
                //var myFile = directory.GetFiles()
                //             .OrderByDescending(f => f.LastWriteTime)
                //             .First();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No file found!!');", true);
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        //protected void DownloadFiles(string[] link, string ENAME)
        //{
        //    using (ZipFile zip = new ZipFile())
        //    {
        //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
        //        zip.AddDirectoryByName("Files");               
        //        string In = "";
        //        foreach (string R in link)
        //        {

        //            string filePath = Server.MapPath(R);
        //            zip.AddFile(filePath, "Files");
        //            In = "IN";
        //        }
        //        if (In == "IN")
        //        {
        //            Response.Clear();
        //            Response.BufferOutput = false;
        //            //string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //            string zipName = String.Format("Documents_{0}.zip", ENAME);
        //            Response.ContentType = "application/zip";
        //            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //            zip.Save(Response.OutputStream);
        //            Response.End();
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Documents are there to download!!');", true);
        //        }
        //    }
        //}

        protected void DownloadFiles(string[] link, string ENAME)
        {
            string In = "";
            string filePath = "";
            foreach (string R in link)
            {
                filePath = Server.MapPath(R);
                In = "IN";
            }
            if (In == "IN")
            {
                if (File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    Response.Clear();
                    Response.ContentType = ContentType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Documents are there to download!!');", true);
            }
        }

        //Commented by Krutika on 06-02-23
        //protected void grdMain_PreRender(object sender, EventArgs e)
        //{
        //    DataSet ds = new DataSet();
        //    ds = objBAL.GET_Employee_Admin_Main_Grid_1();
        //    // ds = objBAL.GET_Employee_Admin_Main_Grid();
        //    if (ds.Tables[1].Rows.Count > 0)
        //    {
        //        grdMain.UseAccessibleHeader = true;
        //        grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
        //End

        protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvApproved.PageIndex = e.NewPageIndex;
            GET_Employee_Secretarial_Approve_Reject_Data();

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
            DataSet ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA_NEW(objBO);
            if (ds.Tables[1].Rows.Count > 0)
            {
                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvReject_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA_NEW(objBO);
            if (ds.Tables[2].Rows.Count > 0)
            {
                GrvReject.UseAccessibleHeader = true;
                GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvPendingforApproval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    TextBox txt = (TextBox)e.Row.FindControl("txt_remark");

                //    //string Repeat = ((HiddenField)e.Row.FindControl("Repeat")).Value;
                //    string Repeat = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Repeat"));

                //    if (Repeat == "Repeat")
                //    {
                //        txt.Text = "Repeat";
                //    }

                //}

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ADMIN_APPROVED_EXERCISE_REPORT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            GrvApproved.GridLines = GridLines.Both;
            GrvApproved.HeaderStyle.Font.Bold = true;
            GrvApproved.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void txt_PerqAmt_TextChanged(object sender, EventArgs e)
        {

            TextBox perqAmtTextBox = (TextBox)sender;
            GridViewRow mainGridViewRow = (GridViewRow)perqAmtTextBox.Parent.Parent;
            GridView childGridView = mainGridViewRow.FindControl("GrvPendingforApproval") as GridView;

            double totalChildAmount = 0;
            foreach (GridViewRow childRow in childGridView.Rows)
            {
                Label childAmtLabel = childRow.FindControl("total_amount") as Label;
                double childAmt = Convert.ToDouble(childAmtLabel.Text);
                totalChildAmount += childAmt;
            }


            double perqAmount = 0;
            if (double.TryParse(perqAmtTextBox.Text, out perqAmount))
            {
                foreach (GridViewRow childRow in childGridView.Rows)
                {
                    Label lblTotalAmt = childRow.FindControl("lblTotal_Amount") as Label;
                    Label lblgrant_price = childRow.FindControl("lblgrant_price") as Label;
                    Label lblno_of_exercise = childRow.FindControl("lblno_of_exercise") as Label;
                    double dblgrant_price = Convert.ToDouble(lblgrant_price.Text);
                    double dblno_of_exercise = Convert.ToDouble(lblno_of_exercise.Text);

                    lblTotalAmt.Text = Convert.ToString(perqAmount + (dblgrant_price * dblno_of_exercise));
                }
                Label totalAmtLabel = mainGridViewRow.FindControl("lblTotal_Amount_main") as Label;
                double totalAmt = totalChildAmount + perqAmount;
                totalAmtLabel.Text = totalAmt.ToString();
            }



            /*

                GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            int rowindex = row.RowIndex;
            TextBox txtPerqAmt = (TextBox)row.FindControl("txt_PerqAmt");
            txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");
            TextBox txtRemark = (TextBox)row.FindControl("txt_remark");
            txtRemark.Text = txtRemark.Text.Replace(",", "");
            double total_amount_main = 0;

            GridView child = row.FindControl("GrvPendingforApproval") as GridView;
            foreach (GridViewRow childrow in child.Rows)
            {
                // GridViewRow childrow = 
                Label lblTotalAmt = (Label)row.FindControl("lblTotal_Amount");
                Label lblgrant_price = (Label)row.FindControl("lblgrant_price");
                Label lblno_of_exercise = (Label)row.FindControl("lblno_of_exercise");
                DataTable dt = (DataTable)ViewState["PendingExercise"];


                double PerqAmt, dblgrant_price, dblno_of_exercise;
                PerqAmt = Convert.ToDouble(txtPerqAmt.Text);
                dblgrant_price = Convert.ToDouble(lblgrant_price.Text);
                dblno_of_exercise = Convert.ToDouble(lblno_of_exercise.Text);

                lblTotalAmt.Text = Convert.ToString(PerqAmt + (dblgrant_price * dblno_of_exercise));

                total_amount_main = Convert.ToDouble(lblTotalAmt.Text);
            }
            Label total = (Label)row.FindControl("lblTotal_Amount_main");
            total.Text = Convert.ToString(total_amount_main);
            /*
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            int rowindex = row.RowIndex;
            TextBox txtPerqAmt = (TextBox)row.FindControl("txt_PerqAmt");
            txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");
            Label lblTotalAmt = (Label)row.FindControl("lblTotal_Amount");
            TextBox txtRemark = (TextBox)row.FindControl("txt_remark");
            Label lblgrant_price = (Label)row.FindControl("lblgrant_price");
            Label lblno_of_exercise = (Label)row.FindControl("lblno_of_exercise");
            txtRemark.Text = txtRemark.Text.Replace(",", "");

            DataTable dt = (DataTable)ViewState["PendingExercise"];



            //Soaumya 
            double PerqAmt, dblgrant_price, dblno_of_exercise;
            PerqAmt = Convert.ToDouble(txtPerqAmt.Text);
            dblgrant_price = Convert.ToDouble(lblgrant_price.Text);
            dblno_of_exercise = Convert.ToDouble(lblno_of_exercise.Text);

            lblTotalAmt.Text = Convert.ToString(PerqAmt + (dblgrant_price * dblno_of_exercise));
            */
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (txtPerqAmt.Text != "")
            //    {
            //        //txtPerqAmt.Text = txtPerqAmt.Text.Replace(",", "");
            //        lblTotalAmt.Text = Convert.ToString(Convert.ToDouble(txtPerqAmt.Text) + (Convert.ToDouble(dt.Rows[i]["grant_price"]) * Convert.ToDouble(dt.Rows[i]["no_of_exercise"])));
            //        lblTotalAmt.Text = lblTotalAmt.Text.Replace(",", "");
            //        //txtRemark.Text = txtRemark.Text.Replace(",", "");
            //    }
            //    else
            //    {
            //        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
            //        showmsg.InnerText = "Please Enter Perq Tax Amount";
            //    }
            //}
            //(sender as TextBox).Text = string.Empty;
        }

        protected void grdMain_PreRender(object sender, EventArgs e)
        {
            //DataSet ds = objBAL.GET_Employee_Admin_Main_Grid_NEW();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    grdMain.UseAccessibleHeader = true;
            //    grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
            DataSet ds = new DataSet();
            ds = objBAL.GET_Employee_Admin_Main_Grid_1();
            // ds = objBAL.GET_Employee_Admin_Main_Grid();
            if (ds.Tables[1].Rows.Count > 0)
            {
                grdMain.UseAccessibleHeader = true;
                grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdMain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            //DataSet ds = new DataSet();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    for (int i = 0; i <= grdMain.Rows.Count; i++)
            //    {
            //        //double id = grdMain.DataKeys[i].Values[0].ToString();
            //        string id = (grdMain.DataKeys[i].Values[0].ToString());
            //        ds = objBAL.GET_Employee_Admin_Main_Data_NEW(id);

            //        GrvPendingforApproval.DataSource = ds.Tables[0];
            //        GrvPendingforApproval.DataBind();
            //    }
            //}
            /*
                        GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
                        DataSet ds = new DataSet();

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (!IsPostBack)
                            {
                                string id = (grdMain.DataKeys[e.Row.RowIndex].Values[0].ToString());
                                ds = objBAL.GET_Employee_Admin_Main_Data_NEW(id);

                                GrvPendingforApproval.DataSource = ds.Tables[0];
                                GrvPendingforApproval.DataBind();
                                ViewState["PendingExercise"] = ds.Tables[0];
                            }
                        }
                        */
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    for (int i = 0; i <= grdMain.Rows.Count; i++)
            //    {
            //        string id = (grdMain.DataKeys[i].Values[0].ToString());
            //        //string grant = (grdMain.DataKeys[i].Values[1].ToString());
            //        ds = objBAL.GET_Employee_Admin_Main_Data_NEW(id);

            //        GrvPendingforApproval.DataSource = ds.Tables[0];
            //        GrvPendingforApproval.DataBind();
            //        ViewState["PendingExercise"] = ds.Tables[0];
            //    }
            //    //ViewState["PendingExercise"] = ds.Tables[0];

            //}
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Bind the child GridView
                string id = (grdMain.DataKeys[e.Row.RowIndex].Values[0].ToString());
                ds = objBAL.GET_Employee_Admin_Main_Data_NEW(id);
                GrvPendingforApproval.DataSource = ds.Tables[0];
                GrvPendingforApproval.DataBind();
                //ViewState["PendingExercise"] = ds.Tables[0];
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attach the TextChanged event handler to the perq amount TextBox
                TextBox txtPerqAmt = e.Row.FindControl("txt_PerqAmt") as TextBox;
                txtPerqAmt.TextChanged += txt_PerqAmt_TextChanged;
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TextBox txtPerqAmt = e.Row.FindControl("txt_PerqAmt") as TextBox;
            //    txtPerqAmt.TextChanged += txt_PerqAmt_TextChanged;
            //}

        }


    }
}