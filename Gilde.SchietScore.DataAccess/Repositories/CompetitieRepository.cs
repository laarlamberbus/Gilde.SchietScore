using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence.Repositories
{
    public class CompetitieRepository : ICompetitieRepository
    {
        private readonly ISchietScoreDbContext _schietScoreDbContext;
        private readonly ICompetitieFactory _competitieFactory;

        public CompetitieRepository(
            ISchietScoreDbContext schietScoreDbContext,
            ICompetitieFactory competitieFactory)
        {
            _schietScoreDbContext = schietScoreDbContext;
            _competitieFactory = competitieFactory;
        }

        public async Task Create(Competitie entity, CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.Competities.AddAsync(_competitieFactory.CreateDto(entity));
        }

        public async Task<Competitie> GetHuidigeCompetitie()
        {
            return _competitieFactory.CreateModel(await _schietScoreDbContext.Competities.SingleOrDefaultAsync(c => c.IsActive && c.StartDatum.Year ==  DateTime.Now.Year));
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
