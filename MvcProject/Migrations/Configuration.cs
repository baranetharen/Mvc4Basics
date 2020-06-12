namespace MvcProject.Migrations
{
    using MvcProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcProject.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcProject.Models.OdeToFoodDb";
        }

        protected override void Seed(MvcProject.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name, new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
               new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
               new Restaurant
               {
                   Name = "Smaka",
                   City = "Gothenburg",
                   Country = "Sweden",
                   Reviews =
                       new List<RestaurantReview> {
                       new RestaurantReview { Rating = 9, Body="Great food!", ReviewerName="Scott"}
                   }
               });

            SeedMemberShip();
        }

        private void SeedMemberShip()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            var role = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!role.RoleExists("admin"))
            {
                role.CreateRole("admin");
            }
            if (membership.GetUser("barane", false) == null)
            {
                membership.CreateUserAndAccount("barane", "123456789");
            }
            if (!role.GetRolesForUser("barane").Contains("admin"))
            {
                role.AddUsersToRoles(new string[] { "barane" }, new string[] { "admin" });
            }
        }
    }
}
