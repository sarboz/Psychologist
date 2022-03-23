using System.Threading.Tasks;
using ReactiveUI;

namespace Psychologist.Core.Abstractions
{
    public abstract class BaseViewModel : ReactiveObject
    {
        public string Title { get; set; }
        public virtual Task ViewInitialized()
        {
            return Task.CompletedTask;
        }
    }
}