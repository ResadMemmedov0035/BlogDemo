using BlogDemo.Application.Features.Categories.DTOs;
using BlogDemo.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Web.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CategoriesViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetCategoryListDTO dto = await _mediator.Send(new GetCategoryListQuery());
            return View(dto.List);
        }
    }
}
