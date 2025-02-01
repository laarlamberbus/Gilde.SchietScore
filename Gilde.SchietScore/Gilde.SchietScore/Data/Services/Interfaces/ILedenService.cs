using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Data.Services.Interfaces
{
    public interface ILedenService
    {
        public Task<List<Lid>> GetLeden();
        public Task SaveLeden(List<Lid> leden);
        public Task EditLeden(List<Lid> leden);
    }
}
