using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class LedgerAccountObjects
    {
        public string Date { get; set; }
        public string Date1 { get; set; }
        public string CloseDate { get; set; }
        public string Particular { get; set; }
        public string Particular1 { get; set; }
        public double TotalShort { get; set; }
        public double ShortAmount { get; set; }
        public double Dr { get; set; }
        public double Cr { get; set; }
    }

    public class TrialBalanceObjects
    {
        public int ID { get; set; }        
        public string Particular { get; set; }
        public double Dr { get; set; }
        public double Cr { get; set; }
    }

    public class BalanceSheetObjects
    {
        public int ID { get; set; }
        public string Particular { get; set; }
        public double Dr { get; set; }
        public double Cr { get; set; }
    }

    public class FinancialYears
    {
        public int ID { get; set; }
        public string years { get; set; }
    }

    public class MonthlyTrialBalanceObjects
    {
        public int ID { get; set; }
        public string Particular { get; set; }
        public double Dr { get; set; }
        public double Cr { get; set; }
    }
}
