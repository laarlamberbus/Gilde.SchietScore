namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface IReadAll<T> where T : class
    {
        Task<IEnumerable<T>> ReadAll(CancellationToken cancellationToken = default);
    }
}
