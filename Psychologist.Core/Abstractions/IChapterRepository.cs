using System.Collections.Generic;
using System.Threading.Tasks;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Abstractions
{
    public interface IChapterRepository
    {
        Task<List<Chapter>> GetAll();
        void Update(Chapter chapter);
        public Task VisibleChapter();
        public Task<bool> IsVisible();
    }
}