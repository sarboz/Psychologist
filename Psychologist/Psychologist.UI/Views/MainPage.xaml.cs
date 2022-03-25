using Autofac;
using Psychologist.Core;
using Psychologist.Core.ViewModels;

namespace Psychologist.UI.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = DependencyInitializerCore.Container.Resolve<MainViewModel>();
        }
    }
}