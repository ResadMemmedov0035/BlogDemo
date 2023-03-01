namespace BlogDemo.Domain.Entities
{
    public class Blog : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ThumbnailImage { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
