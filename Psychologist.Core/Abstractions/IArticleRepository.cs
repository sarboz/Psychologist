using System.Collections.Generic;
using System.Threading.Tasks;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Abstractions
{
    public interface IArticleRepository
    {
        Task<Article> GetBySubChapterId(int id);
        void Update(Article article);
        Task<List<Article>> Search(string text);
    }
}