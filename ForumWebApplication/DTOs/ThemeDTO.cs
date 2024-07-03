using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ForumWebApplication.DTOs
{
    public class ThemeDTO : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20),MinLength(5)]
        public string Name { get; set; }
        [Required]
        [StringLength(150), MinLength(5)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
