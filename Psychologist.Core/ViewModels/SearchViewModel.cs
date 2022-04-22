using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly ISubChapterRepository _subChapterRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly INavigationService _navigationService;
        private string _searchQuery;

        public SubChapter SelectedSubChapter { get; set; }
        public ReactiveCommand<Unit, Unit> SubChapterSelectCommand { get; }

        public string SearchQuery
        {
            get => _searchQuery;
            set => this.RaiseAndSetIfChanged(ref _searchQuery, value);
        }

        private List<SubChapter> SubChapters { get; set; } = new();
        public ObservableCollection<SubChapter> DisplayItems { get; set; } = new();
        public ReactiveCommand<Unit, Unit> SearchCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NavigationBackCommand { get; set; }

        public SearchViewModel(ISubChapterRepository subChapterRepository, IArticleRepository articleRepository,
            INavigationService navigationService)
        {
            _subChapterRepository = subChapterRepository;
            _articleRepository = articleRepository;
            _navigationService = navigationService;
            NavigationBackCommand = ReactiveCommand.CreateFromTask(navigationService.PopNavigateAsync);
            SubChapterSelectCommand = ReactiveCommand.CreateFromTask(NavigateToArticleViewModel);
            SearchCommand = ReactiveCommand.CreateFromTask(Search);
        }

        private Task NavigateToArticleViewModel()
        {
            if (SelectedSubChapter is not null)
            {
                _navigationService.NavigateAsync<ArticleViewModel>(("subChapter", SelectedSubChapter));
                SelectedSubChapter = null;
            }

            return Task.CompletedTask;
        }

        private async Task Search()
        {
            if (_searchQuery.Length > 3)
            {
                var articles = await _articleRepository.Search(_searchQuery.ToLower());
                DisplayItems.Clear();

                var enumerable =
                    SubChapters.Where(chapter => articles.Exists(article => article.SubChapterId == chapter.Id));
                DisplayItems.AddRange(enumerable);
                return;
            }
            DisplayItems.Clear();
            DisplayItems.AddRange(SubChapters);
        }


        public override async Task ViewInitialized()
        {
            SubChapters = await _subChapterRepository.GetAll();
            DisplayItems.AddRange(SubChapters);
        }
    }
}