using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class DeliverySlipDTO
    {
        #region Variables
        private string _LRNo;
        private string _MRNo;
        private DateTime _Date;
        private int _CustomerID;
        private decimal _ActWeight;
        private int _NoOfPackages;
        private string  _Packing;
        private string _PrivateMar;
        private string _Description;
        private decimal _TotalWeight;
        private decimal _InvoiceAmount;
        private decimal _PaidAmount;
        private decimal _TotalBalance;
        private decimal _BalanceAmount;
        private decimal _Freight;
        private decimal _Labour;
        private decimal _DeliveryCh;
        private decimal _StationaryCh;
        private decimal _Demurrage;
        private decimal _LocalCartage;
        private decimal _ServiceTax;
        private string _CustomerName;
        private string _CollectedBy;
        private string _OriCustName;
        private string _BranchName;


        private string _UserID;
        #endregion

        #region LRNo
        public string LRNo
        {
            get { return _LRNo; }
            set { _LRNo = value; }
        }
        #endregion

        #region MRNo
        public string MRNo
        {
            get { return _MRNo; }
            set { _MRNo = value; }
        }
        #endregion

        #region Date
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        #endregion

        #region CustomerID
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        #endregion

        #region ActWeight
        public decimal ActWeight
        {
            get { return _ActWeight; }
            set { _ActWeight = value; }
        }
        #endregion

        #region CustomerName
        public string  CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        #endregion

        #region OriCustName
        public string OriCustName
        {
            get { return _OriCustName; }
            set { _OriCustName = value; }
        }
        #endregion

        #region NoOfPackages
        public int NoOfPackages
        {
            get { return _NoOfPackages; }
            set { _NoOfPackages = value; }
        }
        #endregion

        #region Packing
        public string  Packing
        {
            get { return _Packing; }
            set { _Packing = value; }
        }
        #endregion

        #region PrivateMar
        public string PrivateMar
        {
            get { return _PrivateMar; }
            set { _PrivateMar = value; }
        }
        #endregion

        #region Description
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        #endregion

        #region TotalWeight
        public decimal TotalWeight
        {
            get { return _TotalWeight; }
            set { TotalWeight = value; }
        }
        #endregion

        #region InvoiceAmount
        public decimal InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        #endregion

        #region PaidAmount
        public decimal PaidAmount
        {
            get { return _PaidAmount; }
            set { _PaidAmount = value; }
        }
        #endregion

        #region TotalBalance
        public decimal TotalBalance
        {
            get { return _TotalBalance; }
            set { _TotalBalance = value; }
        }
        #endregion

        #region BalanceAmount
        public decimal BalanceAmount
        {
            get { return _BalanceAmount; }
            set { _BalanceAmount = value; }
        }
        #endregion

        #region UserID
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion

        #region Freight
        public decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        #endregion

        #region Labour
        public decimal Labour
        {
            get { return _Labour; }
            set { _Labour = value; }
        }
        #endregion

        #region CollectedBy
        public string CollectedBy
        {
            get { return _CollectedBy; }
            set { _CollectedBy = value; }
        }
        #endregion

        #region DeliveryCh
        public decimal DeliveryCh
        {
            get { return _DeliveryCh; }
            set { _DeliveryCh = value; }
        }
        #endregion

        #region StationaryCh
        public decimal StationaryCh
        {
            get { return _StationaryCh; }
            set { _StationaryCh = value; }
        }
        #endregion

        #region Demurrage
        public decimal Demurrage
        {
            get { return _Demurrage; }
            set { _Demurrage = value; }
        }
        #endregion

        #region LocalCartage
        public decimal LocalCartage
        {
            get { return _LocalCartage; }
            set { _LocalCartage = value; }
        }
        #endregion

        #region ServiceTax
        public decimal ServiceTax
        {
            get { return _ServiceTax; }
            set { _ServiceTax = value; }
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
