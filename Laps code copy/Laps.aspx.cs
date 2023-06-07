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
    public partial class Laps : System.Web.UI.Page
    {
        PresidentBO PresidentBO = new PresidentBO();
        PresidentBAL PresidentBAL = new PresidentBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainGrid();
            }
        }

        private void BindMainGrid()
        {
            DataSet ds = new DataSet();
            PresidentBO = new PresidentBO();
            PresidentBO.ECode = Convert.ToString(Session["ECODE"]);
            ds = PresidentBAL.GET_ADMIN_EMP_STOCK_MAPPING_2(PresidentBO);

            if (ds.Tables.Count > 0)
            {
                ////////    if (ds.Tables[1].Rows.Count > 0)
                ////////    {
                ////////        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                ////////        {
                ////////            DataTable dt = (ds.Tables[1]);
                ////////            string VP = ds.Tables[0].Rows[i]["ECODE"].ToString();

                ////////            decimal tot = dt.AsEnumerable()
                ////////                        .Where(y => y.Field<string>("EMP_ID") == VP)
                ////////                        .Sum(x => x.Field<decimal?>("LBV") ?? 0);

                ////////            ds.Tables[0].Rows[i]["LBV"] = tot;
                ////////            ds.Tables[0].AcceptChanges();

                ////////            decimal tot1 = dt.AsEnumerable()
                ////////                        .Where(y => y.Field<string>("EMP_ID") == VP)
                ////////                        .Sum(x => x.Field<decimal?>("LAV") ?? 0);

                ////////            ds.Tables[0].Rows[i]["LAV"] = tot1;
                ////////            ds.Tables[0].AcceptChanges();


                ////////            decimal tot2 = dt.AsEnumerable()
                ////////                        .Where(y => y.Field<string>("EMP_ID") == VP)
                ////////                        .Sum(x => x.Field<decimal?>("TOTAL_LAPSED") ?? 0);

                ////////            ds.Tables[0].Rows[i]["TOTAL_LAPSE"] = tot2;
                ////////            ds.Tables[0].AcceptChanges();

                ////////            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Convert.ToDecimal(ds.Tables[0].Rows[i]["EXERCISED"]) - Convert.ToDecimal(ds.Tables[0].Rows[i]["SALE"]);  // Convert.ToDecimal(ds.Tables[0].Rows[i]["GRANTED"]) -
                ////////            ds.Tables[0].Rows[i]["STOCK_IN_HAND"] = Math.Abs(Convert.ToDecimal(ds.Tables[0].Rows[i]["STOCK_IN_HAND"]));
                ////////        }
                ////////    }
                gvParent.DataSource = ds.Tables[0];
                gvParent.DataBind();
                gvParent.UseAccessibleHeader = true;
                gvParent.HeaderRow.TableSection = TableRowSection.TableHeader;

                ////////}
                ////////else
                ////////{
                ////////    gvParent.DataSource = null;
                ////////    gvParent.DataBind();
            }
        }

        protected void TxtLaps_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //    int rowindex = row.RowIndex;
            //    TextBox TxtLaps = (TextBox)row.FindControl("TxtLaps");
            //    double VESTED_PENDING = Convert.ToDouble(row.Cells[3].Text.ToString());
            //    double EXERCISED_PENDING = Convert.ToDouble(row.Cells[4].Text.ToString());

            //    if (Convert.ToDouble(TxtLaps.Text) > (VESTED_PENDING + EXERCISED_PENDING))
            //    {
            //        Common.ShowJavascriptAlert("No.of Laps to be can not greater than : " + (VESTED_PENDING + EXERCISED_PENDING));
            //        TxtLaps.Text = "0";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            //    //throw ex;
            //}
        }

        protected void gvParent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string StrMsg = "";
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                //if (e.CommandName == "Laps")
                {
                    //TextBox txtLAPS = (TextBox)gvParent.Rows[Convert.ToInt32(RowIndex)].FindControl("TxtLaps");

                    PresidentBO.EmpID = Convert.ToInt32(gvParent.DataKeys[gvr.RowIndex].Values[0].ToString());
                    //PresidentBO.LAPS = Convert.ToInt32(txtLAPS.Text);

                    //bool retVal = PresidentBAL.UPDATE_LAPS(PresidentBO);
                    //if (retVal == true)
                    //{
                    //    BindMainGrid();
                    //}
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                // ex;
            }
        }

        protected void gvParent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = e.Row.FindControl("gvChild") as GridView;
                PresidentBO = new PresidentBO();

                GridView gv1 = (GridView)sender;
                HiddenField HdEmpCode = (HiddenField)e.Row.FindControl("HdEmpCode");
                PresidentBO.ECode = HdEmpCode.Value.ToString().Trim();
                DataSet ds = new DataSet();
                ds = PresidentBAL.GET_Distinct_VestID(PresidentBO);

                if (ds.Tables.Count > 0 && ds != null)
                {
                    gvChild.DataSource = ds.Tables[0];
                    gvChild.DataBind();

                }
                else
                {
                    gvChild.DataSource = null;
                    gvChild.DataBind();
                }
            }
        }
        protected void gvSubChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    GridView gv1 = (GridView)sender;
            //    Label lblVPERCENTAGE = (Label)e.Row.FindControl("lblVPERCENTAGE");
            //    Label lblGRANTED = (Label)e.Row.FindControl("lblGRANTED");
            //    Label lblVESTED = (Label)e.Row.FindControl("lblVESTED");
            //    Label lblVESTED_PENDING = (Label)e.Row.FindControl("lblVESTED_PENDING");
            //    Label lblEXERCISED = (Label)e.Row.FindControl("lblEXERCISED");
            //    Label lblEXERCISED_PENDING = (Label)e.Row.FindControl("lblEXERCISED_PENDING");
            //    Label lblSALE = (Label)e.Row.FindControl("lblSALE");
            //    Label lblLBV = (Label)e.Row.FindControl("lblLBV");
            //    Label lblLAV = (Label)e.Row.FindControl("lblLAV");
            //    Label lblTOTAL_LAPSE = (Label)e.Row.FindControl("lblTOTAL_LAPSE");
            //    Label lblSTOCK_IN_HAND = (Label)e.Row.FindControl("lblSTOCK_IN_HAND");

            //    if (lblVPERCENTAGE.Text.Contains("Total"))
            //    {
            //        lblVPERCENTAGE.Font.Bold = true;
            //        lblGRANTED.Font.Bold = true;
            //        lblVESTED.Font.Bold = true;
            //        lblVESTED_PENDING.Font.Bold = true;
            //        lblEXERCISED.Font.Bold = true;
            //        lblEXERCISED_PENDING.Font.Bold = true;
            //        lblSALE.Font.Bold = true;
            //        lblLBV.Font.Bold = true;
            //        lblLAV.Font.Bold = true;
            //        lblTOTAL_LAPSE.Font.Bold = true;
            //        lblSTOCK_IN_HAND.Font.Bold = true;
            //    }
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVESTED = (Label)e.Row.FindControl("lblVESTED");
                Label lblEXERCISED = (Label)e.Row.FindControl("lblEXERCISED");
                double VESTED = Convert.ToDouble(lblVESTED.Text);
                double EXERCISED = Convert.ToDouble(lblEXERCISED.Text);

                if (VESTED - EXERCISED == 0)
                {
                    TextBox txtLapse = (TextBox)e.Row.FindControl("TxtLaps");
                    txtLapse.Enabled = false;
                }
                Label lblLAV = (Label)e.Row.FindControl("lblLAV");
                //lblLAV.Text = "0";
            }
        }

        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gvSubChild = e.Row.FindControl("gvSubChild") as GridView;
                PresidentBO = new PresidentBO();

                GridView gv1 = (GridView)sender;
                Label lblobjective = (Label)e.Row.FindControl("lblTranchName");
                PresidentBO.GRANT_NAME = lblobjective.Text.Trim();

                HiddenField HdEmpCode = (HiddenField)e.Row.FindControl("HdEmpCodeTranchwise");
                PresidentBO.ECode = HdEmpCode.Value.ToString().Trim();
                DataSet ds = new DataSet();
                ds = PresidentBAL.GET_ADMIN_EMP_STOCK_MAPPING_DETAILS(PresidentBO);
                if (ds.Tables.Count > 0 && ds != null)
                {
                    gvSubChild.DataSource = ds.Tables[0];
                    gvSubChild.DataBind();
                }
                else
                {
                    gvSubChild.DataSource = null;
                    gvSubChild.DataBind();
                }
            }
        }


        protected void gvSubChild_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "hide()", true);

            try
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                if (e.CommandName == "Lapse")
                {
                    TextBox txtLAPS = (TextBox)row.FindControl("TxtLaps");

                    //double VESTED_PENDING = Convert.ToDouble(row.Cells[3].Text.ToString());
                    //double EXERCISED_PENDING = Convert.ToDouble(row.Cells[4].Text.ToString());
                    Label VESTED_PENDING = (Label)row.FindControl("lblVESTED_PENDING");
                    Label EXERCISED_PENDING = (Label)row.FindControl("lblEXERCISED_PENDING");
                    double a = Convert.ToDouble(VESTED_PENDING.Text);
                    double b = Convert.ToDouble(EXERCISED_PENDING.Text);
                    double c = Convert.ToDouble(txtLAPS.Text);

                    if (c > (a + b))
                    {
                        Common.ShowJavascriptAlert("No.of Laps to be can not greater than : " + (a + b));
                        txtLAPS.Text = "0";
                    }
                    else
                    {
                        HiddenField HdID = (HiddenField)row.FindControl("Hd_Id");
                        PresidentBO.ECode = HdID.Value.ToString().Trim();
                        bool retVal = PresidentBAL.UPDATE_LAPS(PresidentBO);
                        if (retVal == true)
                        {
                            BindMainGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btn_Lapes_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvParent.Rows)
            {
                GridView gvChild = row.FindControl("gvChild") as GridView;
                foreach (GridViewRow row_1 in gvChild.Rows)
                //    {
                //        GridView gvSubChild = row_1.FindControl("gvSubChild") as GridView;
                //        foreach (GridViewRow row_2 in gvSubChild.Rows)
                //        {
                //            TextBox txt = (TextBox)row_2.FindControl("TxtLaps");
                //            string Lapes = txt.Text.Replace(",", "");
                //            Label lblLAV = (Label)row_2.FindControl("lblLAV");
                //            Int32 LAV = Convert.ToInt32(lblLAV.Text);

                //            if (Lapes != "")
                //            {
                //                if (Convert.ToInt32(Lapes.ToString()) <= LAV)
                //                {
                //                    HiddenField HdID = (HiddenField)row_2.FindControl("Hd_Id");
                //                    HdID.Value = HdID.Value.Substring(0, HdID.Value.IndexOf(",") + 1);
                //                    HdID.Value = HdID.Value.ToString().Replace(",", "");
                //                    PresidentBO.V_ID = HdID.Value.ToString().Trim();
                //                    PresidentBO.LAPS = Convert.ToInt32(Lapes.ToString());

                //                    bool retVal = PresidentBAL.UPDATE_LAPS(PresidentBO);
                //                    if (retVal == true)
                //                    {
                //                        //BindMainGrid();
                //                    }
                //                }
                //                else
                //                {

                //                }
                //            }
                //        }
                //    }
                //}
                {
                    GridView gvSubChild = row_1.FindControl("gvSubChild") as GridView;
                    foreach (GridViewRow row_2 in gvSubChild.Rows)
                    {
                        ////TextBox txt = (TextBox)row_2.FindControl("TxtLaps");
                        ////string Lapes = txt.Text.Replace(",", "");
                        ////Label lblLAV = (Label)row_2.FindControl("lblLAV");
                        ////Int32 LAV = Convert.ToInt32(lblLAV.Text);

                        //TextBox txt = (TextBox)row_2.FindControl("TxtLBV");
                        //string Lapes = txt.Text.Replace(",", "");
                        //Label lblLBV = (Label)row_2.FindControl("lblLBV");
                        //Int32 LBV = Convert.ToInt32(lblLBV.Text);

                        //TextBox txt1 = (TextBox)row_2.FindControl("TxtLAV");
                        //string Lapes1 = txt1.Text.Replace(",", "");
                        //Label lblLAV = (Label)row_2.FindControl("lblLAV");
                        //Int32 LAV = Convert.ToInt32(lblLAV.Text);


                        //if (Lapes != "")
                        //{
                        //    if (Convert.ToInt32(Lapes.ToString()) <= LBV && Convert.ToInt32(Lapes1.ToString()) <= LAV)
                        //    {


                        TextBox txt = (TextBox)row_2.FindControl("TxtLBV");
                        string LBV = txt.Text.Replace(",", "");

                        TextBox txt1 = (TextBox)row_2.FindControl("TxtLAV");
                        string LAV = txt1.Text.Replace(",", "");
                        //if (Convert.ToInt32(LBV.ToString()) != 0  && Convert.ToInt32(LAV.ToString()) != 0)
                        if ((Convert.ToString(LBV) == "" ? 0 : Convert.ToInt32(LBV)) != 0 && (Convert.ToString(LAV) == "" ? 0 : Convert.ToInt32(LAV)) != 0) 
                        {
                            HiddenField HdID = (HiddenField)row_2.FindControl("Hd_Id");
                            HdID.Value = HdID.Value.Substring(0, HdID.Value.IndexOf(",") + 1);
                            HdID.Value = HdID.Value.ToString().Replace(",", "");
                            PresidentBO.V_ID = HdID.Value.ToString().Trim();
                            PresidentBO.LBV = Convert.ToInt32(LBV.ToString());
                            PresidentBO.LAV = Convert.ToInt32(LAV.ToString());
                        }
                        bool retVal = PresidentBAL.UPDATE_LAPS(PresidentBO);
                        if (retVal == true)
                        {
                            //BindMainGrid();
                        }
                        //}
                        //else
                        //{

                        //}
                        //}
                    }
                }
            }
            BindMainGrid();
        }

        protected void TxtLAV_TextChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
                int rowindex = row.RowIndex;

                TextBox TxtLAV = (TextBox)row.FindControl("TxtLAV");
                //double VESTED_PENDING = Convert.ToDouble(row.Cells[4].Text.ToString());
                //double EXERCISED_PENDING = Convert.ToDouble(row.Cells[5].Text.ToString());

                Label VESTED_PENDING_1 = (Label)row.FindControl("lblVESTED_PENDING");
                Label EXERCISED_PENDING_1 = (Label)row.FindControl("lblEXERCISED_PENDING");


                //if (Convert.ToDouble(TxtLAV.Text) > (EXERCISED_PENDING))
                TxtLAV.Text = TxtLAV.Text.Replace(",","");
                if ((Convert.ToString(TxtLAV.Text) == "" ? 0 : (Convert.ToDouble(TxtLAV.Text))) > Convert.ToInt32((EXERCISED_PENDING_1.Text)))
                {
                    Common.ShowJavascriptAlert("No.of LAV to be can not greater than : " + (EXERCISED_PENDING_1.Text));
                    //int x = 0;
                    //TxtLAV.Text = Convert.ToString(x);
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