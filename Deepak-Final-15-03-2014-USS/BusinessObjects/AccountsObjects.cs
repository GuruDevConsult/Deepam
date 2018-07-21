using System;

namespace BusinessObjects
{
    public class AccountsObjects
    {
        #region Public Properties
        public int Id { get; set; }
        public Identifier Company { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }        
        public DateTime ModifyAt { get; set; }
        public string ModifyBy { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public Identifier State { get; set; }
        public int Pincode { get; set; }
        public string PanItNo { get; set; }
        public string SalesTaxNo { get; set; }
        public Identifier Group { get; set; }
        public bool IsHiddenUser { get; set; }
        public string City { get; set; }
        public string BranchName { get; set; }
        #endregion
    }
}
