namespace Gilde.SchietScore.Persistence.Factories.Interfaces.Internals
{
    public interface ICreateDto<Tdto, Tmodel> where Tdto : class where Tmodel : class
    {
        Tdto CreateDto(Tmodel model);
    }
}
