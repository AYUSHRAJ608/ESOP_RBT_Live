
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace ESOP
{
    public partial class Secretarial_Approvals : System.Web.UI.Page
    {
        Employee_secretarialBAL objBAL = new Employee_secretarialBAL();
        Secretarial_grant_approvalBO obj_bo = new Secretarial_grant_approvalBO();
        Secretarial_grant_approvalBAL obj_bal = new Secretarial_grant_approvalBAL();
        employee_saleBO objBO = new employee_saleBO();
        employee_saleBAL objbal = new employee_saleBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = objBAL.GET_Employee_Secretarial_Main_Grid();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Exercisecount.InnerText =Convert.ToString(ds.Tables[0].Rows.Count);
                }
                else
                {
                    Exercisecount.InnerText = "0";
                }

                DataSet ds_1 = new DataSet();
                ds_1 = objbal.GET_EMPLOYEE_SELL_DATA_1(objBO);
                if (ds_1.Tables[0].Rows.Count > 0)
                {
                    Salecount.InnerText = Convert.ToString(ds_1.Tables[0].Rows.Count);
                }
                else
                {
                    Salecount.InnerText = "0";
                }

                DataSet ds_2 = new DataSet();
                ds_1 = obj_bal.get_secretarial_appraval_data(obj_bo);
                if (ds_1.Tables[0].Rows.Count > 0)
                {
                    Grantcount.InnerText = Convert.ToString(ds_1.Tables[0].Rows.Count);
                }
                else
                {
                    Grantcount.InnerText = "0";
                }
            }
        }
    }
}