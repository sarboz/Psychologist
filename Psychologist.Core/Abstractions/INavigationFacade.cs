using System.Threading.Tasks;
using ReactiveUI;

namespace Psychologist.Core.Abstractions
{
    public interface INavigationFacade
    {
        Task PopAsync();
        Task PushAsync<TViewModel>(IViewFor<TViewModel> view) where TViewModel:BaseViewModel;
        void SetMainPage<TViewModel>(IViewFor<TViewModel> view) where TViewModel : BaseViewModel;
    }

   
}