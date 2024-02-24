namespace Gilde.SchietScore.Persistence.Dtos
{
    public class CompetitieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDatum { get; set; }
        public DateOnly EndDatum { get; set; }
        public bool IsActive { get; set; }
        public List<KorpsDto> Korpsen { get; set; }
        public List<WedstrijdDto> Wedstrijden { get; set; }
    }
}
