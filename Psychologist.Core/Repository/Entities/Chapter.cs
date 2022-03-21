using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace Psychologist.Core.Repository.Entities
{
    public class Chapter : BaseEntity
    {
        public string Title { get; set; }
        public string ChapterOrder { get; set; }
    }
}