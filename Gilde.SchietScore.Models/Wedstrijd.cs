namespace Gilde.SchietScore.Domain
{
    public abstract class Wedstrijd
    {
        public int Id { get; set; }
        public DateOnly Datum { get; set; }
        public List<Deelnemer> Deelnemers { get; set; }
    }
}
