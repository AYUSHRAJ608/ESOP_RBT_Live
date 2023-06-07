using BAL_REPORT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity_REPORT;
using System.Configuration;
using System.Drawing;

namespace Report_Builder
{
    public partial class CreateReport : System.Web.UI.Page
    {
        ReportBAL objRpt_BAL = new ReportBAL();
        EReport objRpt_ENT = new EReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDomainName.InnerText = Session["AppConnectionstring"].ToString();

            }
        }

        #region Events Declarations
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objRpt_ENT.key = Session["AppConnectionstring"].ToString();
                objRpt_ENT.DomainName = lblDomainName.InnerText.ToString();
                Session["ReportName"] = objRpt_ENT.ReportName = txtReportName.Text;
                objRpt_ENT.ReportDesc = txtDescription.Text; 
                objRpt_ENT.CreatedBy = Convert.ToInt32(Session["EMPID"]);
                DataSet ds = objRpt_BAL.AddCreateReport(objRpt_ENT);
                Session["ReportId"] = ds.Tables[0].Rows[0]["rpt_id"].ToString();
                Response.Redirect("~/SelectDataset.aspx", false);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion Events Declarations
    }
}