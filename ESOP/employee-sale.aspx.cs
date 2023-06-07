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
using System.Globalization;

namespace ESOP
{
    public partial class employee_sale : System.Web.UI.Page
    {
        employee_saleBO objBO;
        employee_saleBAL objBAL = new employee_saleBAL();
        protected string UploadFolderPath = "~/Sale_Doc/";

        employee_exerciseBO objBO1;
        employee_exerciseBAL objBAL1 = new employee_exerciseBAL();
        bool IsPageRefresh = false;
        CultureInfo CInfo = new CultureInfo("hi-IN");
        //Added on 05-01-2022 by Rahul_Natu
        Employee_profileBO objbo = new Employee_profileBO();
        Employee_profileBAL objbal = new Employee_profileBAL();

        TaxBO taxbo = new TaxBO();
        TaxBAL taxbal = new TaxBAL();

        //END
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (Convert.ToString(Session["Done"]) == "Done")
                {
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Sale Allotment Submitted Successfully and sent to Admin for approval";
                    Session["Done"] = "";
                    btnimport1.Enabled = false;
                    fuCheque.Enabled = false;
                    AsynFileupSaleDeclaration.Enabled = false;
                }
                else
                {
                    showmsg.InnerText = "";
                }
                //txtChequeDate.Attributes.Add("readonly", "readonly");
                if (!IsPostBack)
                {
                    Session["Sale_Declaration_FilePath"] = "";
                    Session["Sale_Offer_FilePath"] = "";
                    Session["Sale_Transaction_Receipt_FilePath"] = "";

                    ViewState["Pending"] = "False";


                    GET_EMP_BANK_DETAILS();
                    GetDematDetails();

                    objBO = new employee_saleBO();
                    Session["Emp_Sale_Session"] = "";
                    ViewState["Grd_Session"] = "";

                    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    DataSet ds1 = objBAL.GET_SESSION(objBO);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Feeldata(ds1);
                    }
                    
                    DataSet ds = objBAL.GET_SALE_WINDOW();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                        Session["SessionId"] = ViewState["ViewStateId"].ToString();

                        objBO = new employee_saleBO();
                        Session["SALE_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["SALE_ID"].ToString());
                        Session["START_DATE"] = ds.Tables[0].Rows[0]["START_DATE"].ToString();
                        Session["FMV_PRICE"] = ds.Tables[0].Rows[0]["FMV_PRICE"].ToString();
                        BIND_SALE_GRID();
                    }

                    if (ds1.Tables[3].Rows.Count > 0)
                    {
                        Session["APPROVE"] = Convert.ToString(ds1.Tables[3].Rows[0]["APPROVE_STATUS"]);
                        objbo.ID = Convert.ToInt32(ds1.Tables[3].Rows[0]["ID"]);
                        DataSet ds2 = objBAL.GET_DATA(objBO);
                        if (ds2.Tables[3].Rows.Count > 0)
                        {
                            Extra_cln_Feeldata(ds2);

                        }
                        if (ds2.Tables[3].Rows.Count > 0)
                        {
                            //Extra_cln_Feeldata(ds2);
                            if (ds2.Tables[3].Rows[0]["APPROVE_STATUS"].ToString() == "Approved")
                            {
                                ViewState["ID"] = (ds2.Tables[3].Rows[0]["Sale_Tran_id"].ToString());
                                ViewState["Approve"] = (ds2.Tables[3].Rows[0]["APPROVE_STATUS"].ToString());
                                uploadTransactionRpt.Attributes.Add("style", "visibility:visible");
                                btnimport.Visible = true;
                                btnimport1.Enabled = false;
                                fuCheque.Enabled = false;
                                AsynFileupSaleDeclaration.Enabled = false;
                            }
                            else
                            {
                                uploadTransactionRpt.Attributes.Add("style", "visibility:hidden");
                                btnimport.Visible = false;
                                btnimport1.Visible = false;
                            }
                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                TextBox txtOptionsSold = new TextBox();
                                txtOptionsSold = (TextBox)gr.FindControl("txtOptionsSold");
                                txtOptionsSold.Enabled = false;

                                TextBox TxtPendingAPP = new TextBox();
                                TxtPendingAPP = (TextBox)gr.FindControl("TxtPendingAPP");
                                txtOptionsSold.Text = TxtPendingAPP.Text;

                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 2))
                                {
                                    txtOptionsSold_TextChanged(txtOptionsSold, e);
                                }
                            }

