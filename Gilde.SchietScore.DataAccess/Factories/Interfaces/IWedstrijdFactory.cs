using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;

namespace Gilde.SchietScore.Persistence.Factories.Interfaces
{
    public interface IWedstrijdFactory
    {
        public Opgelegd CreateOpgelegdModel(WedstrijdDto dto);
        public Vrijehand CreateVrijehandModel(WedstrijdDto dto);
        public Looijmans CreateLooijmansModel(WedstrijdDto dto);
    }
}
