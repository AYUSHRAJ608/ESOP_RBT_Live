using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_DAL;
using ESOP_BAL;

namespace ESOP_BAL
{
   public class BEmployeeMasterUpload
    {
        public DataTable addExcelDump(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.InsertEmpMastRecToDump_BulkUpload(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable fetchLastemuId(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getEMuId_Dal(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable getFailedData(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getFailedData_Dal(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable getRecCount(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getRecCount_DAL(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable getRecCount_Fail(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getRecCountFailed_DAL(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable addSuccessData(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.addSuccessData_DAL(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable updateOverwriteRec(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.UpdateOverwriteRec_BulkUpload(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        //Added by Bhushan on 16-12-2021 for PAN Card upload
        public DataSet getRecordCount(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getRecordCount(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable getLastGuid(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getLastGuid(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable UpdateEmpPANDetails(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.UpdateEmpPANDetails(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataTable getFailedRecordsData(E_EmployeMasterUpload objEntity)
        {
            DAL_EmpMasterUpload objDal = new DAL_EmpMasterUpload();
            try
            {
                return objDal.getFailedRecordsData(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
        //End
    }
}
