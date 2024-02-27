using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages.Wedstrijden
{
    public partial class VrijehandOverzicht
    {
        [Inject]
        protected IVrijehandRepository VrijehandRepository { get; set; }
        [Inject]
        protected IResultaatRepository ResultaatRepository { get; set; }

        protected async new Task OnInitializedAsync()
        {
            var wedstrijd = await VrijehandRepository.ReadLatest();
            vrijehandResultaten = await ResultaatRepository.ReadLatest(wedstrijd.Id);
        }

        private void SubmitVrijehadForm(Wedstrijd model)
        {

        }
        
        private async Task SaveResultaten()
        {
            //if (_schutters != null)
            //{
            //    _vrijehandRepository.Update(_schutters);
            //    await _vrijehandRepository.Create(_nieuweSchutter);
            //    await _vrijehandRepository.SaveChanges();
            //}
            NavigationManager.NavigateTo("vrijehand", true);
        }

        private async Task DeleteResultaat(Vrijehand vrijehandResultaat)
        {
            //bool confirmed = await _jsRuntime.InvokeAsync<bool>("confirm", $"Weet je het zeker om {vrijehandResultaat.Naam} te verwijderen?");
            //if (confirmed)
            //{
            //    await _vrijehandRepository.Delete(schutter.Id);
            //    await _vrijehandRepository.SaveChanges();
            //}
            NavigationManager.NavigateTo("vrijehand", true);
        }
    }
}
