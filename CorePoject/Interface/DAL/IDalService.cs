using System;
using System.Linq;
using System.Linq.Expressions;

namespace Interface.DAL
{
    public interface IDalService<T> where T : class, new()
    {
        T AddEntity(T entity);

        T DeleteEntity(T entity);

        IQueryable<T> LoadEntites(Expression<Func<T, bool>> where);

        int SaveChanges();

    }
}
