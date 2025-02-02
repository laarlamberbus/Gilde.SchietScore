using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class LedenPage
    {
        [Inject]
        private ILedenService? LedenService { get; set; }

        public List<Lid> _leden;

        protected async override Task OnInitializedAsync()
        {
            if(LedenService != null)
                _leden = await LedenService.GetLeden();
        }
    }
}
