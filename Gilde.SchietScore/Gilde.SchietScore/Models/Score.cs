namespace Gilde.SchietScore.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public required Wedstrijd Wedstrijd { get; set; }
        public required Lid Deelnemer  { get; set; }
    }
}
