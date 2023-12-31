using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Service.Users.Commands.RegisterUser;
using Bugeto_Test.Application.Service.Users.Commands.UserLogin;
using EndPoint.Site.Areas.Admin.Models.ViewModels.AuthenticationViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;

        public AuthenticationController(IRegisterUserService registerUserService,
                                         IUserLoginService userLoginService)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
        }





        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignupViewModel request)
        {
            if
                (
                string.IsNullOrEmpty(request.FullName) ||
                string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.RePassword)
                )
            {

                return Json(new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لطفا تمامی موارد رو ارسال نمایید"
                });
            }
            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDTO
                {
                    IsSuccess = false,
                    Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید"
                });
            }
            if (request.Password != request.Password)
            {
                return Json(new ResultDTO
                {
                    IsSuccess = false,
                    Message = "رمز عبور و تکرار آن برابر نیست",
                });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDTO
                {
                    IsSuccess = false,
                    Message = "رمز عبور باید حداقل 8 کاراکتر باشد"
                });
            }
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDTO()
                {
                    IsSuccess = true,
                    Message = "ایمیل خودرا به درستی وارد نمایید"
                });
            }

            var signeupResult = _registerUserService.Execute(new RequestRegisterUserDTO
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RePassword = request.RePassword,
                rols = new List<RolesInRegisterUserDTo>()
                {
                    new RolesInRegisterUserDTo{ID = 3 },
                }


            });
            if (signeupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.UserID.ToString()),
                    new Claim(ClaimTypes.Email , request.Email),
                    new Claim(ClaimTypes.Name ,request.FullName),
                    new Claim(ClaimTypes.Role , "Customer"),

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,

                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signeupResult);


        }
        public IActionResult SignIn(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string Email, string Password, string url = "/")
        {
            var signupResult = _userLoginService.Execute(Email, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserID.ToString()),
                    new Claim(ClaimTypes.Email,Email),
                    new Claim(ClaimTypes.Name,signupResult.Data.Name),
                    new Claim(ClaimTypes.Role,signupResult.Data.Roles),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),

                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signupResult);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
