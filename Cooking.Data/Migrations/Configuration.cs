namespace Cooking.Data.Migrations
{
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Cooking.Data.RecipesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "Cooking.Data.ApplicationDbContext";
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(RecipesDbContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("User");
                manager.Create(role);
            }

        }

    }
}
