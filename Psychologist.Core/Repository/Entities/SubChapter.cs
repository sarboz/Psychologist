using ReactiveUI;

namespace Psychologist.Core.Repository.Entities
{
    public class SubChapter : BaseEntity
    {
        private bool _isFavorite;

        public bool IsFavorite
        {
            get => _isFavorite;
            set => this.RaiseAndSetIfChanged(ref _isFavorite, value);
        }
        
        public string Title { get; set; }
        public int IdChapter { get; set; }
    }
}