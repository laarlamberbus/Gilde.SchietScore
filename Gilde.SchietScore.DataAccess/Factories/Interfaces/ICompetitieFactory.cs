using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces.Internals;

namespace Gilde.SchietScore.Persistence.Factories.Interfaces
{
    public interface ICompetitieFactory : 
        ICreateModel<Competitie, CompetitieDto>,
        ICreateDto<CompetitieDto, Competitie>
    {
    }
}
