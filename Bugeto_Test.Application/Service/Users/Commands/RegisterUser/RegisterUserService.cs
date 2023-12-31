using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;
using Bugeto_Test.Domain.Entities.Users;
using Bugeto_Store.Common;

namespace Bugeto_Test.Application.Service.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _Context;
        public RegisterUserService(IDataBaseContext context)
        {
            _Context = context;
        }

        public ResultDTO<ResultRegisterUserDTO> Execute(RequestRegisterUserDTO requset)
        {

            try
            {

                if (string.IsNullOrEmpty(requset.Email))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"


                    };
                }

                if (string.IsNullOrEmpty(requset.FullName))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }

                if (string.IsNullOrEmpty(requset.Password))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }

                if (requset.Password != requset.RePassword)
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"

                    };
                 
                
                }




                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(requset.Password);

                User user = new User()
                {
                    Email = requset.Email,
                    FullNamee = requset.FullName,
                    Passaword = hashedPassword,
                    IsActive = true,

                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in requset.rols)
                {
                    var roles = _Context.Roles.Find(item.ID);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.ID,
                        User = user,
                        UserId = user.ID

                    });
                }
                user.UserInRoles = userInRoles;
                _Context.Users.Add(user);
                _Context.SaveChanges();
                return new ResultDTO<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        UserID = user.ID,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد"

                };



            }
            catch (Exception)
            {

                return new ResultDTO<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        UserID = 0
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"

                };
            }




        }
    }
}
