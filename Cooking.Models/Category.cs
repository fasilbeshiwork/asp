namespace Cooking.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        private ICollection<Recipe> recipes;

        public Category()
        {
            this.recipes = new HashSet<Recipe>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
