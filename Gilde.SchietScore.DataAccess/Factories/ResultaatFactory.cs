using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class ResultaatFactory : IResultaatFactory
    {
        private ResultaatDto CreateDto(Vrijehand vrijehand, Schutter deelnemer)
        {
            return new ResultaatDto
            {
                Datum = vrijehand.StartDatum,
                DeelnemerId = deelnemer.Id,
                Score = deelnemer.Score,
                WedstrijdId = vrijehand.Id
            };
        }

        public List<ResultaatDto> CreateDto(Vrijehand model)
        {
            var resultaten = new List<ResultaatDto>();

            foreach (var deelnemer in model.Deelnemers)
            {
                resultaten.Add(CreateDto(model, deelnemer));
            }

            return resultaten;
        }

        public Vrijehand CreateModel(List<ResultaatDto> dto)
        {
            var deelnemers = new List<Deelnemer>();
            var vrijehand = new Vrijehand();

            foreach (var resultaat in dto)
            {
                vrijehand.Id = resultaat.WedstrijdId;
                deelnemers.Add(new Schutter
                {
                   Id = resultaat.DeelnemerId,
                   Score = resultaat.Score,
                   Naam = resultaat.Deelnemer.Naam,
                   //DeelnemerKlasseType = resultaat.Deelnemer.DeelnemerClassType.ToString(),
                   KNTSNummer = resultaat.Deelnemer.KNTSNummer,
                   //AantalKogels = resultaat.K
                });
            }

            return vrijehand;
        }
    }
}
