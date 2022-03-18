using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using Psychologist.Core.ViewModels;
using ReactiveUI;

namespace Psychologist.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly INavigationFacade _facade;
        private readonly IDependencyResolver _resolver;

        public NavigationService(INavigationFacade facade, IDependencyResolver resolver)
        {
            _facade = facade;
            _resolver = resolver;
        }

        public Task NavigateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            var view = GetView(viewModel);
            return _facade.PushAsync(view);
        }

        public Task PopNavigateAsync()
        {
            return _facade.PopAsync();
        }

        public void SetMainPage<TViewModel>() where TViewModel : BaseViewModel
        {
            var view = GetView<TViewModel>();
            _facade.SetMainPage(view);
        }

        public void InitMainPage()
        {
            SetMainPage<HomeViewModel>();
        }

        private IViewFor<TViewModel> GetView<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            var view = _resolver.Resolve<IViewFor<TViewModel>>();
            ((IViewFor)view).ViewModel = viewModel;
            return view;
        }

        private IViewFor<TVieWModel> GetView<TVieWModel>(params (string paramaterName, object value)[] parameters)
            where TVieWModel : BaseViewModel
        {
            var viewModel = _resolver.Resolve<TVieWModel>(parameters);
            return GetView(viewModel);
        }
    }
}