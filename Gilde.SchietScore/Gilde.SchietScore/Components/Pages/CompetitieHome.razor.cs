using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class CompetitieHome
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private ICompetitieRepository _competitieRepository { get; set; }

        private Competitie _huidigeCompetitie = new Competitie();
        private string _buttonText;
        private bool _isLopendeCompetitie;
        private DateOnly _today = DateOnly.FromDateTime(DateTime.Now);
        private string _competitieNaam = $"Competitie";

        protected async override Task OnInitializedAsync()
        {
            _huidigeCompetitie = await _competitieRepository.LaadHuidigeCompetitie();
            _isLopendeCompetitie = _huidigeCompetitie != null;
            
            if (_isLopendeCompetitie)
            {
                _buttonText = "Huidige competitie afronden";
            }
            else
            {
                _buttonText = "Nieuwe competitie starten";
                _huidigeCompetitie = new Competitie()
                {
                    Name = "",
                    StartDate = _today,
                    EndDate = _today.AddMonths(6)
                };
            }
        }

        protected async Task HandleCompetitie()
        {
            if (_isLopendeCompetitie)
                await _competitieRepository.CompetitieAfronden(_huidigeCompetitie);
            else
            {
                await _competitieRepository.CompetitieStarten(_huidigeCompetitie);
            }
            await _competitieRepository.SaveChanges();
            _navigationManager.NavigateTo("", true);
        }
    }
}
