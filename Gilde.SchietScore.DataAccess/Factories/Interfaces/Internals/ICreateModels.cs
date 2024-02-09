namespace Gilde.SchietScore.Persistence.Factories.Interfaces.Internals
{
    public interface ICreateModels<Tmodel, Tdto> where Tmodel : class where Tdto : class
    {
        List<Tmodel> CreateModels(List<Tdto> dtos);
    }
}
