using System;
using System.Linq;
using System.Linq.Expressions;

namespace Interface.BLL
{
    public interface IBllService<T> where T : class, new()
    {
        T AddEntity(T entity,bool IsSave);

        IQueryable<T> LoadEntites(Expression<Func<T, bool>> where);

        int SaveChanges();
    }
}
