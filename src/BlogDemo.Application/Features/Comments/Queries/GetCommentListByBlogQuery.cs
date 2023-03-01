using BlogDemo.Application.Features.Comments.DTOs;
using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Features.Comments.Queries
{
    public record GetCommentListByBlogQuery(int BlogId) : IRequest<GetCommentListDTO>;

    internal class GetCommentListQueryHandler : IRequestHandler<GetCommentListByBlogQuery, GetCommentListDTO>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentListQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentListDTO> Handle(GetCommentListByBlogQuery request, CancellationToken cancellationToken)
        {
            List<GetCommentListItemDTO> list = await _repository.GetListAsync<GetCommentListItemDTO>(x => x.BlogId == request.BlogId);
            return new(list);
        }
    }
}
