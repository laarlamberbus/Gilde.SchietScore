namespace Gilde.SchietScore.Models
{
    public class Korps
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }
    public static class KorpsList
    {
        public static List<Korps> AllKorps { get; set; } = new List<Korps>() {
            new() { Name = "Korps 1", Level = 1 },
            new() { Name = "Korps 2", Level = 2 },
            new() { Name = "Korps 3", Level = 3 },
            new() { Name = "Alle korps", Level = 0 },
        };
    }
}
