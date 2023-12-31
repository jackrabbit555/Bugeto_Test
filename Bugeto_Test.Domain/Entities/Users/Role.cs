using Bugeto_Test.Domain.Entities.Common;

namespace Bugeto_Test.Domain.Entities.Users
{
    public class Role:BaseEntity
    {
        public long ID { get; set; }
        public string  Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }


    }


}
