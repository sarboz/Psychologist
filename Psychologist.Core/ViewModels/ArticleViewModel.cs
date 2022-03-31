using System.Reactive;
using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class ArticleViewModel : BaseViewModel
    {
        private readonly IArticleRepository _repository;
        private readonly SubChapter _subChapter;
        private readonly INavigationService _navigationService;
        private Article _article;


        public ReactiveCommand<Unit, Unit> NavigateToContactCommand { get; set; }

        public Article Article
        {
            get => _article;
            private set => this.RaiseAndSetIfChanged(ref _article, value);
        }

        public ArticleViewModel(IArticleRepository repository, SubChapter subChapter,
            INavigationService navigationService)
        {
            _repository = repository;
            _subChapter = subChapter;
            _navigationService = navigationService;
            Title = subChapter.Title;

            NavigateToContactCommand = ReactiveCommand.CreateFromTask(NavigateToAuthorPage);
        }

        private Task NavigateToAuthorPage()
        {
            return _navigationService.NavigateAsync<AuthorViewModel>();
        }

        public override async Task ViewInitialized()
        {
            Article = await _repository.GetBySubChapterId(_subChapter.Id);
        }
    }
}