﻿using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;
using ReactiveUI;

namespace Psychologist.Core.ViewModels
{
    public class FavoriteSubChapterViewModel : BaseViewModel
    {
        private readonly ISubChapterRepository _repository;
        private readonly INavigationService _navigationService;

        public SubChapter SelectedSubChapter { get; set; }
        public ReactiveCommand<Unit, Unit> SubChapterSelectCommand { get; }
        public ObservableCollection<SubChapter> Items { get; set; } = new();

        public FavoriteSubChapterViewModel(ISubChapterRepository repository, INavigationService navigationService)
        {
            _repository = repository;
            _navigationService = navigationService;

            SubChapterSelectCommand = ReactiveCommand.CreateFromTask(NavigateToArticleViewModel);
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

        public override async Task ViewAppearing()
        {
            Items.Clear();
            var subChapters = await _repository.GetFavorites();
            Items.AddRange(subChapters);
        }
    }
}