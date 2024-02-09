namespace Gilde.SchietScore.Domain
{
    public abstract class Deelnemer : Lid
    {
        public string KNTSNummer { get; set; }
        public DeelnemerClassType DeelnemerClassType { get; set; }
        public int Score { get; set; }
    }
}
