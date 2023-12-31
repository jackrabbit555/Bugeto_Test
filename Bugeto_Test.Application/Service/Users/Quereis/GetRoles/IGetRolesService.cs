using Buget_Test.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Quereis.GetRoles
{
    public interface IGetRolesService
    {
        ResultDTO<List<RolsDTO>> Execute();

    }
}
