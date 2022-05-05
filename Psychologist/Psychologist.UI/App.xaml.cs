using System;
using Autofac;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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

            AppCenter.Start("android=47f5c8bc-091b-45ae-817e-da4e629b8a8f;" +
                            "ios=dcc58094-29c9-40a1-a2cb-fcfcd3db550b;",
                typeof(Analytics), typeof(Crashes));
            
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Crashes.TrackError((Exception)e.ExceptionObject);
            };
        }
    }
}