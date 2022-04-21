using System.ComponentModel.DataAnnotations.Schema;
using ReactiveUI;

namespace Psychologist.Core.Repository.Entities
{
    public class Chapter : BaseEntity
    {
        private int _count = 0;
        private int _commentCount=0;
        public string Title { get; set; }
        public string ChapterOrder { get; set; }
        public string Image { get; set; }

        public bool IsViewed { get; set; }

        public int ViewCount
        {
            get => _count;
            set => this.RaiseAndSetIfChanged(ref _count, value);
        }

        public int CommentCount
        {
            get => _commentCount;
            set => this.RaiseAndSetIfChanged(ref _commentCount, value);
        }
    }
}