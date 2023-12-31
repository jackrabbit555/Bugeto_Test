using Buget_Test.Common.DTO;
using Bugeto_Store.Common;
using Bugeto_Test.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Test.Application.Service.Users.Commands.UserLogin
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;

        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultUserLoginDTO> Execute(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName)||string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDTO<ResultUserLoginDTO>()
                {
                    Data = new ResultUserLoginDTO()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }
            var user = _context.Users
                .Include(p =>p.UserInRoles)
                .ThenInclude(p => p.Role)
                .Where(p =>  p.Email.Equals(UserName)   &&
                             p.IsActive    ==   true)
                .FirstOrDefault();

            if (user == null )
            {
                return new ResultDTO<ResultUserLoginDTO>()
                {
                    Data = new ResultUserLoginDTO()
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این ایمیل در سایت فروشگاه باگتو ثبت نام نکرده است",


                };
            }
            var passwordHasher = new PasswordHasher();
            bool resultVerifyPassword = passwordHasher.VerifyPassword(UserName, Password);
            if (resultVerifyPassword == false)
            {
                return new ResultDTO<ResultUserLoginDTO>()
                {
                    Data = new ResultUserLoginDTO() { },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",

                };
            }

            var roles = "";
            foreach (var item in user.UserInRoles)
            {
                roles += $"{item.Role.Name}";
            }
            return new ResultDTO<ResultUserLoginDTO>()
            {
                Data = new ResultUserLoginDTO()
                {
                    Roles = roles,
                    UserID = user.ID,
                    Name = user.FullNamee

                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",

            };
        }
    }
}
