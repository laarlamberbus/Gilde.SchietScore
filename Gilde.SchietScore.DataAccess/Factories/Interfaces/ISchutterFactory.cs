using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces.Internals;

namespace Gilde.SchietScore.Persistence.Factories.Interfaces
{
    public interface ISchutterFactory : 
         ICreateModel<Schutter, LidDto>,
         ICreateModels<Schutter, LidDto>
    {
    }
}
