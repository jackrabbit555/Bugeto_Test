using Bugeto_Test.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugeto_Test.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Buget_Test.Common.Roles;
using Bugeto_Test.Domain.Entities.Products;


namespace Bugeto_Test.Persistence.Contexts
{
    public class DataBaseContext:DbContext ,IDataBaseContext
    {

        public DataBaseContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data
            seedData(modelBuilder);
            //اعمال ایندکس روی فیلد ایمیل
            //اعمال عدم یکتا بودن 
             modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
            //عدم نمایش اطلاعات حذف شده 
            ApplyQueryFilter(modelBuilder);

        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder) 
        {
            //فقط اونهایی رو برگردون که این فیلد مقدارش صحیح است 
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);

        }
        private void seedData(ModelBuilder modelBuilder) 
        {
            //افزودن مقادیر پیشفرض 
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Name = nameof(UserRoles.Oprator) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Name = nameof(UserRoles.Customer) });

        }
    }
}
