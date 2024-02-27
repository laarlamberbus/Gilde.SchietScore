using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class CompetitieFactory : ICompetitieFactory
    {
        public CompetitieDto CreateDto(Competitie model)
        {
            return new CompetitieDto
            {
                Name = model.Name,
                StartDatum = model.StartDate,
                EndDatum = model.EndDate,
                IsAfgerond = false
            };
        }

        public Competitie CreateModel(CompetitieDto dto)
        {
            if (dto == null)
                return null;

            return new Competitie()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartDate = dto.StartDatum,
                EndDate = dto.EndDatum
            };
        }
    }
}
