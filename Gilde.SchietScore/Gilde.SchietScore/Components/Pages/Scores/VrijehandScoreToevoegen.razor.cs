using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages.Scores
{
    public partial class VrijehandScoreToevoegen
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private ISchutterRepository _schutterRepository { get; set; }
        [Inject]
        private IVrijehandRepository _vrijehandRepository { get; set; }

        private DateOnly _invoerDatum = DateOnly.FromDateTime(DateTime.Now);
        private IEnumerable<Schutter> _deelnemers;

        protected async override Task OnInitializedAsync()
        {
            if (_schutterRepository != null)
                _deelnemers = await _schutterRepository.ReadAll();
            _deelnemers = _deelnemers.OrderBy(d => d.Klasse);
        }

        private async Task SaveResultaten()
        {
            foreach(var deelnemer in _deelnemers)
            {
                await _vrijehandRepository.RegisterNewResultaatVrijehand(deelnemer, _invoerDatum);
            }
            await _vrijehandRepository.SaveChanges();
            _navigationManager.NavigateTo("vrijehand");
        }
    }
}
