using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gilde.SchietScore.Components.Pages.Overzicht
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
        public DateOnly _geselecteerdeWedstrijddag;
        public int _geselecteerdWedstrijdJaar;
        public List<DateOnly> _wedstrijddagenPerJaar;
        public List<int> _wedstrijdJaren;
        public DeelnemerKlasse _deelnemerKlasse = DeelnemerKlasse.A;

        protected async override Task OnInitializedAsync()
        {
            _wedstrijddagenPerJaar = await _vrijehandRepository.ReadAlleWedstrijdagenPerJaar(2024);
            _wedstrijdJaren = await _vrijehandRepository.ReadAlleWedstrijdJaren();
            _geselecteerdeWedstrijddag = _wedstrijddagenPerJaar.FirstOrDefault();
            _geselecteerdWedstrijdJaar = _wedstrijdJaren.FirstOrDefault();
            if (_vrijehandRepository != null)
                _vrijehandResultaten = await _vrijehandRepository.ReadWedstrijddag(_deelnemerKlasse, _geselecteerdeWedstrijddag);
        }

        private async Task SaveResultaten()
        {
            //if (_vrijehandResultaten != null)
            //{
            //    _vrijehandRepository.Update(_vrijehandResultaten);
            //    await _vrijehandRepository.Create(_vrijehandResultaten);
            //    await _vrijehandRepository.SaveChanges();
            //}
            _navigationManager.NavigateTo("vrijehand", true);
        }

        private async Task DeleteResultaat(Deelnemer vrijehandResultaat)
        {
            //bool confirmed = await _jsRuntime.InvokeAsync<bool>("confirm", $"Weet je het zeker om {vrijehandResultaat.Naam} te verwijderen?");
            //if (confirmed)
            //{
            //    await _vrijehandRepository.Delete(schutter.Id);
            //    await _vrijehandRepository.SaveChanges();
            //}
            _navigationManager.NavigateTo("vrijehand", true);
        }

        private async Task LaadResultatenVanDag(DateOnly wedstrijddag)
        {
            _geselecteerdeWedstrijddag = wedstrijddag;
            if (_vrijehandRepository != null)
                _vrijehandResultaten = await _vrijehandRepository.ReadWedstrijddag(_deelnemerKlasse, _geselecteerdeWedstrijddag);
        }
        private async Task LaadResultatenVanJaar()
        {
            if (_vrijehandRepository != null)
                _vrijehandResultaten = await _vrijehandRepository.ReadWedstrijddag(_deelnemerKlasse, _geselecteerdeWedstrijddag);
        }

        private async Task LaadResultatenVanKlasse(ChangeEventArgs e)
        {
            _deelnemerKlasse = (DeelnemerKlasse)Enum.Parse(typeof(DeelnemerKlasse), e.Value.ToString());
            if (_vrijehandRepository != null)
                _vrijehandResultaten = await _vrijehandRepository.ReadWedstrijddag(_deelnemerKlasse, _geselecteerdeWedstrijddag);
        }
    }
}
