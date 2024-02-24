using Gilde.SchietScore.Domain.Enums;

namespace Gilde.SchietScore.Domain
{
    public abstract class Deelnemer : Lid
    {
        public string KNTSNummer { get; set; }
        public DeelnemerKlasseType DeelnemerKlasseType { get; set; }
        public int Score { get; set; }
    }
}
