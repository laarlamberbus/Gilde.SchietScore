using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
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
                IsActive = model.IsActive
            };
        }

        public Competitie CreateModel(CompetitieDto dto)
        {
            if (dto is null)
                return null;

            if (dto.Name.Contains(CompetitieType.Zomer.ToString()))
            {
                return new Zomer
                {
                    Name = dto.Name,
                    StartDate = dto.StartDatum,
                    EndDate = dto.EndDatum
                };
            }
            if (dto.Name.Contains(CompetitieType.Winter.ToString()))
            {
                return new Winter
                {
                    Name = dto.Name,
                    StartDate = dto.StartDatum,
                    EndDate= dto.EndDatum
                };
            }

            throw new Exception("The retrieved CompetitieTypes do not match the standards.");
        }
    }
}
