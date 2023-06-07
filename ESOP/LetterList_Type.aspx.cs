using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data;
using System.IO;
using System.Data.OracleClient;
using System.Configuration;

namespace ESOP
{
    public partial class LetterList_Type : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        LetterList_BAL objbal = new LetterList_BAL();
        string Type = "";
        string ID = "";
        private object acknowlegded_date;

        public object HiddenFieldack { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLetter_List();//Gridview data
                GetLetter_DataList();//to get All type Letter
                GetLetter_GrantDOC();//to get Grant type Letter
                //GetLetter_VestingDOC();
                //GetLetter_ExerciseDOC();
                GetLetter_SalesDOC();//to get Sales type Letter
            }

        }

        public void GetLetter_List()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objbal.GetLetter_List(Session["ECode"].ToString());
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    string FileNamePath = ds.Tables[0].Rows[0]["FILENAME"].ToString().Trim();
                    ViewState["FILENAME"] = FileNamePath;
                    GrvLetter_List.DataSource = ds.Tables[0];
                    GrvLetter_List.DataBind();
                    ViewState["GrvLetter_List"] = ds.Tables[0];
                }
                else
                {
                    GrvLetter_List.DataSource = null;
                    GrvLetter_List.DataBind();
                    ViewState["GrvLetter_List"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }


      
        //To get All type 
        public void GetLetter_DataList()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objbal.GetLetter_List(Session["ECode"].ToString());
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    string FileNamePath = ds.Tables[0].Rows[0]["FILENAME"].ToString().Trim();
                    ViewState["FILENAME"] = FileNamePath;
                    dlLetterList.DataSource = ds.Tables[0];
                    dlLetterList.DataBind();
                    ViewState["Data_LetterList"] = ds.Tables[0];
                }
                else
                {
                    dlLetterList.DataSource = null;
                    dlLetterList.DataBind();
                    ViewState["Data_LetterList"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        public void GetLetter_GrantDOC()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objbal.GetGrant_Letter_List(Session["ECode"].ToString());
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    string FileNamePath = ds.Tables[0].Rows[0]["FILENAME"].ToString().Trim();
                    ViewState["FILENAME"] = FileNamePath;
                    dlGrantDoc.DataSource = ds.Tables[0];
                    dlGrantDoc.DataBind();
                    //ViewState["Data_LetterList"] = ds.Tables[0];
                }
                else
                {
                    dlGrantDoc.DataSource = null;
                    dlGrantDoc.DataBind();
                    //  ViewState["Data_LetterList"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        public void GetLetter_SalesDOC()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objbal.Getsales_Letter_List(Session["ECode"].ToString());
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    string FileNamePath = ds.Tables[0].Rows[0]["FILENAME"].ToString().Trim();
                    ViewState["FILENAME"] = FileNamePath;
                    dlSales.DataSource = ds.Tables[0];
                    dlSales.DataBind();
                    //ViewState["Data_LetterList"] = ds.Tables[0];
                }
                else
                {
                    dlSales.DataSource = null;
                    dlSales.DataBind();
                    //  ViewState["Data_LetterList"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //public void GetLetter_VestingDOC()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = objbal.GetLetter_List();
        //        if (ds.Tables[0].Rows.Count > 0 && ds != null)
        //        {
        //            string FileNamePath = ds.Tables[0].Rows[0]["FILENAME"].ToString().Trim();
        //            ViewState["FILENAME"] = FileNamePath;
        //            dlVesting.DataSource = ds.Tables[0];
        //            dlVesting.DataBind();
        //            //ViewState["Data_LetterList"] = ds.Tables[0];
        //        }
        //        else
        //        {
        //            dlVesting.DataSource = null;
        //            dlVesting.DataBind();
        //            //  ViewState["Data_LetterList"] = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        //throw ex;
        //    }
        //}

        //public void GetLetter_ExerciseDOC()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = objbal.GetLetter_List();
        //        if (ds.Tables[0].Rows.Count > 0 && ds != null)
        //        {
        //            string FileNamePath = ds.Tables[0].Rows[0]["FILENAME"].ToString().Trim();
        //            ViewState["FILENAME"] = FileNamePath;
        //            dlExercise.DataSource = ds.Tables[0];
        //            dlExercise.DataBind();
        //            //ViewState["Data_LetterList"] = ds.Tables[0];
        //        }
        //        else
        //        {
        //            dlExercise.DataSource = null;
        //            dlExercise.DataBind();
        //            //  ViewState["Data_LetterList"] = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        //throw ex;
        //    }
        //}


        //protected void lnkbtn_Download_Click(object sender, EventArgs e)
        //{
        //    ////LinkButton btn = sender as LinkButton;

        //    //// string filename = Convert.ToString(ViewState["FILENAME"]);// btn.CommandArgument.ToString();
        //    //string filePath = Convert.ToString(ViewState["FILENAME"]);
        //    //string Vpath = filePath.Replace(@"E:", "~").Replace(@"\", "/");

        //    //if (filePath != string.Empty)
        //    //{
        //    //    DownLoad(filePath);
        //    //}

        //    LinkButton btn = (LinkButton)sender;
        //    GridViewRow row = (GridViewRow)btn.NamingContainer;
        //    // string filename = btn.CommandArgument.ToString();
        //    if (row != null)
        //    {
        //        if (row != null)
        //        {
        //            int rowindex = row.RowIndex;
        //            HiddenField Hdf = GrvLetter_List.Rows[rowindex].FindControl("HiddenField1") as HiddenField;
        //            string filePath = Hdf.Value.ToString().Replace(".docx", ".pdf");
        //            // string Vpath = filePath.Replace(@"E:", "~").Replace(@"\", "/");


        //            if (filePath != string.Empty)
        //            {
        //                DownLoad(filePath);
        //            }
        //        }

        //    }
        //}

        public void DownLoad(string FName)
        {
            string path = Server.MapPath(FName);
            string[] Firstname = FName.Split('/');
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                //Response.AddHeader("Content-Length", file.Length.ToString());
                //Response.ContentType = "application/octet-stream"; // download […]
                Stream s = File.OpenRead(path);
                Byte[] buffer = new Byte[s.Length];
                try
                {
                    s.Read(buffer, 0, (Int32)s.Length);
                }
                //close our stream
                finally { s.Close(); }
                //clear the response headers
                Response.ClearHeaders();
                //clear the content type
                Response.ClearContent();
                Response.ContentType = "application/octet-stream";
                //add our header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Firstname[1].ToString());
                //write the buffer to the http stream
                Response.TransmitFile(path);
                //   Response.BinaryWrite(buffer);
                //end response
                Response.End();
            }
        }
        
        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            try
            {
                string key = "";
                switch (Type)
                {
                    case "Grant Letter":
                        key = "GL";
                        break;

                    case "Sale Declaration":
                        key = "SD";
                        break;

                    case "Sale Offer":
                        key = "SO";
                        break;

                }
                DataSet ds = objbal.UpdateTimestamp(ID, key, Session["ECode"].ToString());
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToString(dt.Rows[0][0]) != "0")
                    {
                        CheckBox1.Checked = true;
                        CheckBox1.Enabled = false;
                    }
                    else
                    {
                        CheckBox1.Checked = false;
                        CheckBox1.Enabled = true;
                    }
                }
                //bool val = objbal.UpdateTimestamp(ID, key, Session["ECode"].ToString());

                string filename = ViewState["arg"].ToString(); //(sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "PreviewFile('" + filePath + "');", true);
                    ViewState["PreviewFilepath"] = filename.Replace("~/", "");
                }
                else
                {
                    Common.ShowJavascriptAlert("Documents Not exist in folder");
                }

				//LinkButton btn = (LinkButton)sender;
				//GridViewRow row = (GridViewRow)btn.NamingContainer;
				//if (row != null)
				//{
				//    int rowindex = row.RowIndex;
				//    HiddenField Hdf = GrvLetter_List.Rows[rowindex].FindControl("HiddenField1") as HiddenField;
				//    string Extention = Path.GetExtension(Hdf.Value.ToString());
				//    //string Path1 = Hdf.Value.ToString().Replace(".docx", ".pdf");

				//    if (Extention == ".pdf")
				//    {
				//        string Path = Hdf.Value.ToString();
				//        if (File.Exists(Server.MapPath(Path)))
				//        {
				//            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + Path.Replace("~/", "") + "');", true);
				//        }
				//        else
				//        {
				//            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
				//            return;
				//        }

				//    }
				//    else
				//    {
				//        if (Extention == ".jpeg" || Extention == ".png" || Extention == ".jpg")
				//        {
				//            string filePath = Server.MapPath(Hdf.Value.ToString());
				//            if (File.Exists(filePath))
				//            {
				//                string Freshchequefile = Hdf.Value.ToString();
				//                FreshChequeImage1.Src = Freshchequefile;
				//                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal1();", true);
				//            }
				//            else
				//            {
				//                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
				//                return;
				//            }
				//        }
				//        else
				//        {
				//            if (Extention == ".docx" || Extention == ".doc")
				//            {
				//                string filePath = Server.MapPath(Hdf.Value.ToString());
				//                if (File.Exists(filePath))
				//                {
				//                    Response.ContentType = ContentType;
				//                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
				//                    Response.WriteFile(filePath);
				//                    Response.End();
				//                }
				//                else
				//                {
				//                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
				//                    return;
				//                }
				//            }
				//        }
				//    }
				//}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //protected void lnkbtn_Download_Click1(object sender, EventArgs e)
        //{
        //    string filename = (sender as LinkButton).CommandArgument;
        //    string Path1 = filename.Replace(".docx", ".pdf");
        //    string filePath = Server.MapPath(Path1);
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    // Response.TransmitFile(Server.MapPath(filePath));

        //    Response.End();
        //}

        //protected void GrvLetter_List_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    LinkButton lb = e.Row.FindControl("lnkbtn_Download") as LinkButton;
        //    if (lb != null)
        //    {
        //        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(lb);
        //    }
        //}

        protected void lnkGrantDOC_Click(object sender, EventArgs e)
        {
            try
            {
                //string filename = (sender as LinkButton).CommandArgument;
                ////string Path1 = filename.Replace(".docx", ".pdf");
                //string filePath = Server.MapPath(filename);
                //if (File.Exists(filePath))
                //{
                //    Response.ContentType = ContentType;
                //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                //    Response.WriteFile(filePath);
                //    Response.End();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                //    return;
                //}
                
                string filename = (sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                    ViewState["filepath"] = filename.Replace("~/", "");
                }
                else
                {
                    Common.ShowJavascriptAlert("Documents Not exist in folder");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        
        protected void lnkAllDoc_Click(object sender, EventArgs e)
        {
            try
            {
                //string filename = (sender as LinkButton).CommandArgument;
                ////string Path1 = filename.Replace(".docx", ".pdf");
                //string filePath = Server.MapPath(filename);
                //if (File.Exists(filePath))
                //{
                //    Response.ContentType = ContentType;
                //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                //    Response.WriteFile(filePath);
                //    Response.End();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                //    return;
                //}

                string filename = (sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                    ViewState["filepath"] = filename.Replace("~/", "");
                }
                else
                {
                    Common.ShowJavascriptAlert("Documents Not exist in folder");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //protected void lnkVestingDoc_Click(object sender, EventArgs e)
        //{
        //    string filename = (sender as LinkButton).CommandArgument;
        //    string Path1 = filename.Replace(".docx", ".pdf");
        //    string filePath = Server.MapPath(Path1);
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    // Response.TransmitFile(Server.MapPath(filePath));

        //    Response.End();
        //}
        //protected void lnkExerciseDoc_Click(object sender, EventArgs e)
        //{
        //    string filename = (sender as LinkButton).CommandArgument;
        //    string Path1 = filename.Replace(".docx", ".pdf");
        //    string filePath = Server.MapPath(Path1);
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    // Response.TransmitFile(Server.MapPath(filePath));

        //    Response.End();
        //}

        protected void lnkSales_Click(object sender, EventArgs e)
        {
            try
            {
                //string filename = (sender as LinkButton).CommandArgument.ToString();
                ////string Path1 = filename.Replace(".docx", ".pdf");
                //string filePath = Server.MapPath(filename);
                //if (File.Exists(filePath))
                //{
                //    Response.ContentType = ContentType;
                //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                //    Response.WriteFile(filePath);
                //    Response.End();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                //    return;
                //}

                string filename = (sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                    ViewState["filepath"] = filename.Replace("~/", "");
                }
                else
                {
                    Common.ShowJavascriptAlert("Documents Not exist in folder");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void GrvLetter_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ViewState["arg"] = e.CommandArgument.ToString();
                if (e.CommandName == "download" || e.CommandName == "Preview")
                {
                    //Reference the GridView Row.
                    GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;

                    //Fetch value of Name.
                    Type = row.Cells[1].Text.ToString().Trim();
                    ID = (row.FindControl("HiddenField2") as HiddenField).Value;

                    switch (e.CommandName)
                    {
                        case "download":
                            lb_download_Click(sender, e);
                            break;

                        case "Preview":
                            btn_Preview_Click(sender, e);
                            break;
                    }
                }

                if (e.CommandName == "download")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string hd = (gvr.FindControl("HiddenField1") as HiddenField).Value;
                    string LtrFile = hd.ToString();

                    string filePath = Server.MapPath(LtrFile);
                    //if (File.Exists(filePath))
                    //{
                    //    Response.ContentType = ContentType;
                    //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    //    Response.WriteFile(filePath);
                    //    Response.End();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                    //    return;
                    //}
                }

                //if (e.CommandName == "Preview")
                //{
                //    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                //    int rowIndex = gvr.RowIndex;

                //    string hd = (gvr.FindControl("HiddenFieldack") as HiddenField).Value;
                //    string LtrFile = hd.ToString();

                //    string filePath = Server.MapPath(LtrFile);
                //    if (HiddenFieldack == NULL)
                //    {
                //        CheckBox1 = unchecked;
                //    }
                //    else
                //    {
                //        CheckBox1 = checked;
                //    };
                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lb_download_Click(object sender, EventArgs e)
        {
            try
            {
                string key = "";
                switch (Type)
                {
                    case "Grant Letter":
                        key = "GL";
                        break;

                    case "Sale Declaration":
                        key = "SD";
                        break;

                    case "Sale Offer":
                        key = "SO";
                        break;

                }
                DataSet ds = objbal.UpdateTimestamp(ID, key, Session["ECode"].ToString());
                //bool val = objbal.UpdateTimestamp(ID, key, Session["ECode"].ToString());
                string filename = ViewState["arg"].ToString(); //(sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                    ViewState["filepath"] = filename.Replace("~/", "");
                }
                else
                {
                    Common.ShowJavascriptAlert("Documents Not exist in folder");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = ViewState["filepath"].ToString();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //protected void GridViewack_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Preview")
        //        {
        //            GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
        //            int rowIndex = gvr.RowIndex;

        //            string hd = (gvr.FindControl("HiddenField1") as HiddenField).Value;
        //            string LtrFile = hd.ToString();
        //            string filePath = Server.MapPath(LtrFile);
        //            if (File.Exists(filePath))
        //            {
        //                Response.ContentType = ContentType;
        //                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //                Response.WriteFile(filePath);
        //                Response.End();
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}
        protected void PreviewFile_Click(object sender, EventArgs e)
        {
            try
            {

                string Extention = Path.GetExtension(ViewState["PreviewFilepath"].ToString());
                string FilePath = ViewState["PreviewFilepath"].ToString();
                
                if (Extention == ".pdf")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + FilePath.Replace("~/", "") + "');", true);
                }
                else
                {
                    if (Extention == ".jpeg" || Extention == ".png" || Extention == ".jpg")
                    {
                        string Freshchequefile = FilePath.ToString();
                        FreshChequeImage1.Src = Freshchequefile;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal1();", true);
                    }
                    else
                    {
                        if (Extention == ".docx" || Extention == ".doc")
                        {
                            string filePaths = Server.MapPath(FilePath);
                            Response.ContentType = ContentType;
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePaths));
                            Response.WriteFile(filePaths);
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

   
        protected void GrvLetter_List_PreRender(object sender, EventArgs e)
        {
            System.Data.DataTable ds = (System.Data.DataTable)ViewState["GrvLetter_List"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    GrvLetter_List.UseAccessibleHeader = true;
                    GrvLetter_List.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
        }
    }
}
