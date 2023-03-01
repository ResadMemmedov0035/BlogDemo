namespace BlogDemo.Application.Features.Categories.DTOs
{
    public record GetCategoryListItemDTO(int Id, string Name, int BlogCount)
    {
        public GetCategoryListItemDTO() : this(default, "", default) { }
    }
}
