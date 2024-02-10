using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces.Internals;

namespace Gilde.SchietScore.Persistence.Factories.Interfaces
{
    public interface IVrijehandFactory : 
        ICreateModel<Vrijehand, WedstrijdDto>,
        ICreateModels<Vrijehand, WedstrijdDto>,
        ICreateDto<WedstrijdDto, Vrijehand>,
        ICreateDtos<WedstrijdDto, Vrijehand>
    {
    }
}
