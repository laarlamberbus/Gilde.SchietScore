using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Data.Services.Interfaces
{
    public interface ILedenService
    {
        public List<Deelnemer> RetrieveLeden();
        public Task SaveLid(Deelnemer deelnemer);
        public Task EditLid(Deelnemer deelnemer);
    }
}
