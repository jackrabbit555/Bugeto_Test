using Bugeto_Test.Application.Interfaces.Context;
using Buget_Test.Common;

namespace Bugeto_Test.Application.Service.Users.Quereis.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDTO Execute(RequestGetUserDTO request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullNamee.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
            }



            int rowsCount = 0;
            var userList =  users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDTO
            {
                Email = p.Email,
                FullNamee = p.FullNamee,
                ID = p.ID,
                IsActive = p.IsActive,
            }).ToList();

            return new ResultGetUserDTO
            {
                Rows = rowsCount,
                Users = userList,

            };
        }
    }
}
