using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class WedstrijdFactory : IWedstrijdFactory
    {
        public Opgelegd CreateOpgelegdModel(WedstrijdDto dto)
        {
            return new Opgelegd
            {

            };
        }

        public Vrijehand CreateVrijehandModel(WedstrijdDto dto)
        {
            return new Vrijehand
            {

            };
        }

        public Looijmans CreateLooijmansModel(WedstrijdDto dto)
        {
            return new Looijmans
            {

            };
        }
    }
}
