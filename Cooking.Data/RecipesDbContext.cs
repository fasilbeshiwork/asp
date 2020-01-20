namespace Cooking.Data
{
    using Models;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Cooking.Data.Migrations;
    public class RecipesDbContext : IdentityDbContext<User>, IRecipesDbContext
    {
        public RecipesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RecipesDbContext, Configuration>());
        }

        public static RecipesDbContext Create()
        {
            return new RecipesDbContext();
        }

        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<Vote> Votes { get; set; }


    }
}
