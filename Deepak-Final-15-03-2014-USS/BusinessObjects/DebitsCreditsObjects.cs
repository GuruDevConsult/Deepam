using System;

namespace BusinessObjects
{
    public class DebitsCreditsObjects
    {
        #region Public Properties
        public int Id { get; set; }
        public string Date { get; set; }
        public string Date1 { get; set; }
        public string CloseDate { get; set; }
        public Identifier Account { get; set; }
        public double Amount { get; set; }
        public double Amount1 { get; set; }
        public double ShortAmount { get; set; }
        public double TotalShort { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyAt { get; set; }
        public string ModifyBy { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public string Type1 { get; set; }
        public string Particular { get; set; }
        public string Particular1 { get; set; }
        public bool IsHiddenUser { get; set; }
        public string RelationAccount { get; set; }
        public long EntryItemCount { get; set; }
        public string BranchName { get; set; }

        #endregion
    }
}
