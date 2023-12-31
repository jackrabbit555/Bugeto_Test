using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDTO Execute(RequestEditUserDTO request);
        
    }

    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEditUserDTO request) 
        {
            var user = _context.Users.Find(request.UserID);
            if (user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullNamee = request.Fullname;
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"

            };
        }

    }
     
    

    public class RequestEditUserDTO 
        {
        public long UserID { get; set; }    
        public string Fullname { get; set; }

        }


}
