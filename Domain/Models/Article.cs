namespace Domain.Models
{
    public class Article : BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid ThemeId { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        
    }
}
