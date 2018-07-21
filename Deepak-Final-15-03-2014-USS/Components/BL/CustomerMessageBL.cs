using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class CustomerMessageBL
    {
        #region variables
        int affectedRows = 0;
        private static CustomerMessageBL _Instance;
        Components.DAL.SQLConnect SqlHelper = Components.DAL.SQLConnect.Instance;
        Components.Common.GlobalFunction GlbFunc;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static CustomerMessageBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerMessageBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region Save
        public int Save(string MobileNo, string Msg, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("CustomerMsg_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@MobileNo", DbType.String, MobileNo);
            objDataBase.AddInParameter(dbCommand, "@Msg", DbType.String, Msg);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region CustomMessage Load
        public DataTable CustomMessage_Load(DateTime FromDate, DateTime ToDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("CustomMessage_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FDate", DbType.DateTime, FromDate);
            objDataBase.AddInParameter(dbCommand, "@TDate", DbType.DateTime, ToDate);
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
