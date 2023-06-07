using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;

namespace ESOP
{
    public partial class Admin_SellWindow : System.Web.UI.Page
    {

        employee_saleBO objBO = new employee_saleBO();
        employee_saleBAL objBAL = new employee_saleBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GET_EMPLOYEE_SELL_DATA();
        }


        protected void GET_EMPLOYEE_SELL_DATA()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objBAL.GET_EMPLOYEE_SELL_DATA_Count(objBO);
                if (ds.Tables[2].Rows.Count > 0)
                {
                    //SaleApprovecount.InnerText =Convert.ToString(ds.Tables[0].Rows[0][0]);
                    SaleApprovecount.InnerText = Convert.ToString(ds.Tables[2].Rows.Count);
                }
                else
                {
                    SaleApprovecount.InnerText = "0";
                }
               
                if (ds.Tables[1].Rows.Count > 0)
                {
                    SaleWindowcount.InnerText = ds.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    SaleWindowcount.InnerText = "0";
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DisApprovecount.InnerText = Convert.ToString(ds.Tables[3].Rows.Count);
                }
                else
                {
                    DisApprovecount.InnerText = "0";
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}