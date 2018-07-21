using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class BalanceSheetModel
    {
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");

        private List<BalanceSheetObjects> GetBalanceSheetObjects(DataSet ds)
        {
            List<BalanceSheetObjects> lstBalanceSheetObjects = new List<BalanceSheetObjects>();
            BalanceSheetObjects objBalanceSheetObjects;
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objBalanceSheetObjects = new BalanceSheetObjects();
                    objBalanceSheetObjects.ID = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    objBalanceSheetObjects.Particular = ds.Tables[0].Rows[i][1].ToString();
                    if (ds.Tables[0].Rows[i][2].ToString() == "Dr")
                    {
                        objBalanceSheetObjects.Dr = Convert.ToDouble(ds.Tables[0].Rows[i][3]);
                    }
                    else
                    {
                        objBalanceSheetObjects.Cr = Convert.ToDouble(ds.Tables[0].Rows[i][3]);
                    }
                    lstBalanceSheetObjects.Add(objBalanceSheetObjects);
                }
            }
            return lstBalanceSheetObjects;
        }

        public List<BalanceSheetObjects> GetBalanceSheetByDate(DateTime startingDate, DateTime closingDate,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("USP_GetBalanceSheetByDate");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@startingDate", DbType.DateTime, startingDate);
            objDataBase.AddInParameter(dbCommand, "@closingDate", DbType.DateTime, closingDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return GetBalanceSheetObjects(ds);
        }
    }
}
