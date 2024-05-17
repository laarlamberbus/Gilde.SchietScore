using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Gilde.SchietScore.Domain.Enums;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components
{
    public abstract class WedstrijdBase : CompetitieBase
    {
        [Inject]
        protected ISchutterRepository SchutterRepository { get; set; }

        protected IEnumerable<Schutter> DeelnemersLijst { get; set; }
        protected Vrijehand? vrijehandResultaten;
                              
        protected DateOnly? wedstrijdDatum;
        protected DateOnly geselecteerdWedstrijdJaar;
        protected DateOnly geselecteerdeWedstrijdWeek;
        protected DeelnemerKlasseType deelnemerKlasse;
        protected bool isNewResultaatForm = true;

        protected async override Task OnInitializedAsync()
        {
            DeelnemersLijst = await SchutterRepository.ReadAll();
            wedstrijdDatum = DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
