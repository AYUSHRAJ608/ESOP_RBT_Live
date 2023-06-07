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
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using iTextSharp.text.pdf;
using DocumentFormat.OpenXml.Packaging;

namespace ESOP
{
    public partial class Lapse_Master : System.Web.UI.Page
    {
        ValuationBO objbo = new ValuationBO();
        ValuationBAL objbal = new ValuationBAL();

        vesting_creation_BO VestingBO = new vesting_creation_BO();
        vesting_creation_BAL VestingBAL = new vesting_creation_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_Data();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            ////try
            ////{

            ////    string message = "";
            ////    bool Flag;   
            ////    if (txt_lpsyer.Text.ToString() =="" )
            ////    {
            ////        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please enter the year!!');", true);
            ////        txt_lpsyer.Focus();
            ////        return;
            ////    }
            ////    // objbo.AGENCY_ADDRESS = ddlEmpPass.Text.ToString();

            ////    objbo.Year_of_Lapse = txt_lpsyer.Text.ToString();
            ////    objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
            ////    DataSet strmsg = objbal.Insert_Yrs_Lapse(objbo);

            ////    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record added successfully.');", true);
            ////    //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
            ////    //showmsg.InnerText = "Password Updated successfully";

            ////    txt_lpsyer.Text = "";
            ////    Get_Data();
            ////}
            ////catch (Exception ex)
            ////{
            ////    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

