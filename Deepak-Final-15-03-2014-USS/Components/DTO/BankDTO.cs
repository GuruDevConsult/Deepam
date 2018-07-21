using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
   public class BankDTO
   {
       #region Variable
       private string _BankCode, _BankName, _BranchName, _Address, _City, _IFSCode, _AccType, _AccName;
       private int _PinCode;
       private string _UserID,_AccNo,_DeepakBranchName;
       #endregion

       #region BankCode
       public string BankCode
       {
           get
           {
               return _BankCode;
           }
           set
           {
               _BankCode = value;
           }

       }
       #endregion

       #region UserID
       public string UserID
       {
           get
           {
               return _UserID;
           }
           set
           {
               _UserID = value;
           }

       }
       #endregion

       #region DeepakBranchName
       public string DeepakBranchName
       {
           get
           {
               return _DeepakBranchName;
           }
           set
           {
               _DeepakBranchName = value;
           }

       }
       #endregion

       #region IFSCode
       public string IFSCode
       {
           get
           {
               return _IFSCode;
           }
           set
           {
               _IFSCode = value;
           }

       }
       #endregion

       #region BankName
       public string BankName
       {
           get
           {
               return _BankName;
           }           
           set
           {
               _BankName=value;
           }
       }
       #endregion

       #region AccName
       public string AccName
       {
           get
           {
               return _AccName;
           }
           set
           {
               _AccName = value;
           }
       }
       #endregion

       #region AccType
       public string AccType
       {
           get
           {
               return _AccType;
           }
           set
           {
               _AccType = value;
           }
       }
       #endregion

       #region BranchName
       public string BranchName
       {
           get
           {
               return _BranchName;
           }
           set
           {
               _BranchName = value;
           }
       }
        #endregion

       #region Address
       public string Address
       {
           get
           {
               return _Address;
           }
           set
           {
               _Address = value;
           }
       }
        #endregion

       #region City
       public string City
       {
           get
           {
               return _City;
           }
           set
           {
               _City = value;
           }
       }
        #endregion

       #region PinCode
       public int PinCode
       {
           get
           {
               return _PinCode;
           }
           set
           {
               _PinCode = value;
           }
       }
       #endregion
      
       #region AccNo
       public string AccNo
       {
           get
           {
               return _AccNo;
           }
           set
           {
               _AccNo = value;
           }

       }
        #endregion
   }
}
