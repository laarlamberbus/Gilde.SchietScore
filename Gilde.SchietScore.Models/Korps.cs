namespace Gilde.SchietScore.Domain
{
    public class Korps : Deelnemer
    {
        public Competitie Competitie { get; set; }
        public Schutter SchutterA { get; set; }
        public Schutter SchutterB { get; set; }
        public Schutter SchutterC { get; set; }
        public int GemiddeldeScore { get; set; }
    }
}
