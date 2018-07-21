using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class NewUserBL
    {
        #region Variable
        Components.Common.GlobalFunction GlbFunc;
        //Components.Common.ObjectWrapper ObjWrp;
        Components.DAL.SQLConnect SqlHelper;
        private static NewUserBL _Instance;

        DataTable dtEmployeeID;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static NewUserBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NewUserBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region LoadEmployee
        public DataTable LoadEmployee(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("NewUser_Emp_S");
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

        #region LoadEmployee
        public DataTable NewUser_UName_Check(string UName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("NewUser_UName_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UName", DbType.String, UName);
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

        #region SaveNewUser
        public int SaveNewUser(Components.DTO.LoginDTO NewUserDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("NewUser_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmpName", DbType.String, NewUserDTO.EmployeeID);
            objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, NewUserDTO.Password);
            objDataBase.AddInParameter(dbCommand, "@SecuQues", DbType.Int32, NewUserDTO.SecuQues);
            objDataBase.AddInParameter(dbCommand, "@SecuAns", DbType.String, NewUserDTO.SecuAns);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, NewUserDTO.UserName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion


    }
}
