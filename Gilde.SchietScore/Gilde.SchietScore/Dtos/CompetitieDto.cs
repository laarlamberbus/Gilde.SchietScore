namespace Gilde.SchietScore.Dtos
{
    public class CompetitieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<KorpsDto> Korpsen { get; set; }
    }
}
