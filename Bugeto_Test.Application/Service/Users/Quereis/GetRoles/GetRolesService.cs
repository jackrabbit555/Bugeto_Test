using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Quereis.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<RolsDTO>> Execute()
        {
           var rols = _context.Roles.ToList().Select(p=>new RolsDTO 
           {
               ID = p.ID,
               Name = p.Name,
           }).ToList();
            return new ResultDTO<List<RolsDTO>>()
            {
                Data = rols,
                IsSuccess = true,
                Message = "",
            };
        }
    }


}
