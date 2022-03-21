using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly IContext _context;

        public ChapterRepository(IContext context)
        {
            _context = context;
        }

        public Task<List<Chapter>> GetAll()
        {
            return _context.Get<Chapter>().ToListAsync();
        }

        public void Update(Chapter chapter)
        {
            _context.Update(chapter);
        }
    }
}