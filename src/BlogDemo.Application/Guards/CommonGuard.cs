namespace BlogDemo.Application.Guards
{
    public class CommonGuard 
    {
        private CommonGuard() { }
    }

    public static class CommonGuardExtensions
    {
        public static T AgainstNull<T>(this CommonGuard _, T? argument, string? argName = null) where T : class
        {
            if (argument is null)
            {
                throw new NotFoundException($"{argName ?? typeof(T).Name} was not found.");
            }
            return argument;
        }
    }
}
