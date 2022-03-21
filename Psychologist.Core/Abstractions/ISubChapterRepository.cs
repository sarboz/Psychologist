using System.Collections.Generic;
using System.Threading.Tasks;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Abstractions
{
    public interface ISubChapterRepository
    {
        Task<List<SubChapter>> GetSubChapterByChapterId(int chapterId);
        void Update(SubChapter subChapter);
    }
}