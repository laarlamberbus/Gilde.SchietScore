using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Filter
{
    public partial class KorpsFilterComponent
    {
        [Parameter]
        public Korps SelectedKorps { get; set; }
        [Parameter]
        public EventCallback<Korps> SelectedKorpsChanged { get; set; }

        protected async Task OnKorpsSelection(Korps selectedKorps)
        {
            SelectedKorps = selectedKorps;
            await SelectedKorpsChanged.InvokeAsync(SelectedKorps);
        }
    }
}
