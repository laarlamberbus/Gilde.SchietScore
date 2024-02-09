namespace Gilde.SchietScore.Application.Builders.Interfaces.Internals
{
    public interface IBuildDto<Tdto, Tmodel>
        where Tdto : class
        where Tmodel : class
    {
        Tdto BuildDto(Tdto toBuild, Tmodel toBuildFrom);
    }
}
