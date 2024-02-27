using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gilde.SchietScore.Components.Pages.Overzicht
{
    public partial class SchuttersOverzicht
    {
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private ISchutterRepository _schutterRepository { get; set; }

        private IEnumerable<Schutter>? _schutters;
        private Schutter _nieuweSchutter = new Schutter();

        protected async override Task OnInitializedAsync()
        {
            if (_schutterRepository != null)
                _schutters = await _schutterRepository.ReadAll();
        }

        private async Task SaveSchutters()
        {
            if (_schutters != null)
            {
                _schutterRepository.Update(_schutters);
                if(_nieuweSchutter.Naam != null && _nieuweSchutter.KNTSNummer != null)
                    await _schutterRepository.Create(_nieuweSchutter);
                await _schutterRepository.SaveChanges();
            }
            _navigationManager.NavigateTo("schutters", true);
        }

        private async Task DeleteSchutter(Schutter schutter)
        {
            bool confirmed = await _jsRuntime.InvokeAsync<bool>("confirm", $"Weet je het zeker om {schutter.Naam} te verwijderen?");
            if (confirmed)
            {
                await _schutterRepository.Delete(schutter.Id);
                await _schutterRepository.SaveChanges();
            }
            _navigationManager.NavigateTo("schutters", true);
        }
    }
}
