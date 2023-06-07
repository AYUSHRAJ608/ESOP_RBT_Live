using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class AuditBAL
    {
        AuditDAL objDAL = new AuditDAL();
        public DataSet GET_Audit(int type)
        {
            return objDAL.GET_AUDIT(type);
        }
        public DataSet GET_ExerciseMainGrid()
        {
            return objDAL.GET_ExerciseMainGrid();
        }
        public DataSet GET_ExerciseChildGrid(int id)
        {
            return objDAL.GET_ExerciseChildGrid(id);
        }

        public DataSet GET_SellMainGrid()
        {
            return objDAL.GET_SellMainGrid();
        }
        public DataSet GET_SellChildGrid(int id)
        {
            return objDAL.GET_SellChildGrid(id);
        }
    }
}
