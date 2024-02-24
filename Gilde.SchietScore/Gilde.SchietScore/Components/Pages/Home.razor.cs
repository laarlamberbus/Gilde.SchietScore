using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private ICompetitieRepository _competitieRepository { get; set; }
        private Competitie _huidigeCompetitie;
        private Competitie _nieuweCompetitie = new Zomer
        {
            Name = CompetitieType.Zomer.ToString(),
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today).AddMonths(6),
        };

        protected async override void OnInitialized()
        {
            _huidigeCompetitie = await _competitieRepository.GetHuidigeCompetitie();
        }
        private async Task StartCompetitie()
        {
            if (_nieuweCompetitie.Name.Contains(CompetitieType.Winter.ToString()))
            {
                
            }
        }
    }
}
