namespace Cooking.Data
{
    using System.Data.Entity;
    using Models;
    public interface IRecipesDbContext
    {
        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }

        int SaveChanges();
    }
}
