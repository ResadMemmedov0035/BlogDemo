namespace BlogDemo.Application.Interfaces
{
    public interface ICriteria<T>
    {
        IQueryable<T> Build(IQueryable<T> query);
    }
}
