namespace Gilde.SchietScore.Persistence.Dtos
{
    public class LidDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string KNTSNummer { get; set; }
        public bool IsSchietendLid { get; set; }
        public string DeelnemerClassType { get; set; }
        public bool SoftDeleted { get; set; }
        public List<WedstrijdDto> Wedstrijden { get; set; }
        public List<KorpsDto> Korpsen { get; set; }
    }
}
