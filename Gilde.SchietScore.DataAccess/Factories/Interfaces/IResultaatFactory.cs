using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces.Internals;

namespace Gilde.SchietScore.Persistence.Factories.Interfaces
{
    public interface IResultaatFactory : 
        ICreateDto<List<ResultaatDto>, Vrijehand>,
        ICreateModel<Vrijehand, List<ResultaatDto>>
    { 
    }
}
