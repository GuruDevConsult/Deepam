using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class CompanyModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");
        
        #region Latest
        public List<CompanyObjects> GetCompanies()
        {
            CompanyObjects Obj = new CompanyObjects();
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_Select");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Obj.BranchName);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            List<CompanyObjects> lstCompanyModel = new List<CompanyObjects>();

            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                CompanyObjects objCompanyObj = new CompanyObjects();
                objCompanyObj.Id = Convert.ToInt32(ds.Tables[0].Rows[row]["COMPANYID"]);
                objCompanyObj.Name = ds.Tables[0].Rows[row]["COMPANYNAME"].ToString();

                lstCompanyModel.Add(objCompanyObj);
            }

            return lstCompanyModel;
        }

        public int InsertUserCompany(int UserId, int CompanyId)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_User");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserId);
            objDataBase.AddInParameter(dbCommand, "@CompanyID", DbType.Int32, CompanyId);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion Latest

        public List<CompanyObjects> SelectAll(string startDate,string endDate)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_SelectByDate");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StartDate", DbType.String, startDate);
            objDataBase.AddInParameter(dbCommand, "@EndDate", DbType.String, endDate);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignCompanyValues(ds);
        }

        public List<CompanyObjects> AssignCompanyValues(DataSet dsAccounts)
        {
            List<CompanyObjects> lstCompanyObjects = new List<CompanyObjects>();

            for (int row = 0; row < dsAccounts.Tables[0].Rows.Count; row++)
            {
                CompanyObjects objCompanyObjects = new CompanyObjects();                
                objCompanyObjects.Id = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["Id"]);
                objCompanyObjects.CreatedAt = Convert.ToString(dsAccounts.Tables[0].Rows[row]["CreatedAt"]);
                objCompanyObjects.CreatedBy = Convert.ToString(dsAccounts.Tables[0].Rows[row]["CreatedBy"]);
                objCompanyObjects.ModifyAt = Convert.ToString(dsAccounts.Tables[0].Rows[row]["ModifyAt"]);
                objCompanyObjects.ModifyBy = Convert.ToString(dsAccounts.Tables[0].Rows[row]["ModifyBy"]);
                objCompanyObjects.Name = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Name"]);
                objCompanyObjects.Status = Convert.ToBoolean(dsAccounts.Tables[0].Rows[row]["Status"]);
                //objCompanyObjects.State = Convert.ToString(dsAccounts.Tables[0].Rows[row]["State"]);
                objCompanyObjects.Address = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Address"]);
                objCompanyObjects.Pincode = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["Pincode"]);
                objCompanyObjects.MailingName = Convert.ToString(dsAccounts.Tables[0].Rows[row]["MailingName"]);
                objCompanyObjects.Telephone = Convert.ToString(dsAccounts.Tables[0].Rows[row]["TelephoneNo"]);
                objCompanyObjects.Email = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Email"]);
                objCompanyObjects.Maintain = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Maintain"]);
                objCompanyObjects.FinancialStart = Convert.ToString(dsAccounts.Tables[0].Rows[row]["FinancialStart"]);
                objCompanyObjects.BooksStart = Convert.ToString(dsAccounts.Tables[0].Rows[row]["BooksStart"]);
                lstCompanyObjects.Add(objCompanyObjects);
            }

            return lstCompanyObjects;
        }
        public List<CompanyObjects> SelectBy(int Id)
        {            
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_SelectBy");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CompanyId", DbType.String, Id);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignCompanyValues(ds);
        }

        public string Insert(CompanyObjects objCompanyObjects)
        {            
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_Insert");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillInsertParams(ref objDataBase, dbCommand, objCompanyObjects);
            objDataBase.AddInParameter(dbCommand, "@CreatedAt", DbType.DateTime, DateTime.Now);
            objDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objCompanyObjects.CreatedBy);            
            object result = objDataBase.ExecuteScalar(dbCommand);
            return result.ToString();            
        }

        private void FillInsertParams(ref Database db, DbCommand dbCommand, CompanyObjects objCompanyObjects)
        {
            //db.AddInParameter(dbCommand, "@ModifyAt", DbType.String, objCompanyObjects.ModifyAt);
            //db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objCompanyObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@Name", DbType.String, objCompanyObjects.Name);
            db.AddInParameter(dbCommand, "@MailingName", DbType.String, objCompanyObjects.MailingName);
            db.AddInParameter(dbCommand, "@Address", DbType.String, objCompanyObjects.Address);
            db.AddInParameter(dbCommand, "@PinCode", DbType.Int32, objCompanyObjects.Pincode);
            db.AddInParameter(dbCommand, "@Telephno", DbType.String, objCompanyObjects.Telephone);
            db.AddInParameter(dbCommand, "@Email", DbType.String, objCompanyObjects.Email);
            db.AddInParameter(dbCommand, "@Maintain", DbType.String, objCompanyObjects.Maintain);
            db.AddInParameter(dbCommand, "@FinancialStart", DbType.String, objCompanyObjects.FinancialStart);
            db.AddInParameter(dbCommand, "@BooksStart", DbType.String, objCompanyObjects.BooksStart);
            db.AddInParameter(dbCommand, "@StateId", DbType.String, objCompanyObjects.objState.Id);
        }

        private void FillUpdateParams(ref Database db, DbCommand dbCommand, CompanyObjects objCompanyObjects)
        {
            db.AddInParameter(dbCommand, "@Companyid", DbType.Int32, objCompanyObjects.Id);            
            db.AddInParameter(dbCommand, "@ModifyAt", DbType.String, objCompanyObjects.ModifyAt);
            db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objCompanyObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@Name", DbType.String, objCompanyObjects.Name);
            db.AddInParameter(dbCommand, "@MailingName", DbType.String, objCompanyObjects.MailingName);
            db.AddInParameter(dbCommand, "@Address", DbType.String, objCompanyObjects.Address);
            db.AddInParameter(dbCommand, "@PinCode", DbType.Int32, objCompanyObjects.Pincode);
            db.AddInParameter(dbCommand, "@Telephno", DbType.String, objCompanyObjects.Telephone);
            db.AddInParameter(dbCommand, "@Email", DbType.String, objCompanyObjects.Email);
            db.AddInParameter(dbCommand, "@Maintain", DbType.String, objCompanyObjects.Maintain);
            db.AddInParameter(dbCommand, "@FinancialStart", DbType.String, objCompanyObjects.FinancialStart);
            db.AddInParameter(dbCommand, "@BooksStart", DbType.String, objCompanyObjects.BooksStart);
            //db.AddInParameter(dbCommand, "@State", DbType.String, objCompanyObjects.State);
        }

        public int Update(CompanyObjects objCompanyObjects)
        {            
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_Update");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillUpdateParams(ref objDataBase, dbCommand, objCompanyObjects);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        public int Delete(int Id,string Name)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Company_Delete");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, Id);
            objDataBase.AddInParameter(dbCommand, "@ModifyBy", DbType.String, Name);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        
    }
}
