//using Gilde.SchietScore.Data.Services.Interfaces;
//using Gilde.SchietScore.Dtos;
//using Gilde.SchietScore.Models;
//using Microsoft.AspNetCore.Components;
//namespace Gilde.SchietScore.Components.Pages.Scores
//{
//    public partial class ScorePage
//    {
//        [Inject]
//        private IGameElementService _gameElementService { get; set; }
//        private static int _currentYear = DateTime.Now.Year;

//        public int SelectedYear { get; set; } = _currentYear;
//        public DateOnly? SelectedWeek { get; set; }
//        public KorpsDto SelectedKorps { get; set; } = KorpsList.AllKorps.Single(k => k.Level == 1);
//        public List<DateOnly> AllGameWeeks { get; set; }
//        public List<int> AllGameYears { get; set; }

//        public string Title { get; set; } = $"Uitslagen {_currentYear}";

//        private List<Score>? _scores;

//        protected override async Task OnInitializedAsync()
//        {
//            await RetrieveGameScores();
//            AllGameYears = await _gameElementService.GetUniqueGameYears();
//            AllGameWeeks = await _gameElementService.GetUniqueGameWeeks(SelectedYear);
//        }

//        private async Task RetrieveGameScores()
//        {
//            UpdateTitle();
//            AllGameWeeks = await _gameElementService.GetUniqueGameWeeks(SelectedYear);
//            _scores = await _gameElementService.GetScores(SelectedYear, SelectedKorps.Level, SelectedWeek);
//        }
//        private async Task RetrieveGameScoresResetSelectedWeek()
//        {
//            SelectedWeek = null;
//            await RetrieveGameScores();
//        }

//        private void UpdateTitle()
//        {
//            if (SelectedWeek.HasValue)
//                Title = $"Uitslagen {SelectedWeek.Value.Day}-{SelectedWeek.Value.Month}-{SelectedWeek.Value.Year}";
//            else
//                Title = $"Uitslagen {SelectedYear}";
//        }
//    }
//}
