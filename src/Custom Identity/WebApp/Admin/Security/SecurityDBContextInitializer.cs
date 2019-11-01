using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Admin.Security
{
    //You can learn about Database Initializtion strategies in EF6 via
    // http://www.entityframworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

        /// <summary>Provide funcionality for setting up the database for the ApplicationDbContext. The specific functionality is to create the database if it does not exist.</summary>
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

            // TODO: Move these hard-coded security roles to Wev.config
            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });
            #endregion

            #region Seed the users
            #endregion
            // Note: keep this call to the case class so it can do its seeding work 
            base.Seed(context);
        }
    }
}