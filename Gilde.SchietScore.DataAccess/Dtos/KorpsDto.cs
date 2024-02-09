namespace Gilde.SchietScore.Persistence.Dtos
{
    public class KorpsDto
    {
        public string Naam { get; set; }
        public int GemiddeldeScore { get; set; }
        public CompetitieDto Competitie { get; set; }
        public List<LidDto> Leden { get; set; }
    }
}
