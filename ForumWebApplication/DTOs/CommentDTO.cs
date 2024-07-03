using Domain;
using System.ComponentModel.DataAnnotations;

namespace ForumWebApplication.DTOs
{
    public class CommentDTO : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
