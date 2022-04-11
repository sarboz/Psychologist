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
                var listAsync = await _context.Get<Chapter>().ToListAsync();
                // listAsync.ForEach(item =>
                // {
                //     var readOnlyCollection = _firebaseClient.Child("chapters")
                //         .OnceAsync<object>().Result;
                //     item.ViewCount = readOnlyCollection.Count;
                // });

                return listAsync;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Chapter chapter)
        {
            _context.Update(chapter);
        }
    }
}