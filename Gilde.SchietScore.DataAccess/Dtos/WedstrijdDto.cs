namespace Gilde.SchietScore.Persistence.Dtos
{
    public class WedstrijdDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateOnly StartDatum { get; set; }
        public DateOnly EindDatum { get; set; }

        public List<ResultaatDto> Resultaten { get; set; }
        public List<LidDto> Deelnemers { get; set; }
    }
}
