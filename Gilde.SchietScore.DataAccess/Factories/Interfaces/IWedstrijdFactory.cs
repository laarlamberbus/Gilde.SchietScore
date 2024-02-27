using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;

namespace Gilde.SchietScore.Persistence.Factories.Interfaces
{
    public interface IWedstrijdFactory
    {
        public Opgelegd CreateOpgelegdModel(WedstrijdDto dto);
        public Vrijehand CreateVrijehandModel(WedstrijdDto dto);
        public Looijmans CreateLooijmansModel(WedstrijdDto dto);
        public WedstrijdDto CreateOpgelegdDto(Opgelegd model);
        public WedstrijdDto CreateVrijehandDto(Vrijehand model);
        public WedstrijdDto CreateLooijmansDto(Looijmans model);
    }
}
