using System;
using Autofac;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Services;
using Psychologist.Core.ViewModels;

namespace Psychologist.Core
{
    public abstract class DependencyInitializerCore
    {
        public static IContainer Container { get; set; }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HomeViewModel>().AsSelf();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DependencyResolver>().As<IDependencyResolver>().SingleInstance();

            RegisterTypes(builder);
            return Container = builder.Build();
        }

        protected abstract void RegisterTypes(ContainerBuilder builder);
    }
}