using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components
{
    public abstract class WedstrijdBase : BaseComponent
    {
        [Inject]
        protected ISchutterRepository SchutterRepository { get; set; }

        protected IEnumerable<Schutter> DeelnemersLijst { get; set; }
        protected Vrijehand? vrijehandResultaten = new Vrijehand();
        protected DateOnly? wedstrijdDatum;
        protected DateOnly geselecteerdWedstrijdJaar;
        protected DateOnly geselecteerdeWedstrijdWeek;
        protected DeelnemerKlasseType deelnemerKlasse;
        protected bool isNewResultaatForm = true;

        protected override async Task OnInitializedAsync()
        {
            DeelnemersLijst = await SchutterRepository.ReadAll();
            vrijehandResultaten.Deelnemers = DeelnemersLijst.ToList();
            wedstrijdDatum = DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
