using Gilde.SchietScore.Application.Builders.Interfaces.Internals;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;

namespace Gilde.SchietScore.Persistence.Builders.Interfaces
{
    public interface ISchutterBuilder : IBuildDto<LidDto, Schutter>
    {
    }
}
