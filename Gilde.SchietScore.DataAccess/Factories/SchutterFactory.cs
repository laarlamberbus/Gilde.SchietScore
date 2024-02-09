using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class SchutterFactory : ISchutterFactory
    {
        public Schutter CreateModel(LidDto dto)
        {
            return new Schutter
            {
                Id = dto.Id,
                Naam = dto.Naam,
                KNTSNummer = dto.KNTSNummer,
                DeelnemerClassType = (DeelnemerClassType)Enum.Parse(typeof(DeelnemerClassType), dto.DeelnemerClassType),
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
