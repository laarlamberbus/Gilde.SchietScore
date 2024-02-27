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

        public WedstrijdDto CreateOpgelegdDto(Opgelegd model)
        {
            return new WedstrijdDto
            {
                Naam = $"{nameof(Opgelegd)} {model.Datum.ToString("dd-MM-yyyy")}",
                
            };
        }

        public WedstrijdDto CreateVrijehandDto(Vrijehand model)
        {
            return new WedstrijdDto
            {
                Naam = $"{nameof(Vrijehand)} {model.Datum.ToString("dd-MM-yyyy")}",

            };
        }

        public WedstrijdDto CreateLooijmansDto(Looijmans model)
        {
            return new WedstrijdDto
            {
                Naam = $"{nameof(Looijmans)} {model.Datum.ToString("dd-MM-yyyy")}",

            };
        }
    }
}
