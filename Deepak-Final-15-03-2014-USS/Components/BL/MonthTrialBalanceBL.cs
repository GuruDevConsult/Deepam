using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class MonthTrialBalanceBL
    {
        #region Vaiables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static MonthTrialBalanceBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static MonthTrialBalanceBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MonthTrialBalanceBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region MonthTrial_Check

        public DataTable MonthTrial(DateTime MonDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("MonthTrialBalance_Report");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, MonDate);
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
