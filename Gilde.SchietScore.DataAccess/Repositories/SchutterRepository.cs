using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence.Repositories
{
    public class SchutterRepository : ISchutterRepository
    {
        private readonly ISchietScoreDbContext _schietScoreDbContext;
        private readonly ISchutterFactory _schutterFactory;

        public SchutterRepository(
            ISchietScoreDbContext schietScoreDbContext,
            ISchutterFactory schutterFactory)
        {
            _schietScoreDbContext = schietScoreDbContext;
            _schutterFactory = schutterFactory;
        }

        public async Task<IEnumerable<Schutter>> ReadAll()
        {
            return _schutterFactory.CreateModels(await _schietScoreDbContext.Leden.ToListAsync());
        }
    }
}
