using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class LorryAcSlipBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static LorryAcSlipBL _Instance;
        int LorryPack = 0;
        DataTable dtLorry = new DataTable();
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static LorryAcSlipBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LorryAcSlipBL();
                }
                return _Instance;
            }
        }

        #endregion

        #region LorryAcSlip_Agent View
        public DataTable LorryAcSlip_Agent_View(string Agent, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_Agent_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Agent", DbType.String, Agent);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region LorryNo
        public DataTable LorryNo(Components.DTO.LorryAcSlipDTO LSDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_LorryNo");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LorryDate", DbType.DateTime, LSDTO.LorryDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region LorryNo
        public DataSet LorryAcSlip_ToPay(Components.DTO.LorryAcSlipDTO LSDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_ToPay");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LorryDate", DbType.DateTime, LSDTO.LorryToPayDate);
            objDataBase.AddInParameter(dbCommand, "@TrukNo", DbType.String, LSDTO.LorryNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region LorryAcSlipSave
        public int LorryAcSlipSave(Components.DTO.LorryAcSlipDTO LSDTO, DataTable dtLSItem, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_I");
            dbCommand.CommandType = CommandType.StoredProcedure;

            objDataBase.AddInParameter(dbCommand, "@LSlip", DbType.String, LSDTO.LSlipNo);
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, LSDTO.Date);
            objDataBase.AddInParameter(dbCommand, "@LorryDate", DbType.DateTime, LSDTO.LorryDate);
            objDataBase.AddInParameter(dbCommand, "@LorryNo", DbType.String, LSDTO.LorryNo);
            objDataBase.AddInParameter(dbCommand, "@StartFrom", DbType.String, LSDTO.StartFrom);
            objDataBase.AddInParameter(dbCommand, "@DestTo", DbType.String, LSDTO.DestTo);
            objDataBase.AddInParameter(dbCommand, "@LorryHire", DbType.Decimal, LSDTO.LorryHire);
            objDataBase.AddInParameter(dbCommand, "@Advance", DbType.Decimal, LSDTO.Advance);
            objDataBase.AddInParameter(dbCommand, "@LorryToPay", DbType.Decimal, LSDTO.LorryToPay);
            objDataBase.AddInParameter(dbCommand, "@LorryToPayBalance", DbType.Decimal, LSDTO.LorryToPayBalance);
            objDataBase.AddInParameter(dbCommand, "@Balance", DbType.Decimal, LSDTO.Balance);
            objDataBase.AddInParameter(dbCommand, "@FreightPayable", DbType.String, LSDTO.FreightPayable);
            objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, LSDTO.AgentID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int LorrySlipID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            if (LorrySlipID > 0)
            {
                foreach (DataRow dr in dtLSItem.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlipPackages_I");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@LorrySlipID", DbType.Int32, LorrySlipID);
                    objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.String, dr["ChallanNo"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Destination", DbType.String, dr["Destination"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Packages", DbType.Int32, dr["Packages"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Collection", DbType.Decimal, dr["Collections"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }

            return 0;
        }

        #endregion

        #region LorrySlipUpdate
        public int LorrySlipUpdate(Components.DTO.LorryAcSlipDTO LSDTO, DataTable dtLSItem, int SlipID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, LSDTO.Date);
            objDataBase.AddInParameter(dbCommand, "@LorryDate", DbType.DateTime, LSDTO.LorryDate);
            objDataBase.AddInParameter(dbCommand, "@LorryNo", DbType.String, LSDTO.LorryNo);
            objDataBase.AddInParameter(dbCommand, "@StartFrom", DbType.String, LSDTO.StartFrom);
            objDataBase.AddInParameter(dbCommand, "@DestTo", DbType.String, LSDTO.DestTo);
            objDataBase.AddInParameter(dbCommand, "@LorryToPay", DbType.Decimal, LSDTO.LorryToPay);
            objDataBase.AddInParameter(dbCommand, "@LorryToPayBalance", DbType.Decimal, LSDTO.LorryToPayBalance);
            objDataBase.AddInParameter(dbCommand, "@LorryHire", DbType.Decimal, LSDTO.LorryHire);
            objDataBase.AddInParameter(dbCommand, "@Advance", DbType.Decimal, LSDTO.Advance);
            objDataBase.AddInParameter(dbCommand, "@Balance", DbType.Decimal, LSDTO.Balance);
            objDataBase.AddInParameter(dbCommand, "@FreightPayable", DbType.String, LSDTO.FreightPayable);
            objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, LSDTO.AgentID);
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, SlipID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            if (affectedRows > 0)
            {
                foreach (DataRow dr in dtLSItem.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlipPackages_U");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@LorryAcID", DbType.Int32, SlipID);
                    objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, dr["ChallanNo"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Destination", DbType.String, dr["Destination"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Packages", DbType.Int32, dr["Packages"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Collection", DbType.String, dr["Collections"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@LorryAcSlipID", DbType.Int32, dr["LorryAcSlipID"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }
            return 0;
        }
        #endregion

        #region LorryAcSlip View
        public DataSet LoadData(Components.DTO.LorryAcSlipDTO LSDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LSlip", DbType.String, LSDTO.LSlipNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region DeleteLorryDet
        public int DeleteLorryDet(Components.DTO.LorryAcSlipDTO LSDTO, DataTable dtLorryD, int LorryAcSlipID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryAcSlip_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, LorryAcSlipID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion
    }
}
