using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PraticeSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Admin.Security
{
    public class SecurityDBContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rolemanager.Create(new IdentityRole { Name = "Administrators" });
            rolemanager.Create(new IdentityRole { Name = "Staff Members" });

            var adminUser = new ApplicationUser
            {
                //ToDO: Move hard-coded values to web.config
                UserName = "WebAdmin",
                Email = "testemail@test.ca",
                EmailConfirmed = true
            };

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var result = userManager.Create(adminUser, "Password");
            if(result.Succeeded)
            {
                var adminId = userManager.FindByName("WebAdmin").Id;
                userManager.AddToRole(adminId, "Administrators");
            }

            var demoManager = new Controller();
            var people = demoManager.ListStaff();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@DemoIsland.com",
                    EmailConfirmed = true,
                    StaffId = person.StaffId
                };
                result = userManager.Create(user, "Password1");
                if(result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, "Staff Members");
                }
            }

            base.Seed(context);
        }
    }
}