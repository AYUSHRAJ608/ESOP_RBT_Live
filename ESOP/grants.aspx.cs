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
    public partial class grants : System.Web.UI.Page
    {
        Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
        AdminBAL objadminbal = new AdminBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            DataSet ds = new DataSet();
            ds = objBAL.Get_correction_records();
            if (ds.Tables[1].Rows.Count > 0)
            {

                countgrnt.InnerText = ds.Tables[1].Rows[0][0].ToString();

            }
            else
            {

            }

            DataSet ds1 = new DataSet();
            ds1 = objadminbal.ESOP_GET_ADMIN_GRANT_UPDATION_COUNT();
            if (ds1.Tables[0].Rows.Count > 0)
            {

                updategrnt.InnerText = ds1.Tables[0].Rows[0][0].ToString();

            }
            else
            {

            }
        }
    }
}