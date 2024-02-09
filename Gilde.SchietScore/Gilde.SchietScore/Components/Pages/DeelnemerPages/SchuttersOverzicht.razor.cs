using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages.DeelnemerPages
{
    public partial class SchuttersOverzicht
    {
        [Inject]
        private ISchutterRepository _schutterRepository { get; set; }

        public IEnumerable<Schutter>? Schutters { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (_schutterRepository != null)
                Schutters = await _schutterRepository.ReadAll();
        }
    }
}
