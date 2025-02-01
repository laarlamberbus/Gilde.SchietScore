using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Data.Services.Interfaces
{
    public interface IWedstrijdService
    {
        public Task<List<Wedstrijd>> GetWedstrijden();
        public Task SaveWedstrijden(List<Wedstrijd> wedstrijden);
        public Task EditWedstrijden(List<Wedstrijd> wedstrijden);
    }
}

