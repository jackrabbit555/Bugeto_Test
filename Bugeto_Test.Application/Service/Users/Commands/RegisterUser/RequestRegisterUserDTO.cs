namespace Bugeto_Test.Application.Service.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }


        public List<RolesInRegisterUserDTo> rols { get; set; }

    }
}
