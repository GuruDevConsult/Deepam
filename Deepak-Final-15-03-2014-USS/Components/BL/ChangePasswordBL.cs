using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{
    public class ChangePasswordBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        private static ChangePasswordBL _Instance;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static ChangePasswordBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangePasswordBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region OldPass_Check
        public DataTable OldPass_Check(string UserName, string OldPass, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ChangePassword_OldPass_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
            objDataBase.AddInParameter(dbCommand, "@OldPassword", DbType.String, OldPass);
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

        #region ChangePassSave
        public int ChangePassSave(string UserName, string OldPass, string NewPass, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ChangePassword_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
            objDataBase.AddInParameter(dbCommand, "@OldPass", DbType.String, OldPass);
            objDataBase.AddInParameter(dbCommand, "@NewPass", DbType.String, NewPass);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedrows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedrows;
        }
        #endregion
    }
}
