namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface ICreate<T> : ISave where T : class
    {
        Task Create(T entity, CancellationToken cancellationToken = default);
    }
}
