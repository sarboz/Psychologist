namespace Psychologist.Core.Repository.Entities
{
    public class Article : BaseEntity
    {
        public int SubChapterId { get; set; }
        public string Content { get; set; }
    }
}