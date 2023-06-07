using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ESOP_BO;
using System.Data.OracleClient;
namespace ESOP_DAL
{
    public class EMailDAL
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLCnnString"].ConnectionString);
        OracleCommand cmd = new OracleCommand();
        DataSet ds = new DataSet();
        public string SendHtmlFormattedEmail(EMailBO objEntity)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(objEntity.EmailTemPath))// Server.MapPath("~/EmailTemplate/SendMail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", objEntity.userName); //replacing the required things 
            body = body.Replace("{FMV_Price}", objEntity.FMV_Price);
            body = body.Replace("{Status}", objEntity.Status1);
            body = body.Replace("{Role}", Convert.ToString(objEntity.Role));


            using (MailMessage mailMessage = new MailMessage())
            {
                string TOEMail = string.Empty;
                string CCMail = string.Empty;
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = objEntity.subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                //To Code
                TOEMail += objEntity.EmailID;
                string[] ToEmailCopy = TOEMail.Split(',');

                foreach (string ToEMailId in ToEmailCopy)
                {
                    if (ToEMailId != "")
                    {
                        mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
                    }
                }

                ///CC CODE
                if (ConfigurationManager.AppSettings["CCMail"] != "")
                    CCMail += objEntity.CCEmailID + ConfigurationManager.AppSettings["CCMail"];
                else
                    CCMail += objEntity.CCEmailID;
                string[] CCMailId = CCMail.Split(',');

                foreach (string CCEmail in CCMailId)
                {
                    mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                }

                //if (objEntity.fileUpload != null)
                //{
                //    //mailMessage.Attachments.Add(new Attachment(objEntity.fileUpload, objEntity.FileName));
                //    mailMessage.Attachments.Add(new Attachment(fileUploader.PostedFile.InputStream, objEntity.FileName));
                //}

                if (objEntity.Attachment != "")
                {
                    Attachment atdoc = new Attachment(objEntity.Attachment);
                    mailMessage.Attachments.Add(atdoc);
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                smtp.Send(mailMessage);
                return body;//return true;
            }

        }
        public bool InsertEmailDetails(EMailBO objEntity)
        {
            bool status = false;
            try
            {                
                cmd = new OracleCommand("sp_InsertEmailDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //  cmd.Parameters.AddWithValue("p_Message", objEntity.body);
                //  cmd.Parameters.AddWithValue("p_Status", objEntity.Status);
                // cmd.Parameters.AddWithValue("p_CreatedBy", objEntity.CreatedBy);
                // cmd.Parameters.AddWithValue("p_EmailID", objEntity.EmailID);
                // cmd.Parameters.AddWithValue("p_Subject", objEntity.subject);
                cmd.Parameters.Add("p_Message", OracleType.VarChar).Value = objEntity.body;
                cmd.Parameters.Add("p_Status", OracleType.VarChar).Value = objEntity.Status;
                cmd.Parameters.Add("p_CreatedBy", OracleType.VarChar).Value = objEntity.CreatedBy;
                cmd.Parameters.Add("p_EmailID", OracleType.VarChar).Value = objEntity.EmailID;
                cmd.Parameters.Add("p_Subject", OracleType.VarChar).Value = objEntity.subject;

                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return status;
        }

        public DataSet GetEMPDetails(EMailBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "USP_GET_EMP_DETAILS_NEW";  //Details to Details1
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.RoleName;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetEMPDetailsPresident(EMailBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "USP_GET_EMP_DETAILS1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.userName;
                // cmd.Parameters.Add("P_ROLEID", OracleType.VarChar).Value = EmpBo.RoleName; //commented by Nagesh 30/03
                //cmd.Parameters.Add("P_Grant_Status", OracleType.VarChar).Value = EmpBo.Status1; //commented by Nagesh 30/03
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                // cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output; //commented by Nagesh 30/03
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public DataSet GetEMPDetailsPresident1(EMailBO EmpBo)
        {
            try
            {
                DataSet dsresult = new DataSet();
                OracleCommand cmd = new OracleCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "USP_GET_EMP_DETAILS_NEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("P_EMPID", OracleType.VarChar).Value = EmpBo.userName;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //--------------------------------------------------------------------
        public DataSet insertEmail(cEmailEntityRequest request)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_ADDEMAIL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Em_Action", OracleType.VarChar).Value = request.EmailEntity.Em_Action;
                cmd.Parameters.Add("p_Em_Body", OracleType.VarChar).Value = request.EmailEntity.Em_Body;
                cmd.Parameters.Add("p_Em_Sub", OracleType.VarChar).Value = request.EmailEntity.Em_Sub;
                cmd.Parameters.Add("p_Em_Type", OracleType.VarChar).Value = request.EmailEntity.Em_Type;
                cmd.Parameters.Add("p_Em_Sub_Type", OracleType.VarChar).Value = request.EmailEntity.Em_Sub_Type;

                cmd.Parameters.Add("p_Em_Type_ID", OracleType.VarChar).Value = request.EmailEntity.Em_Type_ID;
                cmd.Parameters.Add("p_Em_ID", OracleType.VarChar).Value = request.EmailEntity.Em_ID;

                cmd.Parameters.Add("p_Em_CC_ID", OracleType.VarChar).Value = request.EmailEntity.Em_CC_ID;
                cmd.Parameters.Add("p_Em_BCC_ID", OracleType.VarChar).Value = request.EmailEntity.Em_BCC_ID;
                cmd.Parameters.Add("p_EM_From_ID", OracleType.VarChar).Value = request.EmailEntity.EM_From_ID;
                cmd.Parameters.Add("p_EM_CreatedBy", OracleType.VarChar).Value = request.EmailEntity.EM_CretaedBy;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_EM_Status", OracleType.VarChar).Value = request.EmailEntity.Em_Status;
                //cmd.Parameters.Add("p_EM_GFile", OracleType.VarChar).Value = request.EmailEntity.Em_GFile;

                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                con.Close();
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                   con.Close();
                //con.Dispose();
            }
        }

        public DataSet insertEmail1(cEmailEntityRequest request)
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_GET_EMAIL_DATA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_Em_Action", OracleType.VarChar).Value = request.EmailEntity.Em_Action;
                cmd.Parameters.Add("p_Em_Body", OracleType.VarChar).Value = request.EmailEntity.Em_Body;
                cmd.Parameters.Add("p_Em_Sub", OracleType.VarChar).Value = request.EmailEntity.Em_Sub;
                cmd.Parameters.Add("p_Em_Type", OracleType.VarChar).Value = request.EmailEntity.Em_Type;
                cmd.Parameters.Add("p_Em_Sub_Type", OracleType.VarChar).Value = request.EmailEntity.Em_Sub_Type;

                cmd.Parameters.Add("p_Em_Type_ID", OracleType.VarChar).Value = request.EmailEntity.Em_Type_ID;
                cmd.Parameters.Add("p_Em_ID", OracleType.VarChar).Value = request.EmailEntity.Em_ID;

                cmd.Parameters.Add("p_Em_CC_ID", OracleType.VarChar).Value = request.EmailEntity.Em_CC_ID;
                cmd.Parameters.Add("p_Em_BCC_ID", OracleType.VarChar).Value = request.EmailEntity.Em_BCC_ID;
                cmd.Parameters.Add("p_EM_From_ID", OracleType.VarChar).Value = request.EmailEntity.EM_From_ID;
                cmd.Parameters.Add("p_EM_CreatedBy", OracleType.VarChar).Value = request.EmailEntity.EM_CretaedBy;
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_EM_Status", OracleType.VarChar).Value = request.EmailEntity.Em_Status;
                //cmd.Parameters.Add("p_EM_GFile", OracleType.VarChar).Value = request.EmailEntity.Em_GFile;

                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                con.Close();
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }
        public DataSet getDropdown()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_DropdownforEmail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                con.Close();
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //   con.Close();
                //con.Dispose();
            }
        }

        public DataSet GetEmailID()
        {
            try
            {
                DataSet dsresult = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ESOP_GET_EMAILID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur2", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("cur3", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter objAdap = new OracleDataAdapter(cmd);
                objAdap.Fill(dsresult);
                con.Close();
                return dsresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //   con.Close();
                //con.Dispose();
            }
        }
    }
}
