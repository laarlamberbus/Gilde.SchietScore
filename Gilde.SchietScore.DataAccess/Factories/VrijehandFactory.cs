using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class VrijehandFactory : IVrijehandFactory
    {
        public WedstrijdDto CreateDto(Vrijehand model)
        {
            var dto = new WedstrijdDto
            {
                Naam = $"{nameof(Vrijehand)} {model.StartDatum.Year}",
                StartDatum = model.StartDatum,
                EindDatum = model.EindDatum
            };

            return dto;
        }

        public List<WedstrijdDto> CreateDtos(List<Vrijehand> models)
        {
            throw new NotImplementedException();
        }

        public Vrijehand CreateModel(WedstrijdDto dto)
        {
            throw new NotImplementedException();
        }

        public List<Vrijehand> CreateModels(List<WedstrijdDto> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
