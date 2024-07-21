using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs
{
    public class ArticleDTO : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Title { get; set; }
        [Required]
        [StringLength(300), MinLength(10)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
