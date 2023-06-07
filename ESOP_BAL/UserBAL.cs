using ESOP_BO;
using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class UserBAL
    {
        cUserEntityResponse response = new cUserEntityResponse();
        //public cUserEntityResponse GetUser(cUserEntityRequest request)
        //{
        //    List<User> lstcUserEntity = new List<User>();
        //    try
        //    {
        //        UserDAL objUserDAL = new UserDAL();
        //        DataSet dataset = objUserDAL.GetUser(request);
        //        if (dataset.Tables.Count > 0)
        //        {
        //            DataTableToEntity.FillList<User>(dataset.Tables[0], lstcUserEntity);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    response.lstcUserEntity = lstcUserEntity;
        //    return response;
        //}
        public cUserEntityResponse chkLoginCredential(cUserEntityRequest request)
        {
            string result = "";
            DataSet ds = new DataSet();
            List<UserBO> lstcUserEntity = new List<UserBO>();

            try
            {
                UserDAL objcUserDAL = new UserDAL();
                ds = objcUserDAL.chkLoginCredential(request);
                if (ds.Tables.Count > 0)
                {
                    DataTableToEntity.FillList<UserBO>(ds.Tables[0], lstcUserEntity);
                    response.lstcUserEntity = lstcUserEntity;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;

        }

        public int InsertIPAddressDetails(cUserEntityRequest request)
        {
            int result = 0;
            try
            {
                UserDAL objcUserDAL = new UserDAL();
                result= objcUserDAL.InsertIPAddressDetails(request);
            }
            catch(Exception ex)
            {
                throw ex;
             }
            return result;
        }
        public DataSet GetAllUsers()
        {
            UserDAL objcUserDAL = new UserDAL();
            return objcUserDAL.GetAllUsers();
        }

        public DataSet GetUser(UserBO objcUserEntity)
        {
            UserDAL objcUserDAL = new UserDAL();
            return objcUserDAL.GetUser(objcUserEntity);
        }
        public DataSet GetRole(cUserEntityRequest request)
        {
            UserDAL objcUserDAL = new UserDAL();
            return  objcUserDAL.chkLoginCredential(request);
        }
    }
}
