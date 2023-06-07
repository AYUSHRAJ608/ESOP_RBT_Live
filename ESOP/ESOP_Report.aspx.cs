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
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ESOP
{
    public partial class ESOP_Report : System.Web.UI.Page
    {
        Grant_ReportBAL objBAL = new Grant_ReportBAL();
        Grant_ReportBO objBO = new Grant_ReportBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtStartDate.Attributes.Add("readonly", "readonly");
            txtEndDate.Attributes.Add("readonly", "readonly");
            
           
                
            
        }

        public void GET_EMPLOYEE_GRANT_REPORT()
        {
            try
            {
                DataSet ds = new DataSet();
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    objBO.START_DATE = txtStartDate.Text;// Convert.ToDateTime(txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    objBO.END_DATE = txtEndDate.Text;// Convert.ToDateTime(txtEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }

                ds = objBAL.GET_EMPLOYEE_GRANT_REPORT(objBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvExercise.DataSource = ds.Tables[0];
                    gvExercise.DataBind();

                    gvExercise.UseAccessibleHeader = true;
                    gvExercise.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    gvExercise.DataSource = ds.Tables[0];
                    gvExercise.DataBind();

                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

   

     

        

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStartDate.Text != "" && txtEndDate.Text != "")
                {
                    GET_EMPLOYEE_GRANT_REPORT();
                }
                else if (txtStartDate.Text == "" && txtEndDate.Text != "")
                {
                    GET_EMPLOYEE_GRANT_REPORT();
                }
                else
                {
                    Common.ShowJavascriptAlert("Please select date.");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {

            txtStartDate.Text = txtEndDate.Text = string.Empty;
            objBO.START_DATE = "";
            objBO.END_DATE = "";
            GET_EMPLOYEE_GRANT_REPORT();
        }

  

       
    }
}