using Gilde.SchietScore.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data
{
    public interface ISchietScoreDbContext
    {
        public DbSet<LidDto> Leden { get; set; }
        public DbSet<CompetitieDto> Competities { get; set; }
        public DbSet<WedstrijdDto> Wedstrijden { get; set; }
        public DbSet<WedstrijdScoreDto> WedstrijdScores { get; set; }
        public DbSet<KorpsDto> Korpsen { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
