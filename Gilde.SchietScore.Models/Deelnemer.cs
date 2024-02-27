namespace Gilde.SchietScore.Domain
{
    public abstract class Deelnemer : Lid
    {
        public string KNTSNummer { get; set; }
        public DeelnemerKlasse Klasse { get; set; }
        public int Score { get; set; }
        public int AantalKogels { get; set; }
    }
}
