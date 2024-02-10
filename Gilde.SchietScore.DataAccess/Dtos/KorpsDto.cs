namespace Gilde.SchietScore.Persistence.Dtos
{
    public class KorpsDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int GemiddeldeScore { get; set; }

        public int CompetitieId { get; set; }

        public CompetitieDto Competitie { get; set; }
        public List<LidDto> Leden { get; set; }
    }
}
