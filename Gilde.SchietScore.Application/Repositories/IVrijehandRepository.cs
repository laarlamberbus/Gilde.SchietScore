using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface IVrijehandRepository : 
        IReadById<Vrijehand>,
        ISave, 
        ICreate<Vrijehand>, 
        IUpdate<Vrijehand>, 
        IUpdate<IEnumerable<Vrijehand>>,
        IDelete<Vrijehand>
    {
        public Task<Vrijehand> ReadByDate(DateOnly dateOnly, CancellationToken cancellationToken = default);
    }
}
