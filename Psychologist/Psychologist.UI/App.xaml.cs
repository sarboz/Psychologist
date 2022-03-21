using Autofac;
using Microsoft.Extensions.DependencyModel;
using Psychologist.Core.Abstractions;
using Psychologist.UI.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Psychologist.UI
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Get<IDatabaseFileProvider>().CopyToSpecificFolder();
            var container = new DependencyInitializer().Build();
            var navigationService = container.Resolve<INavigationService>();
            navigationService.InitMainPage();
        }
    }
}