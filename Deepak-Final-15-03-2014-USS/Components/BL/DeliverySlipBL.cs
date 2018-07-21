using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class DeliverySlipBL
    {
        #region Variables
        int affectedrows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        //Components.DAL.SQLConnect SqlHelper = Components.DAL.SQLConnect.Instance;
        private static DeliverySlipBL _Instance;
        DataTable dtDelivery = new DataTable();
        int Delivery = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static DeliverySlipBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DeliverySlipBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region LRNo View
        public DataSet LRNo_View(Components.DTO.DeliverySlipDTO DSDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String,DSDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet dt = objDataBase.ExecuteDataSet(dbCommand);
            return dt;
        }
        #endregion

        #region DeliverySlip_Check_LRNO
        public DataTable DeliverySlip_Check_LRNO(Components.DTO.DeliverySlipDTO DSDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Check_LRNO");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String, DSDTO.LRNo);
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

        #region LoadCust
        public DataTable LoadCust(DateTime _FromDate, DateTime _ToDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Cust_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, _FromDate);
            objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, _ToDate);
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

        #region LoadGrid
        public DataTable LoadGrid(DateTime _FromDate, DateTime _ToDate, string _CName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Grid_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, _FromDate);
            objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, _ToDate);
            objDataBase.AddInParameter(dbCommand, "@CustID", DbType.String, _CName);
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

        #region LoadDetails
        public DataTable LoadDetails(int _MRN, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Details_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRN", DbType.Int32, _MRN);      
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

        #region DeliverySlipSave
        public int DeliverySlipSave(Components.DTO.DeliverySlipDTO DSDTO, int hID,int EmpId, string Branch, string UserID)
        {
            try
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_I");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String, DSDTO.LRNo);
                objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, DSDTO.MRNo);
                objDataBase.AddInParameter(dbCommand, "@Packing", DbType.String, DSDTO.Packing);
                objDataBase.AddInParameter(dbCommand, "@PrivateMarks", DbType.String, DSDTO.PrivateMar);
                objDataBase.AddInParameter(dbCommand, "@EmpId", DbType.Int32,EmpId);
                objDataBase.AddInParameter(dbCommand, "@hid", DbType.Int32, hID);
                objDataBase.AddInParameter(dbCommand, "@DeliveryDate", DbType.DateTime, DSDTO.Date);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, DSDTO.CustomerName);
                objDataBase.AddInParameter(dbCommand, "@OriCustName", DbType.String, DSDTO.OriCustName);
                objDataBase.AddInParameter(dbCommand, "@ActWeight", DbType.Decimal, DSDTO.ActWeight);
                objDataBase.AddInParameter(dbCommand, "@Freight", DbType.Decimal, DSDTO.Freight);
                objDataBase.AddInParameter(dbCommand, "@Labour", DbType.Decimal, DSDTO.Labour);
                objDataBase.AddInParameter(dbCommand, "@DeliveryCh", DbType.Decimal, DSDTO.DeliveryCh);
                objDataBase.AddInParameter(dbCommand, "@StationaryCh", DbType.Decimal, DSDTO.StationaryCh);
                objDataBase.AddInParameter(dbCommand, "@Demurrage", DbType.Decimal, DSDTO.Demurrage);
                objDataBase.AddInParameter(dbCommand, "@LocalCartage", DbType.Decimal, DSDTO.LocalCartage);
                objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, DSDTO.ServiceTax);
                //objDataBase.AddInParameter(dbCommand, "@Fixed", DbType.String, Fix);
                //objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, DSDTO.TotalBalance);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                affectedrows = objDataBase.ExecuteNonQuery(dbCommand);
                return affectedrows;
            }

            catch
            {
                return 0;
            }
            
        }
        #endregion

        #region DeliverySlipUpdate
        public int DeliverySlip_Update(Components.DTO.DeliverySlipDTO DSDTO, int DSID,string CollectedBy ,string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String, DSDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, DSDTO.MRNo);
            objDataBase.AddInParameter(dbCommand, "@Packing", DbType.String, DSDTO.Packing);
            objDataBase.AddInParameter(dbCommand, "@PrivateMarks", DbType.String, DSDTO.PrivateMar);
            objDataBase.AddInParameter(dbCommand, "@CollectedBy", DbType.String, CollectedBy);
            objDataBase.AddInParameter(dbCommand, "@DeliverySlipID", DbType.Int32, DSID);
            objDataBase.AddInParameter(dbCommand, "@DeliveryDate", DbType.DateTime, DSDTO.Date);
            objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, DSDTO.CustomerName);
            objDataBase.AddInParameter(dbCommand, "@OriCustName", DbType.String, DSDTO.OriCustName);
            objDataBase.AddInParameter(dbCommand, "@ActWeight", DbType.Decimal, DSDTO.ActWeight);
            objDataBase.AddInParameter(dbCommand, "@Freight", DbType.Decimal, DSDTO.Freight);
            objDataBase.AddInParameter(dbCommand, "@Labour", DbType.Decimal, DSDTO.Labour);
            objDataBase.AddInParameter(dbCommand, "@DeliveryCh", DbType.Decimal, DSDTO.DeliveryCh);
            objDataBase.AddInParameter(dbCommand, "@StationaryCh", DbType.Decimal, DSDTO.StationaryCh);
            objDataBase.AddInParameter(dbCommand, "@Demurrage", DbType.Decimal, DSDTO.Demurrage);
            objDataBase.AddInParameter(dbCommand, "@LocalCartage", DbType.Decimal, DSDTO.LocalCartage);
            objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, DSDTO.ServiceTax);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region DeleteLorryDet
        public int DeleteDeliverySlipDet(Components.DTO.DeliverySlipDTO DSDTO, int DSID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DeliverySlipID", DbType.Int32, DSID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
       #endregion

        #region Check_Payment_Done
        public DataTable Check_Payment_Done(Components.DTO.DeliverySlipDTO DSDTO, int DSID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Check_Payment_Done");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DeliverySlipID", DbType.Int32, DSID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region DeliverySlip Cancel
        public int DeliverySlip_Cancel(Components.DTO.DeliverySlipDTO DSDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Cancel");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, DSDTO.MRNo);
            objDataBase.AddInParameter(dbCommand, "@DeliveryDate", DbType.DateTime, DSDTO.Date);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region DeliverySlip CustomerName_Check
        public DataSet CustomerName_Check(Components.DTO.DeliverySlipDTO DSDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Cust_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, DSDTO.CustomerName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region DeliverySlip_Packing_Change
        public DataTable DeliverySlip_Packing_Change(int PackID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Packings_Change");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@PackID", DbType.Int32, PackID);
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

        #region CollectedBy_Check

        public DataTable CollectedBy_Check(string EmpName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_Check_CollectBy");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmpName", DbType.String, EmpName);
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

        #region DeliverySlip_Packing_MRNo_Change
        public DataTable DeliverySlip_Packing_MRNo_Change(string Pack, string CustName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Packings_MRNo_Change");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Pack", DbType.String, Pack);
            objDataBase.AddInParameter(dbCommand, "@CustName", DbType.String, CustName);
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

        #region DeliverySlip_Packing_Fixed
        public DataTable DeliverySlip_Packing_Fixed(string Pack, string CustName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliverySlip_Packings_Fixed");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Pack", DbType.String, Pack);
            objDataBase.AddInParameter(dbCommand, "@CustName", DbType.String, CustName);
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
    }
}
