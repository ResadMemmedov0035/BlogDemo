using BlogDemo.Domain.Exceptions;

namespace BlogDemo.Web.ErrorHandling
{
    public class MvcExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public static bool IsDevelopment { get; set; } = true;

        public MvcExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                if (IsDevelopment && exception is not NotFoundException and not BusinessException) throw;

                await new MvcExceptionHandler(context).HandleAsync(exception);
            }
        }
    }
}
