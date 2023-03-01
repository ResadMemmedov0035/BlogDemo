using AutoMapper;
using BlogDemo.Application.Features.Blogs.DTOs;
using BlogDemo.Application.Guards;
using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Features.Blogs.Commands
{
    public record CreateBlogCommand(string Title, string Content, string ThumbnailImage, string Image, int CategoryId) : IRequest<CreatedBlogDTO>;

    internal class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreatedBlogDTO>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedBlogDTO> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(request);

            await Guard.Blog.AgainstTitleDuplication(blog, _repository);

            Blog created = await _repository.CreateAsync(blog);
            return _mapper.Map<CreatedBlogDTO>(created);
        }
    }
}
