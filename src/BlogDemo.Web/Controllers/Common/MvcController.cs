using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Web.Controllers.Common
{
    /// <summary>
    /// Custom base controller. Provides commonly used services. Ex.: Mediator
    /// </summary>
    public abstract class MvcController : Controller
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
