using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Interface.DAL
{
    public interface IDalService<T> where T : class, new()
    {
        T AddEntity(T entity);

        IQueryable<T> LoadEntites(Expression<Func<T, bool>> where);

        int SaveChanges();

    }
}
