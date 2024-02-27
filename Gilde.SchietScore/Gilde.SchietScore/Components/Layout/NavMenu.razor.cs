using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Gilde.SchietScore.Components.Layout
{
    public partial class NavMenu
    {
        private string? currentUrl;
        protected async new Task OnInitializedAsync()
        {
            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = NavigationManager.ToBaseRelativePath(e.Location);
            StateHasChanged();
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}
