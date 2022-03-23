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
        private Article _article;

        public Article Article
        {
            get => _article;
            private set => this.RaiseAndSetIfChanged(ref _article, value);
        }

        public ArticleViewModel(IArticleRepository repository, SubChapter subChapter)
        {
            _repository = repository;
            _subChapter = subChapter;
            Title = subChapter.Title;
        }

        public override async Task ViewInitialized()
        {
            Article = await _repository.GetBySubChapterId(_subChapter.Id);
        }
    }
}