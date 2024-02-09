namespace Gilde.SchietScore.Application.Repositories.Internals
{
    public interface ISave
    {
        Task Save(CancellationToken cancellationToken);
    }
}
