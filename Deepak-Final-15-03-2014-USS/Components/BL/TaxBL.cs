using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Components.BL
{
    public class TaxBL
    {
        #region Variables
        int returnVal = 0;
        private static TaxBL instance;
        Components.DAL.SQLConnect SqlHelper;
        Components.Common.GlobalFunction GlbFunc;
        Components.Common.ObjectWrapper ObjWrp;
        DataTable dtTx = null;
        #endregion

        #region Instance
        public static TaxBL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TaxBL();
                }
                return instance;
            }
        }
        #endregion

        #region SaveTax
        public int SaveTax(Components.DTO.TaxDTO TxDTO)
        {
            ObjWrp = Components.Common.ObjectWrapper.Instance;
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                SqlHelper.SqlProcedure = "Tax_I";
                SqlParameter[] Param = ObjWrp.ObjToParam(TxDTO);
                SqlHelper.SqlParam = Param;
                Param = null;
                returnVal = Convert.ToInt32(SqlHelper.ExecScalar());
                return returnVal;
            }
            catch
            {
                return 0;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region TxView
        public DataTable TXView(string _TaxName)
        {
            GlbFunc = Components.Common.GlobalFunction.Instance;
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                SqlHelper.SqlProcedure = "Tax_S";
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@TaxName",_TaxName);
                SqlHelper.SqlParam = Param;
                Param=null;
                dtTx = SqlHelper.ExecReadDT();
                return dtTx;
            }
            catch
            {
                return null;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region UpdateTax
        public int UpdateTax(int TaxID, Components.DTO.TaxDTO TxDTO)
        {
            ObjWrp = Components.Common.ObjectWrapper.Instance;
            DAL.SQLConnect.Reset();
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                SqlHelper.SqlProcedure = "Tax_U";
                SqlParameter[] Param1 = ObjWrp.ObjToParam(TxDTO);
                int cntParam = Param1.Length;
                SqlParameter[] Param = new SqlParameter[cntParam + 1];
                Param1.CopyTo(Param, 0);
                Param[cntParam++] = new SqlParameter("ID", TaxID);
                SqlHelper.SqlParam = Param;
                Param = null;
                returnVal = Convert.ToInt32(SqlHelper.ExecScalar());
                return returnVal;
            }
            catch
            {
                return 0;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region DeleteTax
        public int DeleteTax(int TaxID, string _UserID)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                SqlHelper.SqlProcedure = "Tax_D";
                SqlParameter[] Param = new SqlParameter[2];
                Param[0] = new SqlParameter("@ID", TaxID);
                Param[1] = new SqlParameter("@UserID", _UserID);
                SqlHelper.SqlParam = Param;
                Param = null;
                returnVal = SqlHelper.Exec();
                return returnVal;
            }
            catch
            {
                return 0;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

    }
}
