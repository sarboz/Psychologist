using Autofac;
using Psychologist.Core;
using Psychologist.Core.Abstractions;
using Psychologist.Core.ViewModels;
using Psychologist.UI.Facades;
using Psychologist.UI.Views;
using ReactiveUI;

namespace Psychologist.UI
{
    public class DependencyInitializer : DependencyInitializerCore
    {
        protected override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>().As<IViewFor<MainViewModel>>();
            builder.RegisterType<DatabasePathProvider>().As<IDatabasePathProvider>();
            builder.RegisterType<NavigationFacade>().As<INavigationFacade>();
        }
    }
}