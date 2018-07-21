using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
   public class LorryChallanDTO
   {
       #region Variable
       private int _ChallanNo;
       private string _StartFrom;
       private string _EndTo;
       private string _TruckNo;
       private string _NameofDriver;
       private string _TruckownerName;
       private string _Address;
       private string _City;
       private string _AgentName;
       private int _AgentID;
       private DateTime _ArrivalDate;
       private string _UserID;
       private DateTime _ChallanDate;
       private int _StoreNo;
       private string  _DriverPhoneNo;
       private string _AgentCode;
       private string _PrivateRemarks;
       private string _CustName;
       private string _OriCustName;
       private DateTime _FromDate, _ToDate;
       private string _BranchName;

       #endregion
      
       #region ChallanNo
       public int ChallanNo
       {
           get { return _ChallanNo; }
           set { _ChallanNo=value; }
       }

       #endregion 
       
                
        #region StartFrom
        public string StartFrom
        {
            get { return _StartFrom; }
            set { _StartFrom = value; }
        }
        #endregion

        #region EndTo
        public string EndTo
        {
            get { return _EndTo; }
            set { _EndTo = value; }
        }
        #endregion

        #region TruckNo
        public string TruckNo
        {
            get { return _TruckNo; }
            set { _TruckNo = value; }
        }
        #endregion

        #region NameofDriver
        public string NameofDriver
        {
            get { return _NameofDriver; }
            set { _NameofDriver = value; }
        }
        #endregion

        #region TruckownerName
        public string TruckownerName
        {
            get { return _TruckownerName; }
            set { _TruckownerName = value; }
        }
        #endregion

        #region DriverPhoneNo
        public string DriverPhoneNo
        {
            get { return _DriverPhoneNo; }
            set { _DriverPhoneNo = value; }
        }
        #endregion

        #region StoreNo
        public int StoreNo
        {
            get { return _StoreNo; }
            set { _StoreNo = value; }
        }
        #endregion

        #region Address
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        #endregion

        #region City
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        #endregion

        #region AgentName
        public string  AgentName
        {
            get { return _AgentName; }
            set { _AgentName = value; }
        }
        #endregion

        #region AgentID
        public int AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }
        #endregion

        #region UserID

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        #endregion

        #region ChallanDate
        public DateTime ChallanDate
        {
            get { return _ChallanDate; }
            set { _ChallanDate = value; }
        }

        #endregion 

        #region ArrivalDate
        public DateTime ArrivalDate
        {
            get { return _ArrivalDate; }
            set { _ArrivalDate = value; }
        }

        #endregion 

       #region AgentCode
       public string  AgentCode
       {
           get { return _AgentCode; }
           set { _AgentCode=value; }
       }

       #endregion 

       
       #region CustName
       public string CustName
       {
           get { return _CustName; }
           set { _CustName = value; }
       }

       #endregion 

       #region OriCustName
       public string OriCustName
       {
           get { return _OriCustName; }
           set { _OriCustName = value; }
       }

       #endregion 

       #region FromDate
       public DateTime FromDate
       {
           get { return _FromDate; }
           set { _FromDate = value; }
       }

       #endregion 

       #region ToDate
       public DateTime ToDate
       {
           get { return _ToDate; }
           set { _ToDate = value; }
       }

       #endregion 

       #region BranchName

       public string BranchName
       {
           get { return _BranchName; }
           set { _BranchName = value; }
       }

       #endregion

   }
}
