namespace Domain.Models
{
    public class Comment : BaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid ArticleId { get; set; }
        public Guid? UserId { get; set; }
       
    }
}
