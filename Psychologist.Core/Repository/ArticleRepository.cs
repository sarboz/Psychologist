﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IContext _context;

        public ArticleRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Article> GetBySubChapterId(int id)
        {
            return (await _context.Get<Article>().Where(article => article.SubChapterId == id).ToListAsync()).First();
        }

        public void Update(Article article)
        {
            _context.Update(article);
        }

        public async Task<List<Article>> Search(string text)
        {
            var articles = await _context.Get<Article>().ToListAsync();
            var enumerable = articles.Where(article => article.Content.ToLower().Contains(text)).Select(article =>
                new Article { SubChapterId = article.SubChapterId, Id = article.Id });
            return enumerable.ToList();
        }
    }
}