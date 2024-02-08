namespace Gilde.SchietScore.Models
{
    public class Competition
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}
        public List<GameElement> GameElements { get; set; }
    }
}
