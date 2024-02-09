using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface ILedenRepository : IReadAll<Lid>, ICreate<Lid>, IUpdate<Lid>, IDelete<Lid>, ISave
    { }
}
