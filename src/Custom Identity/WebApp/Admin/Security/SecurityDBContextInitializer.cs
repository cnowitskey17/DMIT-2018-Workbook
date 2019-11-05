using DemoSystem.BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
using static WebApp.Admin.Security.Settings;

namespace WebApp.Admin.Security
{
    //You can learn about Database Initializtion strategies in EF6 via
    // http://www.entityframworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

        /// <summary>Provide funcionality for setting up the database for the ApplicationDbContext. 
        /// The specific functionality is to create the database if it does not exist.</summary>
    public class SecurityDBContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // To "seed" a database is to provide it with some initial data when the databse is created.

            #region Seed the security roles
            //Make the identit's BLL instance to help us manage roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // The Rolemanager<T> and RoleStore<T> are BLL classes that give flexability to the design/structure of how we;re using Asp.Net Identity.
            //The IdentityRole is an Entity class that represents a securtiy role.

            // TODO: Move these hard-coded security roles to Web.config
            foreach(var role in DefaultSecurityRoles)
                roleManager.Create(new IdentityRole { Name = role });
            #endregion

            #region Seed the users
            // Create an Admin user
            var adminUser = new ApplicationUser
            {
                //ToDO: Move hard-coded values to web.config
                UserName = AdminUserName,
                Email = AdminEmail,
                EmailConfirmed = true
            };

            //Instantiate the BLL user manager
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            // - The aplicationUsermanager is a BLL class in this website's App_Start/IdeneityConfig.cs
            var result = userManager.Create(adminUser, AdminPassword); // TODO: Move password
            if(result.Succeeded)
            {
                //Get the Id that was generated for the user we created/added
                var adminId = userManager.FindByName(AdminUserName).Id;
                //Add the user to Administratiors role
                userManager.AddToRole(adminId, AdminRole);
            }

            //Create the other user accounts for all the people in my Demo database
            var demoManager = new DemoController();
            var people = demoManager.ListPeople();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@DemoIsland.com",
                    EmailConfirmed = true,
                    PersonId = person.PersonID
                };
                result = userManager.Create(user, TempPassword);
                if(result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, UserRole);
                }
            }
            #endregion
            // Note: keep this call to the case class so it can do its seeding work 
            base.Seed(context);
        }
    }
}