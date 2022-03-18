using System.Linq;
using Autofac;
using Psychologist.Core.Abstractions;

namespace Psychologist.Core.Services
{
    public class DependencyResolver : IDependencyResolver
    {
        public T Resolve<T>(params (string parametrName, object value)[] parameters)
        {
            var namedParameters = parameters.Select(param => new NamedParameter(param.parametrName, param.value));
            var container = DependencyInitializerCore.Container;
            return container.Resolve<T>(namedParameters);
        }
    }
}