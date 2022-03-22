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
        private readonly INavigationService _navigationService;

        public ObservableCollection<Chapter> Chapters { get; } = new();

        public ReactiveCommand<Unit, Unit> ChapterSelectCommand { get; set; }
        public Chapter SelectedChapter { get; set; }

        public MainViewModel(IChapterRepository chapterRepository, INavigationService navigationService)
        {
            _chapterRepository = chapterRepository;
            _navigationService = navigationService;

            ChapterSelectCommand = ReactiveCommand.CreateFromTask(NavigateToSubChapter);
        }

        private Task NavigateToSubChapter()
        {
            if (SelectedChapter is not null)
            {
                _navigationService.NavigateAsync<SubChapterViewModel>(("chapterId", SelectedChapter.Id));
                SelectedChapter = null;
            }

            return Task.CompletedTask;
        }

        public override async Task ViewInitialized()
        {
            Chapters.Clear();
            var chapters = await _chapterRepository.GetAll();
            Chapters.AddRange(chapters);
        }
    }
}