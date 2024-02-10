namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface ISave
    {
        Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
