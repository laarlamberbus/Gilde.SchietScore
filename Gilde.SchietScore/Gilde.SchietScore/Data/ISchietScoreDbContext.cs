using Gilde.SchietScore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data
{
    public interface ISchietScoreDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<GameElement> GameElements { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
