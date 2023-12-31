using Bugeto_Test.Application.Interfaces.Context;
using Bugeto_Test.Application.Interfaces.FacadePatterns;
using Bugeto_Test.Application.Service.Products.FacadPattern;
using Bugeto_Test.Application.Service.Users.Commands.EditUser;
using Bugeto_Test.Application.Service.Users.Commands.RegisterUser;
using Bugeto_Test.Application.Service.Users.Commands.RemoveUser;
using Bugeto_Test.Application.Service.Users.Commands.UserLogin;
using Bugeto_Test.Application.Service.Users.Commands.UserStatusChange;
using Bugeto_Test.Application.Service.Users.Quereis.GetRoles;
using Bugeto_Test.Application.Service.Users.Quereis.GetUsers;
using Bugeto_Test.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace EndPoint.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(Option =>
            {
                Option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                Option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                Option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(Option =>
            {
                Option.LoginPath = new PathString("/");
                Option.ExpireTimeSpan = TimeSpan.FromDays(5.0);
            });




            builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
            builder.Services.AddScoped<IGetUsersService, GetUsersService>();
            builder.Services.AddScoped<IGetRolesService, GetRolesService>();
            builder.Services.AddScoped<IRegisterUserService,RegisterUserService>();
            builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
            builder.Services.AddScoped<IUserLoginService, UserLoginService>();
            builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
            builder.Services.AddScoped<IEditUserService, EditUserService>();

            //Facade Injection
            builder.Services.AddScoped<IProductFacade, ProductFacade>();



            string contectionString = @"Data Source=DESKTOP-O0PS2HE\SQLEXPRESS; Initial Catalog=Bugeto_StoreDb; Integrated Security=True;TrustServerCertificate=True";
            
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
            builder.Services.AddControllersWithViews();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
                 name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
    }
}