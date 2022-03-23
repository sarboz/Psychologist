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
        private Chapter _selectedActivity;

        public ObservableCollection<Chapter> Chapters { get; } = new();

        public ReactiveCommand<Chapter, Unit> ChapterSelectCommand { get; set; }

        public Chapter SelectedChapter
        {
            get => _selectedActivity;
            set => this.RaiseAndSetIfChanged(ref _selectedActivity, value);
        }

        public MainViewModel(IChapterRepository chapterRepository, INavigationService navigationService)
        {
            _chapterRepository = chapterRepository;
            _navigationService = navigationService;

            ChapterSelectCommand = ReactiveCommand.CreateFromTask<Chapter>(NavigateToSubChapter);
        }

        private Task NavigateToSubChapter(Chapter chapter)
        {
            if (SelectedChapter is not null)
            {
                _navigationService.NavigateAsync<SubChapterViewModel>(("chapter", SelectedChapter));
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