﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebShop_Mobile.Models;

[assembly: OwinStartupAttribute(typeof(WebShop_Mobile.Startup))]
namespace WebShop_Mobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminUser();
        }

        private static void CreateAdminUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (roleManager.RoleExists("Admin"))
            {
                //var role = new IdentityRole();
                //role.Name = "Admin";
                //roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "Admin@Admin.com";
                user.Email = "Admin@Admin.com";

                string userPWD = "password";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
        }
    }
}
