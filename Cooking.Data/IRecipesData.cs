namespace Cooking.Data
{
    using Repositories;
    using Models;
    public interface IRecipesData
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Recipe> Recipes { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
