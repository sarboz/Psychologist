using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Repository
{
    public class SubChapterRepository : ISubChapterRepository
    {
        private readonly IContext _context;

        public SubChapterRepository(IContext context)
        {
            _context = context;
        }

        public Task<List<SubChapter>> GetSubChapterByChapterId(int chapterId)
        {
            return _context.Get<SubChapter>().Where(sub => sub.IdChapter == chapterId).ToListAsync();
        }

        public void Update(SubChapter subChapter)
        {
            _context.Update(subChapter);
        }

        public Task<List<SubChapter>> GetFavorites()
        {
            return _context.Get<SubChapter>().Where(chapter => chapter.IsFavorite).ToListAsync();
        }

        public Task<List<SubChapter>> GetAll()
        {
            return _context.Get<SubChapter>().ToListAsync();
        }
    }
}