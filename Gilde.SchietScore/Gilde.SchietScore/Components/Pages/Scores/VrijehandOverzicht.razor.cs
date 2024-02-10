using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gilde.SchietScore.Components.Pages.Scores
{
    public partial class VrijehandOverzicht
    {
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IVrijehandRepository _vrijehandRepository { get; set; }

        private Vrijehand? _vrijehandResultaten;

        protected async override Task OnInitializedAsync()
        {
            if (_vrijehandRepository != null)
                _schutters = await _vrijehandRepository.ReadByDate();
        }

        private async Task SaveResultaten()
        {
            if (_schutters != null)
            {
                _vrijehandRepository.Update(_schutters);
                await _vrijehandRepository.Create(_nieuweSchutter);
                await _vrijehandRepository.SaveChanges();
            }
            _navigationManager.NavigateTo("vrijehand", true);
        }

        private async Task DeleteResultaat(Vrijehand vrijehandResultaat)
        {
            bool confirmed = await _jsRuntime.InvokeAsync<bool>("confirm", $"Weet je het zeker om {vrijehandResultaat.Naam} te verwijderen?");
            if (confirmed)
            {
                await _vrijehandRepository.Delete(schutter.Id);
                await _vrijehandRepository.SaveChanges();
            }
            _navigationManager.NavigateTo("vrijehand", true);
        }
    }
}
