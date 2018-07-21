
namespace BusinessObjects
{
    public class CompanyObjects
    {
        private Identifier _objState = default(Identifier);

        #region Public Properties
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyAt { get; set; }
        public string ModifyBy { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string MailingName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Maintain { get; set; }
        public string FinancialStart { get; set; }
        public string BooksStart { get; set; }
        public string BranchName { get; set; }
        public Identifier objState
        {
            get
            {
                return _objState;
            }
            set
            {
                _objState = value;
            }
        }
        #endregion
    }
}
