using Gilde.SchietScore.Models;

namespace Gilde.SchietScore.Factories
{
    public class ScoreFormFactory
    {
        public ScoreForm CreateAddForm(Member member, List<GameElement> gameElements)
        {
            var scoreAddForm = new ScoreForm()
            {
                MemberId = member.Id,
                MemberName = member.Name,
                ScoreAddRows = new List<ScoreRow>()
            };
            foreach (var gameElement in gameElements.Where(g => g.Level == member.Level))
            {
                scoreAddForm.ScoreAddRows.Add(new ScoreRow()
                {
                    GameElementId = gameElement.Id,
                    GameElementName = $"{gameElement.Name} {gameElement.Level}",
                });
            }
            return scoreAddForm;
        }
        public ScoreForm CreateEditForm(Member member, List<GameElement> gameElements, List<Score> scoreOfMember)
        {
            if(scoreOfMember.All(s => s.MemberId != member.Id))
                throw new Exception($"ScoreFormFactory.CreateEditForm(Member,List<GameElement>,Score) | The inputed scoreOfMember is not from the same member {member.Id}");

            if (!scoreOfMember.Select(s => s.GameElementId).Any(id => gameElements.Select(g => g.Id).Contains(id)))
                throw new Exception($"ScoreFormFactory.CreateEditForm(Member,List<GameElement>,Score) | The inputed scoreOfMember does not contain any gameElement of the gameElementsList");

            var scoreAddForm = new ScoreForm()
            {
                MemberId = member.Id,
                MemberName = member.Name,
                ScoreAddRows = new List<ScoreRow>()
            };
            foreach (var gameElement in gameElements.Where(g => g.Level == member.Level))
            {
                var score = scoreOfMember.Single(s => s.GameElementId == gameElement.Id);
                scoreAddForm.ScoreAddRows.Add(new ScoreRow()
                {
                    GameElementId = gameElement.Id,
                    GameElementName = $"{gameElement.Name} {gameElement.Level}",
                    Score = score.Amount,
                    ScoreId = score.Id
                });
            }
            return scoreAddForm;
        }
        public List<Score> CreateScores(List<ScoreForm> scoreForms, DateOnly scoreDate)
        {
            var scores = new List<Score>();
            foreach (var scoreForm in scoreForms)
            {
                foreach (var scoreRow in scoreForm.ScoreAddRows)
                {
                    scores.Add(new Score()
                    {
                        Id = scoreRow.ScoreId,
                        MemberId = scoreForm.MemberId,
                        GameElementId = scoreRow.GameElementId,
                        Date = scoreDate,
                        Amount = scoreRow.Score
                    });
                }
            };
            return scores;
        }
    }
}
