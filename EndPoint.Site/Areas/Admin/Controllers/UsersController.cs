using Bugeto_Test.Application.Service.Users.Commands.EditUser;
using Bugeto_Test.Application.Service.Users.Commands.RegisterUser;
using Bugeto_Test.Application.Service.Users.Commands.RemoveUser;
using Bugeto_Test.Application.Service.Users.Commands.UserStatusChange;
using Bugeto_Test.Application.Service.Users.Quereis.GetRoles;
using Bugeto_Test.Application.Service.Users.Quereis.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetUsersService getUsersService,
                               IGetRolesService getRolesService,
                               IRegisterUserService registerUserService,
                               IRemoveUserService removeUserService,
                               IUserStatusChangeService userStatusChangeService,
                               IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userStatusChangeService = userStatusChangeService;
            _editUserService = editUserService;
        }

        [Area("Admin")]
        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDTO
            {

                Page = page,
                SearchKey = searchkey

            }));
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "ID", "Name");
            return View();

        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleID, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDTO
            {
                Email = Email,
                FullName = FullName,
                rols = new List<RolesInRegisterUserDTo>()
                {
                    new RolesInRegisterUserDTo
                   {
                        ID  = RoleID,
                   }

                },
                Password = Password,
                RePassword = RePassword

            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserID)
        {
            return Json(_removeUserService.Execute(UserID));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserID, string Fullname)
        {
            return Json(_userStatusChangeService.Execute(UserID));

        }

        [HttpPost]
        public IActionResult Edit(long UserID, string Fullname) 
        {
            return Json(_editUserService.Execute(new RequestEditUserDTO
            {
                UserID = UserID,
                Fullname = Fullname,
            }));
        
        }
    }
}
