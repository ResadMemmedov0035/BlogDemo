namespace BlogDemo.Application.Features.Blogs.DTOs
{
    public record GetBlogListItemDTO(int Id,
        string Title,
        string ShortContent,
        string ThumbnailImage,
        string CategoryName,
        DateTime CreatedOnUtc,
        int CommentCount)
    {
        // automapper requires parameterless ctor for mapping
        public GetBlogListItemDTO() : this(default, "", "", "", "", default, default) { }
    };
}
