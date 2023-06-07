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
    public partial class ESOP_Excel_Report : System.Web.UI.Page
    {
        PresidentBO PresidentBO;
        PresidentBAL PresidentBAL = new PresidentBAL();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            PresidentBO = new PresidentBO();
            DataSet ds = PresidentBAL.GET_All_Data(PresidentBO);

            //DataTable dtcal_1 = CalculateTotal_1(ds.Tables[0]);
            //GrdExcelData.DataSource = dtcal_1;
            //GrdExcelData.DataBind();


            DataTable dtcal_1_1 = CalculateTotal_1_1(ds.Tables[0]);
            GrdExcelData.DataSource = dtcal_1_1;
            GrdExcelData.DataBind();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PresidentBO = new PresidentBO();
            DataSet ds = PresidentBAL.GET_All_Data(PresidentBO);

            DataTable dtcal_1 = CalculateTotal_1_1(ds.Tables[0]);

            string filename = "Excel_Data" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dtcal_1;
            dgGrid.DataBind();

            dgGrid.RenderControl(hw);

            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }

        private DataTable CalculateTotal_1(DataTable dt)
        {
            DataTable newdt = new DataTable();
            try
            {
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

                DataRow dr1 = newdt.NewRow();

                string emp_id = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    if (emp_id == "" && emp_id != dt.Rows[i][16].ToString())
                    {
                        newdt.Columns.Add("Status");
                        newdt.Columns.Add("Emp_Code");
                        newdt.Columns.Add("Employee_Name");
                        newdt.Columns.Add("DOJ");
                        newdt.Columns.Add("BAND");
                        newdt.Columns.Add("Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
        
                        dr1 = newdt.NewRow();

                        BoundField test = new BoundField();
                        test.DataField = "Status";
                        test.HeaderText = "Status";
                        GrdExcelData.Columns.Add(test);

                        BoundField test1 = new BoundField();
                        test1.DataField = "Emp_Code";
                        test1.HeaderText = "Emp_Code";
                        GrdExcelData.Columns.Add(test1);

                        BoundField test2 = new BoundField();
                        test2.DataField = "Employee_Name";
                        test2.HeaderText = "Employee_Name";
                        GrdExcelData.Columns.Add(test2);

                        BoundField test3 = new BoundField();
                        test3.DataField = "DOJ";
                        test3.HeaderText = "DOJ";
                        GrdExcelData.Columns.Add(test3);

                        BoundField test4 = new BoundField();
                        test4.DataField = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test4.HeaderText = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test4);

                        BoundField test16 = new BoundField();
                        test16.DataField = "Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test16.HeaderText = "Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test16);

                        BoundField test5 = new BoundField();
                        test5.DataField = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test5.HeaderText = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test5);

                        BoundField test6 = new BoundField();
                        test6.DataField = "Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test6.HeaderText = "Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test6);

                        BoundField test7 = new BoundField();
                        test7.DataField = "Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test7.HeaderText = "Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test7);

                        BoundField test8 = new BoundField();
                        test8.DataField = "Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test8.HeaderText = "Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test8);

                        BoundField test9 = new BoundField();
                        test9.DataField = "Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test9.HeaderText = "Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test9);

                        BoundField test10 = new BoundField();
                        test10.DataField = "Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test10.HeaderText = "Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test10);

                        BoundField test11 = new BoundField();
                        test11.DataField = "Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test11.HeaderText = "Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test11);

                        BoundField test12 = new BoundField();
                        test12.DataField = "LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test12.HeaderText = "LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test12);

                        BoundField test13 = new BoundField();
                        test13.DataField = "LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test13.HeaderText = "LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test13);

                        BoundField test14 = new BoundField();
                        test14.DataField = "Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test14.HeaderText = "Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test14);

                        BoundField test15 = new BoundField();
                        test15.DataField = "Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test15.HeaderText = "Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test15);
                    }

                    if (emp_id == "" || newdt.Columns.Contains("PERCENTAGE" + dt.Rows[i][2].ToString()))
                    {
                        dr1["Employee_Name"] = dt.Rows[i][17].ToString();
                        dr1["Status"] = dt.Rows[i][18].ToString();
                        dr1["Doj"] = dt.Rows[i][19].ToString();

                        dr1["Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][3].ToString();
                        dr1["Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][20].ToString();
                        dr1["Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][2].ToString();
                        dr1["Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][4]);
                        dr1["Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][5]);
                        dr1["Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][6]);
                        dr1["Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][7]);
                        dr1["Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][8]);
                        dr1["Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][9]);
                        dr1["LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][10]);
                        dr1["LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][11]);
                        dr1["Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][12]);
                        dr1["Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][13]);
                        //dr1["VESTING_DATE " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][14].ToString();
                        dr1["Emp_Code"] = dt.Rows[i][16].ToString();
                        //newdt.Rows.Add(dr1);
                    }
                    else
                    {

                        string Vper = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        if (newdt.Columns.Equals(Vper))
                        {
                            //emp_id = emp_id;
                        }

                        DataColumnCollection columns = newdt.Columns;
                        if (columns.Contains(Vper))
                        {

                        }
                        else
                        {
                            newdt.Columns.Add("Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                            newdt.Columns.Add("Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());

                            string nme2 = dt.Rows[i][16].ToString();
                            if (str.Contains(dt.Rows[i][16].ToString()))
                            {
                            }
                            else
                            {
                                dr1 = newdt.NewRow();
                            }
                            BoundField test = new BoundField();
                            test.DataField = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test.HeaderText = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test);

                            BoundField test16 = new BoundField();
                            test16.DataField = "Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test16.HeaderText = "Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test16);

                            BoundField test1 = new BoundField();
                            test1.DataField = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test1.HeaderText = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test1);

                            BoundField test2 = new BoundField();
                            test2.DataField = "Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test2.HeaderText = "Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test2);

                            BoundField test3 = new BoundField();
                            test3.DataField = "Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test3.HeaderText = "Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test3);

                            BoundField test4 = new BoundField();
                            test4.DataField = "Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test4.HeaderText = "Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test4);

                            BoundField test5 = new BoundField();
                            test5.DataField = "Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test5.HeaderText = "Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test5);

                            BoundField test6 = new BoundField();
                            test6.DataField = "Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test6.HeaderText = "Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test6);

                            BoundField test7 = new BoundField();
                            test7.DataField = "Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test7.HeaderText = "Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test7);

                            BoundField test8 = new BoundField();
                            test8.DataField = "LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test8.HeaderText = "LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test8);

                            BoundField test9 = new BoundField();
                            test9.DataField = "LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test9.HeaderText = "LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test9);

                            BoundField test10 = new BoundField();
                            test10.DataField = "Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test10.HeaderText = "Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test10);

                            BoundField test11 = new BoundField();
                            test11.DataField = "Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            test11.HeaderText = "Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                            GrdExcelData.Columns.Add(test11);
                        }
                        //DataRow dr1 = newdt.NewRow();

                        string nme = dt.Rows[i][16].ToString();
                        if (str.Contains(dt.Rows[i][16].ToString()))
                        {
                        }
                        else
                        {
                            dr1 = newdt.NewRow();
                        }
                        
                        dr1["Employee_Name"] = dt.Rows[i][17].ToString();
                        dr1["Status"] = dt.Rows[i][18].ToString();
                        dr1["Doj"] = dt.Rows[i][19].ToString();
                        dr1["Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][3].ToString();
                        dr1["Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][20].ToString();
                        dr1["Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][2].ToString();
                        dr1["Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][4]);
                        dr1["Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][5]);
                        dr1["Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][6]);
                        dr1["Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][7]);
                        dr1["Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][8]);
                        dr1["Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][9]);
                        dr1["LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][10]);
                        dr1["LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][11]);
                        dr1["Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][12]);
                        dr1["Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][13]);
                        //dr1["VESTING_DATE " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][14].ToString();
                        dr1["Emp_Code"] = dt.Rows[i][16].ToString();
                    }


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

                    if (str.Contains(dt.Rows[i][16].ToString()))
                    {
                    }
                    else
                    {
                        newdt.Rows.Add(dr1);
                    }
                    emp_id = dt.Rows[i][16].ToString();
                    str = str + dt.Rows[i][16].ToString();

                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

            return newdt;
        }

        private DataTable CalculateTotal_2(DataTable dt)
        {
            DataTable newdt = new DataTable();
            try
            {
                newdt.Columns.Add("GRANT_NAME");
                newdt.Columns.Add("PERCENTAGE");
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

                DataRow dr1 = newdt.NewRow();

                string emp_id = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (emp_id != "" && emp_id != dt.Rows[i][16].ToString())
                    {
                        dr1 = newdt.NewRow();
                    }

                    if (emp_id == "" || emp_id != dt.Rows[i][16].ToString())
                    {
                        //dr1["VID"] = dt.Rows[i][0].ToString();
                        //dr1["V_DETAIL_ID"] = dt.Rows[i][1].ToString();
                        dr1["PERCENTAGE"] = dt.Rows[i][2].ToString();
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
                        //dr1["VESTING_DATE"] = dt.Rows[i][14].ToString();
                        //dr1["EMP_ID"] = dt.Rows[i][16].ToString();
                        //newdt.Rows.Add(dr1);
                    }
                    else
                    {
                        //newdt.Columns.Add("VID" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        //newdt.Columns.Add("V_DETAIL_ID" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("PERCENTAGE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("GRANT_NAME" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("GRANTED" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("VESTED" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("VESTED_PENDING" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("EXERCISED" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("EXERCISED_PENDING" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("SALE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("LBV" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("LAV" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("TOTAL_LAPSE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("STOCK_IN_HAND" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        //newdt.Columns.Add("VESTING_DATE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        //newdt.Columns.Add("EMP_ID" + dt.Rows[i][3].ToString() + dt.Rows[i][16].ToString());

                        //DataRow dr1 = newdt.NewRow();

                        //dr1["VID" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][0].ToString();
                        //dr1["V_DETAIL_ID" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][1].ToString();
                        dr1["PERCENTAGE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][2].ToString();
                        dr1["GRANT_NAME" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][3].ToString();
                        dr1["GRANTED" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][4]);
                        dr1["VESTED" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][5]);
                        dr1["VESTED_PENDING" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][6]);
                        dr1["EXERCISED" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][7]);
                        dr1["EXERCISED_PENDING" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][8]);
                        dr1["SALE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][9]);
                        dr1["LBV" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][10]);
                        dr1["LAV" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][11]);
                        dr1["TOTAL_LAPSE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][12]);
                        dr1["STOCK_IN_HAND" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = Convert.ToDouble(dt.Rows[i][13]);
                        //dr1["VESTING_DATE" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][14].ToString();
                        //dr1["EMP_ID" + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString()] = dt.Rows[i][16].ToString();

                        //newdt.Rows.Add(dr1);

                    }


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

                    if (emp_id == "" || emp_id != dt.Rows[i][16].ToString())
                    {
                        newdt.Rows.Add(dr1);
                    }
                    emp_id = dt.Rows[i][16].ToString();
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

            return newdt;
        }

        private DataTable CalculateTotal_1_1(DataTable dt)
        {
            DataTable newdt = new DataTable();
            try
            {

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

                DataRow dr1 = newdt.NewRow();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string emp_id = "";

                    string GName = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                    foreach (DataColumn dc in newdt.Columns)
                    {
                        if (dc.ColumnName == GName)
                        {
                            emp_id = "True";
                        }
                    }
                    if (emp_id == "True")
                    {
                        //emp_id = emp_id;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            newdt.Columns.Add("Status");
                            newdt.Columns.Add("Emp_Code");
                            newdt.Columns.Add("Employee_Name");
                            newdt.Columns.Add("BAND");
                            newdt.Columns.Add("DOJ");
                            newdt.Columns.Add("Tot Grants");
                            newdt.Columns.Add("Tot Vested");
                            newdt.Columns.Add("Tot Exercised");
                            newdt.Columns.Add("Tot Sell");
                            newdt.Columns.Add("Tot LBV");
                            newdt.Columns.Add("Tot LAV");
                            newdt.Columns.Add("Stock in hand");
                        }
                        newdt.Columns.Add("Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());
                        newdt.Columns.Add("Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString());

                        newdt.AcceptChanges();

                        if (i == 0)
                        {
                            BoundField test = new BoundField();
                            test.DataField = "Status";
                            test.HeaderText = "Status";
                            GrdExcelData.Columns.Add(test);

                            BoundField test1 = new BoundField();
                            test1.DataField = "Emp_Code";
                            test1.HeaderText = "Emp_Code";
                            GrdExcelData.Columns.Add(test1);

                            BoundField test2 = new BoundField();
                            test2.DataField = "Employee_Name";
                            test2.HeaderText = "Employee_Name";
                            GrdExcelData.Columns.Add(test2);

                            BoundField test23 = new BoundField();
                            test23.DataField = "BAND";
                            test23.HeaderText = "BAND";
                            GrdExcelData.Columns.Add(test23);

                            BoundField test3 = new BoundField();
                            test3.DataField = "DOJ";
                            test3.HeaderText = "DOJ";
                            GrdExcelData.Columns.Add(test3);

                            BoundField test17 = new BoundField();
                            test17.DataField = "Tot Grants";
                            test17.HeaderText = "Tot Grants";
                            GrdExcelData.Columns.Add(test17);

                            BoundField test18 = new BoundField();
                            test18.DataField = "Tot Vested";
                            test18.HeaderText = "Tot Vested";
                            GrdExcelData.Columns.Add(test18);

                            BoundField test19 = new BoundField();
                            test19.DataField = "Tot Exercised";
                            test19.HeaderText = "Tot Exercised";
                            GrdExcelData.Columns.Add(test19);

                            BoundField test20 = new BoundField();
                            test20.DataField = "Tot Sell";
                            test20.HeaderText = "Tot Sell";
                            GrdExcelData.Columns.Add(test20);

                            BoundField test21 = new BoundField();
                            test21.DataField = "Tot LBV";
                            test21.HeaderText = "Tot LBV";
                            GrdExcelData.Columns.Add(test21);

                            BoundField test22 = new BoundField();
                            test22.DataField = "Tot LAV";
                            test22.HeaderText = "Tot LAV";
                            GrdExcelData.Columns.Add(test22);

                            BoundField test24 = new BoundField();
                            test24.DataField = "Stock in hand";
                            test24.HeaderText = "Stock in hand";
                            GrdExcelData.Columns.Add(test24);

                        }
                        BoundField test4 = new BoundField();
                        test4.DataField = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test4.HeaderText = "Grant_Name " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test4);

                        BoundField test16 = new BoundField();
                        test16.DataField = "Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test16.HeaderText = "Grant_Date " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test16);

                        BoundField test5 = new BoundField();
                        test5.DataField = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test5.HeaderText = "Percentage " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test5);

                        BoundField test6 = new BoundField();
                        test6.DataField = "Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test6.HeaderText = "Granted " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test6);

                        BoundField test7 = new BoundField();
                        test7.DataField = "Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test7.HeaderText = "Vested " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test7);

                        BoundField test8 = new BoundField();
                        test8.DataField = "Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test8.HeaderText = "Vested_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test8);

                        BoundField test9 = new BoundField();
                        test9.DataField = "Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test9.HeaderText = "Exercised " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test9);

                        BoundField test10 = new BoundField();
                        test10.DataField = "Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test10.HeaderText = "Exercised_Pending " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test10);

                        BoundField test11 = new BoundField();
                        test11.DataField = "Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test11.HeaderText = "Sale " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test11);

                        BoundField test12 = new BoundField();
                        test12.DataField = "LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test12.HeaderText = "LBV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test12);

                        BoundField test13 = new BoundField();
                        test13.DataField = "LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test13.HeaderText = "LAV " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test13);

                        BoundField test14 = new BoundField();
                        test14.DataField = "Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test14.HeaderText = "Total_Lapse " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test14);

                        BoundField test15 = new BoundField();
                        test15.DataField = "Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        test15.HeaderText = "Stock_In_Hand " + dt.Rows[i][3].ToString() + dt.Rows[i][15].ToString();
                        GrdExcelData.Columns.Add(test15);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

            var grouped = from table in dt.AsEnumerable()
                          group table by new { placeCol = table["emp_id"] } into groupby
                          select new
                          {
                              Value = groupby.Key,
                              ColumnValues = groupby
                          };

            foreach (var key in grouped)
            {
                DataRow dr = newdt.NewRow();
                dr["emp_code"] = key.Value.placeCol;
                newdt.Rows.Add(dr);
            }

            for (int i = 0; i < newdt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string emp_code = newdt.Rows[i]["emp_code"].ToString().Trim();
                    string emp_id = dt.Rows[j]["emp_id"].ToString().Trim();
                    if (emp_code == emp_id)
                    {
                        newdt.Rows[i]["Status"] = dt.Rows[j]["Status"];
                        newdt.Rows[i]["Employee_Name"] = dt.Rows[j]["Employee_Name"];
                        newdt.Rows[i]["DOJ"] = dt.Rows[j]["DOJ"];
                        newdt.Rows[i]["BAND"] = dt.Rows[j]["BANDS"];
                        newdt.Rows[i]["Grant_Name " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Grant_Name"].ToString();
                        newdt.Rows[i]["Grant_Date " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Date_of_Grant"].ToString();
                        newdt.Rows[i]["Percentage " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["VPercentage"].ToString();
                        newdt.Rows[i]["Granted " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Granted"].ToString();
                        newdt.Rows[i]["Vested " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Vested"].ToString();
                        newdt.Rows[i]["Vested_Pending " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Vested_Pending"].ToString();
                        newdt.Rows[i]["Exercised " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Exercised"].ToString();
                        newdt.Rows[i]["Exercised_Pending " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Exercised_Pending"].ToString();
                        newdt.Rows[i]["Sale " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Sale"].ToString();
                        newdt.Rows[i]["LBV " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["LBV"].ToString();
                        newdt.Rows[i]["LAV " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["LAV"].ToString();
                        newdt.Rows[i]["Total_Lapse " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Total_Lapse"].ToString();
                        newdt.Rows[i]["Stock_In_Hand " + dt.Rows[j][3].ToString() + dt.Rows[j][15].ToString()] = dt.Rows[j]["Stock_In_Hand"].ToString();

                        double x1 = string.IsNullOrEmpty(newdt.Rows[i]["Tot Grants"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Tot Grants"].ToString());
                        newdt.Rows[i]["Tot Grants"] = Convert.ToDouble(x1)  + Convert.ToDouble(dt.Rows[j]["Granted"].ToString());
                        double x2 = string.IsNullOrEmpty(newdt.Rows[i]["Tot Vested"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Tot Vested"].ToString());
                        newdt.Rows[i]["Tot Vested"] = Convert.ToDouble(x2) + Convert.ToDouble(dt.Rows[j]["Vested"].ToString());
                        double x3 = string.IsNullOrEmpty(newdt.Rows[i]["Tot Exercised"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Tot Exercised"].ToString());
                        newdt.Rows[i]["Tot Exercised"] = Convert.ToDouble(x3) + Convert.ToDouble(dt.Rows[j]["Exercised"].ToString());
                        double x4 = string.IsNullOrEmpty(newdt.Rows[i]["Tot Sell"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Tot Sell"].ToString());
                        newdt.Rows[i]["Tot Sell"] = Convert.ToDouble(x4) + Convert.ToDouble(dt.Rows[j]["Sale"].ToString());
                        double x5 = string.IsNullOrEmpty(newdt.Rows[i]["Tot LBV"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Tot LBV"].ToString());
                        newdt.Rows[i]["Tot LBV"] = Convert.ToDouble(x5) + Convert.ToDouble(dt.Rows[j]["LBV"].ToString());
                        double x6 = string.IsNullOrEmpty(newdt.Rows[i]["Tot LAV"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Tot LAV"].ToString());
                        newdt.Rows[i]["Tot LAV"] = Convert.ToDouble(x6) + Convert.ToDouble(dt.Rows[j]["LAV"].ToString());
                        double x7 = string.IsNullOrEmpty(newdt.Rows[i]["Stock in hand"].ToString()) ? 0 : Convert.ToDouble(newdt.Rows[i]["Stock in hand"].ToString());
                        newdt.Rows[i]["Stock in hand"] = Convert.ToDouble(x7) + Convert.ToDouble(dt.Rows[j]["Stock_In_Hand"].ToString());

                    }
                }
            }
            return newdt;
        }
    }
}