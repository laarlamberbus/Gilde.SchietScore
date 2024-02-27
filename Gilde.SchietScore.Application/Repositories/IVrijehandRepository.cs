using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface IVrijehandRepository : 
        IReadById<Vrijehand>,
        ISave, 
        IUpdate<Vrijehand>, 
        IUpdate<IEnumerable<Vrijehand>>,
        IDelete<Vrijehand>
    {
        public Task<Vrijehand> ReadByDate(DateOnly dateOnly, CancellationToken cancellationToken = default);
        public Task<Vrijehand> ReadLatest(CancellationToken cancellationToken = default);
        public Task<Vrijehand> ReadWedstrijddag(DeelnemerKlasseType klasse, DateOnly dateOnly, CancellationToken cancellationToken = default);
        public Task<List<DateOnly>> ReadAlleWedstrijdagenPerJaar(int jaar, CancellationToken cancellationToken = default);
        public Task<List<int>> ReadAlleWedstrijdJaren(CancellationToken cancellationToken = default);
        public Task RegisterNewResultaatVrijehand(Schutter schutter, DateOnly wedstrijddag, CancellationToken cancellationToken = default);
    }
}