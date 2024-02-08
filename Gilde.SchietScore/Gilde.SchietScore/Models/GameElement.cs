using System.Diagnostics.CodeAnalysis;

namespace Gilde.SchietScore.Models
{
    public class GameElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Score> Scores { get; set; }
    }

    public class GameElementComparer : IEqualityComparer<GameElement>
    {
        public bool Equals(GameElement? x, GameElement? y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] GameElement obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
