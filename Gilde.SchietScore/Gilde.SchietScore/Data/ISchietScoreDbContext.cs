using Gilde.SchietScore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data
{
    public interface ISchietScoreDbContext
    {
        public DbSet<Lid> Leden { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
