using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AppCenter.Crashes;
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
                if (!chapter.IsViewed && _connectivity.IsConnected)
                {
                    try
                    {
                        var count = await _firebaseClient.Child("chapters").Child(chapter.Id.ToString)
                            .OnceSingleAsync<int>();
                        await _firebaseClient.Child("chapters").Child(chapter.Id.ToString).PutAsync(++count);
                        chapter.IsViewed = true;
                        _chapterRepository.Update(chapter);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Crashes.TrackError(e);
                    }
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
            if (DateTime.Now > DateTime.Parse("06/16/2022"))
                await _chapterRepository.VisibleChapter();
            Chapters.Clear();
            var chapters = await _chapterRepository.GetAll();
            Chapters.AddRange(chapters);
        }

        public override async Task ViewInitialized()
        {
            if (_connectivity.IsConnected)
            {
                var enumerable = Chapters.Select(FetchCounts);
                var chapters = await Task.WhenAll(enumerable);
                foreach (var chapter in chapters)
                {
                    _chapterRepository.Update(chapter);
                }
            }
        }

        private async Task<Chapter> FetchCounts(Chapter item)
        {
            try
            {
                var readOnlyCollection = await _firebaseClient.Child("chapters").Child(item.Id.ToString)
                    .OnceSingleAsync<int>();
                var commentChapterCount = await _firebaseClient.Child("comments").Child(item.Id.ToString)
                    .OnceSingleAsync<int>();
                item.ViewCount = readOnlyCollection;
                item.CommentCount = commentChapterCount;
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Crashes.TrackError(e);
            }

            return item;
        }
    }
}