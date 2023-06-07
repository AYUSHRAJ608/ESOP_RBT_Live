using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;
using System.Data;

namespace ESOP
{
    public partial class hr_dashboard : System.Web.UI.Page
    {
        vesting_creation_BO VestingBO;
        vesting_creation_BAL VestingBAL = new vesting_creation_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainGrid();
                //Hide();
            }
        }
        private void BindMainGrid()
        {
            DataSet ds;
            ds = GET_ADMIN_EMP_STOCK_MAPPING();
            //if (ds.Tables[1].Rows[0]["EXERCISED"].ToString() != "")
            //{
            //    ds.Tables[0].Rows[0]["Exercised"] = ds.Tables[1].Rows[0]["EXERCISED"].ToString();
            //    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = Convert.ToInt32(ds.Tables[1].Rows[0]["EXERCISED"]) - Convert.ToInt32(ds.Tables[0].Rows[0]["sale"]);
            //}
            //else
            //{
            //    ds.Tables[0].Rows[0]["Exercised"] = 0;
            //    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = 0;
            //}

            //if (ds.Tables[2].Rows[0]["SALE"].ToString() != "")
            //{
            //    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = 0;
            //    ds.Tables[0].Rows[0]["SALE"] = ds.Tables[2].Rows[0]["SALE"].ToString();
            //    ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = Convert.ToInt32(ds.Tables[0].Rows[0]["EXERCISED"]) - Convert.ToInt32(ds.Tables[0].Rows[0]["SALE"]);
            //}
            //else
            //{
            //    ds.Tables[0].Rows[0]["SALE"] = 0;
            //    //ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = 0;
            //}
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (Convert.ToString(ds.Tables[1].Rows[0]["LBV"]) != "" || Convert.ToString(ds.Tables[1].Rows[0]["LAV"]) != "" || Convert.ToString(ds.Tables[1].Rows[0]["TOTAL_LAPSED"]) != "")
                {
                    ds.Tables[0].Rows[0]["LBV"] = (Convert.ToString(ds.Tables[1].Rows[0]["LBV"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[1].Rows[0]["LBV"].ToString()); //Convert.ToDecimal(ds.Tables[1].Rows[0]["LBV"]);
                    ds.Tables[0].Rows[0]["LAV"] = (Convert.ToString(ds.Tables[1].Rows[0]["LAV"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[1].Rows[0]["LAV"].ToString());  //Convert.ToDecimal(ds.Tables[1].Rows[0]["LAV"]);
                    ds.Tables[0].Rows[0]["TOTAL_LAPSE"] = (Convert.ToString(ds.Tables[1].Rows[0]["TOTAL_LAPSED"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[1].Rows[0]["TOTAL_LAPSED"].ToString()); //Convert.ToDecimal(ds.Tables[1].Rows[0]["TOTAL_LAPSED"]);
                }
            }

            ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = ((Convert.ToString(ds.Tables[0].Rows[0]["EXERCISED"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["EXERCISED"])) - ((Convert.ToString(ds.Tables[0].Rows[0]["SALE"]) == "") ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["SALE"]));// - Convert.ToDecimal(ds.Tables[0].Rows[0]["TOTAL_LAPSE"]);  //- Convert.ToDecimal(ds.Tables[0].Rows[0]["EXERCISED"])  Convert.ToDecimal(ds.Tables[0].Rows[0]["GRANTED"])-
            ds.Tables[0].Rows[0]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[0]["STOCK_IN_HAND"]));
            gvParent.DataSource = ds.Tables[0];
            gvParent.DataBind();
        }
        protected void gvParent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = e.Row.FindControl("gvChild") as GridView;

                DataSet ds = VestingBAL.USP_GET_ADMIN_STOCK_MAPPING_TRANCHWISE();

                gvChild.DataSource = ds.Tables[0]; //GetAdminGoalsDetails(objGoals.Emp_Code);//
                gvChild.DataBind();

            }
        }
        private DataSet GET_ADMIN_EMP_STOCK_MAPPING()
        {
            VestingBO = new vesting_creation_BO();
            DataSet ds = VestingBAL.GET_ADMIN_EMP_STOCK_MAPPING();
            return ds;
        }
        private DataSet GETVESTINGDETAILSBYID(string V_ID)
        {
            DataSet ds = new DataSet();
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.VID = Convert.ToInt32(V_ID);
                ds = VestingBAL.GETVESTINGDETAILSBYID(VestingBO);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            return ds;
        }

        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChildInner = e.Row.FindControl("gvChildInner") as GridView;
                VestingBO = new vesting_creation_BO();
                GridView gv1 = (GridView)sender;
                Label lblobjective = (Label)e.Row.FindControl("lblTranchName");
                VestingBO.GRANT_NAME = lblobjective.Text.Trim();
                DataSet ds = VestingBAL.GET_ADMIN_EMP_STOCK_MAPPING_TRANCHWISE_DETAILS(VestingBO);

                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        DataTable dt = (ds.Tables[1]);
                //        var type = dt.Columns["NO_OF_EXERCISE"].DataType;

                //        string V_C = ds.Tables[0].Rows[i]["V_Cycle"].ToString();

                //        decimal tot = dt.AsEnumerable()
                //                    .Where(y => y.Field<string>("VESTING_DETAIL_CODE") == V_C)
                //                    .Sum(x => x.Field<decimal>("NO_OF_EXERCISE"));
                //        //.ToString();

                //        ds.Tables[0].Rows[i]["EXERCISED"] = tot;
                //        ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = 0;
                //        if (tot > 0)
                //        {
                //            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = tot - Convert.ToInt32(ds.Tables[0].Rows[i]["sale"]);
                //        }

                //    }
                //    ds.Tables[0].AcceptChanges();

                //}
                //else
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //        {
                //            ds.Tables[0].Rows[i]["EXERCISED"] = 0;
                //        }
                //    }
                //}

                //if (ds.Tables[2].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        DataTable dt = (ds.Tables[2]);
                //        var type = dt.Columns["NO_OF_SALE"].DataType;

                //        string V_C = ds.Tables[0].Rows[i]["V_Cycle"].ToString();

                //        decimal tot = dt.AsEnumerable()
                //                    .Where(y => y.Field<string>("VESTING_DETAIL_CODE") == V_C)
                //                    .Sum(x => x.Field<decimal>("NO_OF_SALE"));
                //        //.ToString();

                //        ds.Tables[0].Rows[i]["SALE"] = tot;
                //        ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = 0;
                //        if (tot > 0)
                //        {
                //            //ds.Tables[0].Rows[i]["SALE"] = tot - Convert.ToInt32(ds.Tables[0].Rows[i]["sale"]);
                //            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Convert.ToInt32(ds.Tables[0].Rows[i]["EXERCISED"]) - tot;
                //        }
                //    }
                //    ds.Tables[0].AcceptChanges();
                //}
                //else
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //        {
                //            ds.Tables[0].Rows[i]["SALE"] = 0;
                //        }
                //    }
                //}
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ds.Tables[0].Rows[j]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[j]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[j]["SALE"]);// - Convert.ToDecimal(ds.Tables[0].Rows[j]["TOTAL_LAPSE"]); //- Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"])
                    ds.Tables[0].Rows[j]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[j]["STOCK_IN_HAND"]));
                }
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

                    //string VP2 = ds.Tables[0].Rows[i]["TOTAL_LAPSE"].ToString();

                    //decimal tot2 = dt.AsEnumerable()
                    //            .Where(y => y.Field<string>("VESTINGNAME") == VP)
                    //            .Sum(x => x.Field<decimal?>("TOTAL_LAPSED") ?? 0);

                    //ds.Tables[0].Rows[i]["TOTAL_LAPSE"] = tot2;
                    ds.Tables[0].Rows[i]["TOTAL_LAPSE"] = tot + tot1;
                    ds.Tables[0].AcceptChanges();
                    ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[i]["SALE"]);// - Convert.ToDecimal(ds.Tables[0].Rows[i]["TOTAL_LAPSE"]); //- Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"])
                    ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[i]["STOCK_IN_HAND"]));
                }


                DataTable dtcal = CalculateTotal(ds.Tables[0]);
                gvChildInner.DataSource = dtcal;// ds.Tables[0]; //GetAdminGoalsDetails(objGoals.Emp_Code);//
                gvChildInner.DataBind();

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
                newdt.Columns.Add("LAPSE_DATE");      //Added by Rahul on 22-08-22 for Showing lapse date on employee dashboard

                //----------decimal changes to double--------

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
                    dr1["LAPSE_DATE"] = dt.Rows[i]["lapse_date"].ToString();          //Added by Rahul on 22-08-22 for Showing lapse date on employee dashboard

                    newdt.Rows.Add(dr1);

                    //GRANTED += dt.Rows[i].Field<decimal>(4);
                    //VESTED += dt.Rows[i].Field<decimal>(5);
                    //VESTED_PENDING += dt.Rows[i].Field<decimal>(6);
                    //EXERCISED += dt.Rows[i].Field<decimal>(7);
                    //EXERCISED_PENDING += dt.Rows[i].Field<decimal>(8);
                    //SALE += dt.Rows[i].Field<decimal>(9);
                    //LBV += dt.Rows[i].Field<decimal>(10);
                    //LAV += dt.Rows[i].Field<decimal>(11);
                    //TOTAL_LAPSE += dt.Rows[i].Field<decimal>(12);
                    //STOCK_IN_HAND += dt.Rows[i].Field<decimal>(13);

                    GRANTED += Convert.ToDouble(dt.Rows[i][4].ToString());
                    VESTED += Convert.ToDouble(dt.Rows[i][5].ToString());
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
                throw ex;
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
            //GridView gv2 = (GridView)sender;
            //if (Convert.ToString(ViewState["HideShow"]) == "Show" || Convert.ToString(ViewState["HideShow"]) == "")
            //{
            //    gv2.Columns[3].Visible = false;
            //    gv2.Columns[5].Visible = false;
            //    gv2.Columns[7].Visible = false;
            //    gv2.Columns[8].Visible = false;
            //}
            //else
            //{
            //    gv2.Columns[3].Visible = true;
            //    gv2.Columns[5].Visible = true;
            //    gv2.Columns[7].Visible = true;
            //    gv2.Columns[8].Visible = true;
            //}
        }

        //protected void btnShowHide_Click(object sender, EventArgs e)
        //{
        //    if (Convert.ToString(ViewState["HideShow"]) == "Hide")
        //    {
        //        Show();
        //    }
        //    else
        //    {
        //        Hide();
        //    }
        //}

        //private void Hide()
        //{
        //    BindMainGrid();
        //    gvParent.Columns[3].Visible = false;
        //    gvParent.Columns[5].Visible = false;
        //    gvParent.Columns[7].Visible = false;
        //    gvParent.Columns[8].Visible = false;
        //    ViewState["HideShow"] = "Hide";
        //}
        //private void Show()
        //{
        //    BindMainGrid();
        //    gvParent.Columns[3].Visible = true;
        //    gvParent.Columns[5].Visible = true;
        //    gvParent.Columns[7].Visible = true;
        //    gvParent.Columns[8].Visible = true;
        //    ViewState["HideShow"] = "Show";
        //}
    }
}