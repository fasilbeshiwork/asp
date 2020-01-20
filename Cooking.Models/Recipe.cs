namespace Cooking.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Recipe
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Recipe()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

    }
}
