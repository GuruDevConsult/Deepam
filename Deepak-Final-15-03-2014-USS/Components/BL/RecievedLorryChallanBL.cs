using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class RecievedLorryChallanBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static RecievedLorryChallanBL _Instance;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static RecievedLorryChallanBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RecievedLorryChallanBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region  Save
        public int Save(DataTable dtFreight, string Branch, string UserID,int CHALLANNO, int ReceivedID,string FromBranch)
        {
            try
            {
                int i = 0;
                if (dtFreight != null && dtFreight.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtFreight.Rows)
                    {
                        DbCommand dbCommand = objDataBase.GetSqlStringCommand("RecievedLorryChallanItems_I");
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, CHALLANNO);
                        objDataBase.AddInParameter(dbCommand, "@ReceivedID", DbType.Int32, ReceivedID);
                        objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, dr["Date"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.String, dr["LRNo"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@From", DbType.String, dr["From"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@To", DbType.String, dr["To"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@ConsignorID", DbType.String, dr["ConsignorName"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@ConsigneeID", DbType.String, dr["ConsigneeName"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@NoofPackages", DbType.Int32, dr["NoofPackages"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@CustName", DbType.String, string.IsNullOrEmpty(dr["CustName"].ToString())?DBNull.Value.ToString():dr["CustName"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@ActualWeight", DbType.Decimal, dr["ActualWeight"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@Contents", DbType.String, dr["Items"].ToString());
                        if (dr["PrivateMarks"].ToString() != string.Empty)
                        {
                            objDataBase.AddInParameter(dbCommand, "@PrivateMarks",DbType.String, dr["PrivateMarks"].ToString());
                        }
                        else
                        {
                            objDataBase.AddInParameter(dbCommand, "@PrivateMarks",DbType.String,DBNull.Value.ToString());
                        }

                        objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, dr["Packings"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, dr["AgentName"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@PayType", DbType.String, dr["PayType"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@Freight", DbType.Decimal, dr["Freight"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@LabourCharge", DbType.Decimal, dr["LabourCharge"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@DeliveryCharge", DbType.Decimal, dr["DeliveryCharge"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@StatisticalCharge", DbType.Decimal, dr["StatisticalCharge"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@CartageCharge", DbType.Decimal, dr["CartageCharge"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, dr["ServiceTax"].ToString());
                        //objDataBase.AddInParameter(dbCommand, "@LoadedPackages", DbType.Int32, string.IsNullOrEmpty(dr["LoadedPackages"].ToString()) ? DBNull.Value.ToString() : dr["LoadedPackages"].ToString());
                        //objDataBase.AddInParameter(dbCommand, "@ReceivedPackages", DbType.Int32, string.IsNullOrEmpty(dr["ReceivedPackages"].ToString()) ? DBNull.Value.ToString() : dr["ReceivedPackages"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@Godown", DbType.String, dr["Godown"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                        objDataBase.AddInParameter(dbCommand, "@FromBranch", DbType.String, FromBranch);
                        objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                        affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                    }
                    return affectedRows;
                }
                return affectedRows;
            }
            catch
            {
                return 0;
            }
        }
        #endregion


        #region chkSelect
        public DataTable chkSelect(string Branch, int ChallanNo, string FromBranch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Recievedlorrychallan_Radioselect");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BRANCHNAME", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@CHALLANNO", DbType.Int32, ChallanNo);
            objDataBase.AddInParameter(dbCommand, "@FromBranch", DbType.String, FromBranch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region RCView
        public DataTable RCView(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("RecievedLorryChallan_View");
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

        #region LodeGodownNo
        public DataTable LodeGodownNo(string Branch, DateTime FormDate, DateTime ToDate)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LodeGodownNo_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BRANCHNAME", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, FormDate);
            objDataBase.AddInParameter(dbCommand, "@Todate", DbType.DateTime, ToDate);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        //#region chkSelect
        //public DataTable RecivedlorrychallanView(string Branch, string GodownNo)
        //{
        //    DbCommand dbCommand = objDataBase.GetSqlStringCommand("Recievedlorrychallanitems_V");
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    objDataBase.AddInParameter(dbCommand, "@BRANCHNAME", DbType.String, Branch);
        //    objDataBase.AddInParameter(dbCommand, "@GODOWNNO", DbType.String, GodownNo);
        //    DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        DataTable dt = ds.Tables[0];
        //        return dt;
        //    }
        //    return null;
        //}
        //#endregion

        #region RecivedlorrychallanView
        public DataSet RecivedlorrychallanView(string Branch, int ChallanNo)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Recievedlorrychallanitems_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BRANCHNAME", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, ChallanNo);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
            //return null;
        }
        #endregion

        #region DeliverySlipUpdate
        public int Update(DataTable dtFreight, string Branch, string UserID)
        {
            foreach (DataRow dr in dtFreight.Rows)
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("RecievedLorryChallanItems_U");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.String, dr["LRNo"].ToString());
                //objDataBase.AddInParameter(dbCommand, "@LoadedPackages", DbType.Int32, dr["LoadedPackages"].ToString());
                //objDataBase.AddInParameter(dbCommand, "@ReceivedPackages", DbType.Int32, dr["ReceivedPackages"].ToString());
                objDataBase.AddInParameter(dbCommand, "@Godown", DbType.String, dr["Godown"].ToString());
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            }
            return affectedRows;
        }
        #endregion

        #region UpdateArrivalDate
        public int UpdateArrivalDate(int ChallanNo,DateTime Arrivaldate, string Branch,string UserID)
        {

            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ReceivedLorryArrivalDate_U");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@ArrivalDate", DbType.DateTime, Arrivaldate);
                objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, ChallanNo);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                return affectedRows;

        }
        #endregion
    }
}