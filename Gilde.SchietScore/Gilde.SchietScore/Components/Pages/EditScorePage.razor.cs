using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Factories;
using Gilde.SchietScore.Models;
using Microsoft.AspNetCore.Components;

namespace Gilde.SchietScore.Components.Pages
{
    public partial class EditScorePage
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IMemberService? _memberService { get; set; }
        [Inject]
        private IGameElementService? _gameElementService { get; set; }
        private static int _currentYear = DateTime.Now.Year;
        private ScoreFormFactory _scoreFormFactory = new ScoreFormFactory();

        public int SelectedYear { get; set; } = DateTime.Now.Year;
        public DateOnly? SelectedWeek { get; set; }
        public Korps SelectedKorps { get; set; } = KorpsList.AllKorps.Single(k => k.Level == 0);
        public List<DateOnly> AllGameWeeks { get; set; }
        public List<int> AllGameYears { get; set; }
        public string Title { get; set; } = $"Uitslagen {_currentYear}";

        private List<Member> _shootingMembers;
        private List<GameElement> _uniqueGameElements;
        private List<ScoreForm> _scoreEditForms;

        private List<Score>? _scores;

        protected override async Task OnInitializedAsync()
        {
            if(_gameElementService != null)
            {
                AllGameYears = await _gameElementService.GetUniqueGameYears();
                AllGameWeeks = await _gameElementService.GetUniqueGameWeeks(SelectedYear);
                SelectedWeek = await _gameElementService.GetLatestGameWeek(SelectedYear);
            }
            await RetrieveGameScores();
            await RetrieveShootingMembers();
            await RetrieveGameElements();
            BuildForm();
        }

        protected async Task SubmitScoreFrom()
        {
            if(_gameElementService != null && SelectedWeek.HasValue)
                await _gameElementService.EditScores(_scoreFormFactory.CreateScores(_scoreEditForms, SelectedWeek.Value));

            _navigationManager.NavigateTo("uitslagen");
        }
        private void UpdateTitle()
        {
            if (SelectedWeek.HasValue)
                Title = $"Uitslagen wijzigen {SelectedWeek.Value.Day}-{SelectedWeek.Value.Month}-{SelectedWeek.Value.Year}";
            else
                Title = $"Uitslagen wijzigen {SelectedYear}";
        }
        private void BuildForm()
        {
            _scoreEditForms = new List<ScoreForm>();
            if (_shootingMembers != null && _uniqueGameElements != null && _scores != null)
            {
                foreach (var shootingMember in _shootingMembers)
                {
                    var scoresOfShootingMember = _scores.Where(s => s.MemberId == shootingMember.Id).ToList();
                    var gameElementsOfShootingMember = _uniqueGameElements.Where(g => g.Level == shootingMember.Level).ToList();

                    var scoreForm = _scoreFormFactory.CreateEditForm(shootingMember, gameElementsOfShootingMember, scoresOfShootingMember);
                    _scoreEditForms.Add(scoreForm);
                }
            }
        }
        private async Task RetrieveGameScores()
        {
            UpdateTitle();
            if (_gameElementService != null && _memberService != null)
            {
                AllGameWeeks = await _gameElementService.GetUniqueGameWeeks(SelectedYear);
                _scores = await _gameElementService.GetScores(SelectedYear, SelectedKorps.Level, SelectedWeek);
                var shootingmembers = await _memberService.GetMembers(true);
                _shootingMembers = shootingmembers.Where(s => (s.Level == SelectedKorps.Level) || (SelectedKorps.Level == 0)).ToList();
            }
            BuildForm();
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
