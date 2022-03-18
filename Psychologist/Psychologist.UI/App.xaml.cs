using System;
using Autofac;
using Psychologist.Core.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Psychologist.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var container = new DependencyInitializer().Build();
            var navigationService = container.Resolve<INavigationService>();
            navigationService.InitMainPage();
        }
    }
}