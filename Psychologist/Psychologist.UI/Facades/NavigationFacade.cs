using System;
using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using ReactiveUI;
using Xamarin.Forms;

namespace Psychologist.UI.Facades
{
    public class NavigationFacade : INavigationFacade
    {
        private INavigation Navigation
        {
            get
            {
                if (Shell.Current == null)
                    return Application.Current.MainPage.Navigation;
                return Shell.Current.Navigation;
            }
        }

        public Task PopAsync()
        {
            return Navigation.PopAsync(true);
        }

        public Task PushAsync<TViewModel>(IViewFor<TViewModel> view) where TViewModel : BaseViewModel
        {
            if (view is Page page)
                return Navigation.PushAsync(page, true);
            throw new ArgumentException($"{view} is not Page");
        }

        public void SetMainPage<TViewModel>(IViewFor<TViewModel> view) where TViewModel : BaseViewModel
        {
            if (view is Shell shell)
                Application.Current.MainPage = shell;
            else
                Application.Current.MainPage = new NavigationPage(view as Page);
        }
    }
}