using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class BookDetailsDTO
    {
        #region Variables
        private int _LRNo;
        private DateTime _BookingDate;
        private int _ConsignorID;
        private int _ConsigneeID;
        private int _StoreID;
        private int _NoOfPack;
        private string _Desc;
        private decimal _ActualWeight;
        private decimal _ChargedWeight;
        private decimal _FreightCharges;
        private decimal _HandlingCharges;
        private decimal _DeliveryCharges;
        private decimal _LabourCharges;
        private decimal _CartageCharges;
        private decimal _StatisticalCharges;
        private decimal _MiscExp;
        private decimal _Insurance;
        private decimal _AOC;
        private decimal _ServiceTax, _PaidAmount;
        private decimal _ServiceTaxPer;
        private decimal _Total;
        private string _InsuranceCoName;
        private string _PolicyNo;
        private DateTime _Date;
        private decimal _InsuranceAmt;
        private string _Risk;
        private int _AgentID;
        private string _From;
        private string _To;
        private string _UserID;
        private string _BranchName;
        private string _ItemName;
        private string _PayType;
        private string _PaymentMode;
        private decimal _Amount;
        private int _ChequeNo;
        private DateTime _ChequeDate;
        private string _BankName;
        private decimal _Rate;
        private string _Packings;
        private string _CustomerName;
        private string _PrivateMark;
        private string _ConsignorName;
        private string _ConsigneeName;
        private string _AgentName;
        private string _PhoneNumber;

        #endregion

        #region LRNo
        public int LRNo
        {
            get { return _LRNo; }
            set { _LRNo = value; }
        }
        #endregion

        #region StoreNo
        public int StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }
        #endregion

        #region BookingDate
        public DateTime BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }
        #endregion

        #region ChequeDate
        public DateTime ChequeDate
        {
            get { return _ChequeDate; }
            set { _ChequeDate = value; }
        }
        #endregion

        #region ConsignorID
        public int ConsignorID
        {
            get { return _ConsignorID; }
            set { _ConsignorID = value; }
        }
        #endregion

        #region ConsignorName
        public string ConsignorName
        {
            get { return _ConsignorName; }
            set { _ConsignorName = value; }
        }
        #endregion

        #region ConsigneeName
        public string ConsigneeName
        {
            get { return _ConsigneeName; }
            set { _ConsigneeName = value; }
        }
        #endregion

        #region AgentName

        public string AgentName
        {
            get { return _AgentName; }
            set { _AgentName = value; }
        }
        #endregion

        #region ConsigneeID
        public int ConsigneeID
        {
            get { return _ConsigneeID; }
            set { _ConsigneeID = value; }
        }
        #endregion

        #region Desc
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        #endregion

        #region BankName
        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }
        #endregion

        #region CustomerName
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        #endregion

        #region PrivateMark
        public string PrivateMark
        {
            get { return _PrivateMark; }
            set { _PrivateMark = value; }
        }
        #endregion

        #region Packings
        public string Packings
        {
            get { return _Packings; }
            set { _Packings = value; }
        }
        #endregion

        #region ChequeNo
        public int ChequeNo
        {
            get

            {
                return _ChequeNo;
            }
            set
            {
                _ChequeNo = value;
            }
        }
        #endregion

        #region ActualWeight
        public decimal ActualWeight
        {
            get { return _ActualWeight; }
            set { _ActualWeight = value; }
        }
        #endregion

        #region ChargedWeight
        public decimal ChargedWeight
        {
            get { return _ChargedWeight; }
            set { _ChargedWeight = value; }
        }
        #endregion

        #region FreightCharges
        public decimal FreightCharges
        {
            get { return _FreightCharges; }
            set { _FreightCharges = value; }
        }
        #endregion

        #region HandlingCharges
        public decimal HandlingCharges
        {
            get { return _HandlingCharges; }
            set { _HandlingCharges = value; }
        }
        #endregion

        #region CartageCharges
        public decimal CartageCharges
        {
            get { return _CartageCharges; }
            set { _CartageCharges = value; }
        }
        #endregion

        #region DeliveryCharges
        public decimal DeliveryCharges
        {
            get { return _DeliveryCharges; }
            set { _DeliveryCharges = value; }
        }
        #endregion

        #region LabourCharges
        public decimal LabourCharges
        {
            get { return _LabourCharges; }
            set { _LabourCharges = value; }
        }
        #endregion

        #region PaidAmount
        public decimal PaidAmount
        {
            get { return _PaidAmount; }
            set { _PaidAmount = value; }
        }
        #endregion

        #region StatisticalCharges
        public decimal StatisticalCharges
        {
            get { return _StatisticalCharges; }
            set { _StatisticalCharges = value; }
        }
        #endregion

        #region MiscExp
        public decimal MiscExp
        {
            get { return _MiscExp; }
            set { _MiscExp = value; }
        }
        #endregion

        #region Insurance
        public decimal Insurance
        {
            get { return _Insurance; }
            set { _Insurance = value; }
        }
        #endregion

        #region AOC
        public decimal AOC
        {
            get { return _AOC; }
            set { _AOC = value; }
        }
        #endregion

        #region Rate
        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
        #endregion

        #region ServiceTax
        public decimal ServiceTax
        {
            get { return _ServiceTax; }
            set { _ServiceTax = value; }
        }
        #endregion

        #region ServiceTaxPer
        public decimal ServiceTaxPer
        {
            get { return _ServiceTaxPer; }
            set { _ServiceTaxPer = value; }
        }
        #endregion

        #region NoOfPack
        public int NoOfPack
        {
            get
            {
                return _NoOfPack;
            }
            set
            {
                _NoOfPack = value;
            }
        }
        #endregion


        #region Total
        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        #endregion

        #region Amount
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        #endregion



        #region InsuranceCoName
        public string InsuranceCoName
        {
            get { return _InsuranceCoName; }
            set { _InsuranceCoName = value; }
        }
        #endregion

        #region PolicyNo
        public string PolicyNo
        {
            get { return _PolicyNo; }
            set { _PolicyNo = value; }
        }
        #endregion

        #region Date
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        #endregion

        #region InsuranceAmt
        public decimal InsuranceAmt
        {
            get { return _InsuranceAmt; }
            set { _InsuranceAmt = value; }
        }
        #endregion

        #region Risk
        public string Risk
        {
            get { return _Risk; }
            set { _Risk = value; }
        }
        #endregion

        #region AgentID
        public int AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }
        #endregion

        #region From
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        #endregion

        #region ItemName
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        #endregion

        #region PayType
        public string PayType
        {
            get { return _PayType; }
            set { _PayType = value; }
        }
        #endregion

        #region PaymentMode
        public string PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }
        #endregion

        #region To
        public string To
        {
            get { return _To; }
            set { _To = value; }
        }
        #endregion

        #region UserID

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        #endregion

        #region BranchName

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        #endregion

        #region PhoneNumber
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        #endregion
    }
}
