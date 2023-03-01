using BlogDemo.Application.Features.Comments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Web.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CommentsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var dto = await _mediator.Send(new GetCommentListByBlogQuery(blogId));
            return View(dto.List);
        }
    }
}
