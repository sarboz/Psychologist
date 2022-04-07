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
            builder.RegisterType<SubChapterPage>().As<IViewFor<SubChapterViewModel>>();
            builder.RegisterType<ArticlePage>().As<IViewFor<ArticleViewModel>>();
            builder.RegisterType<HomePage>().As<IViewFor<HomeViewModel>>();
            builder.RegisterType<FavoriteSubChapterPage>().As<IViewFor<FavoriteSubChapterViewModel>>();
            builder.RegisterType<AuthorPage>().As<IViewFor<AuthorViewModel>>();
            builder.RegisterType<SearchPage>().As<IViewFor<SearchViewModel>>();
            builder.RegisterType<SupportPage>().As<IViewFor<SupportViewModel>>();
            
            builder.RegisterType<DatabasePathProvider>().As<IDatabasePathProvider>();
            builder.RegisterType<NavigationFacade>().As<INavigationFacade>();
        }
    }
}