namespace Psychologist.Core.Abstractions
{
    public interface IDependencyResolver
    {
        T Resolve<T>(params (string parametrName, object value)[] parameters);
    }
}