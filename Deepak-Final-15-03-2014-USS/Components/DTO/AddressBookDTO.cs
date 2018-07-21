using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class AddressBookDTO
   {
       #region Variables
       private string _Address,_Type, _City, _Name,_SurName,_OriCustName, _SecPhone,_PriPhone, _Mob1, _Mob2, _SecEmail, _PriEmail, _Fax, _Website, _TinNo, _CstNo,_AreaCode;
       private int _PinCode,_GroupID;
       private string _UserID, _Category, _AgentCode, _GroupName, _BranchName;
       private decimal _Freight, _Labour, _Delivery, _Stationary, _Demurrage, _LocalCartage, _ServiceTax;
       #endregion

       #region ServiceTax
       public decimal ServiceTax
       {
           get
           {
               return _ServiceTax;
           }
           set
           {
               _ServiceTax = value;
           }
       }
       #endregion

       #region LocalCartage
       public decimal LocalCartage
       {
           get
           {
               return _LocalCartage;
           }
           set
           {
               _LocalCartage = value;
           }
       }
       #endregion

       #region Demurrage
       public decimal Demurrage
       {
           get
           {
               return _Demurrage;
           }
           set
           {
               _Demurrage = value;
           }
       }
       #endregion

       #region Stationary
       public decimal Stationary
       {
           get
           {
               return _Stationary;
           }
           set
           {
               _Stationary = value;
           }
       }
       #endregion

       #region Delivery
       public decimal Delivery
       {
           get
           {
               return _Delivery;
           }
           set
           {
               _Delivery = value;
           }
       }
       #endregion

       #region Labour
       public decimal Labour
       {
           get
           {
               return _Labour;
           }
           set
           {
               _Labour = value;
           }
       }
       #endregion

       #region Freight
       public decimal Freight
       {
           get
           {
               return _Freight;
           }
           set
           {
               _Freight = value;
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

       #region AgentCode
       public string AgentCode
       {
           get
           {
               return _AgentCode;
           }
           set
           {
               _AgentCode = value;
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

       #region GroupID
       public int GroupID
       {
           get
           {
               return _GroupID;
           }
           set
           {
               _GroupID = value;
           }

       }
       #endregion

       #region Category
       public string Category
       {
           get
           {
               return _Category;
           }
           set
           {
               _Category = value;
           }

       }
       #endregion

       #region AreaCode
       public string AreaCode
       {
           get
           {
               return _AreaCode;
           }
           set
           {
               _AreaCode = value;
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

       #region Name
       public string Name
       {
           get
           {
               return _Name;
           }
           set
           {
               _Name = value;
           }
       }
       #endregion

       #region SurName
       public string SurName
       {
           get
           {
               return _SurName;
           }
           set
           {
               _SurName = value;
           }
       }
       #endregion

       #region OriCustName
       public string OriCustName
       {
           get
           {
               return _OriCustName;
           }
           set
           {
               _OriCustName = value;
           }
       }
       #endregion

       #region GroupName
       public string GroupName
       {
           get
           {
               return _GroupName;
           }
           set
           {
               _GroupName = value;
           }
       }
       #endregion

       #region SecPhone
       public string SecPhone
       {
           get
           {
               return _SecPhone;
           }
           set
           {
               _SecPhone = value;
           }
       }
       #endregion

       #region Mob1
       public string Mob1
       {
           get
           {
               return _Mob1;
           }
           set
           {
               _Mob1 = value;
           }
       }
       #endregion

       #region Mob2
       public string Mob2
       {
           get
           {
               return _Mob2;
           }
           set
           {
               _Mob2 = value;
           }
       }
       #endregion

       #region PriPhone
       public string PriPhone
       {
           get
           {
               return _PriPhone;
           }
           set
           {
               _PriPhone = value;
           }
       }
       #endregion

       #region SecEmail
       public string SecEmail
       {
           get
           {
               return _SecEmail;
           }
           set
           {
               _SecEmail = value;
           }
       }
       #endregion

       #region PriEmail
       public string PriEmail
       {
           get
           {
               return _PriEmail;
           }
           set
           {
               _PriEmail = value;
           }
       }
       #endregion

       #region Fax
       public string Fax
       {
           get
           {
               return _Fax;
           }
           set
           {
               _Fax = value;
           }
       }
       #endregion

       #region Website
       public string Website
       {
           get
           {
               return _Website;
           }
           set
           {
               _Website = value;
           }
       }
       #endregion

       #region TinNo
       public string TinNo
       {
           get
           {
               return _TinNo;
           }
           set
           {
               _TinNo = value;
           }
       }
       #endregion

       #region CstNo
       public string CstNo
       {
           get
           {
               return _CstNo;
           }
           set
           {
               _CstNo = value;
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
    }
    
}
