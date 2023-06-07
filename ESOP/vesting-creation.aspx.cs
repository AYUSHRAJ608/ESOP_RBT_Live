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
    public partial class vesting_creation : System.Web.UI.Page
    {
        vesting_creation_BO VestingBO;
        vesting_creation_BAL VestingBAL = new vesting_creation_BAL();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerText = "";
            if (Request.UrlReferrer == null)
            {
                Session.Abandon();
                //' Response.Redirect("login.aspx", false);
                // return;
            }
            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                GetVestingDuration1();
                GET_VESTING_MASTER_ID();
                //GETVESTINGDETAILS();
                BindMainGrid();
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
        private void BindMainGrid()
        {
            try
            {
                DataSet ds;
                ds = GETVESTINGDETAILS();
                gvVesting.DataSource = ds.Tables[0];
                gvVesting.DataBind();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        private DataSet GetVestingDuration(vesting_creation_BO VestingBO)
        {
            DataSet ds = null;
            try
            {
                //VestingBO = new vesting_creation_BO();
                ds = VestingBAL.GetVestingDuration(VestingBO);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            return ds;
        }
        private void GetVestingDuration1()
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.YEAR = Convert.ToInt32("0");
                ddlduration1.DataSource = GetVestingDuration(VestingBO);
                ddlduration1.DataTextField = "YEAR_DESC";
                ddlduration1.DataValueField = "YEAR";

                ddlduration1.DataBind();
                ddlduration1.Items.Insert(0, new ListItem("Select", "0"));
                ddlduration2.Items.Insert(0, new ListItem("Select", "0"));
                ddlduration3.Items.Insert(0, new ListItem("Select", "0"));
                ddlduration4.Items.Insert(0, new ListItem("Select", "0"));
                ddlduration5.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        protected void ddlduration1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.YEAR = Convert.ToInt32(ddlduration1.SelectedValue);
                ddlduration2.DataSource = GetVestingDuration(VestingBO);
                ddlduration2.DataTextField = "YEAR_DESC";
                ddlduration2.DataValueField = "YEAR";

                ddlduration2.DataBind();
                ddlduration2.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        protected void ddlduration2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.YEAR = Convert.ToInt32(ddlduration2.SelectedValue);
                ddlduration3.DataSource = GetVestingDuration(VestingBO);
                ddlduration3.DataTextField = "YEAR_DESC";
                ddlduration3.DataValueField = "YEAR";

                ddlduration3.DataBind();
                ddlduration3.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        protected void ddlduration3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.YEAR = Convert.ToInt32(ddlduration3.SelectedValue);
                ddlduration4.DataSource = GetVestingDuration(VestingBO);
                ddlduration4.DataTextField = "YEAR_DESC";
                ddlduration4.DataValueField = "YEAR";

                ddlduration4.DataBind();
                ddlduration4.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        protected void ddlduration4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.YEAR = Convert.ToInt32(ddlduration4.SelectedValue);
                ddlduration5.DataSource = GetVestingDuration(VestingBO);
                ddlduration5.DataTextField = "YEAR_DESC";
                ddlduration5.DataValueField = "YEAR";

                ddlduration5.DataBind();
                ddlduration5.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        protected void btnimport_Click(object sender, EventArgs e)
        {
            try
            {

                if (IsPageRefresh)
                {
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("VID");
                dt.Columns.Add("Vesting_Name");
                dt.Columns.Add("No_Of_Cycle");
                dt.Columns.Add("Vesting_Cycle_Name");
                dt.Columns.Add("Percentage");
                dt.Columns.Add("Duration");


                int VID = GET_VESTING_MASTER_ID();
                DataRow dr = dt.NewRow();
                DataRow dr1 = dt.NewRow();
                DataRow dr2 = dt.NewRow();
                DataRow dr3 = dt.NewRow();
                DataRow dr4 = dt.NewRow();
                if (ddlnoOfCycle1.SelectedValue == "1")
                {
                    dr[0] = VID;
                    dr[1] = txtVestingName.Text;
                    dr[2] = ddlnoOfCycle1.SelectedValue;
                    dr[3] = txtv1.Text;
                    dr[4] = txtperc1.Text;
                    dr[5] = ddlduration1.SelectedValue;
                    dt.Rows.Add(dr);
                }
                else if (ddlnoOfCycle1.SelectedValue == "2")
                {
                    dr[0] = VID;
                    dr[1] = txtVestingName.Text;
                    dr[2] = ddlnoOfCycle1.SelectedValue;
                    dr[3] = txtv1.Text;
                    dr[4] = txtperc1.Text;
                    dr[5] = ddlduration1.SelectedValue;
                    dt.Rows.Add(dr);

                    dr1[0] = VID;
                    dr1[1] = txtVestingName.Text;
                    dr1[2] = ddlnoOfCycle1.SelectedValue;
                    dr1[3] = txtv2.Text;
                    dr1[4] = txtperc2.Text;
                    dr1[5] = ddlduration2.SelectedValue;
                    dt.Rows.Add(dr1);
                }
                else if (ddlnoOfCycle1.SelectedValue == "3")
                {
                    dr[0] = VID;
                    dr[1] = txtVestingName.Text;
                    dr[2] = ddlnoOfCycle1.SelectedValue;
                    dr[3] = txtv1.Text;
                    dr[4] = txtperc1.Text;
                    dr[5] = ddlduration1.SelectedValue;
                    dt.Rows.Add(dr);

                    dr1[0] = VID;
                    dr1[1] = txtVestingName.Text;
                    dr1[2] = ddlnoOfCycle1.SelectedValue;
                    dr1[3] = txtv2.Text;
                    dr1[4] = txtperc2.Text;
                    dr1[5] = ddlduration2.SelectedValue;
                    dt.Rows.Add(dr1);

                    dr2[0] = VID;
                    dr2[1] = txtVestingName.Text;
                    dr2[2] = ddlnoOfCycle1.SelectedValue;
                    dr2[3] = txtv3.Text;
                    dr2[4] = txtperc3.Text;
                    dr2[5] = ddlduration3.SelectedValue;
                    dt.Rows.Add(dr2);
                }
                else if (ddlnoOfCycle1.SelectedValue == "4")
                {
                    dr[0] = VID;
                    dr[1] = txtVestingName.Text;
                    dr[2] = ddlnoOfCycle1.SelectedValue;
                    dr[3] = txtv1.Text;
                    dr[4] = txtperc1.Text;
                    dr[5] = ddlduration1.SelectedValue;
                    dt.Rows.Add(dr);

                    dr1[0] = VID;
                    dr1[1] = txtVestingName.Text;
                    dr1[2] = ddlnoOfCycle1.SelectedValue;
                    dr1[3] = txtv2.Text;
                    dr1[4] = txtperc2.Text;
                    dr1[5] = ddlduration2.SelectedValue;
                    dt.Rows.Add(dr1);

                    dr2[0] = VID;
                    dr2[1] = txtVestingName.Text;
                    dr2[2] = ddlnoOfCycle1.SelectedValue;
                    dr2[3] = txtv3.Text;
                    dr2[4] = txtperc3.Text;
                    dr2[5] = ddlduration3.SelectedValue;
                    dt.Rows.Add(dr2);

                    dr3[0] = VID;
                    dr3[1] = txtVestingName.Text;
                    dr3[2] = ddlnoOfCycle1.SelectedValue;
                    dr3[3] = txtv4.Text;
                    dr3[4] = txtperc4.Text;
                    dr3[5] = ddlduration4.SelectedValue;
                    dt.Rows.Add(dr3);
                }
                else
                {
                    dr[0] = VID;
                    dr[1] = txtVestingName.Text;
                    dr[2] = ddlnoOfCycle1.SelectedValue;
                    dr[3] = txtv1.Text;
                    dr[4] = txtperc1.Text;
                    dr[5] = ddlduration1.SelectedValue;
                    dt.Rows.Add(dr);

                    dr1[0] = VID;
                    dr1[1] = txtVestingName.Text;
                    dr1[2] = ddlnoOfCycle1.SelectedValue;
                    dr1[3] = txtv2.Text;
                    dr1[4] = txtperc2.Text;
                    dr1[5] = ddlduration2.SelectedValue;
                    dt.Rows.Add(dr1);

                    dr2[0] = VID;
                    dr2[1] = txtVestingName.Text;
                    dr2[2] = ddlnoOfCycle1.SelectedValue;
                    dr2[3] = txtv3.Text;
                    dr2[4] = txtperc3.Text;
                    dr2[5] = ddlduration3.SelectedValue;
                    dt.Rows.Add(dr2);

                    dr3[0] = VID;
                    dr3[1] = txtVestingName.Text;
                    dr3[2] = ddlnoOfCycle1.SelectedValue;
                    dr3[3] = txtv4.Text;
                    dr3[4] = txtperc4.Text;
                    dr3[5] = ddlduration4.SelectedValue;
                    dt.Rows.Add(dr3);

                    dr4[0] = VID;
                    dr4[1] = txtVestingName.Text;
                    dr4[2] = ddlnoOfCycle1.SelectedValue;
                    dr4[3] = txtv5.Text;
                    dr4[4] = txtperc5.Text;
                    dr4[5] = ddlduration5.SelectedValue;
                    dt.Rows.Add(dr4);



                }
                VestingBO = new vesting_creation_BO();
                DataSet dsVestingName = new DataSet();
                VestingBO.VNAME = txtVestingName.Text;
                dsVestingName = VestingBAL.CHECK_VESTING_NAME(VestingBO);
                if (dsVestingName.Tables[0].Rows.Count > 0)
                {
                    txtVestingName.Focus();
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Vesting Name alredy exist.";
                    //Common.ShowJavascriptAlert("Vesting Name alredy exist.");
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    VestingBO.VID = Convert.ToInt32(dt.Rows[i][0].ToString());
                    VestingBO.VNAME = dt.Rows[i][1].ToString();
                    VestingBO.VCYCLE = Convert.ToInt32(dt.Rows[i][2].ToString());
                    VestingBO.VCYCLENAME = dt.Rows[i][3].ToString();
                    VestingBO.PERCENTAGE = Convert.ToInt32(dt.Rows[i][4].ToString());
                    VestingBO.DURATION = Convert.ToInt32(dt.Rows[i][5].ToString());
                    VestingBO.CREATEDBY = Convert.ToString(Session["ECode"]);

                    VestingBAL.VESTING_MASTER_INSERT(VestingBO);

                }
                // Page.Response.Redirect("~/vesting-creation.aspx", false);
                BindMainGrid();
                ClearInputs(Page.Controls);
                //Common.ShowJavascriptAlert("Vesting created successfully.");
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Vesting created successfully";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }

        }
        protected void ClearInputs(ControlCollection ctrls)
        {
            ////////foreach (Control ctrl in ctrls)
            ////////{
            ////////    if (ctrl is TextBox)
            ////////        ((TextBox)ctrl).Text = string.Empty;
            ////////    else if (ctrl is DropDownList)
            ////////        ((DropDownList)ctrl).ClearSelection();

            ////////    ClearInputs(ctrl.Controls);
            ////////}
            foreach (Control ctrl in ctrls)
            {
                //if (ctrl is TextBox)
                //    ((TextBox)ctrl).Text = string.Empty;
                //else 
                if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
            }
            txtperc1.Text = string.Empty;
            txtperc2.Text = string.Empty;
            txtperc3.Text = string.Empty;
            txtperc4.Text = string.Empty;
            txtperc5.Text = string.Empty;
            txtVestingName.Text = string.Empty;
        }
        private int GET_VESTING_MASTER_ID()
        {
            DataSet ds;
            int vID = 0;
            try
            {
                VestingBO = new vesting_creation_BO();

                ds = VestingBAL.GET_VESTING_MASTER_ID();

                vID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            return vID;
        }
        protected void gvVesting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gvVestingDetails = e.Row.FindControl("gvVestingDetails") as GridView;
                    Label lblVID = (Label)e.Row.FindControl("lblVID");
                    //string emp_code = e.Row.Cells[1].Text;
                    string V_ID = lblVID.Text;
                    //VestingBO.VID = Convert.ToString(V_ID);

                    DataSet ds = GETVESTINGDETAILSBYID(V_ID);

                    gvVestingDetails.DataSource = ds.Tables[0]; //GetAdminGoalsDetails(objGoals.Emp_Code);//
                    gvVestingDetails.DataBind();

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
        private DataSet GETVESTINGDETAILS()
        {
            DataSet ds = new DataSet();
            try
            {
                VestingBO = new vesting_creation_BO();
                ds = VestingBAL.GETVESTINGDETAILS();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
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



        protected void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                CheckBox cb = (CheckBox)sender;
                GridViewRow row = (GridViewRow)cb.NamingContainer;
                if (row != null)
                {
                    int rowindex = row.RowIndex;
                    //VestingBO.VID = Convert.ToInt32(gvVesting.DataKeys[rowindex].Values[0]);
                    VestingBO = new vesting_creation_BO();
                    VestingBO.VID = Convert.ToInt32(gvVesting.DataKeys[rowindex].Values[0]);
                    VestingBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);

                    DataSet dscheckVID = VestingBAL.CHECK_GRANT_VID(VestingBO);
                    if (dscheckVID.Tables[0].Rows.Count > 0)
                    {
                        BindMainGrid();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Vesting is already mapped to grant, can not set to disable.');", true);
                        return;
                    }
                    if (cb.Checked)
                    {
                        VestingBO.ISACTIVE = "1";
                    }
                    else
                    {
                        VestingBO.ISACTIVE = "0";
                    }
                    VestingBAL.VESTING_MASTER_UPDATE_ACTIVE_STATUS(VestingBO);


                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }

        }

        protected void gvVesting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                VestingBO = new vesting_creation_BO();
                VestingBO.VID = Convert.ToInt32(gvVesting.DataKeys[e.RowIndex].Values[0]);
                VestingBO.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                DataSet dscheckVID = VestingBAL.CHECK_GRANT_VID(VestingBO);
                if (dscheckVID.Tables[0].Rows.Count > 0)
                {
                    showmsg.InnerText = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Vesting is already mapped to grant, can not be delete.');", true);
                    return;
                }


                VestingBAL.VESTING_MASTER_DELETE(VestingBO);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record deleted successfully.');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Vesting deleted successfully";

                BindMainGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        //protected void gvVesting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvVesting.PageIndex = e.NewPageIndex;
        //    BindMainGrid();
        //}

        protected void gvVesting_PreRender(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                ds = GETVESTINGDETAILS();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvVesting.UseAccessibleHeader = true;
                    gvVesting.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }
    }
}