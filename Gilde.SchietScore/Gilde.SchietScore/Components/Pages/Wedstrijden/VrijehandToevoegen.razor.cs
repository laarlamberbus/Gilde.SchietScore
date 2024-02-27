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

        protected override void OnInitialized()
        {
            vrijehandResultaten.StartDatum = DateOnly.FromDateTime(DateTime.Now);
        }

        private async Task SubmitVrijehadForm(Wedstrijd model)
        {
            await Mediator.Send(new VrijehandToevoegenCommand((Vrijehand)model));
        }
    }
}
