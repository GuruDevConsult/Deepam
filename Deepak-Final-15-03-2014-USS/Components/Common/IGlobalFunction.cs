using System;
namespace Common
{
    interface IGlobalFunction
    {
        string AddressDRToCSV(System.Data.DataRow drAddr, string AddrCat);
        string AutoGenID(string IDType);
        void BindDTtoListBox(System.Web.UI.WebControls.ListBox lstBox, System.Data.DataTable dtSource);
        string Condition1 { get; set; }
        string Condition2 { get; set; }
        object ConverFieldType(string fieldType, object fieldValue);
        string ConvertListBoxToCSV(System.Web.UI.WebControls.ListBox lstItem);
        DateTime ConvertStrToDateTime(string strDate);
        decimal ConvertStrToDecimal(string strSource);
        int ConvertStrToInt(string strSource);
        long ConvertStrToLong(string strSource);
        string[] CSVToArray(string strCSV);
        string DefaultToEmptyDate(string strDate);
        string Field1 { get; set; }
        string Field2 { get; set; }
        System.Data.DataTable GetResourceDetails(string ResourceName);
        bool IsAvail();
        bool IsNullorEmptyDT(System.Data.DataTable dtSource);
        System.Data.DataSet LoadDataSet(string _StoredProcedure);
        System.Data.DataTable LoadDataTable(string _StoredProcedure);
        System.Data.SqlClient.SqlParameter[] SqlParam { get; set; }
        string TableName { get; set; }
        string UploadFile(System.Web.UI.WebControls.FileUpload fluSource, string SrcPath, string Prefix);
    }
}
