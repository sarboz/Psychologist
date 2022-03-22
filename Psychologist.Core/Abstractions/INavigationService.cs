using System.Threading.Tasks;

namespace Psychologist.Core.Abstractions
{
    public interface INavigationService
    {
        Task NavigateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;
        Task NavigateAsync<TViewModel>(params (string paramaterName,object value)[] parameters) where TViewModel : BaseViewModel;
        Task PopNavigateAsync();
        void SetMainPage<TViewModel>() where TViewModel : BaseViewModel;
        void InitMainPage();
    }
}