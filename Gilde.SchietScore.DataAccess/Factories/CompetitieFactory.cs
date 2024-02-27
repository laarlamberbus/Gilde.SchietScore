using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class CompetitieFactory : ICompetitieFactory
    {
        private readonly IWedstrijdFactory _wedstrijdFactory;
        public CompetitieFactory(IWedstrijdFactory wedstrijdFactory)
        {
            _wedstrijdFactory = wedstrijdFactory;
        }

        public CompetitieDto CreateDto(Zomer model)
        {
            List<WedstrijdDto> wedstrijden = new List<WedstrijdDto>();
            wedstrijden.Add(_wedstrijdFactory.CreateVrijehandDto(model.Vrijehand));
            wedstrijden.Add(_wedstrijdFactory.CreateOpgelegdDto(model.Opgelegd));

            return new CompetitieDto
            {
                Name = model.Name,
                StartDatum = model.StartDate,
                EndDatum = model.EndDate,
                IsActive = model.IsActive,
                Wedstrijden = wedstrijden
            };
        }

        public CompetitieDto CreateDto(Winter model)
        {
            List<WedstrijdDto> wedstrijden = new List<WedstrijdDto>();
            wedstrijden.Add(_wedstrijdFactory.CreateVrijehandDto(model.Vrijehand));
            wedstrijden.Add(_wedstrijdFactory.CreateOpgelegdDto(model.Opgelegd));
            wedstrijden.Add(_wedstrijdFactory.CreateLooijmansDto(model.LooijmansBeker));

            return new CompetitieDto
            {
                Name = model.Name,
                StartDatum = model.StartDate,
                EndDatum = model.EndDate,
                IsActive = model.IsActive,
                Wedstrijden = wedstrijden
            };
        }

        public CompetitieDto CreateDto(Competitie model)
        {
            if(model.GetType().Name == CompetitieType.Zomer.ToString())
            {
                return CreateDto((Zomer)model);
            }
            else if(model.GetType().Name == CompetitieType.Winter.ToString())
            {
                return CreateDto((Winter)model);
            }
            return null;
        }

        public Competitie CreateModel(CompetitieDto dto)
        {
            if (dto is null)
                return null;

            if (dto.Name.Contains(CompetitieType.Zomer.ToString()))
            {
                return new Zomer
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    StartDate = dto.StartDatum,
                    EndDate = dto.EndDatum
                };
            }
            if (dto.Name.Contains(CompetitieType.Winter.ToString()))
            {
                return new Winter
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    StartDate = dto.StartDatum,
                    EndDate= dto.EndDatum
                };
            }

            throw new Exception("The retrieved CompetitieTypes do not match the standards.");
        }
    }
}