            ////    throw ex;
            ////}

        }
        protected void Get_Data()
        {
            ////DataSet ds = objbal.GET_Yrs_lapsedata();

            ////ViewState["Emp_filterRec"] = null;
            ////ViewState["Emp_filterRec"] = ds.Tables[0];
            ////if (ds.Tables[0].Rows.Count > 0)
            ////{
            ////    grdData.DataSource = ds.Tables[0];
            ////    grdData.DataBind();
            ////    // ViewState["dtAuditExport"] = ds.Tables[0];
            ////}


            DataSet ds = VestingBAL.USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE();

            grdData.DataSource = ds.Tables[1];
            grdData.DataBind();

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

        protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    GridView gvChildInner = e.Row.FindControl("gvChildInner") as GridView;
                    VestingBO = new vesting_creation_BO();
                    GridView gv1 = (GridView)sender;
                    Label lblobjective = (Label)e.Row.FindControl("lblTranchName");
                    VestingBO.GRANT_NAME = lblobjective.Text.Trim();
                    DataSet ds = VestingBAL.GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS(VestingBO);
                    ds.Tables[0].Columns.Add("LAPSE DATE");
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        ds.Tables[0].Rows[j]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[j]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[j]["SALE"]);// - Convert.ToDecimal(ds.Tables[0].Rows[j]["TOTAL_LAPSE"]); //- Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"])
                        ds.Tables[0].Rows[j]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[j]["STOCK_IN_HAND"]));
                        
                        TextBox LapseDate = (TextBox)e.Row.FindControl("TxtLaps");
                        if (LapseDate.Text != "")
                        {
                            DateTime myDate = Convert.ToDateTime(ds.Tables[0].Rows[j]["VESTING_DATE"]);
                            DateTime newDate = myDate.AddYears(Convert.ToInt32(LapseDate.Text)).Date;
                            newDate = newDate.Date;
                            ds.Tables[0].Rows[j]["LAPSE DATE"] = newDate.ToString("dd/MMM/yyyy");
                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataTable dt = (ds.Tables[1]);
                            string VP = ds.Tables[0].Rows[i]["VPERCENTAGE"].ToString();

                            decimal tot = dt.AsEnumerable()
                                        .Where(y => y.Field<string>("VESTINGNAME") == VP)
                                        .Sum(x => x.Field<decimal?>("LBV") ?? 0);

                            ds.Tables[0].Rows[i]["LBV"] = tot;
                            ds.Tables[0].AcceptChanges();

                            DataTable dt1 = (ds.Tables[1]);
                            string VP1 = ds.Tables[0].Rows[i]["VPERCENTAGE"].ToString();

                            decimal tot1 = dt.AsEnumerable()
                                        .Where(y => y.Field<string>("VESTINGNAME") == VP)
                                        .Sum(x => x.Field<decimal?>("LAV") ?? 0);

                            ds.Tables[0].Rows[i]["LAV"] = tot1;
                            ds.Tables[0].AcceptChanges();

                            string VP2 = ds.Tables[0].Rows[i]["TOTAL_LAPSE"].ToString();

                            decimal tot2 = dt.AsEnumerable()
                                        .Where(y => y.Field<string>("VESTINGNAME") == VP)
                                        .Sum(x => x.Field<decimal?>("TOTAL_LAPSED") ?? 0);

                            ds.Tables[0].Rows[i]["TOTAL_LAPSE"] = tot2;
                            ds.Tables[0].AcceptChanges();

                            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[i]["SALE"]);// - Convert.ToDecimal(ds.Tables[0].Rows[i]["TOTAL_LAPSE"]); //- Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"])
                            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[i]["STOCK_IN_HAND"]));
                        }
                    }


                    gvChildInner.DataSource = ds.Tables[0];
                    gvChildInner.DataBind();
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }

            }
        }
        private DataTable CalculateTotal(DataTable dt)
        {
            /* Code for Grouping and Total */
            DataTable newdt = new DataTable();
            try
            {
                newdt.Columns.Add("VID");
                newdt.Columns.Add("V_DETAIL_ID");
                newdt.Columns.Add("VPERCENTAGE");
                newdt.Columns.Add("GRANT_NAME");
                newdt.Columns.Add("GRANTED");
                newdt.Columns.Add("VESTED");
                newdt.Columns.Add("VESTED_PENDING");
                newdt.Columns.Add("EXERCISED");
                newdt.Columns.Add("EXERCISED_PENDING");
                newdt.Columns.Add("SALE");
                newdt.Columns.Add("LBV");
                newdt.Columns.Add("LAV");
                newdt.Columns.Add("TOTAL_LAPSE");
                newdt.Columns.Add("STOCK_IN_HAND");
                newdt.Columns.Add("VESTING_DATE");

                double GRANTED = 0;
                double VESTED = 0;
                double VESTED_PENDING = 0;
                double EXERCISED = 0;
                double EXERCISED_PENDING = 0;
                double SALE = 0;
                double LBV = 0;
                double LAV = 0;
                double TOTAL_LAPSE = 0;
                double STOCK_IN_HAND = 0;


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DataRow dr1 = newdt.NewRow();
                    dr1["VID"] = dt.Rows[i][0].ToString();
                    dr1["V_DETAIL_ID"] = dt.Rows[i][1].ToString();
                    dr1["VPERCENTAGE"] = dt.Rows[i][2].ToString();
                    dr1["GRANT_NAME"] = dt.Rows[i][3].ToString();
                    dr1["GRANTED"] = Convert.ToDouble(dt.Rows[i][4]);
                    dr1["VESTED"] = Convert.ToDouble(dt.Rows[i][5]);
                    dr1["VESTED_PENDING"] = Convert.ToDouble(dt.Rows[i][6]);
                    dr1["EXERCISED"] = Convert.ToDouble(dt.Rows[i][7]);
                    dr1["EXERCISED_PENDING"] = Convert.ToDouble(dt.Rows[i][8]);
                    dr1["SALE"] = Convert.ToDouble(dt.Rows[i][9]);
                    dr1["LBV"] = Convert.ToDouble(dt.Rows[i][10]);
                    dr1["LAV"] = Convert.ToDouble(dt.Rows[i][11]);
                    dr1["TOTAL_LAPSE"] = Convert.ToDouble(dt.Rows[i][12]);
                    dr1["STOCK_IN_HAND"] = Convert.ToDouble(dt.Rows[i][13]);
                    dr1["VESTING_DATE"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");


                    newdt.Rows.Add(dr1);

                    GRANTED += Convert.ToDouble(dt.Rows[i][4].ToString());
                    VESTED += Convert.ToDouble(dt.Rows[i][5].ToString());//he index tak ok
                    VESTED_PENDING += Convert.ToDouble(dt.Rows[i][6].ToString());
                    EXERCISED += Convert.ToDouble(dt.Rows[i][7].ToString());
                    EXERCISED_PENDING += Convert.ToDouble(dt.Rows[i][8].ToString());
                    SALE += Convert.ToDouble(dt.Rows[i][9].ToString());
                    LBV += Convert.ToDouble(dt.Rows[i][10].ToString());
                    LAV += Convert.ToDouble(dt.Rows[i][11].ToString());
                    TOTAL_LAPSE += Convert.ToDouble(dt.Rows[i][12].ToString());
                    STOCK_IN_HAND += Convert.ToDouble(dt.Rows[i][13].ToString());

                    DataRow dr11 = newdt.NewRow();
                    if ((dt.Rows.Count - 1) == i)
                    {
                        dr11["VPERCENTAGE"] = "Total";
                        dr11["GRANTED"] = GRANTED;
                        dr11["VESTED"] = VESTED;
                        dr11["VESTED_PENDING"] = VESTED_PENDING;
                        dr11["EXERCISED"] = EXERCISED;
                        dr11["EXERCISED_PENDING"] = EXERCISED_PENDING;
                        dr11["SALE"] = SALE;
                        dr11["LBV"] = LBV;
                        dr11["LAV"] = LAV;
                        dr11["TOTAL_LAPSE"] = TOTAL_LAPSE;
                        dr11["STOCK_IN_HAND"] = STOCK_IN_HAND;
                        newdt.Rows.Add(dr11);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

            return newdt;
        }
        protected void gvChildInner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv1 = (GridView)sender;
                Label lblVPERCENTAGE = (Label)e.Row.FindControl("lblVPERCENTAGE");
                Label lblGRANTED = (Label)e.Row.FindControl("lblGRANTED");
                Label lblVESTED = (Label)e.Row.FindControl("lblVESTED");
                Label lblVESTED_PENDING = (Label)e.Row.FindControl("lblVESTED_PENDING");
                Label lblEXERCISED = (Label)e.Row.FindControl("lblEXERCISED");
                Label lblEXERCISED_PENDING = (Label)e.Row.FindControl("lblEXERCISED_PENDING");
                Label lblSALE = (Label)e.Row.FindControl("lblSALE");
                Label lblLBV = (Label)e.Row.FindControl("lblLBV");
                Label lblLAV = (Label)e.Row.FindControl("lblLAV");
                Label lblTOTAL_LAPSE = (Label)e.Row.FindControl("lblTOTAL_LAPSE");
                Label lblSTOCK_IN_HAND = (Label)e.Row.FindControl("lblSTOCK_IN_HAND");

                if (lblVPERCENTAGE.Text.Contains("Total"))
                {
                    lblVPERCENTAGE.Font.Bold = true;
                    lblGRANTED.Font.Bold = true;
                    lblVESTED.Font.Bold = true;
                    lblVESTED_PENDING.Font.Bold = true;
                    lblEXERCISED.Font.Bold = true;
                    lblEXERCISED_PENDING.Font.Bold = true;
                    lblSALE.Font.Bold = true;
                    lblLBV.Font.Bold = true;
                    lblLAV.Font.Bold = true;
                    lblTOTAL_LAPSE.Font.Bold = true;
                    lblSTOCK_IN_HAND.Font.Bold = true;
                }
            }
        }
        protected void grdData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Lapse")
                {

                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    string ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[0]);
                    TextBox Lapse = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("TxtLaps");
                    if (Lapse.ToString() != "")
                    {
                        objbo.Year_of_Lapse = Lapse.Text;
                        objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                        objbo.AGENCY_NAME = ID;
                        DataSet strmsg = objbal.Insert_Yrs_Lapse(objbo);
                        Get_Data();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}