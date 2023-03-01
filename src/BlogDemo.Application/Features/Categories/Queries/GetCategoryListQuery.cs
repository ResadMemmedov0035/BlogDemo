using BlogDemo.Application.Features.Categories.DTOs;
using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Features.Categories.Queries
{
    public record GetCategoryListQuery : IRequest<GetCategoryListDTO>;

    internal class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, GetCategoryListDTO>
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryListQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryListDTO> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            List<GetCategoryListItemDTO> list = await _repository.GetListAsync<GetCategoryListItemDTO>();
            return new(list);
        }
    }
}
