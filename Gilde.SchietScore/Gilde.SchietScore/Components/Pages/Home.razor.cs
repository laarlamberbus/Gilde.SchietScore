using Gilde.SchietScore.Application.Competitions.Commands;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class Home
    {
        private Competitie _nieuweCompetitie = new Zomer
        {
            Name = CompetitieType.Zomer.ToString(),
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today).AddMonths(6),
        };

        private async Task StartCompetitie()
        {
            await Mediator.Send(new StartCompetitionCommand(_nieuweCompetitie));
            NavigationManager.NavigateTo("", true);
        }
        private async Task CompetitieAfronden()
        {
            await CompetitieRepository.HuidigeCompetitieAfronden(HuidigeCompetitie);
            await CompetitieRepository.SaveChanges();
            NavigationManager.NavigateTo("", true);
        }
    }
}