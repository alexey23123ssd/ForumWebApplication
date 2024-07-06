using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs
{
    public class UserDTO : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [StringLength(30), MinLength(8)]
        public string Email { get; set; }
        [Required]
        [StringLength(20), MinLength(8)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}
