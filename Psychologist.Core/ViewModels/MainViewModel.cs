using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly ISubChapterRepository _subChapterRepository;
        private readonly INavigationService _navigationService;
        private Chapter _selectedChapter;

        public ObservableCollection<Chapter> Chapters { get; } = new();

        public ReactiveCommand<Chapter, Unit> ChapterSelectCommand { get; set; }

        public Chapter SelectedChapter
        {
            get => _selectedChapter;
            set => this.RaiseAndSetIfChanged(ref _selectedChapter, value);
        }

        public MainViewModel(IChapterRepository chapterRepository, ISubChapterRepository subChapterRepository,
            INavigationService navigationService)
        {
            _chapterRepository = chapterRepository;
            _subChapterRepository = subChapterRepository;
            _navigationService = navigationService;

            ChapterSelectCommand = ReactiveCommand.CreateFromTask<Chapter>(NavigateToSubChapter);
        }

        private async Task NavigateToSubChapter(Chapter chapter)
        {
            if (SelectedChapter is not null)
            {
                if (chapter.Id == 7)
                {
                    var subChapterByChapterId =
                        await _subChapterRepository.GetSubChapterByChapterId(_selectedChapter.Id);
                    await _navigationService.NavigateAsync<ArticleViewModel>(("subChapter", subChapterByChapterId[0]));
                    SelectedChapter = null;
                    return;
                }

                await _navigationService.NavigateAsync<SubChapterViewModel>(("chapter", SelectedChapter));
                SelectedChapter = null;
            }
        }

        public override async Task ViewInitialized()
        {
            Chapters.Clear();
            var chapters = await _chapterRepository.GetAll();
            Chapters.AddRange(chapters);
        }
    }
}