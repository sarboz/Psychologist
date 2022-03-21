using System.Collections.ObjectModel;
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
     
        public ObservableCollection<Chapter> Chapters { get; } = new();

        public MainViewModel(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public override async Task ViewInitialized()
        {
            var chapters = await _chapterRepository.GetAll();
            Chapters.AddRange(chapters);
        }
    }
}