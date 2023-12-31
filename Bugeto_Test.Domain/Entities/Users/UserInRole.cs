using Bugeto_Test.Domain.Entities.Common;

namespace Bugeto_Test.Domain.Entities.Users
{
    public class UserInRole:BaseEntity
    {
        public long ID { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }

       

        public virtual Role Role { get; set; }
        public long RoleId { get; set; }

    }


}
