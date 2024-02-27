using Gilde.SchietScore.Application.Repositories.Internals;
using Gilde.SchietScore.Domain;

namespace Gilde.SchietScore.Application.Repositories
{
    public interface ICompetitieRepository:
        ISave
    {
        public Task<Competitie> LaadHuidigeCompetitie(CancellationToken cancellationToken = default);
        public Task CompetitieAfronden(Competitie competitie, CancellationToken cancellationToken = default);
        public Task CompetitieStarten(Competitie competitie, CancellationToken cancellationToken = default);
    }
}
