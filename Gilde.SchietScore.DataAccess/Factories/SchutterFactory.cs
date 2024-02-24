using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class SchutterFactory : ISchutterFactory
    {
        public LidDto CreateDto(Schutter model)
        {
            return new LidDto
            {
                Id = model.Id,
                Naam = model.Naam,
                KNTSNummer = model.KNTSNummer,
                DeelnemerClassType = model.DeelnemerKlasseType.ToString(),
                IsSchietendLid = true
            };
        }

        public List<LidDto> CreateDtos(List<Schutter> models)
        {
            var leden = new List<LidDto>();
            foreach (var m in models)
            {
                leden.Add(CreateDto(m));
            }
            return leden;
        }

        public Schutter CreateModel(LidDto dto)
        {
            return new Schutter
            {
                Id = dto.Id,
                Naam = dto.Naam,
                KNTSNummer = dto.KNTSNummer,
                DeelnemerKlasseType = (DeelnemerKlasseType)Enum.Parse(typeof(DeelnemerKlasseType), dto.DeelnemerClassType),
            };
        }

        public List<Schutter> CreateModels(List<LidDto> dtos)
        {
            var schutters = new List<Schutter>();
            foreach (var d in dtos)
            {
                schutters.Add(CreateModel(d));
            }
            return schutters;
        }
    }
}
