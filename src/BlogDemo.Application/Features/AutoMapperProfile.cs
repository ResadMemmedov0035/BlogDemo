using AutoMapper;
using BlogDemo.Application.Features.Blogs.Commands;
using BlogDemo.Application.Features.Blogs.DTOs;
using BlogDemo.Application.Features.Categories.DTOs;
using BlogDemo.Application.Features.Comments.DTOs;

namespace BlogDemo.Application.Features
{
    // TODO: Can be added Validation, Caching, Logging, Authorization, Performance, Transaction pipelines

    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Blog

            CreateProjection<Blog, GetBlogDTO>()
                .ForMember(dto => dto.CategoryName, cfg => cfg.MapFrom(b => b.Category.Name))
                .ForMember(dto => dto.CommentCount, cfg => cfg.MapFrom(b => b.Comments.Count));

            CreateProjection<Blog, GetBlogListItemDTO>()
                .ForMember(dto => dto.ShortContent, cfg => cfg.MapFrom(b => b.Content.Substring(0, 100)))
                .ForMember(dto => dto.CommentCount, cfg => cfg.MapFrom(b => b.Comments.Count));

            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<Blog, CreatedBlogDTO>();
            #endregion

            #region Category

            CreateProjection<Category, GetCategoryListItemDTO>()
                .ForMember(dto => dto.BlogCount, opt => opt.MapFrom(c => c.Blogs.Count));
            #endregion

            #region Comment

            CreateProjection<Comment, GetCommentListItemDTO>();
            #endregion
        }
    }
}
