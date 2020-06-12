using System.Data.Entity;

namespace MvcProject.Models
{
    public class OdeToFoodDb : DbContext
    {
        public OdeToFoodDb():base("name=DefaultConnection")
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}