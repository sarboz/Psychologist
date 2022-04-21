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
    public class FeedbackViewModel : BaseViewModel
    {
        private readonly IChapterRepository _repository;
        private readonly FirebaseClient _firebaseClient;
        private readonly int _idChapter;
        private Chapter _selected;

        public ObservableCollection<Chapter> Chapters { get; set; } = new();
        public ReactiveCommand<Unit, Unit> CommentSendCommand { get; set; }

        public Chapter SelectedChapter
        {
            get => _selected;
            set => this.RaiseAndSetIfChanged(ref _selected, value);
        }

        public FeedbackViewModel(IChapterRepository repository, FirebaseClient firebaseClient, int idChapter=0)
        {
            _repository = repository;
            _firebaseClient = firebaseClient;
            _idChapter = idChapter;
            CommentSendCommand = ReactiveCommand.CreateFromTask(ChapterCommented);
        }

        private async Task ChapterCommented()
        {
            try
            {
                if (_selected == null) return;
                var count = await _firebaseClient.Child("comments").Child(_selected.Id.ToString)
                    .OnceSingleAsync<int>();
                await _firebaseClient.Child("comments").Child(_selected.Id.ToString).PutAsync(++count);
                _selected.CommentCount = count;
                _repository.Update(_selected);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Crashes.TrackError(e);
            }
        }

        public override async Task ViewAppearing()
        {
            var chapters = await _repository.GetAll();
            Chapters.AddRange(chapters);
            if (_idChapter != 0)
                SelectedChapter = Chapters.FirstOrDefault(chapter => chapter.Id == _idChapter);
        }
    }
}