using System.ComponentModel.DataAnnotations.Schema;

namespace Psychologist.Core.Repository.Entities
{
    public class Chapter : BaseEntity
    {
        public string Title { get; set; }
        public string ChapterOrder { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public  int ViewCount { get; set; } = 0;
    }
}