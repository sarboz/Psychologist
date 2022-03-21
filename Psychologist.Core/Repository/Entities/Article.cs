namespace Psychologist.Core.Repository.Entities
{
    public class Article : BaseEntity
    {
        public int IdSubChapter { get; set; }
        public string Content { get; set; }
    }
}