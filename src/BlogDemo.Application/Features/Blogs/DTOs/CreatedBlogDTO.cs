namespace BlogDemo.Application.Features.Blogs.DTOs
{
    public record CreatedBlogDTO(int Id,
        string Title,
        DateTime CreatedOnUtc);
}
