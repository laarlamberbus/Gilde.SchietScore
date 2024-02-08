using Gilde.SchietScore.Data.Services.Interfaces;
using Gilde.SchietScore.Factories;
using Gilde.SchietScore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gilde.SchietScore.Data.Services
{
    internal class GameElementService : IGameElementService
    {
        private ISchietScoreDbContext _context;
        private ScoreFormFactory _scoreFormFactory; 

        public GameElementService(ISchietScoreDbContext schietScoreDbContext)
        {
            _context = schietScoreDbContext;
            _scoreFormFactory = new ScoreFormFactory();
        }

        private IQueryable<GameElement> GetGameElementsQuery()
        {
            return _context.GameElements;
        }

        public async Task<List<DateOnly>> GetUniqueGameWeeks(int year)
        {
            return await _context.Scores.Where(s => s.Date.Year == year).Select(s => s.Date).Distinct().ToListAsync();
        }

        public async Task<List<GameElement>> GetScores(int year, int korpsLevel = 1)
        {
            return await GetGameElementsQuery().Where(ge => ge.Scores.Any(s => s.Date.Year == year)).ToListAsync();
        }

        public async Task<List<int>> GetUniqueGameYears()
        {
            return await _context.Scores.Select(s => s.Date.Year).Distinct().ToListAsync();
        }

        public async Task<List<GameElement>> GetGameElements()
        {
            return await GetGameElementsQuery().ToListAsync();
        }

        public async Task<List<Score>> GetScores(int year, int korpsLevel, DateOnly? date = null)
        {
            var result = await _context.Scores
                .Where(s =>
                    ((korpsLevel == 0) || (s.GameElement.Level == korpsLevel))
                    && ((date.HasValue && s.Date == date.Value) || (!date.HasValue && s.Date.Year == year)))
                .Include(s => s.Member)
                .Include(s => s.GameElement)
                .ToListAsync();

            if (!date.HasValue)
            {
                var score = result.ToList();

                return score.GroupBy(s => new { s.Member, s.GameElement })
                .Select(g => new Score
                {
                    Member = g.Key.Member,
                    GameElement = g.Key.GameElement,
                    Amount = g.Sum(s => s.Amount)
                }).ToList();
            }

            return result;
        }

        public async Task SaveScores(List<ScoreForm> scoreForms, DateOnly scoreDate)
        {
            var scores = _scoreFormFactory.CreateScores(scoreForms, scoreDate);
            await _context.Scores.AddRangeAsync(scores);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task EditScores(List<Score> scores)
        {
            foreach(var score in scores)
            {
                var existingScore = await _context.Scores.FindAsync(score.Id);
                if(existingScore != null)
                {
                    existingScore.Amount = score.Amount;
                    await _context.SaveChangesAsync(CancellationToken.None);
                }
            }
        }

        public async Task<DateOnly> GetLatestGameWeek(int year)
        {
            return await _context.Scores.MaxAsync(s => s.Date);
        }
    }
}