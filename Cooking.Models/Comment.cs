namespace Cooking.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
