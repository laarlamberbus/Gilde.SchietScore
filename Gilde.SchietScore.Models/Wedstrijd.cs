namespace Gilde.SchietScore.Domain
{
    public abstract class Wedstrijd
    {
        public int Id { get; set; }
        public DateOnly StartDatum { get; set; }
        public DateOnly EindDatum { get; set; }
        public List<Schutter> Deelnemers { get; set; }
    }
}
