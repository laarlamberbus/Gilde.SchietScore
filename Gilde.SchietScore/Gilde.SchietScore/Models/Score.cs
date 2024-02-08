namespace Gilde.SchietScore.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateOnly Date { get; set; }
        public int AmountOfBullets { get; set; }
        public Member Member { get; set; }
        public GameElement GameElement { get; set; }
        public int GameElementId { get; set; }
        public int MemberId { get; set; }
    }
}
