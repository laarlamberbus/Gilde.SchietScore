namespace Gilde.SchietScore.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public MemberClassType Class { get; set; }
        public bool IsShootingMember { get; set; }
    }

    public enum MemberClassType
    {
        A = 1,
        B = 2,
        C = 3
    }
}
