using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;

namespace MyRecipeApp.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = Context.Set<T>();

            if (include != null)
                query = include(query);

            return query;
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
    }
}
