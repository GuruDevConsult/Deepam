using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BusinessObjects;
using System.Data.Common;
using System.Data;

namespace Model
{
    public class StateModel
    {
        //public Database objDataBase = DatabaseFactory.CreateDatabase();
        public Database objDataBase = DatabaseFactory.CreateDatabase("USS");
        public DataSet SelectAll()
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("SP_State_SelectAll");
            dbCommand.CommandType = CommandType.StoredProcedure;
            return objDataBase.ExecuteDataSet(dbCommand);
        }
    }
}
