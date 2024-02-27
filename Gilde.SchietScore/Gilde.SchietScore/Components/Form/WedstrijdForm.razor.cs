using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Form
{
    public partial class WedstrijdForm
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string FormName { get; set; }
        [Parameter]
        public Wedstrijd Model { get; set; }
        [Parameter]
        public EventCallback<Wedstrijd> OnModelChanged { get; set; }

        protected async Task OnFormSubmit()
        {
            await OnModelChanged.InvokeAsync(Model);
        }
    }
}
