using Interface.DAL;
using Interface.BLL;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    /// <summary>
    /// 数据逻辑层：BLL
    /// </summary>
    public class BllService<T> : IBllService<T> where T : class, new()
    {

        /// <summary>
        /// 数据库服务
        /// </summary>
        protected IDalService<T> DBService;

        public BllService(IDalService<T> dalService)
        {
            this.DBService = dalService;
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="IsSave"></param>
        /// <returns></returns>
        public T AddEntity(T entity, bool IsSave)
        {
            entity = DBService.AddEntity(entity);
            if (IsSave)
            {
                if (DBService.SaveChanges() > 0)
                    return null;
            }
            return entity;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntites(Expression<Func<T, bool>> where)
        {
            return DBService.LoadEntites(where);

        }

    }
}
