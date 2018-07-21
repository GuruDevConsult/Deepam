using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
 public  class PaymentsDTO
 {
     #region variables
     private string _Customer;
     private string _Type;
     private string _Agent;
     private string _Transport;
     private string _PartyName;
     private string _CollectedBy;
     private string  _InvoiceNo;
     private DateTime _PaidDate;
     private decimal _PaidAmount;
     private decimal _Amount;
     private decimal _BalanceAmount;
     private decimal _TotalBalance;
     private string _PaymentMode;
     private int  _ChequeNo;	
	 private DateTime _ChequeDate;
     private DateTime _FromDate;
     private DateTime _ToDate;
	 private string  _BankName;
     private string _UserID;
     private int _InvoiceID;
     private int _PaymentsID;
     private string _MRNO;
     private string _BranchName;
     #endregion

     #region UserID
     public string UserID
     {
         get { return _UserID; }
         set { _UserID = value; }
     }

     #endregion

     #region InvoiceID
     public int InvoiceID
     {
         get { return _InvoiceID; }
         set { _InvoiceID = value; }
     }

     #endregion

     #region PaymentsID
     public int PaymentsID
     {
         get { return _PaymentsID; }
         set { _PaymentsID = value; }
     }

     #endregion


     #region Type
     public string Type
     {
         get { return _Type; }
         set { _Type = value; }
     }

     #endregion

     #region MRNO
     public string MRNO
     {
         get { return _MRNO; }
         set { _MRNO = value; }
     }

     #endregion

     #region Customer
     public string Customer
     {
         get { return _Customer; }
         set { _Customer = value; }
     }

     #endregion

     #region Agent
     public string Agent
     {
         get { return _Agent; }
         set { _Agent = value; }
     }

     #endregion

     #region Transport
     public string Transport
     {
         get { return _Transport; }
         set { _Transport = value; }
     }

     #endregion

     #region PartyName
     public string PartyName
     {
         get { return _PartyName; }
         set { _PartyName = value; }
     }

     #endregion

     #region CollectedBy
     public string CollectedBy
     {
         get { return _CollectedBy; }
         set { _CollectedBy = value; }
     }

     #endregion

     #region InvoiceNo
     public string  InvoiceNo
     {
         get { return _InvoiceNo; }
         set { _InvoiceNo = value; }
     }
     #endregion

     #region PaidDate
     public DateTime PaidDate
     {
         get { return _PaidDate; }
         set { _PaidDate = value; }
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

     #region PaidAmount
     public decimal PaidAmount
     {
         get { return _PaidAmount; }
         set { _PaidAmount = value; }
     }
     #endregion

     #region Amount
     public decimal Amount
     {
         get { return _Amount; }
         set { _Amount = value; }
     }
     #endregion

     #region BalanceAmount
     public decimal BalanceAmount
     {
         get { return _BalanceAmount; }
         set { _BalanceAmount = value; }
     }
     #endregion

     #region TotalBalance
     public decimal TotalBalance
     {
         get { return _TotalBalance; }
         set { _TotalBalance = value; }
     }
     #endregion

     #region PaymentMode
     public string PaymentMode
     {
         get { return _PaymentMode; }
         set { _PaymentMode = value; }
     }
     #endregion

     #region ChequeNo
     public int ChequeNo
     {
         get { return _ChequeNo; }
         set { _ChequeNo = value; }
     }
     #endregion

     #region ChequeDate
     public DateTime ChequeDate
     {
         get { return _ChequeDate; }
         set { _ChequeDate = value; }
     }
     #endregion

     #region BankName
     public string  BankName
     {
         get { return _BankName; }
         set { _BankName = value; }
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
