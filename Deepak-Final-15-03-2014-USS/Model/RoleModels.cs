using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Model
{
    public class RoleModels
    {
        private string connectString = string.Empty;
        //public Database objDataBase = DatabaseFactory.CreateDatabase();
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");

        

        public List<RoleObjects> GetRoles()
        {
            RoleObjects Obj=new RoleObjects();
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Role_Select");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String,Obj.BranchName);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            List<RoleObjects> lstroleobjects = new List<RoleObjects>();
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                RoleObjects objrole = new RoleObjects();
                objrole.RoleId = Convert.ToInt32(ds.Tables[0].Rows[row]["ROLEID"]);
                objrole.RoleName = ds.Tables[0].Rows[row]["ROLENAME"].ToString();
                lstroleobjects.Add(objrole);
            }
            return lstroleobjects;
        }
    }
}
