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
        public Task<Vrijehand> ReadWedstrijddag(DeelnemerKlasse klasse, DateOnly dateOnly, CancellationToken cancellationToken = default);
        public Task<List<DateOnly>> ReadAlleWedstrijdagenPerJaar(int jaar, CancellationToken cancellationToken = default);
        public Task<List<int>> ReadAlleWedstrijdJaren(CancellationToken cancellationToken = default);
        public Task RegisterNewResultaatVrijehand(Schutter schutter, DateOnly wedstrijddag, CancellationToken cancellationToken = default);
    }
}
