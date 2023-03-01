using BlogDemo.Application.Criterias;
using BlogDemo.Application.Features.Blogs.DTOs;
using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Features.Blogs.Queries
{
    public record GetBlogListQuery : IRequest<GetBlogListDTO>;

    internal class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, GetBlogListDTO>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogListQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogListDTO> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            BlogOrderedListCriteria criteria = new();
            List<GetBlogListItemDTO> list = await _repository.GetListAsync<GetBlogListItemDTO>(criteria);
            return new(list);
        }
    }
}
