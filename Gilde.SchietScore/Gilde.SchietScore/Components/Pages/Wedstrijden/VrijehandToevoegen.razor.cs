using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Application.VrijehandWedstrijden.Commands;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages.Wedstrijden
{
    public partial class VrijehandToevoegen
    {
        [Inject]
        protected IVrijehandRepository VrijehandRepository { get; set; }

        protected async override Task OnInitializedAsync()
        {
            DeelnemersLijst = await SchutterRepository.ReadAll();
            wedstrijdDatum = DateOnly.FromDateTime(DateTime.Today);
            vrijehandResultaten = new Vrijehand();
            vrijehandResultaten.StartDatum = DateOnly.FromDateTime(DateTime.Now);
            vrijehandResultaten.Deelnemers = DeelnemersLijst.ToList();
        }

        private async Task SubmitVrijehadForm(Wedstrijd model)
        {
            await Mediator.Send(new VrijehandToevoegenCommand((Vrijehand)model));
        }
    }
}
