using Interface.DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    /// <summary>
    /// 数据访问层：DAL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DalService<T> : IDalService<T> where T : class, new()
    {

        private DbContext DbWrite;
        
        /// <summary>
        /// 获得数据库上下文
        /// </summary>
        /// <param name="dbContext">数据库上下文类</param>
        public DalService(DBCodeFirst dbContext)
        {
            DbWrite = dbContext;
        }

        public T AddEntity(T entity)
        {
            DbWrite.Set<T>().Add(entity);
            return entity;
        }

        public IQueryable<T> LoadEntites(Expression<Func<T, bool>> where)
        {
            return DbWrite.Set<T>().Where(where);
        }

        public int SaveChanges()
        {
            return DbWrite.SaveChanges();
        }

    }
}
