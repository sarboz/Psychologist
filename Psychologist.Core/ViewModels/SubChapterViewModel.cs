﻿using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class SubChapterViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISubChapterRepository _repository;
        public readonly Chapter Chapter;
        private SubChapter _selectedSubChapter;

        public SubChapter SelectedSubChapter
        {
            get => _selectedSubChapter;
            set => this.RaiseAndSetIfChanged(ref _selectedSubChapter, value);
        }

        public ReactiveCommand<SubChapter, Unit> SubChapterSelectCommand { get; }
        public ReactiveCommand<SubChapter, Unit> IsFavoriteChangedCommand { get; }
        public ObservableCollection<SubChapter> Items { get; } = new();

        public SubChapterViewModel(INavigationService navigationService, ISubChapterRepository repository,
            Chapter chapter)
        {
            _navigationService = navigationService;
            _repository = repository;
            Chapter = chapter;
            Title = chapter.Title;
            SubChapterSelectCommand = ReactiveCommand.CreateFromTask<SubChapter>(NavigateToArticleViewModel);
            IsFavoriteChangedCommand = ReactiveCommand.Create<SubChapter>(ChangeFavoriteValue);
        }

        private void ChangeFavoriteValue(SubChapter obj)
        {
            obj.IsFavorite = obj.IsFavorite != true;
            _repository.Update(obj);
        }

        private Task NavigateToArticleViewModel(SubChapter chapter)
        {
            if (SelectedSubChapter is not null)
            {
                _navigationService.NavigateAsync<ArticleViewModel>(("subChapter", SelectedSubChapter));
                SelectedSubChapter = null;
            }

            return Task.CompletedTask;
        }

        public override async Task ViewInitialized()
        {
            Items.Clear();
            var items = await _repository.GetSubChapterByChapterId(Chapter.Id);
            Items.AddRange(items);
        }
    }
}