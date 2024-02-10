namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface IReadById<T> where T : class
    {
        Task<T> ReadById(int id, CancellationToken cancellationToken = default);
    }
}
