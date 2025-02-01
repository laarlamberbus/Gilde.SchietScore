using Gilde.SchietScore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data
{
    public interface ISchietScoreDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<ScoreTwee> ScoresTwee { get; set; }
        public DbSet<GameElement> GameElements { get; set; }


        //2.0
        public DbSet<Lid> Leden { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
