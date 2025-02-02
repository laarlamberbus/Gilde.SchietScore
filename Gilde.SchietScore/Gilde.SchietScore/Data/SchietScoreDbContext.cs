using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data
{
    public class SchietScoreDbContext(DbContextOptions<SchietScoreDbContext> options) : IdentityDbContext<SchietScoreUser>(options), ISchietScoreDbContext
    {
        public DbSet<Lid> Leden { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
    }
}
