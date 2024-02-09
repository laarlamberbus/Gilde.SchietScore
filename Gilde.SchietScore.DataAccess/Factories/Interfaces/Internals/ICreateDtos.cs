namespace Gilde.SchietScore.Persistence.Factories.Interfaces.Internals
{
    public interface ICreateDtos<Tdto, Tmodel> where Tdto : class where Tmodel : class
    {
        List<Tdto> CreateDtos(List<Tmodel> models);
    }
}
