using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components
{
    public class CompetitieBase : BaseComponent
    {
        [Inject]
        protected ICompetitieRepository CompetitieRepository { get; set; }

        protected Competitie HuidigeCompetitie { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HuidigeCompetitie = await CompetitieRepository.GetHuidigeCompetitie();
        }
    }
}
