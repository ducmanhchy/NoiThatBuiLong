using System;
using System.Linq;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Common;
using BlogSystem.Data.Models;

namespace BlogSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserManager<ApplicationUser> userManager;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            SeedSettings(context);
            SeedRoles(context);
            SeedAdmin(context);
        }

        private void SeedSettings(ApplicationDbContext context)
        {
            if (context.Settings.Any())
                return;

            context.Settings.Add(new Setting { Key = "Title", Value = "Nội Thất" });
            context.Settings.Add(new Setting { Key = "Description", Value = "Nội Thất" });
            context.Settings.Add(new Setting { Key = "Keywords", Value = "Nội Thất" });
            context.Settings.Add(new Setting { Key = "Author", Value = "MND" });
            context.Settings.Add(new Setting { Key = "Author_Email", Value = "ducmanhchy@gmail.com" });
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
                u => u.Name, 
                new IdentityRole(GlobalConstants.AdministratorRoleName),
                new IdentityRole(GlobalConstants.GuestRoleName)
            );

            context.SaveChanges();
        }

        private void SeedAdmin(ApplicationDbContext context)
        {
            if (context.Users.Any())
                return;

            var admin = new ApplicationUser
            {
                Email = "ducmanhchy@gmail.com",
                UserName = "admin",
                CreatedOn = DateTime.Now,
                UserCreate = "admin"
            };

            userManager.Create(admin, "123123");
            userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);
        }
    }
}