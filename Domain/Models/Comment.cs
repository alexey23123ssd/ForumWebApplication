using Domain.Interfaces;

namespace Domain.Models
{
    public class Comment : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Guid ArticleId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
