using Autofac;
using Psychologist.Core;
using Psychologist.Core.Abstractions;
using Psychologist.Core.ViewModels;
using Psychologist.UI.Facades;
using ReactiveUI;

namespace Psychologist.UI
{
    public class DependencyInitializer:DependencyInitializerCore
    {
        protected override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>().As<IViewFor<HomeViewModel>>();

            builder.RegisterType<NavigationFacade>().As<INavigationFacade>();
        }
    }
}