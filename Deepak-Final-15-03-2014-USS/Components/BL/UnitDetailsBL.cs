using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Components.BL
{
    public class UnitDetailsBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        Components.Common.ObjectWrapper ObjWrp;
        int affectedRows = 0;
        private static UnitDetailsBL _Instance;
        #endregion

        #region Constructor & Instance
        public static UnitDetailsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UnitDetailsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region UnitMaster Select
        public DataTable UnitMaster_S()
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            SqlHelper.SqlProcedure = "UnitMaster_S";
            SqlHelper.SqlParam = null;
            DataTable dtItem = SqlHelper.ExecReadDT();
            SqlHelper.CloseConnection();
            return dtItem;
        }
        #endregion

        #region UnitDetails Save

        public int UnitDetails_I(DataTable dtLoad)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            int i = 0;
            SqlHelper.SqlProcedure = "UnitMaster_I";
            SqlParameter[] param = new SqlParameter[2];
            foreach (DataRow dr in dtLoad.Rows)
            {
                param[i++] = new SqlParameter("@Unit", dr["UnitName"].ToString());
                param[i++] = new SqlParameter("@UserID", "admin");
                SqlHelper.SqlParam = param;
                affectedRows = SqlHelper.Exec();
                SqlHelper.CloseConnection();
            }
            return affectedRows;
        }
        #endregion

        #region UnitDetails Update
        public int UnitDetails_U(Components.DTO.UnitDetailsDTO UnitDTO, int _UnitID)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            int i = 0;
            SqlHelper.SqlProcedure = "UnitMaster_U";
            SqlParameter[] param = new SqlParameter[3];
            param[i++] = new SqlParameter("@UnitID", _UnitID);
            param[i++] = new SqlParameter("@Unit", UnitDTO.Unit);
            param[i++] = new SqlParameter("@UserID", "admin");
            SqlHelper.SqlParam = param;
            affectedRows = SqlHelper.Exec();
            SqlHelper.CloseConnection();
            return affectedRows;
        }
        #endregion

        #region UnitDetails Delete
        public int UnitDetails_D(int UnitID)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            int i = 0;
            SqlHelper.SqlProcedure = "UnitMaster_D";
            SqlParameter[] param = new SqlParameter[1];
            param[i++] = new SqlParameter("@UnitID", UnitID);
            //param[i++] = new SqlParameter("@UserID", "admin");
            SqlHelper.SqlParam = param;
            affectedRows = SqlHelper.Exec();
            SqlHelper.CloseConnection();
            return affectedRows;
        }
        #endregion

    }
}
