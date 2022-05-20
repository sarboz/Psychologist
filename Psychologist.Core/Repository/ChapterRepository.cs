using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.EntityFrameworkCore;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly IContext _context;
        private readonly FirebaseClient _firebaseClient;

        public ChapterRepository(IContext context, FirebaseClient firebaseClient)
        {
            _context = context;
            _firebaseClient = firebaseClient;
        }

        public async Task<List<Chapter>> GetAll()
        {
            try
            {
                var listAsync = await _context.Get<Chapter>().Where(chapter => chapter.Visible).ToListAsync();
                return listAsync;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task VisibleChapter()
        {
            var listAsync = await _context.Get<Chapter>().Where(chapter => !chapter.Visible).ToListAsync();
            foreach (var chapter in listAsync)
            {
                chapter.Visible = true;
                Update(chapter);
            }
        }

        public void Update(Chapter chapter)
        {
            _context.Update(chapter);
        }
    }
}