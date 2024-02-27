using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Persistence.Dtos;
using Gilde.SchietScore.Persistence.Factories.Interfaces;

namespace Gilde.SchietScore.Persistence.Factories
{
    public class WedstrijdFactory : IWedstrijdFactory
    {
        private SchutterFactory _schutterFactory;

        public WedstrijdFactory(SchutterFactory schutterFactory) 
        { 
            _schutterFactory = schutterFactory;
        }

        public Opgelegd CreateOpgelegdModel(WedstrijdDto dto)
        {
            return new Opgelegd
            {
                StartDatum = dto.StartDatum,
                EindDatum = dto.EindDatum,
                Deelnemers = _schutterFactory.CreateModels(dto.Deelnemers)
            };
        }

        public Vrijehand CreateVrijehandModel(WedstrijdDto dto)
        {
            return new Vrijehand
            {
                StartDatum = dto.StartDatum,
                EindDatum = dto.EindDatum,
                Deelnemers = _schutterFactory.CreateModels(dto.Deelnemers)
            };
        }

        public Looijmans CreateLooijmansModel(WedstrijdDto dto)
        {
            return new Looijmans
            {
                StartDatum = dto.StartDatum,
                EindDatum = dto.EindDatum,
                Deelnemers = _schutterFactory.CreateModels(dto.Deelnemers)
            };
        }

        public WedstrijdDto CreateOpgelegdDto(Opgelegd model)
        {
            return new WedstrijdDto
            {
                Naam = nameof(Opgelegd),
                StartDatum = model.StartDatum,
                EindDatum = model.EindDatum
            };
        }

        public WedstrijdDto CreateVrijehandDto(Vrijehand model)
        {
            return new WedstrijdDto
            {
                Naam = nameof(Vrijehand),
                StartDatum = model.StartDatum,
                EindDatum = model.EindDatum
            };
        }

        public WedstrijdDto CreateLooijmansDto(Looijmans model)
        {
            return new WedstrijdDto
            {
                Naam = nameof(Looijmans),
                StartDatum = model.StartDatum,
                EindDatum = model.EindDatum
            };
        }
    }
}
