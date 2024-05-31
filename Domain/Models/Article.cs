using Domain.Interfaces;

namespace Domain.Models
{
    public class Article : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Guid ThemeId { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
