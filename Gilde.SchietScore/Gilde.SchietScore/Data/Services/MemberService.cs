using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data.Services
{
    internal class MemberService : IMemberService
    {
        private ISchietScoreDbContext _context;

        public MemberService(ISchietScoreDbContext schietScoreDbContext)
        {
            _context = schietScoreDbContext;
        }

        private IQueryable<Member> GetMembersQuery()
        {
            return _context.Members;
        }

        public async Task<List<Member>> GetMembers()
        {
            return await GetMembersQuery().ToListAsync();
        }

        public async Task<List<Member>> GetMembers(bool isShootingMember)
        {
            var result = await GetMembersQuery()
                .Where(p => p.IsShootingMember == isShootingMember)
                .ToListAsync();
            return result;
        }
    }
}
