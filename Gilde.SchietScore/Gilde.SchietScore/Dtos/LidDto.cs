namespace Gilde.SchietScore.Dtos
{
    public class LidDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<WedstrijdScoreDto> Scores { get; set; }
    }
}
