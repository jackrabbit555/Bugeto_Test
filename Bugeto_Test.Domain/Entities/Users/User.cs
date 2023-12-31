using Bugeto_Test.Domain.Entities.Common;

namespace Bugeto_Test.Domain.Entities.Users
{
    public class User:BaseEntity
    {
       
        public string FullNamee { get; set; }
        public string Email { get; set; }
        public string Passaword { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
        public bool IsActive { get; set; }



    }


}
