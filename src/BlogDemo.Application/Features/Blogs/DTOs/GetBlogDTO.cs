namespace BlogDemo.Application.Features.Blogs.DTOs
{
    public record GetBlogDTO(int Id,
        string Title,
        string Content,
        string ThumbnailImage,
        string Image,
        string CategoryName,
        DateTime CreatedOnUtc,
        int CommentCount)
    {
        public GetBlogDTO() : this(default, "", "", "", "", "", default, default) { }
    };
}
