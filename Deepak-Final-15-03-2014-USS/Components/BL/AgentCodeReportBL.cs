using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class AgentCodeReportBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static AgentCodeReportBL _Instance;
        DataTable dtAgent;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static AgentCodeReportBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AgentCodeReportBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region Load AgentName
        public DataTable Load_Agent(DateTime FDate, DateTime TDate,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AgentName_Load_Report");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FDate", DbType.DateTime, FDate);
            objDataBase.AddInParameter(dbCommand, "@TDate", DbType.DateTime, TDate);
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
