using System.Linq;

namespace Psychologist.Core.Abstractions
{
    public interface IContext
    {
        IQueryable<T> Get<T>() where T: class;
        void Update(object entity);
    }
}