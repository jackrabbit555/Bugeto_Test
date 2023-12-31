using Buget_Test.Common.DTO;
using Buget_Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDTO<ResultRegisterUserDTO> Execute(RequestRegisterUserDTO requset);

    }
}
