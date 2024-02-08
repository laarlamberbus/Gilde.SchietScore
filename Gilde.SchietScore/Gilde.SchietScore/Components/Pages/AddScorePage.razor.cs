using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Factories;
using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class AddScorePage
    {
        [Inject]
        private IGameElementService? _gameElementService { get; set; }
        [Inject]
        private IMemberService? _memberService { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private List<Member> _shootingMembers;
        private List<GameElement> _uniqueGameElements;
        private DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        private List<ScoreForm> _scoreAddForms;
        private ScoreFormFactory scoreFormFactory = new ScoreFormFactory();

        protected override async Task OnInitializedAsync()
        {
            await RetrieveShootingMembers();
            await RetrieveGameElements();
            BuildForm();
        }

        private void BuildForm()
        {
            _scoreAddForms = new List<ScoreForm>();

            foreach (var shootingMember in _shootingMembers)
            {
                _scoreAddForms.Add(scoreFormFactory.CreateAddForm(shootingMember, _uniqueGameElements.Where(g => g.Level == shootingMember.Level).ToList()));
            }
        }

        protected async Task  SubmitScoreFrom()
        {
            if(_gameElementService != null)
                await _gameElementService.SaveScores(_scoreAddForms, today);

            _navigationManager.NavigateTo("uitslagen");
        }

        private async Task RetrieveShootingMembers()
        {
            if(_memberService != null)
                _shootingMembers = await _memberService.GetMembers(true);
        }
        private async Task RetrieveGameElements()
        {
            if (_gameElementService != null)
                _uniqueGameElements = await _gameElementService.GetGameElements();
        }
    }
}
