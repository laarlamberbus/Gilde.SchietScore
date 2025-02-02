namespace Gilde.SchietScore.Models
{
    public class Wedstrijd
    {
        public int Id { get; set; }
        public required string Naam { get; set; }
        public DateOnly StartDatum { get; set; }
        public DateOnly EindDatum { get; set; }
    }
}
