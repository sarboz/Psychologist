using System;
using Autofac;
using Psychologist.Core.Abstractions;
using Psychologist.UI.Abstractions;
using Xamarin.Forms;

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
            
            AppDomain.CurrentDomain.UnhandledException += (s,e)=>
            {
                System.Diagnostics.Debug.WriteLine("AppDomain.CurrentDomain.UnhandledException: {0}. IsTerminating: {1}", e.ExceptionObject, e.IsTerminating);
            };
        }
    }
}