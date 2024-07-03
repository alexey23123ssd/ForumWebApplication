using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ForumWebApplication.DTOs
{
    public class ArticleDTO : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Title { get; set; }
        [Required]
        [StringLength(300), MinLength(10)]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
