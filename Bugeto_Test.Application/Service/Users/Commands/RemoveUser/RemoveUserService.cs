using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext context) 
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
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDTO()
            {

                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
