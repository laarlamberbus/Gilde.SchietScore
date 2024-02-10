namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface IUpdate<T> : ISave where T : class
    {
        Task Update(T entity, CancellationToken cancellationToken = default);
    }
}
