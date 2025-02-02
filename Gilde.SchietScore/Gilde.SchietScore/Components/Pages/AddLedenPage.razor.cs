using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class AddLedenPage
    {
        [Inject]
        private ILedenService? _memberService { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        private List<Lid> _ledenAddForms;

        protected override async Task OnInitializedAsync()
        {
            BuildForm();
        }

        private void BuildForm()
        {
            _ledenAddForms = new List<Lid>()
            { new() };

            //foreach (var shootingMember in _shootingMembers)
            //{
            //    _scoreAddForms.Add(scoreFormFactory.CreateAddForm(shootingMember, _uniqueGameElements.Where(g => g.Level == shootingMember.Level).ToList()));
            //}
        }
        private void AddExtraLid()
        {
            _ledenAddForms.Add(new Lid());
        }
        private void RemoveExtraLid()
        {
            _ledenAddForms.Remove(_ledenAddForms[^1]);
        }
        protected async Task SubmitScoreFrom()
        {
            //if (_gameElementService != null)
            //    await _gameElementService.SaveScores(_scoreAddForms, today);

            //_navigationManager.NavigateTo("uitslagen");
        }
    }
}
