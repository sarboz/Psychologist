using System;
using Autofac;

namespace Psychologist.Core
{
    public abstract class DependencyInitializerCore
    {
        public IContainer Container { get; set; }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();


            RegisterTypes(builder);
            return builder.Build();
        }

        protected abstract void RegisterTypes(ContainerBuilder builder);
    }
}