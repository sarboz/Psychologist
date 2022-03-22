using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DynamicData;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.ViewModels
{
    public class SubChapterViewModel : BaseViewModel
    {
        private readonly ISubChapterRepository _repository;
        private readonly int _chapterId;
        private ObservableCollection<SubChapter> Items { get; } = new();

        public SubChapterViewModel(ISubChapterRepository repository, int chapterId)
        {
            _repository = repository;
            _chapterId = chapterId;
        }

        public override async Task ViewInitialized()
        {
            Items.Clear();
            var items = await _repository.GetSubChapterByChapterId(_chapterId);
            Items.AddRange(items);
        }
    }
}