using System.Collections.Generic;

namespace Cooking.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    public class User : IdentityUser
    {
        private ICollection<Recipe> recipes;

        public User()
        {
            this.recipes = new HashSet<Recipe>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
