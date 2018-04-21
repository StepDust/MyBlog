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
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="IsSave"></param>
        /// <returns></returns>
        public T AddEntity(T entity, bool isSave)
        {
            entity = DBService.AddEntity(entity);
            if (isSave)
            {
                if (SaveChanges() > 0)
                    return null;
            }
            return entity;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int DeleteEntity(T entity, bool isSave)
        {
            DBService.DeleteEntity(entity);
            if (isSave)
                return SaveChanges();
            return 0;
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

        /// <summary>
        /// 保存数据库
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DBService.SaveChanges();
        }
    }
}