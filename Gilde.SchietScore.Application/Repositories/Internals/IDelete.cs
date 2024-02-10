namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface IDelete<T> : ISave where T : class
    {
        Task Delete(int id, CancellationToken cancellationToken = default);
    }
}
