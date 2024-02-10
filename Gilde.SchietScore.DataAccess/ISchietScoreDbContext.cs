using Gilde.SchietScore.Persistence.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence
{
    public interface ISchietScoreDbContext
    {
        public DbSet<LidDto> Leden { get; set; }
        public DbSet<CompetitieDto> Competities { get; set; }
        public DbSet<WedstrijdDto> Wedstrijden { get; set; }
        public DbSet<ResultaatDto> Resultaten { get; set; }
        public DbSet<KorpsDto> Korpsen { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
