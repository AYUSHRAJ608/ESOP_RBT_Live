using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data.OleDb;
using System.Data.SqlClient;
using ExcelDataReader;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ESOP
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void Function_SendMail(string from, string to, string EM_Type, string EM_Sub_Type, string Grant_Name, string MailID, string GrantID, string Fmv, string Fromdate, string Todate, string Empname)
        {

            string Mail_Functional = System.Configuration.ConfigurationManager.AppSettings["SendMail_Functionality"];
            if (Mail_Functional == "ON")
            {
                try
                {


                    EMailBO OEMailBO = new EMailBO();
                    EMailBAL OEMailBAL = new EMailBAL();
                    cEmailEntityRequest emailreq = new cEmailEntityRequest();

                    string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
                    string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
                    string Mail_To = System.Configuration.ConfigurationManager.AppSettings["Mail_To"];
                    string Host = System.Configuration.ConfigurationManager.AppSettings["Host"];
                    string Port = System.Configuration.ConfigurationManager.AppSettings["Port"];

                    OEMailBO.Em_Action = "SendEmail";
                    OEMailBO.Em_Type = EM_Type;
                    OEMailBO.Em_Sub_Type = EM_Sub_Type;
                    emailreq.EmailEntity = OEMailBO;
                    DataSet ds = OEMailBAL.insertEmail(emailreq);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["ISACTIVE"].ToString() == "true")
                        {
                            String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
                            ////String SessionCheck = Convert.ToString(Session["UserName"]);
                            String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
                            //body = body.Replace("{{User}}", SessionCheck);
                            body = body.Replace("@To", to);
                            if (EM_Sub_Type == "Grant_Created")
                            {
                                body = body.Replace("@GrantName", Grant_Name);
                            }
                            body = body.Replace("@From", from);
                            body = body.Replace("@GrantID", GrantID.ToString());
                            body = body.Replace("@FMVPrice", Fmv);
                            body = body.Replace("@EMpName", Empname);
                            body = body.Replace("@GrantName", Grant_Name);
                            body = body.Replace("@StartDate", Fromdate);
                            body = body.Replace("@EndDate", Todate);
                            // body = body.Replace("@GrantName", period);


                            string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
                            ccMailID = ccMailID.Replace(";", ",");
                            string[] CCMailId = ccMailID.Split(',');

                            string frommailId = UserMailID;
                            ///string frommailId = "pallavi.chaware@cloverinfotech.com";// ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
                            string ToMailId = Mail_To;

                            MailMessage message = new MailMessage();
                            SmtpClient smtp = new SmtpClient();
                            message.From = new MailAddress(frommailId);
                            message.To.Add(new MailAddress(ToMailId));

                            //added on 11/03/2022
                            string AppLocation = "";
                            AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                            AppLocation = AppLocation.Replace("file:\\", "").Replace("\\bin", "");
                            var Server = HttpContext.Current.Server;
                            string Attachment = Server.MapPath("\\Grant_Files\\Grant_Issued.xls");
                            //added by Pallavi on 07/03/2022

                            OEMailBO.Attachment = Attachment;

                            if (!string.IsNullOrEmpty(OEMailBO.Attachment))
                            {
                                Attachment atdoc = new Attachment(OEMailBO.Attachment);
                                message.Attachments.Add(atdoc);
                            }
                            //if (MailID != "")
                            //{
                            //    message.CC.Add(MailID);
                            //}
                            //else
                            //{
                            //    message.CC.Add(ccMailID);
                            //}
                            ////////////if (MailID != "")
                            ////////////{
                            ////////////    ccMailID = ccMailID + "," + MailID;
                            ////////////}
                            ////////////string[] cceMailID = ccMailID.Split(',');
                            ////////////foreach (string CCEmail in cceMailID)
                            ////////////{
                            ////////////    if (CCEmail != "")
                            ////////////    {
                            ////////////        message.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            ////////////    }
                            ////////////}
                            ////foreach (string CCEmail in CCMailId)
                            ////{
                            ////    if (CCEmail != "")
                            ////    {
                            ////        message.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            ////    }
                            ////}
                            // message.CC.Add(ccMailID);
                            message.Subject = mailSubject;
                            message.IsBodyHtml = true;
                            message.Body = body;

                            smtp.Port = Convert.ToInt32(Port);// 25;
                            smtp.Host = Host; // "email.cloverinfotech.com";
                            smtp.EnableSsl = false;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(UserMailID, UserPassword);

                            //Comeented Temporary
                            try
                            {
                                smtp.Send(message);
                            }
                            catch (Exception ex)
                            {
                                Common.ErrorLogging("SendMail.aspx", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                                //throw ex;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging("SendMail.aspx", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
            }
            else
            {
                //Commented by Rahul_Natu on 19-05-2022 to short fix on ERGO_UAT
                //try
                //{
                //    string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
                //    string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
                //    string Mail_To = System.Configuration.ConfigurationManager.AppSettings["Mail_To"];
                //    string MailSubject = System.Configuration.ConfigurationManager.AppSettings["Mail_To"];
                //    string Host = System.Configuration.ConfigurationManager.AppSettings["Host"];
                //    string Port = System.Configuration.ConfigurationManager.AppSettings["Port"];

                //    string AppLocation = "";
                //    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                //    AppLocation = AppLocation.Replace("file:\\", "").Replace("\\bin", "");
                //    string file = AppLocation + "\\Grant_Files\\Grant_Issued.xls";
                //    MailMessage mail = new MailMessage();
                //    SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["Host"].ToString());
                //    string frommailId = "pallavi.chaware@cloverinfotech.com";
                //    mail.From = new MailAddress(frommailId);
                //    mail.To.Add(Mail_To); // Sending MailTo  
                //    //List<string> li = new List<string>();
                //    //li.Add("pallavi.chaware@cloverinfotech.com");
                //    //li.Add("saihacksoft@gmail.com");  
                //    //li.Add("saihacksoft@gmail.com");  
                //    //li.Add("saihacksoft@gmail.com");  
                //    //li.Add("saihacksoft@gmail.com");  
                //    //mail.CC.Add(string.Join<string>(",", li)); // Sending CC  
                //    //mail.Bcc.Add(string.Join<string>(",", li)); // Sending Bcc   
                //    mail.Subject = MailSubject; // Mail Subject  
                //    mail.Body = "Grant Issued *This is an automatically generated email, please do not reply*";
                //    System.Net.Mail.Attachment attachment;
                //    attachment = new System.Net.Mail.Attachment(file); //Attaching File to Mail  
                //    mail.Attachments.Add(attachment);
                //    SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]); //PORT  
                //    SmtpServer.EnableSsl = true;
                //    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    SmtpServer.UseDefaultCredentials = false;
                //    SmtpServer.Credentials = new NetworkCredential("Email id of Gmail", "Password of Gmail");
                //    SmtpServer.Send(mail);
                //}
                //catch (Exception ex)
                //{
                //    Common.ErrorLogging("SendMail.aspx", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //}
                //END
            }
            //else
            //{

            //    EMailBO OEMailBO = new EMailBO();
            //    EMailBAL OEMailBAL = new EMailBAL();
            //    cEmailEntityRequest emailreq = new cEmailEntityRequest();

            //    string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
            //    string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
            //    string Mail_To = System.Configuration.ConfigurationManager.AppSettings["Mail_To"];
            //    string Host = System.Configuration.ConfigurationManager.AppSettings["Host"];
            //    string Port = System.Configuration.ConfigurationManager.AppSettings["Port"];

            //    OEMailBO.Em_Action = "SendEmail";
            //    OEMailBO.Em_Type = EM_Type;
            //    OEMailBO.Em_Sub_Type = EM_Sub_Type;
            //    emailreq.EmailEntity = OEMailBO;
            //    DataSet ds = OEMailBAL.insertEmail(emailreq);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows[0]["ISACTIVE"].ToString() == "true")
            //        {
            //            String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
            //            ////String SessionCheck = Convert.ToString(Session["UserName"]);
            //            String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
            //            //body = body.Replace("{{User}}", SessionCheck);
            //            body = body.Replace("@To", to);
            //            if (EM_Sub_Type == "Grant_Created")
            //            {
            //                body = body.Replace("@GrantName", Grant_Name);
            //            }
            //            body = body.Replace("@From", from);
            //            body = body.Replace("@GrantID", GrantID.ToString());
            //            body = body.Replace("@FMVPrice", Fmv);
            //            body = body.Replace("@EMpName", Empname);
            //            body = body.Replace("@GrantName", Grant_Name);
            //            body = body.Replace("@StartDate", Fromdate);
            //            body = body.Replace("@EndDate", Todate);
            //            // body = body.Replace("@GrantName", period);


            //            string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
            //            ccMailID = ccMailID.Replace(";", ",");

            //            string frommailId = UserMailID;// ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
            //            string ToMailId = Mail_To;

            //            MailMessage message = new MailMessage();
            //            SmtpClient smtp = new SmtpClient();
            //            message.From = new MailAddress(frommailId);
            //            message.To.Add(new MailAddress(ToMailId));
            //            //added by Pallavi on 07/03/2022
            //            System.Net.Mail.Attachment attachment;
            //            attachment = new System.Net.Mail.Attachment("~/Grant_Files/Grant_Issued.xls");
            //            message.Attachments.Add(attachment);
            //            //if (MailID != "")
            //            //{
            //            //    message.CC.Add(MailID);
            //            //}
            //            //else
            //            //{
            //            //    message.CC.Add(ccMailID);
            //            //}
            //            if (MailID != "")
            //            {
            //                ccMailID = ccMailID + "," + MailID;
            //            }
            //            string[] cceMailID = ccMailID.Split(',');
            //            foreach (string CCEmail in cceMailID)
            //            {
            //                if (CCEmail != "")
            //                {
            //                    message.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
            //                }
            //            }
            //            // message.CC.Add(ccMailID);
            //            message.Subject = mailSubject;
            //            message.IsBodyHtml = true;
            //            message.Body = body;

            //            smtp.Port = Convert.ToInt32(Port);// 25;
            //            smtp.Host = Host; // "email.cloverinfotech.com";
            //            smtp.EnableSsl = false;
            //            smtp.UseDefaultCredentials = false;
            //            smtp.Credentials = new NetworkCredential(UserMailID, UserPassword);
            //        }
            //    }
            //}
        }
    }
}