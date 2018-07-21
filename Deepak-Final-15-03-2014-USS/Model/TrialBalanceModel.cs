using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class TrialBalanceModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");

        public List<TrialBalanceObjects> GetBalanceAmountByAll(DateTime startingDate,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("USP_GetBalanceAmountByAll");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, startingDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return GetLedgerAccountObjects(ds);
        }

        private List<TrialBalanceObjects> GetLedgerAccountObjects(DataSet ds)
        {
            List<TrialBalanceObjects> lstTrialBalanceObjects = new List<TrialBalanceObjects>();
            TrialBalanceObjects objTrialBalanceObjects;
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objTrialBalanceObjects = new TrialBalanceObjects();
                    objTrialBalanceObjects.ID=Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    objTrialBalanceObjects.Particular = ds.Tables[0].Rows[i][1].ToString();
                    if (ds.Tables[0].Rows[i][2].ToString() == "Dr")
                    {
                        objTrialBalanceObjects.Dr = Convert.ToDouble(ds.Tables[0].Rows[i][3]);
                    }
                    else
                    {
                        objTrialBalanceObjects.Cr = Convert.ToDouble(ds.Tables[0].Rows[i][3]);
                    }
                    lstTrialBalanceObjects.Add(objTrialBalanceObjects);
                }
            }
            return lstTrialBalanceObjects;
        }

        public List<TrialBalanceObjects> GetBalanceAmountByDate(DateTime startingDate, DateTime closingDate,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("USP_GetBalanceAmountByDate");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, startingDate);
            objDataBase.AddInParameter(dbCommand, "@closingDate", DbType.DateTime, closingDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return GetLedgerAccountObjects(ds);
        }
    }
}
