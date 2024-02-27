using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Builders.Interfaces;
using Gilde.SchietScore.Persistence.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence.Repositories
{
    public class SchutterRepository : ISchutterRepository
    {
        private readonly ISchietScoreDbContext _schietScoreDbContext;
        private readonly ISchutterFactory _schutterFactory;
        private readonly ISchutterBuilder _schutterBuilder;

        public SchutterRepository(
            ISchietScoreDbContext schietScoreDbContext,
            ISchutterFactory schutterFactory,
            ISchutterBuilder schutterBuilder)
        {
            _schietScoreDbContext = schietScoreDbContext;
            _schutterFactory = schutterFactory;
            _schutterBuilder = schutterBuilder;
        }

        public async Task Create(Schutter entity, CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.Leden.AddAsync(_schutterFactory.CreateDto(entity), cancellationToken);
        }

        public async Task<IEnumerable<Schutter>> ReadAll(CancellationToken cancellationToken = default)
        {
            return _schutterFactory.CreateModels(await _schietScoreDbContext.Leden.Where(l => l.IsSchietendLid).ToListAsync(cancellationToken));
        }

        public async Task Update(IEnumerable<Schutter> entities, CancellationToken cancellationToken = default)
        {
            foreach (var schutter in entities)
            {
                await Update(schutter, cancellationToken);
            }
        }

        public async Task Update(Schutter entity, CancellationToken cancellationToken = default)
        {
            var schutterToPersist = await _schietScoreDbContext.Leden.FindAsync(entity.Id, cancellationToken);

            if(schutterToPersist != null)
                _schutterBuilder.BuildDto(schutterToPersist, entity);
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _schietScoreDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await _schietScoreDbContext.Leden.FindAsync(id, cancellationToken);
            
            if (entityToDelete != null)
                entityToDelete.SoftDeleted = true;
        }

        public async Task<Schutter> ReadById(int id, CancellationToken cancellationToken = default)
        {
            return _schutterFactory.CreateModel(await _schietScoreDbContext.Leden.FindAsync(id, cancellationToken));
        }
    }
}
