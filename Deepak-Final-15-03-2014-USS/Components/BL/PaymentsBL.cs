using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{

    public class PaymentsBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static PaymentsBL _Instance;
        private static DataTable _SearchResult;
        int BookItem = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static PaymentsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region Payments_Type

        public DataSet Payments_Type(Components.DTO.PaymentsDTO PDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_GridSelect");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@PartyName", DbType.String, PDTO.PartyName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region View_PartyName
        public DataSet View_PartyName(Components.DTO.PaymentsDTO PDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_View_PartyName");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, PDTO.FromDate);
            objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, PDTO.ToDate);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
             return ds;
            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    DataTable dt = ds.Tables[0];
            //    return dt;
            //}
            //return null;
        }
        #endregion

        #region View_InvoiceNo

        public DataTable View_InvoiceNo(Components.DTO.PaymentsDTO PDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_View_InvoiceNo");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@PartyName", DbType.String, PDTO.PartyName);
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

        #region SearchResult
        public static DataTable SearchResult
        {
            get
            {
                return _SearchResult;
            }
            set
            {
                _SearchResult = value;
            }
        }
        #endregion


        #region Payments_OldBal_Check

        public DataTable Payments_OldBal_Check(string ContactName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_OldBal_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ContactName", DbType.String, ContactName);
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

        #region Payments_TotalBal_I

        public int Payments_TotalBal_I(Components.DTO.PaymentsDTO PDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_TotalBal_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, PDTO.PaidAmount);
            objDataBase.AddInParameter(dbCommand, "@Name", DbType.String, PDTO.PartyName);
            objDataBase.AddInParameter(dbCommand, "@OldDate", DbType.DateTime, PDTO.PaidDate);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region Payments_TotalBal_U

        public int Payments_TotalBal_U(Components.DTO.PaymentsDTO PDTO, int ID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_TotalBal_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Decimal, ID);
            objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, PDTO.PaidAmount);
            objDataBase.AddInParameter(dbCommand, "@Name", DbType.String, PDTO.PartyName);
            objDataBase.AddInParameter(dbCommand, "@OldDate", DbType.DateTime, PDTO.PaidDate);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion


        #region PaymentDetailsLoad

        public DataTable PaymentDetailsLoad(string MRNo, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_DetailSelect");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@MRNo", DbType.String, MRNo);
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

        public DataTable LoadGrid(int ContactID, Components.DTO.PaymentsDTO PDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_LoadDate");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
            objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, PDTO.FromDate);
            objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, PDTO.ToDate);
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

        public DataTable LoadGridMRNO(string MRNo, Components.DTO.PaymentsDTO PDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_LoadDate_MRNO");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, MRNo);
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

        #region Payments_Save
        public int Payments_Save(Components.DTO.PaymentsDTO PDTO,int EmpID, int RNo, int ContactID,decimal ShortAmt, int ID, string Branch, string UserID)
        {
            int PaymentsID = 0;
            string PaymentMode = PDTO.PaymentMode;
            if (PaymentMode == "Cash")
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_Insert");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@EmpID", DbType.Int32, EmpID);
                objDataBase.AddInParameter(dbCommand, "@RNo", DbType.Int32, RNo);
                objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, PDTO.PartyName);
                objDataBase.AddInParameter(dbCommand, "@CollectedBy", DbType.String, PDTO.CollectedBy);
                objDataBase.AddInParameter(dbCommand, "@BalanceAmount", DbType.Decimal, PDTO.BalanceAmount);
                objDataBase.AddInParameter(dbCommand, "@PaidAmount", DbType.Decimal, PDTO.PaidAmount);
                objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, PDTO.Amount);
                 objDataBase.AddInParameter(dbCommand, "@ShortAmt", DbType.Decimal, ShortAmt);
                objDataBase.AddInParameter(dbCommand, "@Type", DbType.String, PDTO.Type);
                objDataBase.AddInParameter(dbCommand, "@PaidDate", DbType.DateTime, PDTO.PaidDate);
                objDataBase.AddInParameter(dbCommand, "@PaymentMode", DbType.String, PDTO.PaymentMode);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, PDTO.MRNO);
                objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            }
            else
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_Insert");
                dbCommand.CommandType = CommandType.StoredProcedure;
                //SqlHelper.SqlProcedure = "Payments_Insert";
                //SqlParameter[] Param = new SqlParameter[13];
                int i = 0;
                objDataBase.AddInParameter(dbCommand, "@EmpID", DbType.Int32, EmpID);
                objDataBase.AddInParameter(dbCommand, "@RNo", DbType.Int32, RNo);
                objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, PDTO.PartyName);
                objDataBase.AddInParameter(dbCommand, "@CollectedBy", DbType.String, PDTO.CollectedBy);
                objDataBase.AddInParameter(dbCommand, "@BalanceAmount", DbType.Decimal, PDTO.BalanceAmount);
                objDataBase.AddInParameter(dbCommand, "@PaidAmount", DbType.Decimal, PDTO.PaidAmount);
                objDataBase.AddInParameter(dbCommand, "@Amount", DbType.Decimal, PDTO.Amount);
                objDataBase.AddInParameter(dbCommand, "@ShortAmt", DbType.Decimal, ShortAmt);
                objDataBase.AddInParameter(dbCommand, "@Type", DbType.String, PDTO.Type);
                objDataBase.AddInParameter(dbCommand, "@PaidDate", DbType.DateTime, PDTO.PaidDate);
                objDataBase.AddInParameter(dbCommand, "@PaymentMode", DbType.String, PDTO.PaymentMode);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, PDTO.MRNO);
                objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                PaymentsID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
                if (PaymentsID > 0)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("Payments_ChequeDet_I");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@PaymentsID", DbType.Int32, PaymentsID);
                    objDataBase.AddInParameter(dbCommand, "@ChequeNo", DbType.Int32, PDTO.ChequeNo);
                    objDataBase.AddInParameter(dbCommand, "@ChequeDate", DbType.DateTime, PDTO.ChequeDate);
                    objDataBase.AddInParameter(dbCommand, "@BankName", DbType.String, PDTO.BankName);
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }
            return affectedRows;
            //return 0;
        }
        #endregion

        #region Payments_Update
        public int Payments_Update(Components.DTO.PaymentsDTO PDTO, int ID, int ContactID, decimal ShortAmt, int EmpID, int DeliveryID, string Branch, string UserID)
        {
            string Mode = PDTO.PaymentMode;
            if (Mode == "Cash")
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_Update");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@ID", DbType.String, ID);
                objDataBase.AddInParameter(dbCommand, "@DeliveryID", DbType.String, DeliveryID);
                objDataBase.AddInParameter(dbCommand, "@Type", DbType.String, PDTO.Type);
                objDataBase.AddInParameter(dbCommand, "@PaidAmount", DbType.String, PDTO.PaidAmount);
                objDataBase.AddInParameter(dbCommand, "@Amount", DbType.String, PDTO.Amount);
                objDataBase.AddInParameter(dbCommand, "@Balance", DbType.String, PDTO.BalanceAmount);
                objDataBase.AddInParameter(dbCommand, "@ShortAmt", DbType.Decimal, ShortAmt);
                objDataBase.AddInParameter(dbCommand, "@Date", DbType.String, PDTO.PaidDate);
                objDataBase.AddInParameter(dbCommand, "@PaymentMode", DbType.String, PDTO.PaymentMode);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, PDTO.PartyName);
                objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, PDTO.MRNO);
                objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.String, ContactID);
                objDataBase.AddInParameter(dbCommand, "@EmpID", DbType.String, EmpID);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            }
            else
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_Update");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@ID", DbType.String, ID);
                objDataBase.AddInParameter(dbCommand, "@DeliveryID", DbType.String, DeliveryID);
                objDataBase.AddInParameter(dbCommand, "@Type", DbType.String, PDTO.Type);
                objDataBase.AddInParameter(dbCommand, "@PaidAmount", DbType.String, PDTO.PaidAmount);
                objDataBase.AddInParameter(dbCommand, "@Amount", DbType.String, PDTO.Amount);
                objDataBase.AddInParameter(dbCommand, "@ShortAmt", DbType.Decimal, ShortAmt);
                objDataBase.AddInParameter(dbCommand, "@Balance", DbType.String, PDTO.BalanceAmount);
                objDataBase.AddInParameter(dbCommand, "@Date", DbType.String, PDTO.PaidDate);
                objDataBase.AddInParameter(dbCommand, "@PaymentMode", DbType.String, PDTO.PaymentMode);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, PDTO.PartyName);
                //objDataBase.AddInParameter(dbCommand, "@CollectedBy", PDTO.CollectedBy);
                objDataBase.AddInParameter(dbCommand, "@EmpID", DbType.String, EmpID);

                objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, PDTO.MRNO);
                objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.String, ContactID);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                int PaymentsID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
                if (PaymentsID > 0)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("PaymentsChequeDet_U");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@ID", DbType.String, ID);
                    objDataBase.AddInParameter(dbCommand, "@ChequeNo", DbType.String, PDTO.ChequeNo);
                    objDataBase.AddInParameter(dbCommand, "@ChequeDate", DbType.String, PDTO.ChequeDate);
                    objDataBase.AddInParameter(dbCommand, "@BankName", DbType.String, PDTO.BankName);
                    objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.String, ContactID);
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }
            return 0;
        }
        #endregion

        #region Payments_OldBal

        public DataTable Payments_OldBal(Components.DTO.PaymentsDTO PDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_OldBal");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@PartyName", DbType.String, PDTO.PartyName);
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

        #region Payment_NameLoad
        public DataTable NameLoad(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_PayNameLoad");
            dbCommand.CommandType = CommandType.StoredProcedure;
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

        #region Payment_View
        public DataSet Payment_View(DateTime date, int ContactID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@PaidDate", DbType.DateTime, date);
            objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region Payment_View_MRNO
        public DataSet Payment_View_MRNO(DateTime date, string MRNO,int ContactID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_View_MRNo");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@PaidDate", DbType.DateTime, date);
            objDataBase.AddInParameter(dbCommand, "@MRNO", DbType.String, MRNO);
            objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region CheckBalance
        public DataTable CheckBalance(string MRNo, DateTime PDate, int ContactID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Payments_CheckBal");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@MRNo", DbType.String, MRNo);
            objDataBase.AddInParameter(dbCommand, "@PDate", DbType.DateTime, PDate);
            objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
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
    }
}
