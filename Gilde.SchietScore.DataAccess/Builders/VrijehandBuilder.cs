using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Builders.Interfaces;
using Gilde.SchietScore.Persistence.Dtos;

namespace Gilde.SchietScore.Persistence.Builders
{
    public class VrijehandBuilder : IVrijehandBuilder
    {
        public WedstrijdDto BuildDto(WedstrijdDto toBuild, Vrijehand toBuildFrom)
        {
            return toBuild;
        }
    }
}
