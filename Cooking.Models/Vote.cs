using System.ComponentModel.DataAnnotations;

namespace Cooking.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
