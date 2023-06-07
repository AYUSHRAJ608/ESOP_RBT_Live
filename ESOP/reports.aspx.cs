using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class reports : System.Web.UI.Page
    {
        PresedentApprovalBO objbo = new PresedentApprovalBO();
        PresedentApprovalBAL objbal = new PresedentApprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        exercise_reportBAL objBAL = new exercise_reportBAL();
        exercise_reportBO objBO = new exercise_reportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        
        protected void dataexcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                DataSet ds = new DataSet();
                ds = objbal.GET_ALL_EMPLOYEE_DETAIL_REPORT(objbo);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvexcel.DataSource = ds.Tables[0];
                    gvexcel.DataBind();
                    gvexcel.UseAccessibleHeader = true;
                    gvexcel.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    gvexcel.DataSource = ds.Tables[0];
                    gvexcel.DataBind();

                }
                ////string FileName = "SELL_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string FileName = "DETAIL_REPORT_" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                ////Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                ////gvParent.GridLines = GridLines.Both;
                ////gvParent.HeaderStyle.Font.Bold = true;
                ////gvParent.RenderControl(htmltextwrtter);
                ////Response.Write(strwritter.ToString());
                ////Response.End();
                gvexcel.RenderControl(htmltextwrtter);
                Response.Output.Write(strwritter.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}