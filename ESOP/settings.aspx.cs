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
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FMVCreationBAL FMVBAL = new FMVCreationBAL();
            vesting_creation_BAL vestbal = new vesting_creation_BAL();
            ValuationBAL ValuationBAL = new ValuationBAL();
            LetterConfigBAL letterbal = new LetterConfigBAL();
            TaxBAL taxbal = new TaxBAL();

            DataSet ds = new DataSet();
            ds = FMVBAL.ESOP_FMV_CREATION_ALL_COUNT();
            if (ds.Tables[0].Rows.Count > 0)
            {

                fmvcount.InnerText = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {

            }

            DataSet ds1 = new DataSet();
            ds1 = vestbal.ESOP_VESTING_ALL_COUNT();
            if (ds1.Tables[0].Rows.Count > 0)
            {

                vestingcount.InnerText = ds1.Tables[0].Rows[0][0].ToString();

            }
            else
            {

            }


            DataSet ds2 = new DataSet();
            ds2 = ValuationBAL.ESOP_GET_VALUATION_ALL_COUNT();
            if (ds2.Tables[0].Rows.Count > 0)
            {

                valuationcount.InnerText = ds2.Tables[0].Rows[0][0].ToString();

            }
            else
            {

            }
            DataSet ds3 = new DataSet();
            ds3 = letterbal.ESOP_GET_LETTER_CONFIGURATION_COUNT();
            if (ds3.Tables[0].Rows.Count > 0)
            {

                lettercount.InnerText = ds3.Tables[0].Rows[0][0].ToString();

            }
            else
            {

            }
            DataSet ds4 = new DataSet();
            ds4 = taxbal.taxcount();
            if (ds4.Tables[0].Rows.Count > 0)
            {

                taxcount.InnerText = ds4.Tables[0].Rows[0][0].ToString();

            }
            else
            {

            }
        }
    }
}