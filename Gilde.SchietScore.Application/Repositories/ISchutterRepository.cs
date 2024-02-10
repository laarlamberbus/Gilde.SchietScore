using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface ISchutterRepository : 
        IReadAll<Schutter>, 
        IReadById<Schutter>,
        ISave, 
        ICreate<Schutter>, 
        IUpdate<Schutter>, 
        IUpdate<IEnumerable<Schutter>>,
        IDelete<Schutter>
    {
    }
}
