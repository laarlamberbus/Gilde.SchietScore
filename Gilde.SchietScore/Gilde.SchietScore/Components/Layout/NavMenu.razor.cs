using Gilde.SchietScore.Application.Repositories;
using Gilde.SchietScore.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Gilde.SchietScore.Components.Layout
{
    public partial class NavMenu
    {
        private string? currentUrl;
        [Inject]
        private ICompetitieRepository _competitieRepository { get; set; }
        private Competitie _huidigeCompetitie;

        protected async override void OnInitialized()
        {
            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            NavigationManager.LocationChanged += OnLocationChanged;
            _huidigeCompetitie = await _competitieRepository.GetHuidigeCompetitie();
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
