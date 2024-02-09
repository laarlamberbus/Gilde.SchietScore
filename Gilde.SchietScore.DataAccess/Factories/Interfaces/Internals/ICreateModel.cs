namespace Gilde.SchietScore.Persistence.Factories.Interfaces.Internals
{
    public interface ICreateModel<Tmodel, Tdto> where Tmodel : class where Tdto : class
    {
        Tmodel CreateModel(Tdto dto);
    }
}
