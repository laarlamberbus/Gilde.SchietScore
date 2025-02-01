using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Data.Services.Interfaces;

internal interface IGameElementService 
{
    public Task<List<GameElement>> GetScores(int year, int korpsLevel = 1);
    public Task<List<ScoreTwee>> GetScores(int year, int korpsLevel, DateOnly? dateOnly = null);
    public Task<List<int>> GetUniqueGameYears();
    public Task<List<DateOnly>> GetUniqueGameWeeks(int year);
    public Task<DateOnly> GetLatestGameWeek(int year);
    public Task<List<GameElement>> GetGameElements();
    public Task SaveScores(List<ScoreForm> scoreAddForms, DateOnly scoreDate);
    public Task EditScores(List<ScoreTwee> scores);
}
