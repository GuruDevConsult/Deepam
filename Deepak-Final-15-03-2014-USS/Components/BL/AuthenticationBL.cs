using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class AuthenticationBL
    {
        #region Variable
        Components.Common.GlobalFunction GlbFunc = Components.Common.GlobalFunction.Instance;
        Components.DAL.SQLConnect SqlHelper = Components.DAL.SQLConnect.Instance;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        private static AuthenticationBL _Instance;
        #endregion

        #region Instance
        public static AuthenticationBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AuthenticationBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region Select
        public DataTable Select(string _User, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Authent_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@User", DbType.String, _User);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            //DataTable dt = new DataTable();
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region Load_Emp
        public DataSet Load_Emp(string BranchName)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Authent_Load_Emp");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BranchName);
            //DataTable dt = new DataTable();
            DataSet dt = objDataBase.ExecuteDataSet(dbCommand);
            return dt;
        }
        #endregion

        #region SelectID
        public DataTable SelectID(string _UserID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Authent_UserID_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, _UserID);
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
        
        #region AddressBook_UName_Check
        public DataTable AddressBook_UName_Check(string UserName,string BranchName)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_UName_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BranchName);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region AuthentSelect
        public DataTable AuthentSelect(int _EmployeeName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Authentication_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmployeeName", DbType.Int32, _EmployeeName);
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

        #region AuthentSave
        public int AuthentSave(int _EmployeeName, string _ResourceID, string _ResourceAll, string _ResourceSave, string _ResourceDelete, string _ResourceView, string _ResourceEdit, string Userid, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Authentication_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmployeeName", DbType.Int32, _EmployeeName);
            objDataBase.AddInParameter(dbCommand, "@ResourceAll", DbType.String, _ResourceAll);
            objDataBase.AddInParameter(dbCommand, "@ResourceSave", DbType.String, _ResourceSave);
            objDataBase.AddInParameter(dbCommand, "@ResourceDelete", DbType.String, _ResourceDelete);
            objDataBase.AddInParameter(dbCommand, "@ResourceView", DbType.String, _ResourceView);
            objDataBase.AddInParameter(dbCommand, "@ResourceEdit", DbType.String, _ResourceEdit);
            objDataBase.AddInParameter(dbCommand, "@ResourceID", DbType.String, _ResourceID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@userName", DbType.String, Userid);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region AuthentUpdate
        public int AuthentUpdate(int _ID, int _EmployeeName, string _ResourceID, string _ResourceAll, string _ResourceSave, string _ResourceDelete, string _ResourceView, string _ResourceEdit, string UserID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Authentication_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmployeeName", DbType.Int32, _EmployeeName);
            objDataBase.AddInParameter(dbCommand, "@ResourceAll", DbType.String, _ResourceAll);
            objDataBase.AddInParameter(dbCommand, "@ResourceSave", DbType.String, _ResourceSave);
            objDataBase.AddInParameter(dbCommand, "@ResourceDelete", DbType.String, _ResourceDelete);
            objDataBase.AddInParameter(dbCommand, "@ResourceView", DbType.String, _ResourceView);
            objDataBase.AddInParameter(dbCommand, "@ResourceEdit", DbType.String, _ResourceEdit);
            objDataBase.AddInParameter(dbCommand, "@ResourceID", DbType.String, _ResourceID);
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, _ID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@userName", DbType.String, UserID);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion
    }
}
