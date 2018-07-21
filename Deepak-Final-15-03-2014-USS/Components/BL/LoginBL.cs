using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class LoginBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static LoginBL _Instance;

        int affectedRows;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static LoginBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoginBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region CheckLogin()
        public int CheckLogin(Components.DTO.LoginDTO LGDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Login_Chk");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, LGDTO.UserName);
            objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, LGDTO.Password);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            return affectedRows;
        }
        #endregion

        public int CheckUserName(Components.DTO.LoginDTO ForgotDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ForgotPwd_Chk");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@SecuQues", DbType.String, ForgotDTO.SecuQues);
            objDataBase.AddInParameter(dbCommand, "@SecuAns", DbType.String, ForgotDTO.SecuAns);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            return affectedRows;
        }

        public int ResetPwd(Components.DTO.LoginDTO LGDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ForgotPwd_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, LGDTO.UserName);
            objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, LGDTO.Password);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            return affectedRows;
        }

        public int PwdCheck(Components.DTO.LoginDTO LGDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("CheckLogin");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, LGDTO.UserName);
            objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, LGDTO.Password);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            return affectedRows;
        }
    }
}
