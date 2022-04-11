using System;
using System.Reactive;
using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEnvironment _environment;
        public ReactiveCommand<Unit, Unit> NavigateToSearchPageCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NavigateToSupportPageCommand { get; set; }

        public HomeViewModel(INavigationService navigationService, IEnvironment environment)
        {
            _navigationService = navigationService;
            _environment = environment;
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

        public override async Task ViewInitialized()
        {
            var value = _environment.GetValue("firstStart");
            if (string.IsNullOrEmpty(value))
            {
                _environment.SetValue("firstStart", DateTime.Today.ToString("d"));
            }
            else if (DateTime.Today > DateTime.Parse(value).Add(TimeSpan.FromDays(1)))
            {
                var displayAlert = await _environment.DisplayAlert("Оцените приложение",
                    "Напишете свое мнение о приложении", "Позже");
                if (displayAlert)
                {
                    await _environment.OpenUrl("https://play.google.com/store/apps/details?id=com.whatsapp");
                    _environment.SetValue("firstStart", DateTime.MaxValue.Subtract(TimeSpan.FromDays(10)).ToString("d"));
                }
            }
        }
    }
}