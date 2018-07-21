using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class MonthTrialBalanceModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase();

        public List<MonthlyTrialBalanceObjects> GetBalanceAmountByAll(DateTime startingDate)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("USP_GetBalanceAmountByAll");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, startingDate);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return GetLedgerAccountObjects(ds);
        }

        private List<MonthlyTrialBalanceObjects> GetLedgerAccountObjects(DataSet ds)
        {
            List<MonthlyTrialBalanceObjects> lstTrialBalanceObjects = new List<MonthlyTrialBalanceObjects>();
            MonthlyTrialBalanceObjects objTrialBalanceObjects;
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objTrialBalanceObjects = new MonthlyTrialBalanceObjects();
                    objTrialBalanceObjects.ID = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
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

        //public List<MonthlyTrialBalanceObjects> GetBalanceAmountByDate(DateTime MonDate)
        //{
        //    DbCommand dbCommand = objDataBase.GetSqlStringCommand("USP_GetBalanceAmountByDate");
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    objDataBase.AddInParameter(dbCommand, "@closingDate", DbType.DateTime, MonDate);
        //    DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
        //    return GetLedgerAccountObjects(ds);
        //}
    }
}
