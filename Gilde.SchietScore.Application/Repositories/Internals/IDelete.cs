namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface IDelete<T> : ISave where T : class
    {
        void Delete(T entity);
    }
}
