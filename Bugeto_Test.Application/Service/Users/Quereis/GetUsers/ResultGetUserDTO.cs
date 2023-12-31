using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Users.Quereis.GetUsers
{
    public class ResultGetUserDTO()
    {
        public List<GetUsersDTO> Users { get; set; }
        public int Rows { get; set; }

    }
}
