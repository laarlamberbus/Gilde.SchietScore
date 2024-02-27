using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain.Enums;
using Gilde.SchietScore.Domain;
using MediatR;

namespace Gilde.SchietScore.Application.Competitions.Commands
{
    public class StartCompetitionCommandHandler : IRequestHandler<StartCompetitionCommand>
    {
        private ICompetitieRepository _competitieRepository { get; set; }

        public StartCompetitionCommandHandler(ICompetitieRepository competitieRepository)
        {
            _competitieRepository = competitieRepository;
        }

        public async Task Handle(StartCompetitionCommand request, CancellationToken cancellationToken)
        {
            var vrijehand = new Vrijehand
            {
                Datum = DateOnly.FromDateTime(DateTime.Now)
            };
            var looijmans = new Looijmans
            {
                Datum = DateOnly.FromDateTime(DateTime.Now)
            };
            var opgelegd = new Opgelegd
            {
                Datum = DateOnly.FromDateTime(DateTime.Now)
            };

            if (request.Competition.Name.Contains(CompetitieType.Winter.ToString()))
            {
                var competitie = new Winter()
                {
                    StartDate = request.Competition.StartDate,
                    EndDate = request.Competition.EndDate,
                    IsActive = true,
                    Name = $"{request.Competition.Name} {request.Competition.StartDate.Year}",
                    Opgelegd = opgelegd,
                    Vrijehand = vrijehand,
                    LooijmansBeker = looijmans
                };
                await _competitieRepository.Create(competitie);
            }
            if (request.Competition.Name.Contains(CompetitieType.Zomer.ToString()))
            {
                var competitie = new Zomer()
                {
                    StartDate = request.Competition.StartDate,
                    EndDate = request.Competition.EndDate,
                    IsActive = true,
                    Name = $"{request.Competition.Name} {request.Competition.StartDate.Year}",
                    Opgelegd = opgelegd,
                    Vrijehand = vrijehand
                };
                await _competitieRepository.Create(competitie);
            }

            await _competitieRepository.SaveChanges();
        }
    }
}
