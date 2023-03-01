namespace BlogDemo.Application.Features.Comments.DTOs
{
    public record GetCommentListItemDTO(int Id,
        DateTime CreatedOnUtc,
        DateTime? ModifiedOnUtc,
        string CommentorName,
        string Content,
        int BlogId)
    {
        public GetCommentListItemDTO() : this(default, default, default, "", "", default) { }
    }
}
