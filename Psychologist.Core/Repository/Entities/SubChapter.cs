using ReactiveUI;

namespace Psychologist.Core.Repository.Entities
{
    public class SubChapter:BaseEntity
    {
        public bool IsFavorite { get; set; }
        public string Title { get; set; }
        public int IdChapter { get; set; }
    }
}