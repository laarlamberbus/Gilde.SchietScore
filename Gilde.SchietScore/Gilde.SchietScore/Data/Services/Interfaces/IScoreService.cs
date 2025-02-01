using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Data.Services.Interfaces
{
    public interface IScoreService
    {
        public Task<List<Score>> GetScores();
        public Task SaveScores(List<Score> scores);
        public Task EditScores(List<Score> scores);
    }
}