                            foreach (GridViewRow gr in gvExercise.Rows)
                            {
                                if (gr.RowIndex < (Convert.ToInt32(gvExercise.Rows.Count) - 2))
                                {
                                    TextBox txtOptionsSold = new TextBox();
                                    txtOptionsSold = (TextBox)gr.FindControl("txtOptionsSold");
                                    txtOptionsSold.Enabled = false;

                                    TextBox TxtPendingAPP = new TextBox();
                                    TxtPendingAPP = (TextBox)gr.FindControl("TxtPendingAPP");
                                    txtOptionsSold.Text = TxtPendingAPP.Text;
                                }
                            }
                        }
                    }
                    DateTime myDateTime = DateTime.Now;
                    int year = myDateTime.Year;
                    int nextyear = year + 1;
                    string combyear = Convert.ToString(year) + "-" + Convert.ToString(nextyear);
                    //combyear = "1990-1991"; //to be commented in future
                    taxbo.FINANCIAL_YEAR = combyear;
                    DataSet dstax = taxbal.gettaxdata(taxbo);

                    if (dstax.Tables[0].Rows.Count < 0)
                    {
                        showmsg.Visible = true;
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        string msg = "Tax Slab for Current Year is not submitted";
                        showmsg.InnerText = msg;
                        DisablePageControls(false);
                    }
                }
                else
                {

                    if (Convert.ToString(ViewState["ViewStateId"]) != Convert.ToString(Session["SessionId"]))
                    {
                        IsPageRefresh = true;
                    }
                    Session["SessionId"] = System.Guid.NewGuid().ToString();
                    ViewState["ViewStateId"] = Session["SessionId"].ToString();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        private void BIND_SALE_GRID()
        {
            objBO = new employee_saleBO();
            try
            {
                objBO.ECODE = Convert.ToString(Session["ECODE"]);
                objBO.SALE_WINDOW_ID = Convert.ToInt32(Session["SALE_ID"].ToString());
                objBO.SALE_WINDOW_START_DATE = Convert.ToDateTime(Session["START_DATE"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat).ToString();
                DataSet ds;

                ds = objBAL.GET_EMP_SALE_DATA(objBO);

                ////////////new change/////////
                if (Convert.ToString(ViewState["Grd_Session"]) == "True")
                {
                    DataTable GrdTable = (DataTable)ViewState["Grd_Table"];

                    if (GrdTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < GrdTable.Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                if (ds.Tables[0].Rows[j]["TRANCH_VESTING"].ToString() == GrdTable.Rows[i]["GRANT_NAME"].ToString() + GrdTable.Rows[i]["VESTING_DETAIL_CODE"].ToString())
                                {
                                    ds.Tables[0].Rows[j]["NO_OF_OPTION_SOLD"] = GrdTable.Rows[i]["NO_OF_SALE"].ToString();
                                }
                                ds.Tables[0].AcceptChanges();
                            }

                        }
                    }
                }

                //////////////////////////////////////////////////////
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["sale_fmv_price"] = Convert.ToDouble(Session["FMV_PRICE"]);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataTable dt = (ds.Tables[1]);
                        var type = dt.Columns["NO_OF_EXERCISE"].DataType;

                        string V_C = ds.Tables[0].Rows[i]["Vesting_ID"].ToString();
                        decimal grant_id = Convert.ToDecimal(ds.Tables[0].Rows[i]["Grant_ID"]);

                        decimal tot = dt.AsEnumerable()
                                    .Where(y => y.Field<string>("VESTING_DETAIL_CODE") == V_C)
                                    .Where(y => y.Field<decimal>("Grant_ID") == grant_id)
                                    .Sum(x => x.Field<decimal>("NO_OF_EXERCISE"));
                        //.ToString();

                        ds.Tables[0].Rows[i]["NO_OF_EXERCISE"] = tot;
                        ds.Tables[0].Rows[i]["PENDING_SALE"] = 0;
                        if (tot > 0)
                        {
                            ds.Tables[0].Rows[i]["PENDING_SALE"] = tot - Convert.ToInt32(ds.Tables[0].Rows[i]["NO_OF_SALE"]);
                        }

                    }
                    ds.Tables[0].AcceptChanges();

                }

                ViewState["SALE"] = ds.Tables[0];
                DataTable dtExCount = CalculateTotal_No_Of_Options(0, 0);
                if (dtExCount.Rows.Count > 0)
                {
                    gvExercise.DataSource = dtExCount;
                    gvExercise.DataBind();
                }

                //if (ds.Tables[2].Rows.Count > 0)
                //{
                //    if (ds.Tables[2].Rows[0][0].ToString() == "")
                //    {

                //    }
                //    ViewState["Satus"] = ds.Tables[2].Rows[0][0].ToString();
                //    ViewState["Pending"] = "True";
                //    DisablePageControls(false);

                //    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                //    showmsg.InnerText = "Sale is" + ds.Tables[2].Rows[0][0].ToString() + " for approavl"; //Commented by Nagesh
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }
        private void GET_EMP_BANK_DETAILS()
        {
            objBO1 = new employee_exerciseBO();
            try
            {
                objBO1.ECODE = Convert.ToString(Session["ECODE"]);
                DataSet ds = objBAL1.GET_EMP_BANK_DETAILS(objBO1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["Bank_Details"] = ds.Tables[0];
                    ddlChequeBankName.DataSource = ds.Tables[0];
                    ddlChequeBankName.DataTextField = "BANK_ACC";
                    ddlChequeBankName.DataValueField = "ID";
                    ddlChequeBankName.DataBind();
                    ddlChequeBankName.Items.Insert(0, new ListItem("Select Bank", "0"));

                    //ddlNEFTBankName.DataSource = ds.Tables[0];
                    //ddlNEFTBankName.DataTextField = "BANK_ACC";
                    //ddlNEFTBankName.DataValueField = "ID";
                    //ddlNEFTBankName.DataBind();
                    //ddlNEFTBankName.Items.Insert(0, new ListItem("Select Bank", "0"));
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetDematDetails()
        {
            objBO1 = new employee_exerciseBO();
            try
            {
                objBO1.ECODE = Convert.ToString(Session["ECODE"]);
                DataSet ds = objBAL1.GetDematDetails(objBO1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DematDetails"] = ds.Tables[0];
                    ViewState["Demat_FilePath"] = Convert.ToString(ds.Tables[0].Rows[0]["File_path"]);
                }
                else
                {
                    ViewState["DematDetails"] = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void GET_EMP_DEMAT_DETAILS()
        //{
        //    objBO1 = new employee_exerciseBO();
        //    try
        //    {
        //        objBO1.ECODE = Convert.ToString(Session["ECODE"]);
        //        DataSet ds = objBAL1.GET_EMP_DEMAT_DETAILS(objBO1);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ViewState["DEMAT_Details"] = ds.Tables[0];
        //            ddlOtherSecurity.DataSource = ds.Tables[0];
        //            ddlOtherSecurity.DataTextField = "SECURITY_DPID";
        //            ddlOtherSecurity.DataValueField = "ID";
        //            ddlOtherSecurity.DataBind();
        //            ddlOtherSecurity.Items.Insert(0, new ListItem("Select Security Name", "0"));


        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private DataTable CalculateTotal_No_Of_Options(int Vesting_Detail_ID, double OptionsSold)
        //{
        //    /* Code for Grouping and Total */
        //    DataTable newdt = new DataTable();
        //    /////double Total_Amount = 0;
        //    double Sale_Count = 0;
        //    string Tranch_Vesting = "";
        //    try
        //    {

        //        DataTable dt = (DataTable)ViewState["SALE"];

        //        newdt.Columns.Add("Vesting_DETAIL_ID");
        //        newdt.Columns.Add("ECODE");
        //        newdt.Columns.Add("EMP_NAME");
        //        newdt.Columns.Add("GRANT_ID");
        //        newdt.Columns.Add("GRANT_NAME");
        //        newdt.Columns.Add("VESTING_ID");
        //        newdt.Columns.Add("V_DETAIL_ID");
        //        newdt.Columns.Add("no_of_vesting");
        //        newdt.Columns.Add("Vesting_Date");
        //        newdt.Columns.Add("Tranch_Vesting");
        //        newdt.Columns.Add("status");
        //        newdt.Columns.Add("GRANT_PRICE");
        //        newdt.Columns.Add("fmv_price");
        //        newdt.Columns.Add("no_of_exercise");
        //        newdt.Columns.Add("pending_exercise");
        //        newdt.Columns.Add("taxable_income");

        //        newdt.Columns.Add("Exercise_Consideration");
        //        newdt.Columns.Add("FMV_Grant_Option__Exercise");
        //        newdt.Columns.Add("Revised_Taxable_Income");
        //        newdt.Columns.Add("Tax_Per_Option");
        //        newdt.Columns.Add("Perq_Tax_Amount");
        //        newdt.Columns.Add("Total_Amount");
        //        //newdt.Columns.Add("no_of_option_exercise");

        //        newdt.Columns.Add("no_of_option_sold");

        //        newdt.Columns.Add("sale_fmv_price");
        //        newdt.Columns.Add("no_of_sale");
        //        newdt.Columns.Add("pending_sale");

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (Convert.ToString(dt.Rows[i][0].ToString()) == Convert.ToString(Vesting_Detail_ID))
        //            {
        //                DataRow dr1 = newdt.NewRow();
        //                dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
        //                dr1["ECODE"] = dt.Rows[i][1].ToString();
        //                dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
        //                dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
        //                dr1["GRANT_NAME"] = (dt.Rows[i][4]);
        //                dr1["VESTING_ID"] = (dt.Rows[i][5]);
        //                dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
        //                dr1["no_of_vesting"] = (dt.Rows[i][7]);
        //                dr1["Vesting_Date"] = (dt.Rows[i][8]);
        //                dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
        //                dr1["status"] = (dt.Rows[i][10]);
        //                dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
        //                dr1["fmv_price"] = (dt.Rows[i][12]);
        //                dr1["no_of_exercise"] = (dt.Rows[i][13]);
        //                dr1["pending_exercise"] = Convert.ToDouble(dt.Rows[i][14].ToString());//Convert.ToInt32(dt.Rows[i][7].ToString()) - OptionsExercised;
        //                dr1["taxable_income"] = dt.Rows[i][15].ToString();

        //                dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
        //                dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i][17].ToString();
        //                dr1["Revised_Taxable_Income"] = dt.Rows[i][18].ToString(); //dt.Rows[i][18].ToString();
        //                dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
        //                dr1["Perq_Tax_Amount"] = dt.Rows[i][20].ToString();
        //                dr1["Total_Amount"] = dt.Rows[i][21].ToString();
        //                //dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();

        //                dr1["no_of_option_sold"] = OptionsSold;// dt.Rows[i][22].ToString();

        //                dr1["sale_fmv_price"] = (dt.Rows[i][23]);
        //                dr1["no_of_sale"] = (dt.Rows[i][24]);
        //                dr1["pending_sale"] = Convert.ToDouble(dt.Rows[i][13].ToString()) - Convert.ToDouble(dt.Rows[i][24].ToString()) - OptionsSold; //(dt.Rows[i][25]);
        //                if (dr1["pending_sale"].ToString().Contains("Total"))
        //                {

        //                }
        //                else
        //                {
        //                    newdt.Rows.Add(dr1);
        //                    //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised);
        //                    Sale_Count += OptionsSold;
        //                    if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
        //                    {
        //                        if (OptionsSold == 0)
        //                        {
        //                            Tranch_Vesting = Tranch_Vesting.Replace((dt.Rows[i][9].ToString()), "");
        //                        }
        //                        else
        //                        {
        //                            Tranch_Vesting = (dt.Rows[i][9].ToString());
        //                        }

        //                    }
        //                    else
        //                    {
        //                        if (OptionsSold == 0)
        //                        {
        //                            Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace((dt.Rows[i][9].ToString()), "");
        //                        }
        //                        else
        //                        {
        //                            Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]) + "," + (dt.Rows[i][9].ToString());
        //                        }

        //                    }

        //                }
        //            }
        //            else
        //            {
        //                DataRow dr1 = newdt.NewRow();
        //                dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
        //                dr1["ECODE"] = dt.Rows[i][1].ToString();
        //                dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
        //                dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
        //                dr1["GRANT_NAME"] = (dt.Rows[i][4]);
        //                dr1["VESTING_ID"] = (dt.Rows[i][5]);
        //                dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
        //                dr1["no_of_vesting"] = (dt.Rows[i][7]);
        //                dr1["Vesting_Date"] = (dt.Rows[i][8]);
        //                dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
        //                dr1["status"] = (dt.Rows[i][10]);
        //                dr1["GRANT_PRICE"] = (dt.Rows[i][11]);
        //                dr1["fmv_price"] = (dt.Rows[i][12]);
        //                dr1["no_of_exercise"] = (dt.Rows[i][13]);
        //                dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
        //                dr1["taxable_income"] = dt.Rows[i][15].ToString();


        //                dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
        //                dr1["FMV_Grant_Option__Exercise"] = dt.Rows[i][17].ToString();
        //                dr1["Revised_Taxable_Income"] = dt.Rows[i][18].ToString(); //dt.Rows[i][18].ToString();
        //                dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
        //                dr1["Perq_Tax_Amount"] = dt.Rows[i][20].ToString();
        //                dr1["Total_Amount"] = dt.Rows[i][21].ToString();
        //                //dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();


        //                dr1["no_of_option_sold"] = dt.Rows[i][22].ToString();

        //                dr1["sale_fmv_price"] = (dt.Rows[i][23]);
        //                dr1["no_of_sale"] = (dt.Rows[i][24]);
        //                dr1["pending_sale"] = (dt.Rows[i][25]);
        //                //newdt.Rows.Add(dr1);
        //                if (dr1["pending_sale"].ToString().Contains("Total"))
        //                {

        //                }
        //                else
        //                {
        //                    newdt.Rows.Add(dr1);

        //                    Sale_Count += Convert.ToDouble(dt.Rows[i][22].ToString());
        //                }


        //            }
        //            DataRow dr11 = newdt.NewRow();
        //            if ((dt.Rows.Count - 1) == i)
        //            {

        //                dr11["pending_sale"] = "Total";
        //                dr11["no_of_option_sold"] = Sale_Count;

        //                newdt.Rows.Add(dr11);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //    ViewState["SALE"] = newdt;
        //    //ViewState["Total_Amount"] = Total_Amount;
        //    ViewState["Sale_Count"] = Sale_Count;
        //    ViewState["Tranch_Vesting"] = Tranch_Vesting;
        //    return newdt;

        //}
        private DataTable CalculateTotal_No_Of_Options(int Vesting_Detail_ID, double OptionsSold)
        {
            /* Code for Grouping and Total */
            DataTable newdt = new DataTable();
            /////double Total_Amount = 0;
            double Sale_Count = 0;
            double Sale_Total_Amt = 0;
            string Tranch_Vesting = "";
            try
            {
                DataTable dt = (DataTable)ViewState["SALE"];

                newdt.Columns.Add("Vesting_DETAIL_ID");
                newdt.Columns.Add("ECODE");
                newdt.Columns.Add("EMP_NAME");
                newdt.Columns.Add("GRANT_ID");
                newdt.Columns.Add("GRANT_NAME");
                newdt.Columns.Add("VESTING_ID");
                newdt.Columns.Add("V_DETAIL_ID");
                newdt.Columns.Add("no_of_vesting");
                newdt.Columns.Add("Vesting_Date");
                newdt.Columns.Add("Tranch_Vesting");
                newdt.Columns.Add("status");
                newdt.Columns.Add("GRANT_PRICE");
                newdt.Columns.Add("fmv_price");
                newdt.Columns.Add("no_of_exercise");
                newdt.Columns.Add("pending_exercise");
                newdt.Columns.Add("taxable_income");

                newdt.Columns.Add("Exercise_Consideration");
                newdt.Columns.Add("FMV_Grant_Option__Exercise");
                newdt.Columns.Add("Revised_Taxable_Income");
                newdt.Columns.Add("Tax_Per_Option");
                newdt.Columns.Add("Perq_Tax_Amount");
                newdt.Columns.Add("Total_Amount");
                //newdt.Columns.Add("no_of_option_exercise");

                newdt.Columns.Add("no_of_option_sold");

                newdt.Columns.Add("sale_fmv_price");
                newdt.Columns.Add("no_of_sale");
                newdt.Columns.Add("pending_sale");
                newdt.Columns.Add("Pending_for_Approval");
                newdt.Columns.Add("Tranch_wise_options");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i][0].ToString()) == Convert.ToString(Vesting_Detail_ID))
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
                        dr1["ECODE"] = dt.Rows[i][1].ToString();
                        dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
                        dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
                        dr1["GRANT_NAME"] = (dt.Rows[i][4]);
                        dr1["VESTING_ID"] = (dt.Rows[i][5]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
                        dr1["no_of_vesting"] = (dt.Rows[i][7]);
                        dr1["Vesting_Date"] = (dt.Rows[i][8]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
                        dr1["status"] = (dt.Rows[i][10]);
                        dr1["GRANT_PRICE"] = string.IsNullOrEmpty(dt.Rows[i][11].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][11].ToString()).ToString("N", CInfo);//(dt.Rows[i][11]);
                        dr1["fmv_price"] = (dt.Rows[i][12]);
                        dr1["no_of_exercise"] = (dt.Rows[i][13]);
                        dr1["pending_exercise"] = Convert.ToDouble(dt.Rows[i][14].ToString());//Convert.ToInt32(dt.Rows[i][7].ToString()) - OptionsExercised;
                        dr1["taxable_income"] = string.IsNullOrEmpty(dt.Rows[i][15].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][15].ToString()).ToString("N", CInfo);// dt.Rows[i][15].ToString();
                        dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = Convert.ToDecimal(dt.Rows[i][17].ToString()).ToString("N", CInfo);// dt.Rows[i][17].ToString();
                        dr1["Revised_Taxable_Income"] = Convert.ToDecimal(dt.Rows[i][18].ToString()).ToString("N", CInfo);// dt.Rows[i][18].ToString(); //dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
                        dr1["Perq_Tax_Amount"] = Convert.ToDecimal(dt.Rows[i][20].ToString()).ToString("N", CInfo);//dt.Rows[i][20].ToString();
                        dr1["Total_Amount"] = Convert.ToDecimal(dt.Rows[i][21].ToString()).ToString("N", CInfo);// dt.Rows[i][21].ToString();
                        //dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();

                        dr1["no_of_option_sold"] = OptionsSold;// dt.Rows[i][22].ToString();

                        dr1["sale_fmv_price"] = Convert.ToDecimal(dt.Rows[i][23].ToString()).ToString("N", CInfo);// (dt.Rows[i][23]);
                        dr1["no_of_sale"] = (dt.Rows[i][24]);
                        // dr1["pending_sale"] = Convert.ToDouble(dt.Rows[i][13].ToString()) - Convert.ToDouble(dt.Rows[i][24].ToString()) - OptionsSold; //(dt.Rows[i][25]);
                        dr1["pending_sale"] = Convert.ToDouble(dt.Rows[i][13].ToString()) - Convert.ToDouble(dt.Rows[i][24].ToString()) - Convert.ToDouble(dt.Rows[i]["Pending_for_Approval"].ToString());
                        dr1["Pending_for_Approval"] = (dt.Rows[i]["Pending_for_Approval"]);
                        dr1["Tranch_wise_options"] = (dt.Rows[i]["Tranch_wise_options"]);
                        if (dr1["pending_sale"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            newdt.Rows.Add(dr1);
                            //Total_Amount += ((((Convert.ToDouble(dt.Rows[i][12]) - Convert.ToDouble(dt.Rows[i][11])) * OptionsExercised) * Convert.ToDouble(dt.Rows[i][19])) / 100) + (Convert.ToDouble(dt.Rows[i][11]) * OptionsExercised);
                            Sale_Count += OptionsSold;
                            Sale_Total_Amt += (OptionsSold * Convert.ToDouble(dt.Rows[i][23]));
                            if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
                            {
                                if (OptionsSold == 0)
                                {
                                    Tranch_Vesting = Tranch_Vesting.Replace((dt.Rows[i][9].ToString()), "");
                                }
                                else
                                {
                                    Tranch_Vesting = (dt.Rows[i][9].ToString());
                                }

                            }
                            else
                            {
                                if (OptionsSold == 0)
                                {
                                    Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace((dt.Rows[i][9].ToString()), "");
                                }
                                else
                                {
                                    Tranch_Vesting = Convert.ToString(ViewState["Tranch_Vesting"]) + "," + (dt.Rows[i][9].ToString());
                                }

                            }

                        }
                    }
                    else
                    {
                        DataRow dr1 = newdt.NewRow();
                        dr1["Vesting_DETAIL_ID"] = dt.Rows[i][0].ToString();
                        dr1["ECODE"] = dt.Rows[i][1].ToString();
                        dr1["EMP_NAME"] = dt.Rows[i][2].ToString();
                        dr1["GRANT_ID"] = dt.Rows[i][3].ToString();
                        dr1["GRANT_NAME"] = (dt.Rows[i][4]);
                        dr1["VESTING_ID"] = (dt.Rows[i][5]);
                        dr1["V_DETAIL_ID"] = (dt.Rows[i][6]);
                        dr1["no_of_vesting"] = (dt.Rows[i][7]);
                        dr1["Vesting_Date"] = (dt.Rows[i][8]);
                        dr1["Tranch_Vesting"] = (dt.Rows[i][9]);
                        dr1["status"] = (dt.Rows[i][10]);
                        dr1["GRANT_PRICE"] = string.IsNullOrEmpty(dt.Rows[i][11].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][11].ToString()).ToString("N", CInfo);// (dt.Rows[i][11]);
                        dr1["fmv_price"] = (dt.Rows[i][12]);
                        dr1["no_of_exercise"] = (dt.Rows[i][13]);
                        dr1["pending_exercise"] = dt.Rows[i][14].ToString();//Convert.ToDateTime(dt.Rows[i][14]).ToString("MM/dd/yyyy");
                        dr1["taxable_income"] = string.IsNullOrEmpty(dt.Rows[i][15].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][15].ToString()).ToString("N", CInfo);// dt.Rows[i][15].ToString();


                        dr1["Exercise_Consideration"] = dt.Rows[i][16].ToString();
                        dr1["FMV_Grant_Option__Exercise"] = string.IsNullOrEmpty(dt.Rows[i][17].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][17].ToString()).ToString("N", CInfo);//dt.Rows[i][17].ToString();
                        dr1["Revised_Taxable_Income"] = string.IsNullOrEmpty(dt.Rows[i][18].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][18].ToString()).ToString("N", CInfo);// dt.Rows[i][18].ToString(); //dt.Rows[i][18].ToString();
                        dr1["Tax_Per_Option"] = dt.Rows[i][19].ToString();
                        dr1["Perq_Tax_Amount"] = string.IsNullOrEmpty(dt.Rows[i][20].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][20].ToString()).ToString("N", CInfo);//dt.Rows[i][20].ToString();
                        dr1["Total_Amount"] = string.IsNullOrEmpty(dt.Rows[i][21].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][21].ToString()).ToString("N", CInfo);// dt.Rows[i][21].ToString();
                        //dr1["no_of_option_exercise"] = dt.Rows[i][22].ToString();


                        dr1["no_of_option_sold"] = dt.Rows[i][22].ToString();

                        dr1["sale_fmv_price"] = string.IsNullOrEmpty(dt.Rows[i][23].ToString()) ? "" : Convert.ToDecimal(dt.Rows[i][23].ToString()).ToString("N", CInfo);// (dt.Rows[i][23]);
                        dr1["no_of_sale"] = (dt.Rows[i][24]);
                        dr1["pending_sale"] = (dt.Rows[i][25]);
                        dr1["Pending_for_Approval"] = (dt.Rows[i]["Pending_for_Approval"]);
                        dr1["Tranch_wise_options"] = (dt.Rows[i]["Tranch_wise_options"]);
                        //newdt.Rows.Add(dr1);
                        if (dr1["pending_sale"].ToString().Contains("Total"))
                        {

                        }
                        else
                        {
                            newdt.Rows.Add(dr1);
                            Sale_Count += Convert.ToDouble(dt.Rows[i][22].ToString());
                            Sale_Total_Amt += (Convert.ToDouble(dt.Rows[i][22].ToString()) * Convert.ToDouble(dt.Rows[i][23]));
                            ///////////////////////////////
                            if (Convert.ToString(Session["Emp_Sale_Session"]) != "True")
                            {
                                double sessionOptionsSold = Convert.ToDouble(dt.Rows[i][22].ToString());
                                if (Convert.ToString(ViewState["Tranch_Vesting"]) == "")
                                {
                                    if (sessionOptionsSold != 0)
                                    {
                                        if (Tranch_Vesting == "")
                                        {
                                            Tranch_Vesting = dt.Rows[i][9].ToString();
                                        }
                                        else
                                        {
                                            Tranch_Vesting = Tranch_Vesting + "," + (dt.Rows[i][9].ToString());
                                        }
                                    }
                                }
                            }
                            ////////////////////////
                        }

                    }
                    DataRow dr11 = newdt.NewRow();
                    DataRow dr12 = newdt.NewRow();
                    if ((dt.Rows.Count - 1) == i)
                    {

                        dr11["pending_sale"] = "Total";
                        dr11["no_of_option_sold"] = Sale_Count;
                        newdt.Rows.Add(dr11);

                        dr12["pending_sale"] = "Total Amount(₹)";
                        dr12["no_of_option_sold"] = string.IsNullOrEmpty(Sale_Total_Amt.ToString()) ? "" : Convert.ToDecimal(Sale_Total_Amt.ToString()).ToString("N", CInfo);// string.Format("{0:0.00}", Sale_Total_Amt);
                        newdt.Rows.Add(dr12);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
            ViewState["SALE"] = newdt;
            ViewState["Total_Amount"] = Sale_Total_Amt;
            ViewState["Sale_Count"] = Sale_Count;
            ViewState["Tranch_Vesting"] = Tranch_Vesting;
            return newdt;

        }
        protected void gvExercise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv1 = (GridView)sender;
                TextBox txtTranchVesting = (TextBox)e.Row.FindControl("txtTranchVesting");
                Label lblTranchVesting = (Label)e.Row.FindControl("lblTranchVesting");

                TextBox txtGrantPrice = (TextBox)e.Row.FindControl("txtGrantPrice");
                Label lblGrantPrice = (Label)e.Row.FindControl("lblGrantPrice");

                TextBox txtFMV = (TextBox)e.Row.FindControl("txtFMV");
                Label lblFMV = (Label)e.Row.FindControl("lblFMV");

                TextBox txtFMVSale = (TextBox)e.Row.FindControl("txtFMVSale");
                Label lblFMVSale = (Label)e.Row.FindControl("lblFMVSale");

                TextBox txtOptions = (TextBox)e.Row.FindControl("txtOptions");
                Label lblOptions = (Label)e.Row.FindControl("lblOptions");

                TextBox txtOptionsExercised = (TextBox)e.Row.FindControl("txtOptionsExercised");
                Label lblOptionsExercised = (Label)e.Row.FindControl("lblOptionsExercised");

                TextBox txtOptionsPendingSale = (TextBox)e.Row.FindControl("txtOptionsPendingSale");
                Label lblOptionsPendingSale = (Label)e.Row.FindControl("lblOptionsPendingSale");

                TextBox txtOptionsSold = (TextBox)e.Row.FindControl("txtOptionsSold");
                Label lblOptionsSold = (Label)e.Row.FindControl("lblOptionsSold");

                TextBox TxtPendingAPP = (TextBox)e.Row.FindControl("TxtPendingAPP");
                Label lblPendingAPP = (Label)e.Row.FindControl("lblPendingAPP");

                TextBox txtTotOptions = (TextBox)e.Row.FindControl("txtTotOptions");
                Label lblTotOptions = (Label)e.Row.FindControl("lblTotOptions");

                TextBox txtNoOfSale = (TextBox)e.Row.FindControl("txtNoOfSale");


                if (txtOptionsPendingSale.Text.Contains("Total"))
                {
                    txtTranchVesting.Visible = false;
                    txtGrantPrice.Visible = false;
                    txtFMV.Visible = false;
                    txtFMVSale.Visible = false;
                    txtOptions.Visible = false;
                    txtOptionsExercised.Visible = false;
                    txtOptionsPendingSale.Visible = false;
                    lblOptionsPendingSale.Font.Bold = true;
                    txtOptionsSold.Visible = true;
                    txtOptionsSold.Font.Bold = true;
                    lblOptionsSold.Visible = false;
                    txtOptionsSold.Enabled = false;

                    lblOptions.Font.Bold = true;
                    lblOptionsSold.Font.Bold = true;
                    TxtPendingAPP.Visible = false;

                    txtTotOptions.Visible = false;
                    lblTotOptions.Visible = false;

                    txtNoOfSale.Visible = false;
                }
                else
                {
                    lblTranchVesting.Visible = false;
                    lblGrantPrice.Visible = false;
                    lblFMV.Visible = false;
                    lblFMVSale.Visible = false;
                    lblOptions.Visible = false;
                    lblOptionsExercised.Visible = false;
                    lblOptionsPendingSale.Visible = false;

                    txtOptionsSold.Visible = true;
                    lblOptionsSold.Visible = false;
                    lblPendingAPP.Visible = false;

                    lblTotOptions.Visible = false;
                }
            }
        }
        protected void txtOptionsSold_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            int rowindex = row.RowIndex;
            string Vesting_Detail_ID = gvExercise.DataKeys[rowindex].Values[0].ToString();

            TextBox txtOptionsPendingSale = (TextBox)row.FindControl("txtOptionsPendingSale");
            TextBox txtOptionsExercised = (TextBox)row.FindControl("txtOptionsExercised");
            TextBox txtOptionsSold = (TextBox)row.FindControl("txtOptionsSold");
            TextBox TxtPendingAPP = (TextBox)row.FindControl("TxtPendingAPP");
            Label LblAlert = (Label)row.FindControl("LblAlert");

            if (txtOptionsSold.Text == "")
            {
                txtOptionsSold.Text = "0";
            }
            if ((Convert.ToDouble(txtOptionsPendingSale.Text) < Convert.ToDouble(txtOptionsSold.Text)) && Convert.ToDouble(TxtPendingAPP.Text) == 0)
            {
                // Common.ShowJavascriptAlert("No.of options to be Sold is not greater than pending for sale");
                showmsg.InnerText = "No.of options to be Sold is not greater than pending for sale";
                //LblAlert.Text = "*";
                txtOptionsSold.Text = "0";
                //return;
            }
            else
            {
                //LblAlert.Text = "";
            }

            txtOptionsPendingSale.Text = Convert.ToString(Convert.ToDouble(txtOptionsExercised.Text) - Convert.ToDouble(txtOptionsSold.Text));

            DataTable dtcalexCount = CalculateTotal_No_Of_Options(Convert.ToInt32(Vesting_Detail_ID), Convert.ToDouble(txtOptionsSold.Text));
            gvExercise.DataSource = null;
            gvExercise.DataSource = dtcalexCount;
            gvExercise.DataBind();

            ////Session["Sale_Declaration_FilePath"] = "";
            ////lblSaleDeclaration.Text = "";

            ////Session["Sale_Offer_FilePath"] = "";
            ////LblSaleOffer.Text = "";

            ////Session["Sale_Transaction_Receipt_FilePath"] = "";
            ////lblTransactionReceipt.Text = "";
        }
        protected void ddlChequeBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                {
                    if (ddlChequeBankName.SelectedValue == Convert.ToString(dtBankDetails.Rows[i][0]))
                    {
                        txtChequeBankName.Text = Convert.ToString(dtBankDetails.Rows[i][3]);
                        txtChequeBranchName.Text = Convert.ToString(dtBankDetails.Rows[i][4]);
                        txtChequeAccNo.Text = Convert.ToString(dtBankDetails.Rows[i][5]);
                        txtChequeIFSC.Text = Convert.ToString(dtBankDetails.Rows[i][6]);
                        ViewState["Cheque_FilePath"] = Convert.ToString(dtBankDetails.Rows[i][8]);
                    }
                    if (ddlChequeBankName.SelectedValue == "0")
                    {
                        txtChequeBankName.Text = "";
                        txtChequeBranchName.Text = "";
                        txtChequeIFSC.Text = "";
                        txtChequeAccNo.Text = "";
                        ViewState["Cheque_FilePath"] = "";
                    }
                }
                ////Session["Sale_Declaration_FilePath"] = "";
                ////lblSaleDeclaration.Text = "";

                ////Session["Sale_Offer_FilePath"] = "";
                ////LblSaleOffer.Text = "";

                ////Session["Sale_Transaction_Receipt_FilePath"] = "";
                ////lblTransactionReceipt.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        //protected void ddlNEFTBankName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
        //        for (int i = 0; i < dtBankDetails.Rows.Count; i++)
        //        {
        //            if (ddlNEFTBankName.SelectedValue == Convert.ToString(dtBankDetails.Rows[i][0]))
        //            {
        //                txtNEFTBankName.Text = Convert.ToString(dtBankDetails.Rows[i][3]);
        //                txtNEFTBranchName.Text = Convert.ToString(dtBankDetails.Rows[i][4]);
        //                txtNEFTAccNo.Text = Convert.ToString(dtBankDetails.Rows[i][5]);
        //                txtNEFTIFSC.Text = Convert.ToString(dtBankDetails.Rows[i][6]);
        //            }
        //            if (ddlNEFTBankName.SelectedValue == "0")
        //            {
        //                txtNEFTBankName.Text = "";
        //                txtNEFTBranchName.Text = "";
        //                txtNEFTAccNo.Text = "";
        //                txtNEFTIFSC.Text = "";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //protected void ddlOtherSecurity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dtDEMATDetails = (DataTable)ViewState["DEMAT_Details"];
        //        for (int i = 0; i < dtDEMATDetails.Rows.Count; i++)
        //        {
        //            if (ddlOtherSecurity.SelectedValue == Convert.ToString(dtDEMATDetails.Rows[i][0]))
        //            {
        //                txtOtherSECURITYNAME.Text = Convert.ToString(dtDEMATDetails.Rows[i][3]);
        //                txtOtherDPID.Text = Convert.ToString(dtDEMATDetails.Rows[i][4]);
        //                txtOtherClientID.Text = Convert.ToString(dtDEMATDetails.Rows[i][5]);
        //                txtOtherMemberType.Text = Convert.ToString(dtDEMATDetails.Rows[i][6]);
        //                ////////////////ViewState["OtherSecurity_FilePath"] = Server.MapPath("~/Exercise_Doc/EmployeeExcelFormatFile.xls");
        //                //////////////////lnkDownload.Text = Path.GetFileName(Convert.ToString(ViewState["OtherSecurity_FilePath"]));
        //                //////////////////lnkDownload.Visible = true;


        //                ViewState["OtherSecurity_FilePath"] = Convert.ToString(dtDEMATDetails.Rows[i][8]);
        //                ViewState["PAN_FilePath"] = Convert.ToString(dtDEMATDetails.Rows[i][9]);

        //            }
        //        }
        //        if (ddlOtherSecurity.SelectedValue == "0")
        //        {
        //            txtOtherSECURITYNAME.Text = "";
        //            txtOtherDPID.Text = "";
        //            txtOtherClientID.Text = "";
        //            txtOtherMemberType.Text = "";
        //            ViewState["OtherSecurity_FilePath"] = "";
        //            ViewState["PAN_FilePath"] = "";
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //protected void lnkDownload_Click(object sender, EventArgs e)
        //{


        //    try
        //    {
        //        var scriptManager = ScriptManager.GetCurrent(this.Page);
        //        if (scriptManager != null)
        //        {
        //            scriptManager.RegisterPostBackControl(lnkDownload);
        //        }
        //        if (Convert.ToString(ViewState["OtherSecurity_FilePath"]) == "")
        //        {
        //            Common.ShowJavascriptAlert("Please Select Security Name.");
        //            return;
        //        }
        //        string filePath = Server.MapPath(Convert.ToString(ViewState["OtherSecurity_FilePath"]));
        //        if (File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
        //        {
        //            Response.ContentType = ContentType;
        //            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
        //            Response.WriteFile(filePath);
        //            Response.End();
        //        }
        //        else
        //        {
        //            Common.ShowJavascriptAlert("No file available to download.");

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        //protected void lnkPANCard_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (Convert.ToString(ViewState["PAN_FilePath"]) == "")
        //        {
        //            Common.ShowJavascriptAlert("Please Upload PAN card first.");
        //            return;
        //        }
        //        string filePath = Server.MapPath(Convert.ToString(ViewState["PAN_FilePath"]));
        //        if (File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
        //        {
        //            Response.ContentType = ContentType;
        //            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
        //            Response.WriteFile(filePath);
        //            Response.End();
        //        }
        //        else
        //        {
        //            Common.ShowJavascriptAlert("No file available to download.");

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //    }
        //}
        protected void btnimport_Click(object sender, EventArgs e)
        {
            string S0 = LblSaleOffer.Text;
            try
            {
                //lblTranchVesting.InnerText = Convert.ToString(ViewState["Tranch_Vesting"]).Replace(", ,", ",");

                string tranch_vesting;
                tranch_vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace(",,", ",");
                string temp = "";
                tranch_vesting.Split(',').Distinct().ToList().ForEach(k => temp += k + ",");
                tranch_vesting = temp.Trim(',');
                tranch_vesting = tranch_vesting.Replace(",,", ",");
                tranch_vesting = tranch_vesting.Replace(",", ", ");
                lblTranchVesting.InnerText = tranch_vesting;
                lblExercise_Count.InnerText = Convert.ToString(ViewState["Sale_Count"]);

                DataTable DtDemat = new DataTable();
                DtDemat = (DataTable)ViewState["DematDetails"];
                if (ViewState["DematDetails"] != null)
                {
                    if (DtDemat.Rows.Count > 0)
                    {
                        lblSecurityName.InnerText = DtDemat.Rows[0]["SECURITY_NAME"].ToString();
                        lblDPID.InnerText = DtDemat.Rows[0]["DPID"].ToString();
                        lblClientID.InnerText = DtDemat.Rows[0]["CLIENT_ID"].ToString();
                        lblMemberType.InnerText = DtDemat.Rows[0]["MEMBER_TYPE"].ToString();
                    }
                }

                if (lblExercise_Count.InnerText == "0" && Convert.ToString(Session["Emp_Sale_Session"]) != "True")
                {
                    // Common.ShowJavascriptAlert("Please Add Atleast One Option To Sale.");
                    showmsg.InnerText = "Please Add Atleast One Option To Sale.";
                    return;
                }

                //Added By Nagesh 30/03
                if (Convert.ToString(ViewState["Total_Amount"]) != "")
                {
                    lblTotalAmount.InnerText = string.Format("{0:0.00}", Convert.ToDouble(ViewState["Total_Amount"].ToString()));
                }
                lblChequeBankName.InnerText = txtChequeBankName.Text;
                lblChequeBranchName.InnerText = txtChequeBranchName.Text;
                lblChequeAccNo.InnerText = txtChequeAccNo.Text;
                lblChequeIFSC.InnerText = txtChequeIFSC.Text;

                //lblChequeMICR.InnerText = txtChequeMICR.Text;
                //lblChequeNo.InnerText = txtChequeNo.Text;
                //lblChequeDate.InnerText = txtChequeDate.Text;
                //lblChequeAmount.InnerText = txtChequeAmount.Text;

                //lblNEFTBankName.InnerText = txtNEFTBankName.Text;
                //lblNEFTBranchName.InnerText = txtNEFTBranchName.Text;
                //lblNEFTIFSC.InnerText = txtNEFTIFSC.Text;
                //lblNEFTAccNo.InnerText = txtNEFTAccNo.Text;
                ////lblNEFTUTR.InnerText = txtNEFTUTR.Text;

                //lblLoanBankName.InnerText = txtLoanBankName.Text;
                //lblLoanAmount.InnerText = txtLoanAmount.Text;
                //lblLoanMarginAmount.InnerText = txtLoanMarginAmount.Text;
                //lblLoanPaymentMode.InnerText = ddlLoanMarginMode.SelectedValue;

                //if (Convert.ToString(ViewState["Cheque_FilePath"]) != "")
                //{
                //    Image1.ImageUrl = ViewState["Cheque_FilePath"].ToString();
                //}
                //if (Convert.ToString(ViewState["Demat_FilePath"]) != "")
                //{
                //    Image2.ImageUrl = ViewState["Demat_FilePath"].ToString();
                //}
                if (Convert.ToString(Session["Sale_Offer_FilePath"]) != "")
                {
                    Image1.ImageUrl = Session["Sale_Offer_FilePath"].ToString();
                    string S = LblSaleOffer.Text;
                }
                if (Convert.ToString(Session["Sale_Declaration_FilePath"]) != "")
                {
                    Image2.ImageUrl = Session["Sale_Declaration_FilePath"].ToString();
                    string S1 = lblSaleDeclaration.Text;
                }
                if (Convert.ToString(Session["Sale_Transaction_Receipt_FilePath"]) != "")
                {
                    Image3.ImageUrl = Session["Sale_Transaction_Receipt_FilePath"].ToString();
                    string S2 = lblTransactionReceipt.Text;
                    uploadTransactionRpt1.Attributes.Add("style", "visibility:visible");
                }



                //Image2.ImageUrl = ViewState["OtherSecurity_FilePath"].ToString();
                //Image3.ImageUrl = ViewState["PAN_FilePath"].ToString();


                if (Convert.ToString(Session["Emp_Sale_Session"]) == "True")
                {
                    btnSubmit_Click(this, new EventArgs());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }

            }
            //Common.ShowJavascriptAlert(Convert.ToString(ViewState["Total_Amount"]));
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBO = new employee_saleBO();
            try
            {
                int SALE_TRANSACTION_RECEIPT_ID = 0;
                if (Convert.ToString(ViewState["Approve"]) == "Approved")
                {
                    objBO.ID = Convert.ToString(ViewState["ID"]);
                    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    objBO.SALE_TRANSACTION_RECEIPT_FILE_PATH = Session["Sale_Transaction_Receipt_FilePath"].ToString();
                    SALE_TRANSACTION_RECEIPT_ID = objBAL.INSERT_SALE_TRANSACTION_RECEIPT_FILE_PATH(objBO);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "DIS Status submitted and send to Admin for approval.";
                    btnimport1.Enabled = false;
                    fuCheque.Enabled = false;
                    AsynFileupSaleDeclaration.Enabled = false;
                    btnimport.Enabled = false;
                    AsyncFileupTransactionReceipt.Enabled = false;
                   

                }
                else
                {
                    if (IsPageRefresh)
                    {
                        return;
                    }
                    if (Convert.ToString(ViewState["Pending"]) == "True")
                    {
                        return;
                    }
                    if (Convert.ToString(Session["Emp_Sale_Session"]) != "True")
                    {
                        if (Convert.ToString(Session["Sale_Offer_FilePath"]) == "")  //(Convert.ToString(LblSaleOffer.Text) == "")
                        {
                            Common.ShowJavascriptAlert("Please upload Sale Offer.");
                            showmsg.InnerText = "Please upload Sale Offer.";
                            return;
                        }

                        if (Convert.ToString(Session["Sale_Declaration_FilePath"]) == "") // (Convert.ToString(lblSaleDeclaration.Text) == "")
                        {
                            Common.ShowJavascriptAlert("Please upload Sale Declaration.");
                            showmsg.InnerText = "Please upload Sale Declaration.";
                            return;
                        }

                        //if (Convert.ToString(Session["Sale_Transaction_Receipt_FilePath"]) == "") //(Convert.ToString(lblTransactionReceipt.Text) == "")
                        //{
                        //    Common.ShowJavascriptAlert("Please upload Transaction Receipt.");
                        //    return;
                        //}
                    }
                    objBO.ECODE = Convert.ToString(Session["ECODE"]);
                    objBO.OPTION_SALE = Convert.ToInt32(ViewState["Sale_Count"]); ;
                    objBO.TRANCH_VESTING = Convert.ToString(lblTranchVesting.InnerText);
                    //objBO.TOTAL_AMOUNT = Convert.ToDouble(ViewState["Total_Amount"]);
                    // objBO.PAYMENT_MODE = Convert.ToString(Request.Form[hfPaymantMode.UniqueID]);
                    //if (objBO.PAYMENT_MODE == "Cheque")
                    //{
                    objBO.CHEQUE_BANK_NAME = Convert.ToString(lblChequeBankName.InnerText);
                    objBO.CHEQUE_BRANCH_NAME = Convert.ToString(lblChequeBranchName.InnerText);
                    objBO.CHEQUE_ACC_NO = Convert.ToString(lblChequeAccNo.InnerText);
                    objBO.CHEQUE_IFSC = Convert.ToString(lblChequeIFSC.InnerText);
                    //objBO.CHEQUE_MICR = Convert.ToString(lblChequeMICR.InnerText);
                    objBO.CHEQUE_FILE_NAME = "";
                    if (Convert.ToString(ViewState["Cheque_FilePath"]) != "")
                    {
                        objBO.CHEQUE_FILE_PATH = Convert.ToString(ViewState["Cheque_FilePath"]);
                    }

                    objBO.TOTAL_AMOUNT = Convert.ToDouble(lblTotalAmount.InnerText);
                    //objBO.CHEQUE_NUMBER = Convert.ToString(lblChequeNo.InnerText);
                    //objBO.CHEQUE_DATE = Convert.ToDateTime(lblChequeDate.InnerText, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    //objBO.CHEQUE_AMOUNT = Convert.ToDouble(lblChequeAmount.InnerText);
                    //}
                    //else if (objBO.PAYMENT_MODE == "NEFT")
                    //{
                    //    objBO.NEFT_BANK_NAME = Convert.ToString(lblNEFTBankName.InnerText);
                    //    objBO.NEFT_BRANCH_NAME = Convert.ToString(lblNEFTBranchName.InnerText);
                    //    objBO.NEFT_ACC_NO = Convert.ToString(lblNEFTAccNo.InnerText);
                    //    objBO.NEFT_IFSC = Convert.ToString(lblNEFTIFSC.InnerText);
                    //    //objBO.NEFT_FILE_NAME = "";
                    //    //objBO.NEFT_FILE_PATH = "";
                    //    //objBO.NEFT_UTR_NO = Convert.ToString(lblNEFTIFSC.InnerText);
                    //}


                    objBO.SECURITY_NAME = Convert.ToString(lblSecurityName.InnerText);
                    objBO.DPID = Convert.ToString(lblDPID.InnerText);
                    objBO.CLIENT_ID = Convert.ToString(lblClientID.InnerText);
                    objBO.MEMBER_TYPE = Convert.ToString(lblMemberType.InnerText);
                    //objBO.DEMAT_FILE_PATH = Convert.ToString(ViewState["OtherSecurity_FilePath"]);
                    //objBO.PAN_FILE_PATH = Convert.ToString(ViewState["PAN_FilePath"]);
                    if (Convert.ToString(Session["Sale_Offer_FilePath"]) != "")
                    {
                        objBO.SALE_OFFER_FILE_PATH = Convert.ToString(Session["Sale_Offer_FilePath"]);
                    }

                    if (Convert.ToString(Session["Sale_Declaration_FilePath"]) != "")
                    {
                        objBO.SALE_DECLARATION_FILE_PATH = Convert.ToString(Session["Sale_Declaration_FilePath"]);
                    }

                    if (Convert.ToString(Session["Sale_Transaction_Receipt_FilePath"]) != "")
                    {
                        objBO.SALE_TRANSACTION_RECEIPT_FILE_PATH = Convert.ToString(Session["Sale_Transaction_Receipt_FilePath"]);
                    }


                    objBO.CREATEDBY = Convert.ToString(Session["ECODE"]);
                    int SALE_TRAN_ID = 0;
                    objBO.DIS_STATUS = "Pending";
                    objBO.APPROVE_STATUS = "Pending";


                    if (Convert.ToString(Session["Emp_Sale_Session"]) == "True")
                    {
                        SALE_TRAN_ID = objBAL.INSERT_EMPLOYEE_SALE_TRANSACTION_SESSION(objBO);
                    }
                    else
                    {
                        SALE_TRAN_ID = objBAL.INSERT_EMPLOYEE_SALE_TRANSACTION(objBO);
                    }

                    if (SALE_TRAN_ID > 0)
                    {
                        DataTable dt = (DataTable)ViewState["SALE"];
                        for (int i = 0; i < dt.Rows.Count - 2; i++)
                        {
                            if (Convert.ToDouble(dt.Rows[i][22]) != 0)
                            {
                                //objBO.ECODE = Convert.ToString(Session["ECODE"]);
                                //objBO.VESTING_DETAIL_ID = Convert.ToInt32(dt.Rows[i][0]);
                                //objBO.OPTION_SALE = Convert.ToDouble(dt.Rows[i][22]);

                                //objBAL.UPDATE_EMPLOYEE_SALE(objBO);

                                //----------------------insert into transaction details table for each option sold tranch vesting wise-------------
                                objBO._SALE_TRAN_ID = SALE_TRAN_ID;
                                objBO._GRANT_ID = Convert.ToInt32(dt.Rows[i][3]);
                                objBO._VESTING_DETAIL_ID = Convert.ToInt32(dt.Rows[i][0]);
                                objBO._ECODE = Convert.ToString(dt.Rows[i][1]);
                                objBO._ENAME = Convert.ToString(dt.Rows[i][2]);
                                objBO._GRANT_NAME = Convert.ToString(dt.Rows[i][4]);
                                objBO._VESTING_DETAIL_CODE = Convert.ToString(dt.Rows[i][5]);
                                objBO._VESTING_DATE = Convert.ToDateTime(dt.Rows[i][8]);
                                objBO._NO_OF_VESTING = Convert.ToDouble(dt.Rows[i][7]);
                                objBO._GRANT_PRICE = Convert.ToDouble(dt.Rows[i][11]);
                                objBO._EXERCISE_FMV_PRICE = Convert.ToDouble(dt.Rows[i][12]);
                                objBO._SALE_FMV_PRICE = Convert.ToDouble(dt.Rows[i][23]);
                                objBO._NO_OF_SALE = Convert.ToDouble(dt.Rows[i][22]);
                                //objBO._EXERCISE_DATE = Convert.ToInt32();
                                //objBO._TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i][15]);
                                //objBO._EXERCISE_CONSIDERATION = Convert.ToDouble(dt.Rows[i][16]);
                                //objBO._FMV_GRANT_OPTION_EXERCISE = Convert.ToDouble(dt.Rows[i][17]);
                                //objBO._REVISED_TAXABLE_INCOME = Convert.ToDouble(dt.Rows[i][18]);
                                //objBO._TAX_PER_OPTION = Convert.ToDouble(dt.Rows[i][19]);
                                //objBO._PERQ_TAX_AMOUNT = Convert.ToDouble(dt.Rows[i][20]);
                                //objBO._TOTAL_AMOUNT = Convert.ToDouble(dt.Rows[i][21]);
                                //objBO._AMOUNT_DEPOSITED = Convert.ToDouble(0);
                                //objBO._FUNDING_AMOUNT = Convert.ToDouble(0);
                                objBO._SECURITY_NAME = Convert.ToString(lblSecurityName.InnerText);
                                objBO._DPID = Convert.ToString(lblDPID.InnerText);
                                objBO._CLIENT_ID = Convert.ToString(lblClientID.InnerText);
                                objBO._MEMBER_TYPE = Convert.ToString(lblMemberType.InnerText);
                                //objBO._PAYMENT_MODE = Convert.ToString(Request.Form[hfPaymantMode.UniqueID]);
                                //if (objBO._PAYMENT_MODE == "Cheque")
                                //{
                                objBO._BANK_NAME = Convert.ToString(lblChequeBankName.InnerText);
                                objBO._BANK_BRANCH = Convert.ToString(lblChequeBranchName.InnerText);
                                objBO._ACC_NO = Convert.ToString(lblChequeAccNo.InnerText);
                                objBO._IFSC = Convert.ToString(lblChequeIFSC.InnerText);
                                //objBO.=
                                //objBO._MICR = Convert.ToString(lblChequeMICR.InnerText);
                                //objBO._CHEQUE_NUMBER = Convert.ToString(lblChequeNo.InnerText);
                                //objBO._CHEQUE_DATE = Convert.ToDateTime(lblChequeDate.InnerText, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                                //}
                                //else if (objBO._PAYMENT_MODE == "NEFT")
                                //{
                                //    objBO._BANK_NAME = Convert.ToString(lblNEFTBankName.InnerText);
                                //    objBO._BANK_BRANCH = Convert.ToString(lblNEFTBranchName.InnerText);
                                //    objBO._ACC_NO = Convert.ToString(lblNEFTAccNo.InnerText);
                                //    objBO._IFSC = Convert.ToString(lblNEFTIFSC.InnerText);
                                //}
                                //////else if (objBO.PAYMENT_MODE == "Loan")
                                //////{

                                //////    objBO._BANK_NAME = Convert.ToString(lblLoanBankName.InnerText);
                                //////    //////////objBO.LOAN_AMOUNT = Convert.ToDouble(lblLoanAmount.InnerText);
                                //////    //////////objBO.LOAN_MARGIN_AMOUNT = Convert.ToDouble(lblLoanMarginAmount.InnerText);
                                //////    //////////objBO.LOAN_MARGIN_PAYMENT_MODE = Convert.ToString(lblLoanPaymentMode.InnerText);
                                //////}
                                objBO._CREATEDBY = Convert.ToString(Session["ECODE"]);
                                objBO.DIS_STATUS = "Pending";
                                objBO.APPROVE_STATUS = "Pending";

                                if (Convert.ToString(Session["Emp_Sale_Session"]) == "True")
                                {
                                    objBAL.INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS_SESSION(objBO);
                                }
                                else
                                {
                                    objBAL.INSERT_EMPLOYEE_SALE_TRANSACTION_DETAILS(objBO);
                                }

                            }
                        }
                    }
                    //Common.ShowJavascriptAlert("Sale Submitted Successfully.");
                    //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //showmsg.InnerText = "Sale Submitted Successfully";

                    if (Convert.ToString(Session["Emp_Sale_Session"]) != "True")
                    {
                        ClearInputs(Page.Controls);
                        BIND_SALE_GRID();
                        lblSaleDeclaration.Text = "";
                        LblSaleOffer.Text = "";
                        Session["Done"] = "Done";
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Sale allotment is submitted successfully and sent to Admin for approval";
                        Response.Redirect(Request.RawUrl);
                    }
                    

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {

                if (Convert.ToString(Session["Emp_Sale_Session"]) == "True")
                {
                    //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //showmsg.InnerText = "Exercise Data Saved";
                }
                else
                {
                    //ClearInputs(Page.Controls);
                    //BIND_SALE_GRID();
                    //lblSaleDeclaration.Text = "";
                    //LblSaleOffer.Text = "";
                    //Session["Done"] = "Done";
                    //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    //showmsg.InnerText = "Sale Submitted Successfully";
                    //Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
            }

        }
        protected void lnkChequeDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var scriptManager = ScriptManager.GetCurrent(this.Page);
                if (scriptManager != null)
                {
                    scriptManager.RegisterPostBackControl(lnkChequeDownload);
                }
                if (Convert.ToString(ViewState["Cheque_FilePath"]) == "")
                {
                    // Common.ShowJavascriptAlert("Please Select Bank Name.");
                    showmsg.InnerText = "Please Select Bank Name.";
                    return;
                }
                string filePath = Server.MapPath(Convert.ToString(ViewState["Cheque_FilePath"]));
                if (File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }

                else
                {
                    // Common.ShowJavascriptAlert("No file available to download.");
                    showmsg.InnerText = "No file available to download.";

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkSaleOffer_Click(object sender, EventArgs e)
        {
            try
            {
                //string sourceFile = Server.MapPath("~/Sale_Doc_Template/ESOP-Sale-Offer.docx");
                //string destinationFile = System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template/ESOP-Sale-Offer_New.docx"));
                string sourceFile = FunGetActiveLetter("Sale Offer Letter");
                if (sourceFile == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Atleast one Sale offer letter should be active!!');", true);
                    return;
                }

                string destinationFile = System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template/ESOP-Sale-Offer_New.docx"));
                string filePath = FuncReplaceWord(sourceFile, destinationFile, Convert.ToString(Session["ECODE"]));
                if (File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    // Common.ShowJavascriptAlert("No file available to download.");
                    showmsg.InnerText = "No file available to download.";

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        protected void lnkSaleDeclaration_Click(object sender, EventArgs e)
        {
            try
            {

                //string sourceFile = Server.MapPath("~/Sale_Doc_Template/ESOP-Sale-Declaration.docx");
                //string destinationFile = System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template/ESOP-Sale-Declaration_New.docx"));

                string sourceFile = FunGetActiveLetter("Sale Declaration Letter");
                if (sourceFile == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Atleast one Sale Declaration letter should be active!!');", true);
                    return;
                }

                string destinationFile = System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template/ESOP-Sale-Declaration_New.docx"));

                string filePath = FuncReplaceWord(sourceFile, destinationFile, Convert.ToString(Session["ECODE"]));
                if (File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    //Common.ShowJavascriptAlert("No file available to download.");
                    showmsg.InnerText = "No file available to download.";

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        //protected void fuSaleOffer_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        //{
        //    try
        //    {
        //        string fileName = System.IO.Path.GetFileName(fuSaleOffer.FileName);
        //        string ext = System.IO.Path.GetExtension(fuSaleOffer.FileName);

        //        if (System.IO.Path.GetExtension(fileName).Contains(".jpeg") || System.IO.Path.GetExtension(fileName).Contains(".png") || System.IO.Path.GetExtension(fileName).Contains(".jpg") || System.IO.Path.GetExtension(fileName).Contains(".pdf"))
        //        {
        //            fileName = "ESOP-Sale-Offer-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
        //            //string filename = System.IO.Path.GetFileName(fuNEFT1.FileName);
        //            fuSaleOffer.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
        //            Session["Sale_Offer_FilePath"] = "~/Sale_Doc/" + fileName;
        //            //txtSaleOffer.Text = "1234";
        //        }
        //        else
        //        {
        //            Common.ShowJavascriptAlert("File type not allowed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}

        //protected void fuSaleDeclaration_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        //{
        //    try
        //    {
        //        string fileName = System.IO.Path.GetFileName(fuSaleDeclaration.FileName);
        //        string ext = System.IO.Path.GetExtension(fuSaleDeclaration.FileName);

        //        if (System.IO.Path.GetExtension(fileName).Contains(".jpeg") || System.IO.Path.GetExtension(fileName).Contains(".png") || System.IO.Path.GetExtension(fileName).Contains(".jpg") || System.IO.Path.GetExtension(fileName).Contains(".pdf"))
        //        {
        //            fileName = "ESOP-Sale-Declaration-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
        //            //string filename = System.IO.Path.GetFileName(fuNEFT1.FileName);
        //            fuSaleDeclaration.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
        //            Session["Sale_Declaration_FilePath"] = "~/Sale_Doc/" + fileName;
        //        }
        //        else
        //        {
        //            Common.ShowJavascriptAlert("File type not allowed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}

        public string FuncReplaceWord(string sourceFile, string destinationFile, string EmpID)
        {

            employee_saleBO objBO = new employee_saleBO();
            employee_saleBAL objBAL = new employee_saleBAL();
            try
            {
                if (!File.Exists(sourceFile))
                {
                    return "";
                }
                File.Copy(sourceFile, destinationFile, true);
                DataSet ds = new DataSet();
                objBO.ECODE = EmpID.ToString();
                ds = objBAL.GET_EMP_data(objBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Editing Docx file with Dynamic data from database.
                    using (WordprocessingDocument doc = WordprocessingDocument.Open(destinationFile, true))
                    {
                        string docText = null;
                        using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        ////////////////////////////////////---Letter Edit Keywords---////////////////////////////////////
                        if (docText.Contains("@Emp_Code"))
                        {
                            Regex regexText = new Regex("@Emp_Code");
                            docText = regexText.Replace(docText, EmpID.ToString());
                        }

                        if (docText.Contains("@Emp_Name"))
                        {
                            Regex regexText = new Regex("@Emp_Name");
                            docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                        }


                        //////////////////////////////////////////////////////////
                        int No_Of_Shares = 0;
                        decimal FMVPrice = 0;

                        for (int i = gvExercise.Rows.Count - 1; i >= 0; i--)
                        {
                            if (i == (gvExercise.Rows.Count - 2))
                            {
                                if (No_Of_Shares == 0)
                                {
                                    No_Of_Shares = Convert.ToInt16(((TextBox)gvExercise.Rows[i].FindControl("txtOptionsSold")).Text);
                                }
                            }

                            if (FMVPrice == 0)
                            {
                                string Val = ((TextBox)gvExercise.Rows[i].FindControl("txtFMVSale")).Text;
                                if (!string.IsNullOrEmpty(Val))
                                {
                                    FMVPrice = Convert.ToDecimal(Val);
                                }
                            }

                        }

                        if (docText.Contains("@No_Of_Options"))
                        {
                            Regex regexText = new Regex("@No_Of_Options");
                            docText = regexText.Replace(docText, No_Of_Shares.ToString());
                        }

                        if (docText.Contains("@In_Words"))
                        {
                            string word = ConvertNumbertoWords(Convert.ToInt32(No_Of_Shares));
                            Regex regexText = new Regex("@In_Words");
                            docText = regexText.Replace(docText, word);
                        }

                        if (docText.Contains("@FMV"))
                        {
                            Regex regexText = new Regex("@FMV");
                            docText = regexText.Replace(docText, FMVPrice.ToString());
                        }

                        if (docText.Contains("@FMV_Price"))
                        {
                            Regex regexText = new Regex("@FMV_Price");
                            docText = regexText.Replace(docText, FMVPrice.ToString());
                        }
                        ///////////////////////////////////////////////////////////

                        if (docText.Contains("@Date"))
                        {
                            Regex regexText = new Regex("@Date");
                            docText = regexText.Replace(docText, DateTime.Now.ToString("MMMM dd,yyyy"));
                        }

                        if (docText.Contains("@Emp_Full_Name"))
                        {
                            Regex regexText = new Regex("@Emp_Full_Name");
                            docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                        }

                        if (docText.Contains("@Address1"))
                        {
                            Regex regexText = new Regex("@Address1");
                            docText = regexText.Replace(docText, "Chakala");
                        }

                        if (docText.Contains("@Address2"))
                        {
                            Regex regexText = new Regex("@Address2");
                            docText = regexText.Replace(docText, "Andheri");
                        }

                        if (docText.Contains("@Email_ID"))
                        {
                            Regex regexText = new Regex("@Email_ID");
                            docText = regexText.Replace(docText, ds.Tables[0].Rows[0]["EMAILID"].ToString());
                        }

                        if (ViewState["DematDetails"] != null)
                        {
                            DataTable DtDemat = new DataTable();
                            DtDemat = (DataTable)ViewState["DematDetails"];
                            if (DtDemat.Rows.Count > 0)
                            {
                                if (docText.Contains("@DPID"))
                                {
                                    Regex regexText = new Regex("@DPID");
                                    docText = regexText.Replace(docText, DtDemat.Rows[0]["DPID"].ToString());
                                }

                                if (docText.Contains("@Client_ID"))
                                {
                                    Regex regexText = new Regex("@Client_ID");
                                    docText = regexText.Replace(docText, DtDemat.Rows[0]["CLIENT_ID"].ToString());
                                }
                            }
                        }
                        if (docText.Contains("@Acc_No"))
                        {
                            Regex regexText = new Regex("@Acc_No");
                            //if (txtNEFTAccNo.Text != "")
                            //{
                            //    docText = regexText.Replace(docText, txtNEFTAccNo.Text.ToString());
                            //}
                            //else
                            //{
                            if (txtChequeAccNo.Text != "")
                            {
                                docText = regexText.Replace(docText, txtChequeAccNo.Text.ToString());
                            }
                            else
                            {
                                docText = regexText.Replace(docText, "");
                            }
                            //}

                        }

                        if (docText.Contains("@Bank_Name"))
                        {
                            Regex regexText = new Regex("@Bank_Name");
                            if (txtChequeBankName.Text != "")
                            {
                                docText = regexText.Replace(docText, txtChequeBankName.Text.ToString());
                            }
                            else
                            {
                                //if (txtNEFTBankName.Text != "")
                                //{
                                //    docText = regexText.Replace(docText, txtNEFTBankName.Text.ToString());
                                //}
                                //else
                                //{
                                docText = regexText.Replace(docText, "");
                                //}
                            }
                        }

                        if (docText.Contains("@MICR_Code"))
                        {
                            Regex regexText = new Regex("@MICR_Code");
                            //if (txtChequeMICR.Text != "")
                            //{
                            //    docText = regexText.Replace(docText, txtChequeMICR.Text.ToString());
                            //}
                            //else
                            //{
                            docText = regexText.Replace(docText, "");
                            // }
                        }

                        if (docText.Contains("@IFSC_Code"))
                        {
                            Regex regexText = new Regex("@IFSC_Code");
                            if (txtChequeIFSC.Text != "")
                            {
                                docText = regexText.Replace(docText, txtChequeIFSC.Text.ToString());
                            }
                            else
                            {
                                docText = regexText.Replace(docText, "");
                            }

                        }

                        //////////////////////////////////////////////////////////////////////////

                        using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return destinationFile;
        }

        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(ViewState["Pending"]) == "True")
                //{
                //    Common.ShowJavascriptAlert("Sale transaction has been sent to the Admin for approval");
                //    return;
                //}
                //string fileName = System.IO.Path.GetFileName(fileupSaleOffer.FileName);
                //string ext = System.IO.Path.GetExtension(fileupSaleOffer.FileName);

                //if (System.IO.Path.GetExtension(fileName).Contains(".jpeg") || System.IO.Path.GetExtension(fileName).Contains(".png") || System.IO.Path.GetExtension(fileName).Contains(".jpg") || System.IO.Path.GetExtension(fileName).Contains(".pdf") || System.IO.Path.GetExtension(fileName).Contains(".docx") || System.IO.Path.GetExtension(fileName).Contains(".doc"))
                //{
                //    fileName = "ESOP-Sale-Offer-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                //    fileupSaleOffer.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
                //    Session["Sale_Offer_FilePath"] = "~/Sale_Doc/" + fileName;
                //    LblSaleOffer.Text = fileupSaleOffer.FileName;
                //    FileupSaleDeclaration.Focus();

                //    //string F_Path = Server.MapPath("~/Sale_Doc/" + fileName);
                //    //Common.UploadFtpFile("Sale_Doc/" + fileName, F_Path);

                //}
                //else
                //{
                //    Common.ShowJavascriptAlert("File type not allowed");
                //    fileupSaleOffer.Focus();
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void BtnSaleDeclaration_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToString(ViewState["Pending"]) == "True")
            //    {
            //        Common.ShowJavascriptAlert("sale transaction is pending with the Admin");
            //        return;
            //    }
            //    string fileName = System.IO.Path.GetFileName(FileupSaleDeclaration.FileName);
            //    string ext = System.IO.Path.GetExtension(FileupSaleDeclaration.FileName);

            //    if (System.IO.Path.GetExtension(fileName).Contains(".jpeg") || System.IO.Path.GetExtension(fileName).Contains(".png") || System.IO.Path.GetExtension(fileName).Contains(".jpg") || System.IO.Path.GetExtension(fileName).Contains(".pdf") || System.IO.Path.GetExtension(fileName).Contains(".docx") || System.IO.Path.GetExtension(fileName).Contains(".doc"))
            //    {
            //        fileName = "ESOP-Sale-Declaration-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
            //        //string filename = System.IO.Path.GetFileName(fuNEFT1.FileName);
            //        FileupSaleDeclaration.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
            //        Session["Sale_Declaration_FilePath"] = "~/Sale_Doc/" + fileName;
            //        lblSaleDeclaration.Text = FileupSaleDeclaration.FileName;
            //        btnimport.Focus();

            //        //string F_Path = Server.MapPath("~/Sale_Doc/" + fileName);
            //        //Common.UploadFtpFile("Sale_Doc/" + fileName, F_Path);
            //    }
            //    else
            //    {
            //        Common.ShowJavascriptAlert("File type not allowed");
            //        FileupSaleDeclaration.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            //}
        }

        public string FunGetActiveLetter(string ReportType)
        {
            string Letter = "";
            DataSet DsLetter = new DataSet();
            DsLetter = objBAL.GetSalesActiveLetter();
            if (ReportType == "Sale Offer Letter")
            {
                if (DsLetter != null && DsLetter.Tables[0].Rows.Count > 0)
                {
                    Letter = Server.MapPath(DsLetter.Tables[0].Rows[0]["FILENAME"].ToString());
                }
            }
            else
            {
                if (DsLetter != null && DsLetter.Tables[1].Rows.Count > 0)
                {
                    Letter = Server.MapPath(DsLetter.Tables[1].Rows[0]["FILENAME"].ToString());
                }
            }
            return Letter;
        }

        protected void gvExercise_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            ////e.Row.Cells[6].Visible = false;

            e.Row.Cells[8].Visible = false;
        }

        protected void btnSession_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["APPROVE"]) == "")
            {
                Session["Emp_Sale_Session"] = "True";
                btnimport_Click(btnimport, new EventArgs());
            }
        }
        protected void Feeldata(DataSet ds1)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                ViewState["Grd_Session"] = "True";
                ViewState["Grd_Table"] = ds1.Tables[1];
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString() != "")
                    {
                        for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                        {
                            if (Convert.ToString(dtBankDetails.Rows[i][2]).Contains(ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString()))
                            {
                                ddlChequeBankName.SelectedValue = Convert.ToString(dtBankDetails.Rows[i][0]);
                                ddlChequeBankName_SelectedIndexChanged(this, EventArgs.Empty);
                            }
                        }
                    }
                    else
                    {
                        ddlChequeBankName.SelectedIndex = 0;
                    }

                    txtChequeBankName.Text = ds1.Tables[0].Rows[0]["CHEQUE_BANK_NAME"].ToString();
                    txtChequeAccNo.Text = ds1.Tables[0].Rows[0]["CHEQUE_ACC_NO"].ToString();
                    txtChequeBranchName.Text = ds1.Tables[0].Rows[0]["CHEQUE_BRANCH_NAME"].ToString();
                    txtChequeIFSC.Text = ds1.Tables[0].Rows[0]["CHEQUE_IFSC"].ToString();

                    //Sale offer & Declaration Letter

                    if (ds1.Tables[0].Rows[0]["SALE_OFFER_FILE_PATH"].ToString() != "")
                    {
                        Session["Sale_Offer_FilePath"] = ds1.Tables[0].Rows[0]["SALE_OFFER_FILE_PATH"].ToString();
                        string[] Sale_Offer_FilePath = ds1.Tables[0].Rows[0]["SALE_OFFER_FILE_PATH"].ToString().Split(new Char[] { '/' });
                        LblSaleOffer.Text = Sale_Offer_FilePath[2].ToString();
                        TextBox0.Text = "File";
                    }

                    if (ds1.Tables[0].Rows[0]["SALE_DECLARATION_FILE_PATH"].ToString() != "")
                    {
                        Session["Sale_Declaration_FilePath"] = ds1.Tables[0].Rows[0]["SALE_DECLARATION_FILE_PATH"].ToString();
                        string[] Sale_Declaration_FilePath = ds1.Tables[0].Rows[0]["SALE_DECLARATION_FILE_PATH"].ToString().Split(new Char[] { '/' });
                        lblSaleDeclaration.Text = Sale_Declaration_FilePath[2].ToString();
                        TextBox1.Text = "File";
                    }

                    if (ds1.Tables[0].Rows[0]["SALE_TRANSACTION_RECEIPT_FILE_PATH"].ToString() != "")
                    {
                        Session["Sale_Transaction_Receipt_FilePath"] = ds1.Tables[0].Rows[0]["SALE_TRANSACTION_RECEIPT_FILE_PATH"].ToString();
                        string[] Sale_Transaction_Receipt_FilePath = ds1.Tables[0].Rows[0]["SALE_TRANSACTION_RECEIPT_FILE_PATH"].ToString().Split(new Char[] { '/' });
                        lblTransactionReceipt.Text = Sale_Transaction_Receipt_FilePath[2].ToString();
                        TextBox2.Text = "File";
                    }
                    //Session["Cheque_FilePathFresh"] = ds1.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                    //if (ds1.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString() != "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop1", "uploadComplete1();", true);
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop2", "FreshChequeSS();", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop3", "Fresh_Cheque_SS_Hide();", true);
                    //}
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Extra_cln_Feeldata(DataSet ds1)
        {
            try
            {
                DataTable dtBankDetails = (DataTable)ViewState["Bank_Details"];
                ViewState["Grd_Session"] = "True";
                ViewState["Grd_Table"] = ds1.Tables[3];
                if (ds1.Tables[2].Rows.Count > 0)
                {
                    if (ds1.Tables[2].Rows[0]["CHEQUE_BANK_NAME"].ToString() != "")
                    {
                        for (int i = 0; i < dtBankDetails.Rows.Count; i++)
                        {
                            if (Convert.ToString(dtBankDetails.Rows[i][2]).Contains(ds1.Tables[2].Rows[0]["CHEQUE_BANK_NAME"].ToString()))
                            {
                                ddlChequeBankName.SelectedValue = Convert.ToString(dtBankDetails.Rows[i][0]);
                                ddlChequeBankName_SelectedIndexChanged(this, EventArgs.Empty);
                            }
                        }
                    }
                    else
                    {
                        ddlChequeBankName.SelectedIndex = 0;
                    }

                    txtChequeBankName.Text = ds1.Tables[2].Rows[0]["CHEQUE_BANK_NAME"].ToString();
                    txtChequeAccNo.Text = ds1.Tables[2].Rows[0]["CHEQUE_ACC_NO"].ToString();
                    txtChequeBranchName.Text = ds1.Tables[2].Rows[0]["CHEQUE_BRANCH_NAME"].ToString();
                    txtChequeIFSC.Text = ds1.Tables[2].Rows[0]["CHEQUE_IFSC"].ToString();

                    //Sale offer & Declaration Letter
                    if (ds1.Tables[2].Rows[0]["SALE_DECLARATION_FILE_PATH"].ToString() != "")
                    {
                        Session["Sale_Declaration_FilePath"] = ds1.Tables[2].Rows[0]["SALE_DECLARATION_FILE_PATH"].ToString();
                        string[] Sale_Declaration_FilePath = ds1.Tables[2].Rows[0]["SALE_DECLARATION_FILE_PATH"].ToString().Split(new Char[] { '/' });
                        lblSaleDeclaration.Text = Sale_Declaration_FilePath[2].ToString();
                        TextBox0.Text = "File";
                    }


                    if (ds1.Tables[2].Rows[0]["SALE_OFFER_FILE_PATH"].ToString() != "")
                    {
                        Session["Sale_Offer_FilePath"] = ds1.Tables[2].Rows[0]["SALE_OFFER_FILE_PATH"].ToString();
                        string[] Sale_Offer_FilePath = ds1.Tables[2].Rows[0]["SALE_OFFER_FILE_PATH"].ToString().Split(new Char[] { '/' });
                        LblSaleOffer.Text = Sale_Offer_FilePath[2].ToString();
                        TextBox1.Text = "File";
                    }

                    if (ds1.Tables[2].Rows[0]["SALE_TRANSACTION_RECEIPT_FILE_PATH"].ToString() != "")
                    {
                        Session["Sale_Transaction_Receipt_FilePath"] = ds1.Tables[2].Rows[0]["SALE_TRANSACTION_RECEIPT_FILE_PATH"].ToString();
                        string[] Sale_Transaction_Receipt_FilePath = ds1.Tables[2].Rows[0]["SALE_TRANSACTION_RECEIPT_FILE_PATH"].ToString().Split(new Char[] { '/' });
                        lblTransactionReceipt.Text = Sale_Transaction_Receipt_FilePath[2].ToString();
                        TextBox2.Text = "File";
                    }
                    //Session["Cheque_FilePathFresh"] = ds1.Tables[2].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                    //if (ds1.Tables[2].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString() != "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop1", "uploadComplete1();", true);
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop2", "FreshChequeSS();", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop3", "Fresh_Cheque_SS_Hide();", true);
                    //}

                    ////if (Convert.ToString(Session["Sale_Transaction_Receipt_FilePath"]) == "")
                    ////{
                    ////    Common.ShowJavascriptAlert("Please upload Transaction Receipt.");
                    ////    return;
                    ////}
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTransactionReceipt_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToString(ViewState["Pending"]) == "True")
            //    {
            //        Common.ShowJavascriptAlert("sale transaction is pending with the Admin");
            //        return;
            //    }
            //    string fileName = System.IO.Path.GetFileName(FileupTransactionReceipt.FileName);
            //    string ext = System.IO.Path.GetExtension(FileupTransactionReceipt.FileName);

            //    if (System.IO.Path.GetExtension(fileName).Contains(".jpeg") || System.IO.Path.GetExtension(fileName).Contains(".png") || System.IO.Path.GetExtension(fileName).Contains(".jpg") || System.IO.Path.GetExtension(fileName).Contains(".pdf") || System.IO.Path.GetExtension(fileName).Contains(".docx") || System.IO.Path.GetExtension(fileName).Contains(".doc"))
            //    {
            //        fileName = "ESOP-Sale-Declaration-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
            //        //string filename = System.IO.Path.GetFileName(fuNEFT1.FileName);
            //        FileupTransactionReceipt.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
            //        Session["Sale_Transaction_Receipt_FilePath"] = "~/Sale_Doc/" + fileName;
            //        lblTransactionReceipt.Text = FileupTransactionReceipt.FileName;
            //        btnimport.Focus();

            //        string F_Path = Server.MapPath("~/Sale_Doc/" + fileName);
            //        Common.UploadFtpFile("Sale_Doc/" + fileName, F_Path);
            //    }
            //    else
            //    {
            //        Common.ShowJavascriptAlert("File type not allowed");
            //        FileupTransactionReceipt.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            //}
        }

        protected void lnkSaleTransactionReceipt_Click(object sender, EventArgs e)
        {
            try
            {

                //string sourceFile = Server.MapPath("~/Sale_Doc_Template/ESOP-Sale-Declaration.docx");
                //string destinationFile = System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template/ESOP-Sale-Declaration_New.docx"));

                string sourceFile = FunGetActiveLetter("Sale Declaration Letter");
                if (sourceFile == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Atleast one Sale Declaration letter should be active!!');", true);
                    return;
                }

                string destinationFile = System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template/Sale_Transaction_Receipt.docx"));

                string filePath = FuncReplaceWord(sourceFile, destinationFile, Convert.ToString(Session["ECODE"]));
                if (File.Exists(filePath) && System.IO.Path.HasExtension(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    //Common.ShowJavascriptAlert("No file available to download.");
                    showmsg.InnerText = "No file available to download.";

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        public void DisablePageControls(bool status)
        {
            //foreach (Control c in Page.Controls)
            //{
            //    foreach (Control ctrl in c.Controls)
            //    {
            //        if (ctrl is TextBox)
            //            ((TextBox)ctrl).Enabled = status;
            //        else if (ctrl is Button)
            //            ((Button)ctrl).Enabled = status;
            //        else if (ctrl is RadioButton)
            //            ((RadioButton)ctrl).Enabled = status;
            //        else if (ctrl is RadioButtonList)
            //            ((RadioButtonList)ctrl).Enabled = status;
            //        else if (ctrl is ImageButton)
            //            ((ImageButton)ctrl).Enabled = status;
            //        else if (ctrl is CheckBox)
            //            ((CheckBox)ctrl).Enabled = status;
            //        else if (ctrl is CheckBoxList)
            //            ((CheckBoxList)ctrl).Enabled = status;
            //        else if (ctrl is DropDownList)
            //            ((DropDownList)ctrl).Enabled = status;
            //        else if (ctrl is HyperLink)
            //            ((HyperLink)ctrl).Enabled = status;


            //    }
            //}
            foreach (GridViewRow row in gvExercise.Rows)
            {
                TextBox name = row.FindControl("txtOptionsSold") as TextBox;
                name.Enabled = false;
            }
            ddlChequeBankName.Enabled = status;
            btnimport.Enabled = status;
            //Common.ShowJavascriptAlert("sale transaction is " + ViewState["Satus"].ToString());
            //Common.ShowJavascriptAlert("Sale is " + ViewState["Satus"].ToString() + " for approavl");
            showmsg.InnerText = "Sale is Pending with secretarial for approval";
        }

        protected void fuCheque_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["Pending"]) == "True")
                {
                    //Common.ShowJavascriptAlert("Sale transaction has been sent to the Admin for approval");
                    showmsg.InnerText = "Sale transaction has been sent to the Admin for approval";
                    return;
                }
                string fileName = System.IO.Path.GetFileName(fuCheque.FileName);
                string ext = System.IO.Path.GetExtension(fuCheque.FileName).ToLower();

                if (ext.Contains(".png") || ext.Contains(".jpeg") || ext.Contains(".jpg") || ext.Contains(".pdf") || ext.Contains(".doc") || ext.Contains(".docx"))
                {
                    string FilePath = Server.MapPath("Sale_Doc");   // checked the file path 

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    fileName = "ESOP-Sale-Offer-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    string path = FilePath + "/" + fileName; // given file name as required
                    fuCheque.SaveAs(path);
                    
                    //fuCheque.SaveAs(Server.MapPath(Server.MapPath("Sale_Doc/") + fileName));
                    Session["Sale_Offer_FilePath"] = "~/Sale_Doc/" + fileName;
                    //string F_Path = Server.MapPath(this.UploadFolderPath + fileName);

                    LblSaleOffer.Text = System.IO.Path.GetFileName(fuCheque.FileName);
                    //ViewState["LblSaleOffer"] = System.IO.Path.GetFileName(fuCheque.FileName);
                }
                else
                {
                    // Common.ShowJavascriptAlert("Only .jpg, .gif, .png, .gif, .pdf, .doc, .docx files are allowed");
                    showmsg.InnerText = "Only .jpg, .gif, .png, .gif, .pdf, .doc, .docx files are allowed";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void AsynFileupSaleDeclaration_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["Pending"]) == "True")
                {
                    //Common.ShowJavascriptAlert("sale transaction is pending with the Admin");
                    showmsg.InnerText = "sale transaction is pending with the Admin";
                    return;
                }
                string fileName = System.IO.Path.GetFileName(AsynFileupSaleDeclaration.FileName);
                string ext = System.IO.Path.GetExtension(AsynFileupSaleDeclaration.FileName).ToLower();

                if (ext.Contains(".jpeg") || ext.Contains(".png") || ext.Contains(".jpg") || ext.Contains(".pdf") || ext.Contains(".docx") || ext.Contains(".doc"))
                {
                    string FilePath = Server.MapPath("Sale_Doc");   // checked the file path 

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    fileName = "ESOP-Sale-Declaration-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    string path = FilePath + "/" + fileName; // given file name as required
                    AsynFileupSaleDeclaration.SaveAs(path);
                    
                    //AsynFileupSaleDeclaration.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
                    Session["Sale_Declaration_FilePath"] = "~/Sale_Doc/" + fileName;

                    lblSaleDeclaration.Text = AsynFileupSaleDeclaration.FileName;

                }
                else
                {
                    // Common.ShowJavascriptAlert("File type not allowed");
                    showmsg.InnerText = "File type not allowed";
                    AsynFileupSaleDeclaration.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void AsyncFileupTransactionReceipt_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["Pending"]) == "True")
                {
                    //Common.ShowJavascriptAlert("sale transaction is pending with the Admin");
                    showmsg.InnerText = "sale transaction is pending with the Admin";
                    return;
                }
                string fileName = System.IO.Path.GetFileName(AsyncFileupTransactionReceipt.FileName);
                string ext = System.IO.Path.GetExtension(AsyncFileupTransactionReceipt.FileName).ToLower();

                if (ext.Contains(".jpeg") || ext.Contains(".png") || ext.Contains(".jpg") || ext.Contains(".pdf") || ext.Contains(".docx") || ext.Contains(".doc"))
                {
                    string FilePath = Server.MapPath("Sale_Doc");   // checked the file path 

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    fileName = "ESOP-Sale-Transaction-Receipt-" + Convert.ToString(Session["ECODE"]) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    string path = FilePath + "/" + fileName; // given file name as required
                    AsyncFileupTransactionReceipt.SaveAs(path);
                    
                    //AsyncFileupTransactionReceipt.SaveAs(Server.MapPath("Sale_Doc/") + fileName);
                    Session["Sale_Transaction_Receipt_FilePath"] = "~/Sale_Doc/" + fileName;
                    lblTransactionReceipt.Text = AsyncFileupTransactionReceipt.FileName;
                }
                else
                {
                    // Common.ShowJavascriptAlert("File type not allowed");
                    showmsg.InnerText = "File type not allowed";
                    AsyncFileupTransactionReceipt.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void save_bankdetail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (IsPageRefresh)
                //{
                //    return;
                //}

                string extension = System.IO.Path.GetExtension(calcel_cheque_file.FileName).ToLower();
                string filaname = Convert.ToString(Session["ECode"]) + "_" + "CHEQUE" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string filepath = "~/EMP_BankDetail/" + filaname;
                string PhysicalPath = Server.MapPath(filepath);
                calcel_cheque_file.SaveAs(PhysicalPath);
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                objbo.BANK_NAME = txtbankname.Text;
                objbo.BRANCH_NAME = txtbranchname.Text;
                objbo.ACC_NO = txtaccnumber.Text;
                objbo.IFSC = txtifsccode.Text;
                objbo.FILE_PATH = filepath;
                objbo.CREATEDBY = Convert.ToString(Session["ECode"]);

                bool result = objbal.Insert_Emp_bankDetail(objbo);
                if (result == true)
                {
                    //lblmsg1.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    ////showmsg.InnerText = "Bank details created successfully";
                    //lblmsg1.Visible = true;
                    //lblmsg1.Text = "Bank details created successfully";
                    ////btnmsg1.Visible = false;
                    //bool msgBank = GET_EMP_BANK_DETAILS();
                    //if (lblmsg2.Text == "Please submit Demat details for login Employee")
                    //{
                    //    Session["Checkerlblmsg1"] = false;
                    //    Session["Checkerlblmsg2"] = true;
                    //    lblmsg2.Visible = true;
                    //    //btnmsg2.Visible = true;
                    //}
                }
                clearcontrol();
                //if (lblmsg1.Text == "Please submit Bank details for login Employee"
                //    || lblmsg2.Text == "Please submit Demat details for login Employee"
                //    || lblmsg3.Text == "Exercise window is closed or not been created by admin")
                //{
                //    DisablePageControls(false);
                //}
                //else
                //{
                //    DisablePageControls(true);
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;

            }
        }

        private void clearcontrol()
        {
            txtbankname.Text = txtbranchname.Text = txtaccnumber.Text = txtifsccode.Text = string.Empty;
        }

        protected void btnimport_Click1(object sender, EventArgs e)
        {
            string S0 = LblSaleOffer.Text;
            try
            {
                //lblTranchVesting.InnerText = Convert.ToString(ViewState["Tranch_Vesting"]).Replace(", ,", ",");

                string tranch_vesting;
                tranch_vesting = Convert.ToString(ViewState["Tranch_Vesting"]).Replace(",,", ",");
                string temp = "";
                tranch_vesting.Split(',').Distinct().ToList().ForEach(k => temp += k + ",");
                tranch_vesting = temp.Trim(',');
                tranch_vesting = tranch_vesting.Replace(",,", ",");
                tranch_vesting = tranch_vesting.Replace(",", ", ");
                lblTranchVesting.InnerText = tranch_vesting;
                lblExercise_Count.InnerText = Convert.ToString(ViewState["Sale_Count"]);

                DataTable DtDemat = new DataTable();
                DtDemat = (DataTable)ViewState["DematDetails"];
                if (ViewState["DematDetails"] != null)
                {
                    if (DtDemat.Rows.Count > 0)
                    {
                        lblSecurityName.InnerText = DtDemat.Rows[0]["SECURITY_NAME"].ToString();
                        lblDPID.InnerText = DtDemat.Rows[0]["DPID"].ToString();
                        lblClientID.InnerText = DtDemat.Rows[0]["CLIENT_ID"].ToString();
                        lblMemberType.InnerText = DtDemat.Rows[0]["MEMBER_TYPE"].ToString();
                    }
                }

                if (lblExercise_Count.InnerText == "0" && Convert.ToString(Session["Emp_Sale_Session"]) != "True")
                {
                    // Common.ShowJavascriptAlert("Please Add Atleast One Option To Sale.");
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Please Add Atleast One Option To Sale.";
                    return;
                }
                
                lblTotalAmount.InnerText = string.Format("{0:0.00}", Convert.ToDouble(ViewState["Total_Amount"].ToString()));

                //lblChequeBankName.InnerText = txtChequeBankName.Text;
                //lblChequeBranchName.InnerText = txtChequeBranchName.Text;
                //lblChequeAccNo.InnerText = txtChequeAccNo.Text;
                //lblChequeIFSC.InnerText = txtChequeIFSC.Text;

                lblChequeBankName.InnerHtml = txtChequeBankName.Text;
                lblChequeBranchName.InnerHtml = txtChequeBranchName.Text;
                lblChequeAccNo.InnerText = txtChequeAccNo.Text;
                lblChequeIFSC.InnerText = txtChequeIFSC.Text;

                if (Convert.ToString(Session["Sale_Offer_FilePath"]) != "")
                {
                    Image1.ImageUrl = Session["Sale_Offer_FilePath"].ToString();
                    string S = LblSaleOffer.Text;
                }
                if (Convert.ToString(Session["Sale_Declaration_FilePath"]) != "")
                {
                    Image2.ImageUrl = Session["Sale_Declaration_FilePath"].ToString();
                    string S1 = lblSaleDeclaration.Text;
                }
                //if (Convert.ToString(Session["Sale_Transaction_Receipt_FilePath"]) != "")
                //{
                //    Image3.ImageUrl = Session["Sale_Transaction_Receipt_FilePath"].ToString();
                //    string S2 = lblTransactionReceipt.Text;
                //}
                if (Convert.ToString(Session["Emp_Sale_Session"]) == "True")
                {
                    btnSubmit_Click(this, new EventArgs());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
            }
            //Common.ShowJavascriptAlert(Convert.ToString(ViewState["Total_Amount"]));
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
    }
}