namespace Gilde.SchietScore.Models
{
    public class ScoreForm
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateOnly Date { get; set; }
        public List<ScoreRow> ScoreAddRows { get; set; }
    }

    public class ScoreRow
    {
        public int ScoreId { get; set; }
        public int Score { get; set; }
        public int GameElementId { get; set; }
        public string GameElementName { get; set; }
    }
}
