using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class AccountsModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");
        AccountsObjects objAccountsObjects;
        
        public List<AccountsObjects> SelectAll(string Branch)
        {
            UserObjects Obj=new UserObjects();
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Accounts_SelectAll");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return AssignAccountValues(ds);            
        }

        public List<AccountsObjects> Ledger_Name_Load(string Branch)
        {
            UserObjects Obj = new UserObjects();
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LedgerAcc_Name_Load");
            dbCommand.CommandType = CommandType.StoredProcedure;
            //objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.String, FromDate);
            //objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.String, Todate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return LoadAccountName(ds);
        }

        public List<AccountsObjects> LoadAccountName(DataSet dsAccounts)
        {
            List<AccountsObjects> lstAccountObjects = new List<AccountsObjects>();

            for (int row = 0; row < dsAccounts.Tables[0].Rows.Count; row++)
            {
                AccountsObjects objAccountObjects = new AccountsObjects();
                objAccountObjects.Id = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["ID"]);
                objAccountObjects.Name = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Name"]);
                lstAccountObjects.Add(objAccountObjects);
            }
            return lstAccountObjects;
        }


        public List<AccountsObjects> SelectByCompanyId(int id)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Accounts_SelectByCompanyId");
            objDataBase.AddInParameter(dbCommand, "@Companyid", DbType.Int32, id);
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignAccountValues(ds);
        }

        public List<AccountsObjects> AssignAccountValues(DataSet dsAccounts)
        {
            List<AccountsObjects> lstAccountObjects = new List<AccountsObjects>();

            for (int row = 0; row < dsAccounts.Tables[0].Rows.Count; row++)
            {
                AccountsObjects objAccountObjects = new AccountsObjects();
                objAccountObjects.Id = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["Id"]);
                
                objAccountObjects.Group = new Identifier();
                objAccountObjects.Group.Id = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["GroupId"]);
                objAccountObjects.Name = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Name"]);
                objAccountObjects.Address = Convert.ToString(dsAccounts.Tables[0].Rows[row]["Address"]);
                objAccountObjects.Pincode = Convert.ToInt32(dsAccounts.Tables[0].Rows[row]["Pincode"]);
                objAccountObjects.PanItNo = Convert.ToString(dsAccounts.Tables[0].Rows[row]["PanItNo"]);
                objAccountObjects.SalesTaxNo = Convert.ToString(dsAccounts.Tables[0].Rows[row]["SalesTaxNo"]);
                objAccountObjects.Group.Name = Convert.ToString(dsAccounts.Tables[0].Rows[row]["GroupName"]);
                objAccountObjects.City = Convert.ToString(dsAccounts.Tables[0].Rows[row]["City"]);
                lstAccountObjects.Add(objAccountObjects);
            }
            return lstAccountObjects;
        }

        public List<AccountsObjects> SelectByAccountId(int Id)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Accounts_SelectBy");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AccountId", DbType.String, Id);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);

            return AssignAccountValues(ds);            
        }

        public string Insert(AccountsObjects objAccountObjects)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Accounts_Insert");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillInsertParams(ref objDataBase, dbCommand, objAccountObjects);
            objDataBase.AddInParameter(dbCommand, "@CreatedAt", DbType.DateTime, DateTime.Now);
            objDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objAccountObjects.CreatedBy);
            object result = objDataBase.ExecuteScalar(dbCommand);
            return result.ToString();
        }

        private void FillInsertParams(ref Database db, DbCommand dbCommand, AccountsObjects objAccountObjects)
        {
            db.AddInParameter(dbCommand, "@Companyid", DbType.Int32, objAccountObjects.Company.Id);            
            db.AddInParameter(dbCommand, "@Name", DbType.String, objAccountObjects.Name);            
            db.AddInParameter(dbCommand, "@Address", DbType.String, objAccountObjects.Address);
            db.AddInParameter(dbCommand, "@StateId", DbType.Int32, objAccountObjects.State.Id);
            db.AddInParameter(dbCommand, "@Pincode", DbType.Int32, objAccountObjects.Pincode);
            db.AddInParameter(dbCommand, "@PanITNo", DbType.String, objAccountObjects.PanItNo);
            db.AddInParameter(dbCommand, "@SalesTaxNo", DbType.String, objAccountObjects.SalesTaxNo);
            db.AddInParameter(dbCommand, "@GroupId", DbType.Int32, objAccountObjects.Group.Id);
            db.AddInParameter(dbCommand, "@IsHiddenUser", DbType.Boolean, objAccountObjects.IsHiddenUser);
            db.AddInParameter(dbCommand, "@City", DbType.String, objAccountObjects.City);
        }

        private void FillUpdateParams(ref Database db, DbCommand dbCommand, AccountsObjects objAccountObjects)
        {
            db.AddInParameter(dbCommand, "@AccountId", DbType.Int32, objAccountObjects.Id);
            db.AddInParameter(dbCommand, "@Companyid", DbType.Int32, objAccountObjects.Company.Id);
            db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objAccountObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@Name", DbType.String, objAccountObjects.Name);
            db.AddInParameter(dbCommand, "@Address", DbType.String, objAccountObjects.Address);
            db.AddInParameter(dbCommand, "@StateiD", DbType.Int32, objAccountObjects.State.Id);
            db.AddInParameter(dbCommand, "@Pincode", DbType.Int32, objAccountObjects.Pincode);
            db.AddInParameter(dbCommand, "@PanItNo", DbType.String, objAccountObjects.PanItNo);
            db.AddInParameter(dbCommand, "@SalesTaxNo", DbType.String, objAccountObjects.SalesTaxNo);
            db.AddInParameter(dbCommand, "@GroupId", DbType.Int32, objAccountObjects.Group.Id);
        }

        public bool Update(AccountsObjects objAccountsObjects)
        {
            bool result = false;
            try
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Accounts_Update");
                dbCommand.CommandType = CommandType.StoredProcedure;
                FillUpdateParams(ref objDataBase, dbCommand, objAccountsObjects);
                int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public int Delete(int Id,string modifyBy,bool status)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_Accounts_Delete");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AccountId", DbType.Int32, Id);
            objDataBase.AddInParameter(dbCommand, "@ModifyBy", DbType.String, modifyBy);
            objDataBase.AddInParameter(dbCommand, "@Status", DbType.Boolean, status);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        public DataSet SelectAccountByCompany(int CompanyId, bool IsHiddenUser)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Sp_Account_Company");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            objDataBase.AddInParameter(dbCommand, "@IsHiddenUser", DbType.Boolean, IsHiddenUser);
            return objDataBase.ExecuteDataSet(dbCommand);
        }

        public List<FinancialYears> GetFinancialYears()
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Usp_GetFinancialYears");
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            List<FinancialYears> lstFinancialYears = new List<FinancialYears>();

            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                FinancialYears financialYears = new FinancialYears();
                financialYears.ID = Convert.ToInt32(ds.Tables[0].Rows[row]["ID"]);
                financialYears.years = Convert.ToString(ds.Tables[0].Rows[row]["years"]);
                lstFinancialYears.Add(financialYears);
            }
            return lstFinancialYears;
        }
    }
}
