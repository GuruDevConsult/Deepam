using System.Xml.Serialization;

namespace BusinessObjects
{    
    public class UserObjects
    {
        #region Public Properties   
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
        public bool IsHiddenUser { get; set; }
        public string RoleName { get; set; }
        public string CompanyId { get; set; }
        public string BranchName { get; set; }
        #endregion
    }
}
