using System;
using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository;
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

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<SubChapterViewModel>().AsSelf();
            builder.RegisterType<ArticleViewModel>().AsSelf();
            builder.RegisterType<HomeViewModel>().AsSelf();
            builder.RegisterType<FavoriteSubChapterViewModel>().AsSelf();
            builder.RegisterType<AuthorViewModel>().AsSelf();
            
            
            builder.RegisterType<Context>().As<IContext>().OnActivated(OnDatabaseCreating);
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DependencyResolver>().As<IDependencyResolver>().SingleInstance();
            
            builder.RegisterType<ChapterRepository>().As<IChapterRepository>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<SubChapterRepository>().As<ISubChapterRepository>();

            RegisterTypes(builder);
            return Container = builder.Build();
        }

        private void OnDatabaseCreating(IActivatedEventArgs<Context> obj)
        {
            try
            {
                obj.Instance.Database.OpenConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Database creating exception:{e.Message}");
            }
        }

        protected abstract void RegisterTypes(ContainerBuilder builder);
    }
}