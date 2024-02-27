using Gilde.SchietScore.Domain;
using MediatR;

namespace Gilde.SchietScore.Application.Competitions.Commands
{
    public class StartCompetitionCommand : IRequest
    {
        public Competitie Competition { get; set; }
        public StartCompetitionCommand(Competitie competitie)
        {
            Competition = competitie;
        }
    }
}
