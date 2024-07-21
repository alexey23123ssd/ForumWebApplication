using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs
{
    public class CommentDTO : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}
