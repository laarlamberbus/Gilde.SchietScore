using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface ICompetitieRepository : ICreate<Competitie>, ISave
    {
        public Task<Competitie> GetHuidigeCompetitie();
    }
}
