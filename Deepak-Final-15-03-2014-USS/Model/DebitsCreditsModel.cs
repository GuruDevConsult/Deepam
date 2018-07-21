using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class DebitsCreditsModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");
        DebitsCreditsObjects objDebitsCreditsObjects;


        public List<DebitsCreditsObjects> SelectBy(DateTime startDate, DateTime endDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_GetDebitsCredits");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StartDate", DbType.DateTime, startDate);
            objDataBase.AddInParameter(dbCommand, "@EndDate", DbType.DateTime, endDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return AssignDCValues(ds);
        }

        //LedgerAccountObjects LAO
        public List<DebitsCreditsObjects> GetEntries(long accountId, DateTime startingDate, DateTime closingDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_GetEneries");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AccountId", DbType.Int64, accountId);
            objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, startingDate);
            objDataBase.AddInParameter(dbCommand, "@closingDate", DbType.DateTime, closingDate);
            //objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, DateTime.ParseExact(LAO.Date, "dd/MM/yyyy", null));
            //objDataBase.AddInParameter(dbCommand, "@closingDate", DbType.DateTime, DateTime.ParseExact(LAO.CloseDate, "dd/MM/yyyy", null));
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return AssignEneriesValues(ds);
        }
        //LedgerAccountObjects LAO
        public DataSet GetBalanceAmount(long accId, DateTime startingDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("USP_GetBalanceAmount");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AccountId", DbType.Int64, accId);
            objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, startingDate);
            //objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, DateTime.ParseExact(LAO.Date,"dd/MM/yyyy",null));
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }

        public List<DebitsCreditsObjects> AssignEneriesValues(DataSet dsDC)
        {
            List<DebitsCreditsObjects> lstDCObjects = new List<DebitsCreditsObjects>();
            DateTime outDateTime;
            double outDouble;
            double outDouble1;
            double outDouble2;
            Components.Common.GlobalFunction GlbFunc = Components.Common.GlobalFunction.Instance;

            for (int row = 0; row < dsDC.Tables[0].Rows.Count; row++)
            {
                DebitsCreditsObjects objDCObjects = new DebitsCreditsObjects();
                DateTime.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Date"]), out outDateTime);
                objDCObjects.Date = string.Format(outDateTime.ToShortDateString(), "dd/MM/yyyy");
                //objDCObjects.Particular = Convert.ToString(dsDC.Tables[0].Rows[row]["RelationAccount"]);
                objDCObjects.Particular = Convert.ToString(dsDC.Tables[0].Rows[row]["Particular"]);
                objDCObjects.Type = Convert.ToString(dsDC.Tables[0].Rows[row]["Type"]);
                double.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Amount"]), out outDouble);
                DateTime.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Date1"]), out outDateTime);
                objDCObjects.Date1 = string.Format(outDateTime.ToShortDateString(), "dd/MM/yyyy");
                //objDCObjects.Particular = Convert.ToString(dsDC.Tables[0].Rows[row]["RelationAccount"]);
                objDCObjects.Particular1 = Convert.ToString(dsDC.Tables[0].Rows[row]["Particular1"]);
                objDCObjects.Type1 = Convert.ToString(dsDC.Tables[0].Rows[row]["Type1"]);
                double.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Amount1"]), out outDouble1);
                double.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["ShortAmount"]), out outDouble2);        
                objDCObjects.Amount = outDouble;
                objDCObjects.Amount1 = outDouble1;
                objDCObjects.ShortAmount = outDouble2;
                lstDCObjects.Add(objDCObjects);
            }
            return lstDCObjects;
        }

        public List<DebitsCreditsObjects> AssignDCValues(DataSet dsDC)
        {
            List<DebitsCreditsObjects> lstDCObjects = new List<DebitsCreditsObjects>();
            int outInt;
            long outLong;
            double outDouble;
            bool outBool;
            DateTime outDateTime;
            for (int row = 0; row < dsDC.Tables[0].Rows.Count; row++)
            {
                outInt = 0;
                outLong = 0;
                outDouble = 0;
                outBool = false;

                DebitsCreditsObjects objDCObjects = new DebitsCreditsObjects();
                objDCObjects.Account = new Identifier();
                Int32.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Accountid"]), out outInt);
                objDCObjects.Account.Id = outInt;
                objDCObjects.Account.Name = Convert.ToString(dsDC.Tables[0].Rows[row]["AccountName"]);
                double.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Amount"]), out outDouble);
                objDCObjects.Amount = outDouble;
                objDCObjects.CreatedAt = Convert.ToString(dsDC.Tables[0].Rows[row]["CreatedAt"]);
                objDCObjects.CreatedBy = Convert.ToString(dsDC.Tables[0].Rows[row]["CreatedBy"]);
                DateTime.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["Date"]), out outDateTime);
                objDCObjects.Date = outDateTime.ToShortDateString();
                long.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["EntryItemCount"]), out outLong);
                objDCObjects.EntryItemCount = outLong;
                int.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["id"]), out outInt);
                objDCObjects.Id = outInt;
                bool.TryParse(Convert.ToString(dsDC.Tables[0].Rows[row]["IsHiddenUser"]), out outBool);
                objDCObjects.IsHiddenUser = outBool;
                objDCObjects.Particular = Convert.ToString(dsDC.Tables[0].Rows[row]["Particular"]);
                objDCObjects.RelationAccount = Convert.ToString(dsDC.Tables[0].Rows[row]["RelationAccount"]);
                objDCObjects.Type = Convert.ToString(dsDC.Tables[0].Rows[row]["Type"]);
                lstDCObjects.Add(objDCObjects);
            }
            return lstDCObjects;
        }

        public string Insert(DebitsCreditsObjects objDCObjects)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_DebitsCredits_Insert");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillInsertParams(ref objDataBase, dbCommand, objDCObjects);
            objDataBase.AddInParameter(dbCommand, "@CreatedAt", DbType.DateTime, DateTime.Now);
            objDataBase.AddInParameter(dbCommand, "@CreatedBy", DbType.String, objDCObjects.CreatedBy);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, objDCObjects.BranchName);

            object result = objDataBase.ExecuteScalar(dbCommand);
            return result.ToString();
        }

        private void FillInsertParams(ref Database db, DbCommand dbCommand, DebitsCreditsObjects objDCObjects)
        {
            if (objDCObjects.Account != null)
            {
                db.AddInParameter(dbCommand, "@AccountsId", DbType.Int32, objDCObjects.Account.Id);
            }
            db.AddInParameter(dbCommand, "@Date", DbType.DateTime, Convert.ToDateTime(objDCObjects.Date));
            db.AddInParameter(dbCommand, "@Amount", DbType.String, objDCObjects.Amount);
            //db.AddInParameter(dbCommand, "@ModifyAt", DbType.String, objDCObjects.ModifyAt);
            //db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objDCObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@Type", DbType.String, objDCObjects.Type);
            db.AddInParameter(dbCommand, "@Status", DbType.String, objDCObjects.Status);
            db.AddInParameter(dbCommand, "@Particular", DbType.String, objDCObjects.Particular);
            db.AddInParameter(dbCommand, "@RelationAccount", DbType.String, objDCObjects.RelationAccount);
            db.AddInParameter(dbCommand, "@EntryItemCount", DbType.String, objDCObjects.EntryItemCount);
            db.AddInParameter(dbCommand, "@BranchName", DbType.String, objDCObjects.BranchName);
        }

        private void FillUpdateParams(ref Database db, DbCommand dbCommand, DebitsCreditsObjects objDCObjects)
        {
            db.AddInParameter(dbCommand, "@Id", DbType.Int32, objDCObjects.Id);
            db.AddInParameter(dbCommand, "@Date", DbType.DateTime, Convert.ToDateTime(objDCObjects.Date));
            db.AddInParameter(dbCommand, "@AccountId", DbType.Int32, objDCObjects.Account.Id);
            db.AddInParameter(dbCommand, "@Particular", DbType.String, objDCObjects.Particular);
            db.AddInParameter(dbCommand, "@Type", DbType.String, objDCObjects.Type);
            db.AddInParameter(dbCommand, "@Amount", DbType.Decimal, objDCObjects.Amount);
            db.AddInParameter(dbCommand, "@ModifyBy", DbType.String, objDCObjects.ModifyBy);
            db.AddInParameter(dbCommand, "@BranchName", DbType.String, objDCObjects.BranchName);

        }

        public string Update(DebitsCreditsObjects objDCObjects)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_DebitsCredits_Update");
            dbCommand.CommandType = CommandType.StoredProcedure;
            FillUpdateParams(ref objDataBase, dbCommand, objDCObjects);
            object result = objDataBase.ExecuteScalar(dbCommand);
            return result.ToString();
        }

        public int Delete(int Id)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_DebitsCredits_Delete");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DCId", DbType.Int32, Id);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        public long GetItemCountForCompany(long accID,string Branch)
        {
            long lnResult = 0;
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_GetItemCount");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Accountid", DbType.Int64, accID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            object result = objDataBase.ExecuteScalar(dbCommand);
            long.TryParse(result.ToString(), out lnResult);
            return lnResult;
        }
    }
}
