namespace BlogDemo.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
    }
}
