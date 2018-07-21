using System;
using BusinessObjects;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Model
{
    public class UserModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");

        private void FillInsertParams(ref Database db, DbCommand dbCommand, UserObjects objLoginUserObjects)
        {
            db.AddInParameter(dbCommand, "@FirstName", DbType.String, objLoginUserObjects.FirstName);
            db.AddInParameter(dbCommand, "@LastName", DbType.String, objLoginUserObjects.LastName);
            db.AddInParameter(dbCommand, "@Sex", DbType.String, objLoginUserObjects.Sex);
            db.AddInParameter(dbCommand, "@State", DbType.String, objLoginUserObjects.State);
            db.AddInParameter(dbCommand, "@City", DbType.String, objLoginUserObjects.City);
            db.AddInParameter(dbCommand, "@Email", DbType.String, objLoginUserObjects.Email);
            db.AddInParameter(dbCommand, "@UserName", DbType.String, objLoginUserObjects.UserName);
            db.AddInParameter(dbCommand, "@Password", DbType.String, objLoginUserObjects.Password);
            db.AddInParameter(dbCommand, "@ConfirmPassword", DbType.String, objLoginUserObjects.ConfirmPassword);
            db.AddInParameter(dbCommand, "@IsHiddenUser", DbType.Boolean, objLoginUserObjects.IsHiddenUser);
            db.AddInParameter(dbCommand, "@RoleId", DbType.String, objLoginUserObjects.RoleId);
            db.AddInParameter(dbCommand, "@BranchName", DbType.String, objLoginUserObjects.BranchName);
            
        }

        public string Insert(UserObjects objUserObjects)
        {            
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Create_User");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillInsertParams(ref objDataBase, dbCommand, objUserObjects);

            object result = objDataBase.ExecuteScalar(dbCommand);
            return result.ToString();            
        }

        public UserObjects LoginUser(string Username, string Password,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Login_User");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, Username);
            objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, Password);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            UserObjects userObjects = null;
            if (ds != null && ds.Tables[0].Rows.Count > default(int))
            {
                userObjects = new UserObjects();
                userObjects.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"]);
                userObjects.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                userObjects.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                userObjects.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                userObjects.IsHiddenUser = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHiddenUser"]);
                userObjects.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                userObjects.BranchName = ds.Tables[0].Rows[0]["BranchName"].ToString();
                
            }
            return userObjects;
        }
    }
}
