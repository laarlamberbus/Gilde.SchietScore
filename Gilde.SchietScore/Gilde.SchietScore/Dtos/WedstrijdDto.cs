namespace Gilde.SchietScore.Dtos
{
    public class WedstrijdDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<WedstrijdScoreDto> Scores { get; set; }
    }
}
