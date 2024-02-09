using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Persistence
{
    public class SchietScoreDbContext(DbContextOptions<SchietScoreDbContext> options) : IdentityDbContext<SchietScoreUser>(options), ISchietScoreDbContext
    {
        public DbSet<LidDto> Leden { get; set; }
        public DbSet<CompetitieDto> Competities { get; set; }
        public DbSet<WedstrijdDto> Wedstrijden { get; set; }
        //public DbSet<WedstrijdScoreDto> WedstrijdScores { get; set; }
        //public DbSet<KorpsDto> Korpsen { get; set; }
    }
}
