﻿namespace Domain.Models
{
    public class Theme : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Article>? Articles { get; set; }
       
    }
}
