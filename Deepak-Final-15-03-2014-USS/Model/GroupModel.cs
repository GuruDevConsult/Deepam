using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class GroupModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");
        GroupObjects objGroupObjects = default(GroupObjects);

        public List<GroupObjects> SelectAll()
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_SelectAll");
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignGroupValues(ds);
        }

        public List<GroupObjects> BindGroupNames()
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_Bind");
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignGroup(ds);
        }

        public List<GroupObjects> AssignGroup(DataSet dsAccounts)
        {
            List<GroupObjects> lstDCObjects = new List<GroupObjects>();

            for (int row = 0; row < dsAccounts.Tables[0].Rows.Count; row++)
            {
                GroupObjects objDCObjects = new GroupObjects();
                objDCObjects.Id = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["Id"]);
                objDCObjects.Name = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Name"]);

                lstDCObjects.Add(objDCObjects);
            }

            return lstDCObjects;
        }

        public List<GroupObjects> AssignGroupValues(DataSet dsAccounts)
        {
            List<GroupObjects> lstDCObjects = new List<GroupObjects>();

            for (int row = 0; row < dsAccounts.Tables[0].Rows.Count; row++)
            {
                GroupObjects objDCObjects = new GroupObjects();
                objDCObjects.Id = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["Id"]);
                objDCObjects.CreatedAt = Convert.ToString(dsAccounts.Tables[0].Rows[row]["CreatedAt"]);
                objDCObjects.CreatedBy = Convert.ToString(dsAccounts.Tables[0].Rows[row]["CreatedBy"]);
                objDCObjects.ModifyAt = Convert.ToString(dsAccounts.Tables[0].Rows[row]["ModifyAt"]);
                objDCObjects.ModifyBy = Convert.ToString(dsAccounts.Tables[0].Rows[row]["ModifyBy"]);
                objDCObjects.Name = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Name"]);
                objDCObjects.Status = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Status"]);

                lstDCObjects.Add(objDCObjects);
            }

            return lstDCObjects;
        }
        public List<GroupObjects> SelectBy(int Id)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_SelectBy");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@GroupId", DbType.String, Id);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignGroupValues(ds);
        }

        public bool Insert(GroupObjects objGroupObjects)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_Insert");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillInsertParams(ref objDataBase, dbCommand, objGroupObjects);

            if (objDataBase.ExecuteNonQuery(dbCommand) > 0)
                return true;
            else
                return false;
        }

        private void FillInsertParams(ref Database db, DbCommand dbCommand, GroupObjects objGroupObjects)
        {
            db.AddInParameter(dbCommand, "@CreatedAt", DbType.String, objGroupObjects.CreatedAt);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objGroupObjects.CreatedBy);
            db.AddInParameter(dbCommand, "@ModifyAt", DbType.String, objGroupObjects.ModifyAt);
            db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objGroupObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@Name", DbType.String, objGroupObjects.Name);
            db.AddInParameter(dbCommand, "@Status", DbType.String, objGroupObjects.Status);
        }

        public List<GroupObjects> SelectByName(string Name)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_SelectByName");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@GroupName", DbType.String,Name);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignGroupValues(ds);
        }

        private void FillUpdateParams(ref Database db, DbCommand dbCommand, GroupObjects objGroupObjects)
        {
            db.AddInParameter(dbCommand, "@Groupid", DbType.Int32, objGroupObjects.Id);
            db.AddInParameter(dbCommand, "@CreatedAt", DbType.String, objGroupObjects.CreatedAt);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objGroupObjects.CreatedBy);
            db.AddInParameter(dbCommand, "@ModifyAt", DbType.String, objGroupObjects.ModifyAt);
            db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objGroupObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@Name", DbType.String, objGroupObjects.Name);
            db.AddInParameter(dbCommand, "@Status", DbType.String, objGroupObjects.Status);
        }

        public int Update(GroupObjects objGroupObjects)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_Update");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillUpdateParams(ref objDataBase, dbCommand, objGroupObjects);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        public int Delete(int Id)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Group_Delete");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@GroupId", DbType.Int32, Id);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
    }
}
