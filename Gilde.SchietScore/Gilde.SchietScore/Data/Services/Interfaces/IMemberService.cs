using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Data.Services.Interfaces
{
    public interface IMemberService
    {
        public Task<List<Member>> GetMembers();
        public Task<List<Member>> GetMembers(bool isShootingMember);
    }
}
