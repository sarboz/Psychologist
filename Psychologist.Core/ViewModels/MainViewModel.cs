using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using Firebase.Database;
using Firebase.Database.Query;
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
        private readonly FirebaseClient _firebaseClient;
        private readonly INetworkConnectivity _connectivity;
        private Chapter _selectedChapter;

        public ObservableCollection<Chapter> Chapters { get; } = new();

        public ReactiveCommand<Chapter, Unit> ChapterSelectCommand { get; set; }

        public Chapter SelectedChapter
        {
            get => _selectedChapter;
            set => this.RaiseAndSetIfChanged(ref _selectedChapter, value);
        }

        public MainViewModel(IChapterRepository chapterRepository, ISubChapterRepository subChapterRepository,
            INavigationService navigationService, FirebaseClient firebaseClient, INetworkConnectivity connectivity)
        {
            _chapterRepository = chapterRepository;
            _subChapterRepository = subChapterRepository;
            _navigationService = navigationService;
            _firebaseClient = firebaseClient;
            _connectivity = connectivity;

            ChapterSelectCommand = ReactiveCommand.CreateFromTask<Chapter>(NavigateToSubChapter);
        }

        private async Task NavigateToSubChapter(Chapter chapter)
        {
            if (SelectedChapter is not null)
            {
                if (!chapter.IsViewed && _connectivity.IsConnected )
                {
                    var count = await _firebaseClient.Child("chapters").Child(chapter.Id.ToString)
                        .OnceSingleAsync<int>();
                    await _firebaseClient.Child("chapters").Child(chapter.Id.ToString).PutAsync(++count);
                    chapter.IsViewed = true;
                    _chapterRepository.Update(chapter);
                }

                switch (chapter.Id)
                {
                    case 8:
                    {
                        var subChapterByChapterId =
                            await _subChapterRepository.GetSubChapterByChapterId(_selectedChapter.Id);
                        await _navigationService.NavigateAsync<ArticleViewModel>(("subChapter",
                            subChapterByChapterId[0]));
                        SelectedChapter = null;
                        return;
                    }
                    case 9:
                    {
                        var subChapterByChapterId =
                            await _subChapterRepository.GetSubChapterByChapterId(_selectedChapter.Id);
                        await _navigationService.NavigateAsync<ArticleViewModel>(("subChapter",
                            subChapterByChapterId[0]));
                        SelectedChapter = null;
                        return;
                    }
                    default:
                        await _navigationService.NavigateAsync<SubChapterViewModel>(("chapter", SelectedChapter));
                        SelectedChapter = null;
                        break;
                }
            }
        }

        public override async Task ViewAppearing()
        {
            Chapters.Clear();
            var chapters = await _chapterRepository.GetAll();
            Chapters.AddRange(chapters);
        }

        public override Task ViewInitialized()
        {
            if (_connectivity.IsConnected)
                foreach (var chapter in Chapters)
                    Task.Factory.StartNew(() => FetchCounts(chapter));
            return Task.CompletedTask;
        }

        private async Task FetchCounts(Chapter item)
        {
            var readOnlyCollection = await _firebaseClient.Child("chapters").Child(item.Id.ToString)
                .OnceSingleAsync<int>();
            item.ViewCount = readOnlyCollection;
            _chapterRepository.Update(item);
        }
    }
}