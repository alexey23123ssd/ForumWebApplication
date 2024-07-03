namespace Domain.Models
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Theme? Theme { get; set; }
        public ICollection<Article>? Articles { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
