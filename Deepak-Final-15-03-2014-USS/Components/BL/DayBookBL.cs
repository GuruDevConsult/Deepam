using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class DayBookBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static DayBookBL _Instance;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static DayBookBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DayBookBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region DayBook Save

        public int DayBook_I(DataTable dtLoad, string Branch, string UserID)
        {
            foreach (DataRow dr in dtLoad.Rows)
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("DayBook_I");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, dr["Date"].ToString());
                objDataBase.AddInParameter(dbCommand, "@AccountName", DbType.String, dr["AccountName"].ToString());
                objDataBase.AddInParameter(dbCommand, "@Types", DbType.String, dr["Types"].ToString());
                objDataBase.AddInParameter(dbCommand, "@Particulars", DbType.String, dr["Particulars"].ToString());
                objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, dr["Amount"].ToString());
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                return affectedRows;
            }
            return 0;

        }
        #endregion

        #region DayBook_AccountName
        public DataTable DayBook_AccountName(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DayBook_AccountName");
            dbCommand.CommandType = CommandType.StoredProcedure;
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

        #region DayBook_DayGrid
        public DataTable DayBook_DayGrid(DateTime DayDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DayBook_DayGrid");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DayDate", DbType.DateTime, DayDate);
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

        #region DayBook Update
        public int DayBook_U(DateTime _Date, string ddlA, string ddlT, string txtP, decimal txtAmt, int _DayBookID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DayBook_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DayBookID", DbType.Int32, _DayBookID);
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, _Date);
            objDataBase.AddInParameter(dbCommand, "@AccountName", DbType.String, ddlA);
            objDataBase.AddInParameter(dbCommand, "@Types", DbType.String, ddlT);
            objDataBase.AddInParameter(dbCommand, "@Particulars", DbType.String, txtP);
            objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, txtAmt);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region DayBook Delete
        public int DayBook_D(int _DayBookID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DayBook_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DayBookID", DbType.Int32, _DayBookID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion
    }
}
