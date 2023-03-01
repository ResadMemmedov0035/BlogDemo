using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Guards
{
    public class BlogGuard 
    {
        private BlogGuard() { }
    }

    public static class BlogGuardExtensions
    {
        public static async Task AgainstTitleDuplication(this BlogGuard _, Blog blog, IRepository<Blog> repository)
        {
            if (await repository.AnyAsync(x => x.Title == blog.Title))
                throw new BusinessException("A blog already exists on this title.");
        }
    }
}
