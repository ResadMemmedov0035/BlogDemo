using BlogDemo.Application.ErrorHandling;
using BlogDemo.Domain.Exceptions;

namespace BlogDemo.Web.ErrorHandling
{
    public class MvcExceptionHandler : ExceptionHandler
    {
        private readonly HttpContext _context;

        public MvcExceptionHandler(HttpContext context)
        {
            _context = context;
        }

        protected override Task HandleBusiness(BusinessException exception)
        {
            _context.Response.Redirect($"/Error/Alert?redirectTo={_context.Request.Path}&message={exception.Message}");
            return Task.CompletedTask;
        }

        protected override Task HandleNotFound(NotFoundException exception)
        {
            _context.Response.Redirect($"/NotFound");
            return Task.CompletedTask;
        }

        protected override Task HandleDefault(Exception exception)
        {
            _context.Response.Redirect($"/Error");
            return Task.CompletedTask;
        }
    }
}
