using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class CategoryBL
    {
        int rowsAffected = 0;
        private static CategoryBL instance;
        Components.DAL.SQLConnect sqlHelper;
        Components.Common.GlobalFunction GlbFunc;
        public Database objDataBase = DatabaseFactory.CreateDatabase();

        public static CategoryBL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryBL();
                }
                return instance;
            }
        }
        private CategoryBL()
        {
        }
        public DataTable LoadGrid()
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Category_v");
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }


        public int save(Components.DTO.CategoryDTO catDTO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Category_s");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Category", DbType.String, catDTO.Category);
            objDataBase.AddInParameter(dbCommand, "@CategoryName", DbType.String, catDTO.CategoryName);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        public int delete(Components.DTO.CategoryDTO catDTO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Category_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Category", DbType.String, catDTO.Category);
            objDataBase.AddInParameter(dbCommand, "@CategoryName", DbType.String, catDTO.CategoryName);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

        public int update(Components.DTO.CategoryDTO catDTO, int _hid)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Category_u");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Category", DbType.String, catDTO.Category);
            objDataBase.AddInParameter(dbCommand, "@CategoryName", DbType.String, catDTO.CategoryName);
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, _hid);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }

    }
}
