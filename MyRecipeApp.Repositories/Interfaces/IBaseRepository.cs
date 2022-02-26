using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyRecipeApp.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
