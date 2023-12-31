using Buget_Test.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDTO<ResultUserLoginDTO> Execute(string UserName, string Password);

    }




    public class ResultUserLoginDTO 
    {
        public long UserID { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }

    }
}
