using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence.Repositories
{
    public class ResultaatRepository : IResultaatRepository
    {
        private readonly ISchietScoreDbContext _schietScoreDbContext;
        private readonly IResultaatFactory _resultaatFactory;

        public ResultaatRepository(
            ISchietScoreDbContext schietScoreDbContext,
            IResultaatFactory resultaatFactory)
        {
            _schietScoreDbContext = schietScoreDbContext;
            _resultaatFactory = resultaatFactory;
        }

        public async Task Create(Vrijehand entity, CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.Resultaten.AddRangeAsync(_resultaatFactory.CreateDto(entity), cancellationToken);
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<Vrijehand> ReadLatest(int wedstrijdId, CancellationToken cancellationToken = default)
        {
            return _resultaatFactory.CreateModel(await _schietScoreDbContext.Resultaten.Where(r => r.WedstrijdId == wedstrijdId).ToListAsync(cancellationToken));
        }
    }
}
