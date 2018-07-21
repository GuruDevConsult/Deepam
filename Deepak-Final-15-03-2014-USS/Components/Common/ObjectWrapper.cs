using System;
using System.Data.SqlClient;
using System.Reflection;
using System.ComponentModel;
using System.Data;
//using System.Reflection.Emit;

namespace Components.Common
{
    public class ObjectWrapper
    {
        private static ObjectWrapper instance;
        Components.Common.GlobalFunction GlbFunc;
        
        #region Constructor & Instance
        public static ObjectWrapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectWrapper();
                }
                return instance;
            }
        }

        private ObjectWrapper()
        {
        }

        public SqlParameter[] ObjToParam(Object ObjSource,string ParamPrefix)
        {
            string fieldName = string.Empty;
            object fieldValue = null;
            int lenProperty = TypeDescriptor.GetProperties(ObjSource).Count;
            int ptr = 0;
            SqlParameter[] paramPrp = new SqlParameter[lenProperty];

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(ObjSource)) 
            {
            
                fieldName = prop.Name;
                fieldValue = prop.GetValue(ObjSource);
                paramPrp[ptr++] = new SqlParameter("@" + ParamPrefix + prop.Name, fieldValue);
            }
            return paramPrp;
        }

        public SqlParameter[] ObjToParam(Object ObjSource)
        {
            string fieldName = string.Empty;
            object fieldValue = null;
          
            int lenProperty = TypeDescriptor.GetProperties(ObjSource).Count;
            int ptr = 0;
            SqlParameter[] paramPrp = new SqlParameter[lenProperty];

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(ObjSource))
            {
                fieldName = prop.Name;
                fieldValue = prop.GetValue(ObjSource);
                paramPrp[ptr++] = new SqlParameter("@" + prop.Name, fieldValue);
            }
            return paramPrp;
        }

        public SqlParameter[] DrToParam(DataRow drSource)
        {
            int colCount = 0;
            int colPtr = 0;
            int paramPtr = 0;
            SqlParameter[] paramDT = null;
            
            if (drSource != null)
            {
                colCount = drSource.Table.Columns.Count;
                paramDT = new SqlParameter[colCount];
                    for (colPtr = 0; colPtr < colCount; colPtr++)
                    {
                        paramDT[paramPtr++] = new SqlParameter("@" + drSource.Table.Columns[colPtr].ColumnName, drSource[colPtr]);
                    }
            }
            return paramDT;
        }

        //public SqlParameter[] DtToParam(DataTable dtSource)
        //{
        //    int colCount = 0;
        //    int rowCount = 0;
        //    int colPtr = 0;
        //    int rowPtr = 0;
        //    int paramPtr = 0;
        //    SqlParameter[] paramDT = null;
        //    GlbFunc = Components.Common.GlobalFunction.Instance;
        //    if (!GlbFunc.IsNullorEmptyDT(dtSource))
        //    {
        //        rowCount = dtSource.Rows.Count;
        //        colCount = dtSource.Columns.Count;
        //        paramDT = new SqlParameter[colCount];
        //        for (rowPtr = 0; rowPtr < rowCount; rowPtr++)
        //        {
        //            for (colPtr = 0; colPtr < colCount; colPtr++)
        //            {
        //                paramDT[paramPtr++] = new SqlParameter("@" + dtSource.Columns[colPtr].ColumnName, dtSource.Rows[rowPtr][colPtr]);
        //            }
        //        }

        //    }
        //    return paramDT;
        //}

        public string GetClassName(Object ObjSource)
        {
            string className = string.Empty;
            className = TypeDescriptor.GetClassName(ObjSource);
            return className;
        }
        #endregion
    }
}
