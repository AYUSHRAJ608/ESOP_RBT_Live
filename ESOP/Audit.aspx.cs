using ESOP_BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class Audit : System.Web.UI.Page
    {
        AuditBAL objbal = new AuditBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            int ddlAditvalue = ddlAudit.SelectedIndex;

            if (ddlAudit.SelectedValue != "")
            {
                if (ddlAudit.SelectedValue == "1" || ddlAudit.SelectedValue == "2")
                {
                    grdAudit.Visible = true;
                    ds = objbal.GET_Audit(ddlAditvalue);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdAudit.DataSource = ds.Tables[0];
                        grdAudit.DataBind();

                        grdAudit.UseAccessibleHeader = true;
                        grdAudit.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdAudit.DataSource = null;
                        grdAudit.DataBind();

                        grdAudit.UseAccessibleHeader = true;
                        grdAudit.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    grdExercise.Visible = false;
                    grdSell.Visible = false;
                }
                else if (ddlAudit.SelectedValue == "3")
                {
                    grdExercise.Visible = true;
                    DataSet ds1 = new DataSet();
                    ds1 = objbal.GET_ExerciseMainGrid();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        grdExercise.DataSource = ds1.Tables[0];
                        grdExercise.DataBind();
                        grdExercise.UseAccessibleHeader = true;
                        grdExercise.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdExercise.DataSource = null;
                        grdExercise.DataBind();
                        grdExercise.UseAccessibleHeader = true;
                        grdExercise.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    grdAudit.Visible = false;
                    grdSell.Visible = false;
                }
                else
                {
                    grdSell.Visible = true;
                    DataSet ds2 = new DataSet();
                    ds2 = objbal.GET_SellMainGrid();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        grdSell.DataSource = ds2.Tables[0];
                        grdSell.DataBind();
                        grdSell.UseAccessibleHeader = true;
                        grdSell.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdSell.DataSource = null;
                        grdSell.DataBind();
                        grdSell.UseAccessibleHeader = true;
                        grdSell.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    grdAudit.Visible = false;
                    grdExercise.Visible = false;
                }
            }
            else
            {
                Common.ShowJavascriptAlert("Select audit type.");
            }
        }

        protected void grdExercis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView grdExercisChild = e.Row.FindControl("grdExercisChild") as GridView;
            DataSet ds3 = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdExercise.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(grdExercise.DataKeys[i].Values[0]);
                    ds3 = objbal.GET_ExerciseChildGrid(id);
                    if (ds3.Tables[0].Rows.Count > 0) { 
                    grdExercisChild.DataSource = ds3.Tables[0];
                    grdExercisChild.DataBind();
                    }
                    else
                    {
                        grdExercisChild.DataSource = null;
                        grdExercisChild.DataBind();
                    }
                }


            }
        }

        protected void grdSell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView grdSellChild = e.Row.FindControl("grdSellChild") as GridView;
            DataSet ds4 = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdSell.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(grdSell.DataKeys[i].Values[0]);
                    ds4 = objbal.GET_SellChildGrid(id);
                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        grdSellChild.DataSource = ds4.Tables[0];
                        grdSellChild.DataBind();
                    }
                    else
                    {
                        grdSellChild.DataSource = null;
                        grdSellChild.DataBind();
                    }

                }


            }

        }
    }
}