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

        public async Task CompetitieAfronden(Competitie competitie, CancellationToken cancellationToken = default)
        {
            var result = await _schietScoreDbContext.Competities.FindAsync(competitie.Id);
            result.IsAfgerond = true;
        }

        public async Task CompetitieStarten(Competitie competitie, CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.Competities.AddAsync(_competitieFactory.CreateDto(competitie));
        }

        public async Task<Competitie> LaadHuidigeCompetitie(CancellationToken cancellationToken = default)
        {
            return _competitieFactory.CreateModel(await _schietScoreDbContext.Competities.SingleOrDefaultAsync(c => !c.IsAfgerond));
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
