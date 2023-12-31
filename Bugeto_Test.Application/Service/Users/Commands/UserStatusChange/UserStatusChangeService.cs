using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;

namespace Bugeto_Test.Application.Service.Users.Commands.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {

        private readonly IDataBaseContext _context;


        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(long UserID)
        {
            var user = _context.Users.Find(UserID);

            if (user == null)
            {
                return new ResultDTO() 
                { 
                IsSuccess = false,
                Message = "کاربر یافت نشد"
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDTO() 
            {
            IsSuccess = true,
            Message = $"کاربر با موفقیت {userstate} شد!",
            };
        }
    }


}
