using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs
{
    public class ThemeDTO : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20),MinLength(5)]
        public string Name { get; set; }
        [Required]
        [StringLength(150), MinLength(5)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}
