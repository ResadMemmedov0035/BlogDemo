namespace BlogDemo.Application.ErrorHandling
{
    public abstract class ExceptionHandler
    {
        public Task HandleAsync(Exception exception)
        {
            // TODO: Can be added Authorization and Validation exceptions
            return exception switch
            {
                BusinessException businessException => HandleBusiness(businessException),
                NotFoundException notFoundException => HandleNotFound(notFoundException),
                _ => HandleDefault(exception)
            };
        }

        protected abstract Task HandleBusiness(BusinessException exception);
        protected abstract Task HandleNotFound(NotFoundException exception);
        protected abstract Task HandleDefault(Exception exception);
    }
}
