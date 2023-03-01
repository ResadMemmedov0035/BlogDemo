namespace BlogDemo.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        // this property probably will change as User in the future
        public string CommentorName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }
}
