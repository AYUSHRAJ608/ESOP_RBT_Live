using DAL_REPORT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entity_REPORT;
using System.IO;


namespace BAL_REPORT
{
    public class ReportBAL
    {
        ReportDAL objRptDAL = new ReportDAL();

        public void GetConnString(string key)
        {
            objRptDAL.GetConnString(key);
        }
        public DataSet GetDataSet()
        {
            return objRptDAL.GetDataSet();
        }
        public DataSet GetColumnsForDatasets(string tableName)
        {
            return objRptDAL.GetColumnsForDatasets(tableName);
        }
        public DataSet ShowReport(string columns, string[] tableName, int count)
        {
            return objRptDAL.ShowReport(columns, tableName, count);
        }
        public DataSet AddCreateReport(EReport objEnt)
        {
            return objRptDAL.AddCreateReport(objEnt);
        }
        public DataSet GetReportData(string Squery)
        {
            return objRptDAL.GetReportData(Squery);
        }
        public void UpdateReportsData(EReport objReport)
        {
            objRptDAL.UpdateReportsData(objReport);
        }
        public DataSet FillUsers()
        {
            return objRptDAL.FillUsers();
        }
        public DataSet FillDepartments()
        {
            return objRptDAL.FillDepartments();
        }
        public DataSet FillRoles()
        {
            return objRptDAL.FillRoles();
        }
        public DataSet FillRpts()
        {
            return objRptDAL.FillRptNames();
        }
        public DataSet getMaxRSID()
        {
            return objRptDAL.getMaxRSID_DAL();
        }
        public void addShareRpt(EReport objReport)
        {
            objRptDAL.addShareRpt_dal(objReport);
        }
        public DataSet GetFilterData_ByReport(string val)
        {
            return objRptDAL.GetFilterData_ByReport(val);
        }
        public DataSet GetFilterData_ByUsers(string val)
        {
            return objRptDAL.GetFilterData_ByUsers(val);
        }
        public DataSet GetFilterData_All()
        {
            return objRptDAL.GetFilterData_All();
        }
        public DataSet setRptStatus(Int32 rsId, Int32 shareid, String Action)
        {
            return objRptDAL.setRptStatus_DAL(rsId, shareid, Action);
        }
        public DataSet GetDataTypeForColumns(string tableName, string columnName)
        {
            return objRptDAL.GetDataTypeForColumns(tableName, columnName);
        }
    }
}
