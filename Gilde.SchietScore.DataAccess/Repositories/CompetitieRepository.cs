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
            var comp = _competitieFactory.CreateDto(entity);
            await _schietScoreDbContext.Competities.AddAsync(comp);
        }

        public async Task<Competitie> GetHuidigeCompetitie(CancellationToken cancellationToken = default)
        {
            var huidigeCompetitie = await _schietScoreDbContext.Competities.SingleOrDefaultAsync(c => c.IsActive && c.StartDatum.Year == DateTime.Now.Year, cancellationToken);
            return _competitieFactory.CreateModel(huidigeCompetitie);
        }

        public async Task HuidigeCompetitieAfronden(Competitie competitie)
        {
            var competitieDto = await _schietScoreDbContext.Competities.FindAsync(competitie.Id);
            competitieDto.IsActive = false;
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
