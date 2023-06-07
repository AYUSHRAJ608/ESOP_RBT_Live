using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.IO;

namespace ESOP
{
    public partial class QueryWindow : System.Web.UI.Page
    {
        EmployeeBO objEmpBo = new EmployeeBO();
        EmployeeBAL objEmpBal = new EmployeeBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showmsg.Visible = false;
                btnexcelExport.Visible = false;
            }
        }

        protected void btnrun_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = Convert.ToString(txtquerywindow.Text).Trim();
                DataSet ds = new DataSet();
                if (Query.EndsWith(";"))
                {
                    Query = Query.Remove(Query.Length - 1, 1);
                }
                ds = Common.Execute_Query(Query);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdMain.DataSource = ds.Tables[0];
                        grdMain.DataBind();
                        grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdMain.DataSource = ds.Tables[0];
                        grdMain.DataBind();
                    }
                }

                btnexcelExport.Visible = true;
            }
            catch (Exception ex)
            {
                showmsg.Visible = true;
                showmsg.InnerText = ex.Message;
                showmsg.Attributes["style"] = "color:red; font-weight:bold; text-align: center; margin:auto";
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                grdMain.DataSource = new DataTable();
                grdMain.DataBind();
            }
        }

        public DataTable FetchData()
        {
            string Query = Convert.ToString(txtquerywindow.Text).Trim();
            DataSet ds = new DataSet();
            if (Query.EndsWith(";"))
            {
                Query = Query.Remove(Query.Length - 1, 1);
            }
            ds = Common.Execute_Query(Query);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return ds.Tables[0];
                }
            }
            return new DataTable();
        }

        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";

                string FileName = "QueryResult" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                DataGrid dgGrid = new DataGrid();
                //dt = (DataTable)ViewState["DataHistory"];
                dgGrid.DataSource = FetchData();
                dgGrid.DataBind();

                dgGrid.RenderControl(hw);

                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);

                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();

               
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                grdMain.GridLines = GridLines.Both;
                grdMain.HeaderStyle.Font.Bold = true;
                grdMain.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                showmsg.Visible = true;
                showmsg.InnerText = ex.Message;
                showmsg.Attributes["style"] = "color:red; font-weight:bold; text-align: center; margin:auto";
                //Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}