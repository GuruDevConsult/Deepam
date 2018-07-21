using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class PaidAmtReportBL
    {
        #region Vaiables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static PaidAmtReportBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static PaidAmtReportBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaidAmtReportBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region PaidDateCheck
        public DataTable PaidDateCheck(DateTime FDate, DateTime ToDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("PaidAmount_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FDate", DbType.DateTime, FDate);
            objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, ToDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion
    }
}
