using BlogDemo.Application.Interfaces;

namespace BlogDemo.Application.Guards
{
    public class CategoryGuard 
    {
        private CategoryGuard() { }
    }

    public static class CategoryGuardExtensions
    {
        public static async Task AgainstNameDuplication(this CategoryGuard _, Category category, IRepository<Category> repository)
        {
            if (await repository.AnyAsync(x => x.Name == category.Name))
                throw new BusinessException("A category already exists on this name.");
        }
    }
}
