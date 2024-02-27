using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface IResultaatRepository :
        ICreate<Vrijehand>
    {
        public Task<Vrijehand> ReadLatest(int wedstrijdId, CancellationToken cancellationToken = default);
    }
}
