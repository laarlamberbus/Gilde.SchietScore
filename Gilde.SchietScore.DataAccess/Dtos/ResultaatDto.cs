namespace Gilde.SchietScore.Persistence.Dtos
{
    public class ResultaatDto
    {
        public int Id { get; set; }
        public DateOnly Datum { get; set; }
        public int Score { get; set; }
        public int AantalKogels { get; set; }

        public int WedstrijdId { get; set; }
        public int DeelnemerId { get; set; }

        public WedstrijdDto Wedstrijd { get; set; }
        public LidDto Deelnemer { get; set; }
    }
}
