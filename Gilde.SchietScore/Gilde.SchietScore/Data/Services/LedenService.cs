using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data.Services
{
    public class LedenService : ILedenService
    {
        private ISchietScoreDbContext _context;

        public LedenService(ISchietScoreDbContext schietScoreDbContext)
        {
            _context = schietScoreDbContext;
        }

        private IQueryable<Lid> GetLedenQuery()
        {
            return _context.Leden;
        }

        public async Task<List<Lid>> GetLeden()
        {
            return await GetLedenQuery().ToListAsync();
        }

        public Task EditLeden(List<Lid> leden)
        {
            throw new NotImplementedException();
        }

        public async Task SaveLeden(List<Lid> leden)
        {
            await _context.Leden.AddRangeAsync(leden);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
