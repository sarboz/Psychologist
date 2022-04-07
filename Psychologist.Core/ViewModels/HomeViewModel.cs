using System.Reactive;
using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ReactiveCommand<Unit, Unit> NavigateToSearchPageCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NavigateToSupportPageCommand { get; set; }

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToSearchPageCommand = ReactiveCommand.CreateFromTask(NavigateToSearchPage);
            NavigateToSupportPageCommand = ReactiveCommand.CreateFromTask(NavigateToSupportPage);
        }

        private Task NavigateToSearchPage()
        {
            return _navigationService.NavigateAsync<SearchViewModel>();
        }
        
        private Task NavigateToSupportPage()
        {
            return _navigationService.NavigateAsync<SupportViewModel>();
        }
    }
}