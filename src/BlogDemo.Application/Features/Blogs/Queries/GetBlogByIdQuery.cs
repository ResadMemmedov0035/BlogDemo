using BlogDemo.Application.Features.Blogs.DTOs;
using BlogDemo.Application.Guards;
using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Features.Blogs.Queries
{
    public record GetBlogByIdQuery(int Id) : IRequest<GetBlogDTO>;

    internal class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogDTO>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogDTO> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            GetBlogDTO? blog = await _repository.GetAsync<GetBlogDTO>(x => x.Id == request.Id);
            return Guard.Common.AgainstNull(blog, "Blog");
        }
    }
}
