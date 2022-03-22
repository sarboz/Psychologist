using System.Linq;
using Microsoft.EntityFrameworkCore;
using Psychologist.Core.Abstractions;
using Psychologist.Core.Repository.Entities;

namespace Psychologist.Core.Repository
{
    public class Context:DbContext,IContext
    {
        private readonly IDatabasePathProvider _pathProvider;
        public Context(IDatabasePathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<SubChapter> SubChapters { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={_pathProvider.GetDatabasePath()}");
            base.OnConfiguring(optionsBuilder);
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void Update(object entity)
        {
            base.Update(entity);
            SaveChanges();
        }
    }
}